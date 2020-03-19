/*
 * CCSrcIFCreator.cpp
 *
 *  Created on: 2016/05/28
 *      Author: Kensuke
 */
#include <iostream>
#include <sstream>
#include <string>
#include <algorithm>
#include "CCSrcIFCreator.h"
using namespace std;

CCSrcIFCreator::CCSrcIFCreator()
{
    setFileExtention(String(".c"));
}

CCSrcIFCreator::~CCSrcIFCreator() {}

VOID CCSrcIFCreator::SetStartSection(String FileName)
{
    /*
     * スタブのヘッダーファイルをインクルードするために、ヘッダーファイルの
     * 名前を生成する。
     */
    String StubHeaderFileName =
            this->CreateFileName(FileName, String("_stub.h"));

    //ファイル先頭のインクルード処理
    this->WriteLine(String("#include <stdio.h>"));  //おまじない
    this->WriteLine(String("#include \"") +
            StubHeaderFileName +
            String("\""));
}

VOID CCSrcIFCreator::CreateBody(CParamInfo *FuncInfo)
{
    //関数の定義
    this->SetDec(FuncInfo);

    //関数の処理部分
    this->SetBody(FuncInfo);
}

/*
 * スタブ関数へのIF部分の実装(スタブの呼出処理)
 */
VOID CCSrcIFCreator::SetDec(CParamInfo *FuncInfo)
{
    String FuncDef;
    String FuncDataType = FuncInfo->getDataType();
    String FuncName = FuncInfo->getName();
    list<String> ArgDataTypeList;
    list<String> ArgNameList;

    //引数リストの取得
    CCSrcCreator::CreateArgList(FuncInfo, &ArgDataTypeList, &ArgNameList);

    FuncDef = FuncDataType + String(" ") + FuncName;
    if ((0 == ArgDataTypeList.size() && (0 == ArgNameList.size()))) {
        //引数なしの場合：FunctionName() のフォーマットでデータを出力
        FuncDef = FuncDef + String("()");
    } else {
        //引数情報ありの場合
        FuncDef = FuncDef + String("(\r\n\t\t\t");
        list<String>::iterator ArgDataTypeListIt = ArgDataTypeList.begin();
        list<String>::iterator ArgNameListIt = ArgNameList.begin();
        while ((ArgDataTypeList.end() != ArgDataTypeListIt) &&
                (ArgNameList.end() != ArgNameListIt))
        {
            String ArgDataType = *ArgDataTypeListIt;
            String ArgName = *ArgNameListIt;
            String ArgDef = ArgDataType + String(" ") + ArgName;

            /*
             * 引数リストの末尾か確認する。
             * 末尾であった場合には、閉じ括弧を追加する。
             * 末尾でなかった場合は、「,」区切りを追加する。
             */
            ArgDataTypeListIt++;
            ArgNameListIt++;
            if ((ArgDataTypeList.end() != ArgDataTypeListIt) &&
                    (ArgNameList.end() != ArgNameListIt))
            {
                //末尾ではない場合
                ArgDef = ArgDef + String(", \r\n\t\t\t");
            } else {
                ArgDef = ArgDef + String(")");
            }
            FuncDef = FuncDef + ArgDef;
        }
    }
    this->WriteLine(FuncDef);
}

VOID CCSrcIFCreator::SetBody(CParamInfo *FuncInfo)
{
    String BaseFuncName = FuncInfo->getName();
    String BaseFuncType = FuncInfo->getDataType();
    String StubFuncName = this->CreateStubFuncName(BaseFuncName);
    String FuncBody;
    String ArgDef;
    list<String> ArgDataTypeList;   //引数の型を格納する。ただし、使用しない。
    list<String> ArgNameList;

    CCSrcCreator::CreateArgList(FuncInfo, &ArgDataTypeList, &ArgNameList);

    if (0 != this->HasReturn(FuncInfo)) {
        FuncBody = String("return ");   //引数がある場合には、
    } else {
        FuncBody = String("");
    }
    FuncBody = FuncBody + StubFuncName;

    if (0 == ArgNameList.size()) {
        ArgDef = String("();");
    } else {
        ArgDef = String("(\r\n\t\t");
        list<String>::iterator ArgNameListIt = ArgNameList.begin();
        while (ArgNameList.end() != ArgNameListIt) {
            String ArgName = *ArgNameListIt;
            ArgDef = ArgDef + ArgName;

            ArgNameListIt++;
            if (ArgNameList.end() != ArgNameListIt) {
                ArgDef = ArgDef + String(",\r\n\t\t");
            } else {
                ArgDef = ArgDef + String(");");
            }
        }
    }
    FuncBody = FuncBody + ArgDef;

    this->WriteLine(String("{"));
    this->WriteLine(String("\t") + FuncBody);
    this->WriteLine(String("}"));
}

VOID CCSrcIFCreator::SetSectionSep(String FuncName)
{
    //実行前に、画面にログを出力する。
    cout << String("Create a IF body of ") << FuncName << endl;

    AStubCreater::SetSectionSep(FuncName);
}


SINT CCSrcIFCreator::HasReturn(CParamInfo *Info)
{
    SINT HasRet;
    String DataType = Info->getDataType();
    String DataTypeVoid = String("void");

    //データ型を全て小文字に変換
    transform(DataType.begin(), DataType.end(), DataType.begin(), ::tolower);

    if ((DataTypeVoid == DataType) && (0 == Info->getIsPtr())) {
        HasRet = 0;
    } else {
        HasRet = 1;
    }

    return (HasRet);
}
