/*
 * CArgExtracter.cpp
 *
 *  Created on: 2016/03/18
 *      Author: Kensuke
 */
#include <iostream>
#include <list>
#include <stdexcept>
#include "types.h"
#include "CArgExtracter.h"
#include "CParamInfo.h"

using namespace std;

CONST String CArgExtracter::MODIFIER_STATIC = "static";
CONST String CArgExtracter::MODIFIER_EXTERN = "extern";

list<String>::iterator CArgExtracter::Extract(
        list<String>& src, CParamInfo *dst)
{
    SINT IsPtr = 0;
    String DataType = String("");
    String ArgName = String("");
    String DataString = String("");
    list<String>::iterator ArgIt;

    try {
        ArgIt = this->GetArgStart(src);
    } catch (length_error& e) {
        cout << __FUNCTION__ << " length_error : " << e.what() << endl;

        throw e;
    }

    while (src.end() != ArgIt) {
        DataString = *ArgIt;
        if (AExtracter::IsModifier(&DataString)) {
            AExtracter::AddTypeString(DataString, &DataType);
        } else {
            /*
             * 文字列が修飾子ではなかった場合には、現在の状況に従って
             * 読み出した文字列の格納先を変更する。
             */
            if (AExtracter::ARG_EXTRACTER_EXTRACT_DATA_TYPE == m_State) {
                AExtracter::AddTypeString(DataString, &DataType);
                /*
                 * 型取得中に修飾子以外の文字列を取得した場合、型情報の
                 * 取得が完了したと判断。変数名を扱う状態に変更する。
                 */
                m_State = AExtracter::ARG_EXTRACTER_EXTRACT_DATA_NAME;
            } else {
                ArgName = DataString;
                /*
                 * 変数名を取得した時点で、引数情報の取得完了と判断。
                 * 取得済みデータの追加を追加する。
                 */
                if ((AExtracter::HasAsterisk(DataType)) ||
                        (AExtracter::HasAsterisk(ArgName)))
                {
                    IsPtr = 1;
                } else {
                    IsPtr = 0;
                }
                if (0 == AExtracter::IsArg(DataType, IsPtr)) {
                    //VOID型の場合には、何もしない。
                    cout <<
                        String("VOID type data found. Skip.")
                        << endl;
                } else {
                    dst->AddOpt(new CParamInfo(
                                    CParamInfo::PARAM_TYPE_ARG,
                                    ArgName, DataType, IsPtr));
                    //次の引数情報取得のため、情報をリセットする。
                    m_State = AExtracter::ARG_EXTRACTER_EXTRACT_DATA_TYPE;
                    ArgName = String("");
                    DataType = String("");
                    DataString = String("");
                }
            }
        }
        ArgIt++;
    }

    return ArgIt;
}

SINT CArgExtracter::IsModifier(String modifier)
{
    SINT ret = AExtracter::IsModifier(modifier);
    if (0 == ret) {
        ret = ((CArgExtracter::MODIFIER_EXTERN == modifier) ||
                (CArgExtracter::MODIFIER_STATIC == modifier));
    }
    return (ret);
}

list<String>::iterator CArgExtracter::GetArgStart(list<String>& src)
{
    CParamInfo ParamInfo;
    list<String>::iterator ArgBeginIterator;

    try {
        ArgBeginIterator = CFuncExtracter::Extract(src,
                (CParamInfo *)&ParamInfo);
        if (src.end() != ArgBeginIterator) {
            /*
             * CFuncExtracter::Extract の戻り値は、関数名へのイテレータ
             * ->関数名の次が引数の開始位置
             */
            ArgBeginIterator++;
        }
    } catch (length_error& e) {
        cout << __FUNCTION__ << " length_error : " << e.what() << endl;

        throw;
    }
    return (ArgBeginIterator);
}
