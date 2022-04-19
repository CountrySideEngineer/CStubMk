/*
 * CCHeaderCreater.cpp
 *
 *  Created on: 2016/04/01
 *      Author: Kensuke
 */
#include <iostream>
#include <sstream>
#include <string>
#include <algorithm>
#include <cctype>
#include <cstdio>
#include "CCHeaderCreator.h"
using namespace std;

String CCHeaderCreator::CreateHeaderMacro(String FileName)
{
    String HeaderDefineMacro;
    HeaderDefineMacro = FileName + "_h_";

    //  文字を全て大文字にする。
    transform(HeaderDefineMacro.begin(),
            HeaderDefineMacro.end(),
            HeaderDefineMacro.begin(),
            ::toupper);

    return HeaderDefineMacro;
}

inline String CreateGetterMacro(String VarName)
{
    String GetterName;

    GetterName = String("get_") + VarName + String("()");
    transform(GetterName.begin(),
            GetterName.end(),
            GetterName.begin(),
            ::toupper);

    return (GetterName);
}

inline String CreateGetterMacroIndex(String VarName)
{
    String GetterName;

    GetterName = String("get_") + VarName;
    transform(GetterName.begin(),
            GetterName.end(),
            GetterName.begin(),
            ::toupper);
    GetterName += String("(idx)");
    return (GetterName);
}

inline String CreateSetterMacro(String VarName)
{
    String SetterName;

    SetterName = String("set_") + VarName;
    transform(SetterName.begin(),
            SetterName.end(),
            SetterName.begin(),
            ::toupper);
    SetterName += String("(value)");

    return (SetterName);
}

inline String CreateSetterMacroIndex(String VarName)
{
    String SetterName;

    SetterName = String("set_") + VarName;
    transform(SetterName.begin(),
            SetterName.end(),
            SetterName.begin(),
            ::toupper);
    SetterName = SetterName + String("(idx, value)");

    return (SetterName);
}

CCHeaderCreator::CCHeaderCreator()
{
    setFileExtention(String(".h"));
}
CCHeaderCreator::~CCHeaderCreator() {}

/**
 * ヘッダーファイルの先頭部分(#define マクロ、__cplusplus)などを追加する。
 */
VOID CCHeaderCreator::SetStartSection(String FileName)
{
    String FileNameNoExt = this->RemoveExtention(FileName);
    String HeaderDefineMacro = CreateHeaderMacro(FileNameNoExt);

    this->WriteLine(String("#ifndef ") + HeaderDefineMacro);
    this->WriteLine(String("#define ") + HeaderDefineMacro);
    this->WriteLine(String(""));
    this->WriteLine(String("#ifdef __cplusplus"));
    this->WriteLine(String("extern \"C\" {"));
    this->WriteLine(String("#endif /* __cplusplus */"));
}

/**
 * ヘッダーファイルの末尾部分(#endif マクロ)を追加する。
 */
VOID CCHeaderCreator::SetEndSection(String FileName)
{
    String FileNameNoExt = this->RemoveExtention(FileName);
    String HeaderDefineMacro = CreateHeaderMacro(FileNameNoExt);

    this->WriteLine(String(""));
    this->WriteLine(String("#ifdef __cplusplus"));
    this->WriteLine(String("}"));
    this->WriteLine(String("#endif /* __cplusplus */"));
    this->WriteLine(String("#endif /* ") + HeaderDefineMacro + String(" */"));
}

/*
 * スタブ関数の宣言本体を作成する。
 */
VOID CCHeaderCreator::CreateBody(CParamInfo *FuncInfo)
{
    /*
     * スタブ関数、及び各引数とそれぞれのgetter/setterの記入開始
     */
    this->CreateStubDec(FuncInfo);
    this->CreateVariableDec(FuncInfo);
    this->CreateVarGetSetMacro(FuncInfo);
}

/*
 * 関数の宣言の開始を示す部分を作成する。
 */
VOID CCHeaderCreator::SetSectionSep(String FuncName)
{
    //実行前に、画面にログを出力する。
    cout << String("Create a header of ") << FuncName << endl;

    AStubCreater::SetSectionSep(FuncName);
}

/*
 * スタブ関数の宣言のセット
 */
VOID CCHeaderCreator::CreateStubDec(CParamInfo *FuncInfo)
{
    String StubFuncName = CreateStubFuncName(FuncInfo->getName());
    String FuncDec = String("");
    list<String> ArgNameList;
    list<String> ArgDataList;
    list<String>::iterator ArgDataIterator;
    list<String>::iterator ArgNameIterator;

    // 各バッファーの初期化関数の宣言
    FuncDec = String("extern void ") +
            this->CreateInitialFuncName(FuncInfo->getName()) + String("();");
    this->WriteLine(FuncDec);

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

/*
 * 呼び出し回数、および引数を格納する配列を追加する。
 */
VOID CCHeaderCreator::CreateVariableDec(CParamInfo *FuncInfo)
{
    String StubFuncName = CreateStubFuncName(FuncInfo->getName());
    String CalledCountVarName = CreateCalledCountVarName(StubFuncName);
    String RetValArrayVarName = CreateRetValArrayName(StubFuncName);
    list<String> ArgDataTypeList;
    list<String> ArgNameList;
    list<String>::iterator ArgDataIterator;
    list<String>::iterator ArgNameIterator;

    this->CreateArgList(FuncInfo, &ArgDataTypeList, &ArgNameList);

    this->WriteLine(String("extern int ") + CalledCountVarName + String(";"));
    this->WriteLine(String("extern int ") + RetValArrayVarName +
            String("[];"));
    ArgDataIterator = ArgDataTypeList.begin();
    ArgNameIterator = ArgNameList.begin();
    while ((ArgDataTypeList.end() != ArgDataIterator) &&
            (ArgNameList.end() != ArgNameIterator))
    {
        String DataType = this->RemoveConstModifier(*ArgDataIterator);
        this->WriteLine(String("extern ") +
                DataType + String(" ") +
                *ArgNameIterator + String("[];"));
        ArgDataIterator++;
        ArgNameIterator++;
    }
}

/*
 * 引数を格納する配列へのgetter/setterを追記する。
 */
VOID CCHeaderCreator::CreateVarGetSetMacro(CParamInfo *FuncInfo)
{
    String StubFuncName = CreateStubFuncName(FuncInfo->getName());
    String CalledCountVarName = CreateCalledCountVarName(StubFuncName);
    String RetValArrayVarName = CreateRetValArrayName(StubFuncName);
    list<String> ArgNameList;
    list<String> ArgDataList;
    list<String>::iterator ArgDataIterator;
    list<String>::iterator ArgNameIterator;

    this->CreateArgList(FuncInfo, &ArgDataList, &ArgNameList);

    this->WriteLine(String("#define\t") +
            CreateGetterMacro(CalledCountVarName) + String("\t\\\n\t(") +
            CalledCountVarName + String(")"));
    this->WriteLine(String("#define\t") +
            CreateSetterMacro(CalledCountVarName) + String("\t\\\n\t(") +
            CalledCountVarName + String(" = value)"));
    ArgNameIterator = ArgNameList.begin();
    while (ArgNameList.end() != ArgNameIterator) {
        // getter マクロを追加
        this->WriteLine(String("#define\t") +
                CreateGetterMacroIndex(*ArgNameIterator) +
                String("\t\\\n\t(") +
                *ArgNameIterator + String("[idx])"));
        // setter マクロを追加
        this->WriteLine(String("#define\t") +
                CreateSetterMacroIndex(*ArgNameIterator) +
                String("\t\\\n\t(") +
                *ArgNameIterator + String("[idx] = value)"));
        ArgNameIterator++;
    }
    this->WriteLine(String("#define\t") +
            CreateGetterMacroIndex(RetValArrayVarName) +
            String("\t\\\n\t(") +
            RetValArrayVarName + String("[idx])"));
    this->WriteLine(String("#define\t") +
            CreateSetterMacroIndex(RetValArrayVarName) +
            String("\t\\\n\t(") +
            RetValArrayVarName + String("[idx] = value)"));
}

