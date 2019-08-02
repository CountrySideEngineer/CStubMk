/*
 * CCHeaderIFCreator.cpp
 *
 *  Created on: 2016/06/25
 *      Author: Kensuke
 */
#include <iostream>
#include <sstream>
#include <string>
#include <algorithm>
#include "CCHeaderIFCreator.h"
using namespace std;

CCHeaderIFCreator::CCHeaderIFCreator() {
    setFileExtention(String(".h"));
}
CCHeaderIFCreator::~CCHeaderIFCreator() {}

VOID CCHeaderIFCreator::CreateBody(CParamInfo *FuncInfo)
{
    //関数の宣言
    this->CreateStubDec(FuncInfo);
}

VOID CCHeaderIFCreator::CreateStubDec(CParamInfo *FuncInfo)
{
    String StubFuncName = CreateStubFuncName(FuncInfo->getName());
    String FuncDec = String("");
    list<String> ArgNameList;
    list<String> ArgDataList;
    list<String>::iterator ArgDataIterator;
    list<String>::iterator ArgNameIterator;

    // スタブ関数の宣言の作成
    this->CreateArgList(FuncInfo, &ArgDataList, &ArgNameList);
    if ((0 == ArgDataList.size()) && (0 == ArgNameList.size())) {
        // 引数がない場合は不要な改行の挿入を回避し、その場で括弧を閉じる
        FuncDec = String("extern ") + FuncInfo->getDataType() +
                String(" ") + StubFuncName + (String("();"));
    } else {
        // 引数あり：引数ごとに1行
        FuncDec = String("extern ") + FuncInfo->getDataType() +
                String(" ") + StubFuncName + (String("(\n"));
        ArgDataIterator = ArgDataList.begin();
        ArgNameIterator = ArgNameList.begin();
        int index = 1;
        while ((ArgDataList.end() != ArgDataIterator) &&
                (ArgNameList.end() != ArgNameIterator))
        {
            String ArgName = AddIndex("Arg", index);
            String ArgDef = String("\t") +
                    *ArgDataIterator + String(" ") + ArgName;
            ArgDataIterator++;
            ArgNameIterator++;
            if ((ArgDataList.end() != ArgDataIterator) &&
                    (ArgNameList.end() != ArgNameIterator))
            {
                ArgDef += ", \n";
                index++;
            } else {
                ArgDef += String(");");
            }
            FuncDec += ArgDef;
        }
    }
    this->WriteLine(FuncDec);
}
