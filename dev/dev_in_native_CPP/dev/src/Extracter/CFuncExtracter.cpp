/*
 * CFuncExtracter.cpp
 *
 *  Created on: 2016/03/15
 *      Author: Kensuke
 */
#include <iostream>
#include <list>
#include <stdexcept>
#include "types.h"
#include "CFuncExtracter.h"

using namespace std;

CONST String CFuncExtracter::MODIFIER_EXTERN = "extern";
CONST String CFuncExtracter::MODIFIER_STATIC = "static";

CFuncExtracter::CFuncExtracter() {}

SINT CFuncExtracter::IsModifier(String Modifier)
{
    SINT ret = 0;

    ret = AExtracter::IsModifier(Modifier);
    if (0 == ret) {
        ret = ((CFuncExtracter::MODIFIER_EXTERN == Modifier) ||
                (CFuncExtracter::MODIFIER_STATIC == Modifier));
    }

    return (ret);
}

list<String>::iterator CFuncExtracter::Extract(
        list<String>& Src,
        CParamInfo *Dst)
{
    SINT IsPtr = 0;
    String DataType = String("");
    String FuncName = String("");
    String DataString = String("");
    list<String>::iterator SrcIterator;
    list<String>::iterator RetIterator;

    //  引数確認
    if (Src.size() <= 0) { throw length_error("Src"); }
    if (NULL == Dst) { throw invalid_argument("Dst"); }

    SrcIterator = Src.begin();
    while (Src.end() != SrcIterator) {
        DataString = *SrcIterator;
        if (CFuncExtracter::FUNC_EXTRACTER_STATE_DATA_TYPE == m_State) {
            if (DataType.length() != 0) {
                /**
                 * 修飾子 + 型を示す文字列の末尾に半角ペースが付加されることを
                 * 回避する。そのため、既存の修飾子文字列の後ろに半角スペースを
                 * 追加した後に、新たに文字列を付加する。
                 */
                DataType += " ";
            }
            DataType += DataString;

            if (!AExtracter::IsModifier(&DataString)) {
                /*
                 * 修飾子以外の文字列は型名と判断。そのため、状態を
                 * 「関数取得」の状態に変更する。
                 */
                m_State = CFuncExtracter::FUNC_EXTRACTER_STATE_FUNC_NAME;
            }
        } else {
            FuncName = DataString;
            break;
        }
        SrcIterator++;
    }

    if ((Src.end() != SrcIterator) &&
            (CFuncExtracter::FUNC_EXTRACTER_STATE_FUNC_NAME == m_State)) {
        /*
         * イテレータが末尾に到達しておらず、かつ状態が関数読み出し状態であった
         * 場合には、関数情報の取得が完了したと判断し、読み出したデータを
         * 戻り値にセットする。
         */
        if ((this->HasAsterisk(DataType)) || (this->HasAsterisk(FuncName))) {
            /*
             * 関数型あるいは関数名に'*'が含まれていた場合には、ポインタを
             * 返す関数であると判断する。
             */
            IsPtr = 1;
        } else {
            IsPtr = 0;
        }
        Dst->setDataType(DataType);
        Dst->setName(FuncName);
        Dst->setIsPtr(IsPtr);
    }

    // 連続呼び出し対応のために、状態を示す変数を初期化する。
    m_State = CFuncExtracter::FUNC_EXTRACTER_STATE_DATA_TYPE;

    // 注：関数データが不十分であった場合には、イテレータが末尾を指している。
    RetIterator = SrcIterator;
    return (RetIterator);
}
