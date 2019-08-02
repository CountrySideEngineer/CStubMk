/*
 * CCSrcStubCreater.cpp
 *
 *  Created on: 2016/04/07
 *      Author: Kensuke
 */
#include <iostream>
#include <sstream>
#include <string>
#include <algorithm>
#include "CCSrcCreator.h"

CCSrcCreator::CCSrcCreator()
    : m_BuffSizeMacroName(String(""))
{
    setFileExtention(String(".c"));
}
CCSrcCreator::CCSrcCreator(int BuffSize)
    : m_BuffSizeMacroName(String(""))
{
    setFileExtention(String(".c"));
}
CCSrcCreator::~CCSrcCreator() {}

VOID CCSrcCreator::SetStartSection(String FileName)
{
    //おまじないとして、stdio.h をインクルードする。
    this->WriteLine(String("#include <stdio.h>"));
    this->SetBuffSizeMacro(FileName, m_BuffSize);
}

VOID CCSrcCreator::CreateBody(CParamInfo *FuncInfo)
{
    // 呼出回数、引数、及び戻り値のバッファの定義
    this->SetBuffVarDeclare(FuncInfo);

    // 関数の定義
    this->SetDec(FuncInfo);

    // 関数の処理部分
    this->SetBody(FuncInfo);

    // 初期化関数の定義
    this->SetInitDec(FuncInfo);
    this->SetInitBody(FuncInfo);
}

/**
 * 呼出回数、および引数のバッファーを定義するコードを追記する
 */
VOID CCSrcCreator::SetBuffVarDeclare(CParamInfo *FuncInfo)
{
    String StubFuncName = this->CreateStubFuncName(FuncInfo->getName());
    String CalledCountVarName = this->CreateCalledCountVarName(StubFuncName);
    String RetValVarName = this->CreateRetValArrayName(StubFuncName);

    list<String> ArgDataTypeList;
    list<String> ArgNameList;
    list<String>::iterator ArgDataTypeListIterator;
    list<String>::iterator ArgNameListIterator;

    AStubCreater::CreateArgList(FuncInfo, &ArgDataTypeList, &ArgNameList);

    /*
     * 各種バッファーの定義を追記する。
     */
    //呼出回数
    this->WriteLine(String("int ") + CalledCountVarName + String(";"));
    //引数バッファー
    ArgDataTypeListIterator = ArgDataTypeList.begin();
    ArgNameListIterator = ArgNameList.begin();
    while ((ArgDataTypeList.end() != ArgDataTypeListIterator) &&
            (ArgNameList.end() != ArgNameListIterator))
    {
        String DataType = this->RemoveConstModifier(*ArgDataTypeListIterator);
        this->WriteLine(DataType +
                String(" ") +
                *ArgNameListIterator +
                String("[") +  this->m_BuffSizeMacroName + String("];"));
        ArgDataTypeListIterator++;
        ArgNameListIterator++;
    }
    // 戻り値バッファ
    this->WriteLine(String("int ") + RetValVarName +
            String("[") +  this->m_BuffSizeMacroName + String("];"));
}

/**
 * スタブ関数の定義部分を実装する。
 */
VOID CCSrcCreator::SetDec(CParamInfo *FuncInfo)
{
    String StubFuncName = this->CreateStubFuncName(FuncInfo->getName());
    String FuncDef;

    list<String> ArgBuffDataTypeList;
    list<String> ArgBuffNameList;
    list<String>::iterator ArgBuffDataTypeListIterator;
    list<String>::iterator ArgBuffNameListIterator;

    this->CreateArgList(FuncInfo, &ArgBuffDataTypeList, &ArgBuffNameList);

    // 本体の実装開始
    if ((0 == ArgBuffDataTypeList.size()) && (0 == ArgBuffNameList.size())) {
        FuncDef = FuncInfo->getDataType() + String(" ") +
                StubFuncName + String("()");
    } else {
        FuncDef = FuncInfo->getDataType() + String(" ") +
                StubFuncName + String("(") + String("\r\n");
        ArgBuffDataTypeListIterator = ArgBuffDataTypeList.begin();
        ArgBuffNameListIterator = ArgBuffNameList.begin();
        while ((ArgBuffDataTypeList.end() != ArgBuffDataTypeListIterator) &&
                (ArgBuffNameList.end() != ArgBuffNameListIterator))
        {
            String ArgDef = String("\t") +
                    *ArgBuffDataTypeListIterator + String(" ") +
                    *ArgBuffNameListIterator;
            ArgBuffDataTypeListIterator++;
            ArgBuffNameListIterator++;
            if ((ArgBuffDataTypeList.end() != ArgBuffDataTypeListIterator) &&
                    (ArgBuffNameList.end() != ArgBuffNameListIterator))
            {
                ArgDef += String(", \n");
            } else {
                ArgDef += String(")");
            }
            FuncDef += ArgDef;
        }
    }
    this->WriteLine(FuncDef);
}

/*
 * 引数がポインタ、かつ「*」が先頭に付加されていた場合には、
 * それを削除する。
 */
inline VOID RemoveTopAster(String &Target) {
    if ('*' == *(Target.begin())) {
        Target.erase(0, 1);
    }
}

/**
 * スタブ関数の処理部分を実装する。
 */
VOID CCSrcCreator::SetBody(CParamInfo *FuncInfo)
{
    String StubFuncName = this->CreateStubFuncName(FuncInfo->getName());
    String CalledCountVarName = this->CreateCalledCountVarName(StubFuncName);
    String RetValVarName = this->CreateRetValArrayName(StubFuncName);

    list<String> ArgDataTypeList;
    list<String> ArgNameList;
    list<String> ArgBuffDataTypeList;
    list<String> ArgBuffNameList;
    list<String>::iterator ArgDataTypeListIterator;
    list<String>::iterator ArgNameListIterator;
    list<String>::iterator ArgBuffDataTypeListIterator;
    list<String>::iterator ArgBuffNameListIterator;

    //引数バッファーリストの作成
    AStubCreater::CreateArgList(FuncInfo, &ArgBuffDataTypeList,
            &ArgBuffNameList);
    //引数リストの作成
    this->CreateArgList(FuncInfo, &ArgDataTypeList, &ArgNameList);

    //処理部分の実装開始
    this->WriteLine(String("{"));
    this->WriteLine(String("\tint ret_val ="));
    this->WriteLine(String("\t\t") + RetValVarName);
    this->WriteLine(String("\t\t[") + CalledCountVarName + String("];"));
    this->WriteLine(String(""));

    //引数をバッファーに格納する処理を実装
    ArgBuffDataTypeListIterator = ArgBuffNameList.begin();
    ArgBuffNameListIterator = ArgBuffNameList.begin();
    ArgDataTypeListIterator = ArgDataTypeList.begin();
    ArgNameListIterator = ArgNameList.begin();
    while ((ArgBuffDataTypeList.end() != ArgBuffDataTypeListIterator) &&
            (ArgBuffNameList.end() != ArgBuffNameListIterator) &&
            (ArgDataTypeList.end() != ArgDataTypeListIterator) &&
            (ArgNameList.end() != ArgNameListIterator))
    {
        String ArgName = *ArgNameListIterator;
        String ArgBuffName = *ArgBuffNameListIterator;
        RemoveTopAster(ArgBuffName);
        RemoveTopAster(ArgName);
        /*
         * 出力されるコードは、以下のフォーマット
         * BuffVarName
         *  [CalledCountVarName] =
         *      ArgVarName;
         */
        this->WriteLine(String("\t") +
                ArgBuffName +
                String("\n\t\t[") + CalledCountVarName + String("] ="));
        this->WriteLine(String("\t\t\t") + ArgName + String(";"));
        ArgBuffDataTypeListIterator++;
        ArgBuffNameListIterator++;
        ArgDataTypeListIterator++;
        ArgNameListIterator++;
    }
    this->WriteLine("");
    this->WriteLine(String("\t") + CalledCountVarName + String("++;"));
    this->WriteLine("");
    this->WriteLine("\treturn (ret_val);");
    this->WriteLine("}");
}

VOID CCSrcCreator::SetInitDec(CParamInfo *FuncInfo)
{
    // 各バッファーの初期化関数の開始部分
    String FuncDec = String("void ") +
            this->CreateInitialFuncName(FuncInfo->getName()) + String("()");
    this->WriteLine(FuncDec);
}

VOID CCSrcCreator::SetInitBody(CParamInfo *FuncInfo)
{
    String StubFuncName = this->CreateStubFuncName(FuncInfo->getName());
    String CalledCountVarName = this->CreateCalledCountVarName(StubFuncName);
    String RetVaVarName = this->CreateRetValArrayName(StubFuncName);

    list<String> ArgBuffDataTypeList;
    list<String> ArgBuffNameList;
    const list<CParamInfo *> *FuncArgInfo = FuncInfo->getOpt();
    list<String>::iterator ArgBuffDataTypeListIterator;
    list<String>::iterator ArgBuffNameListIterator;
    list<CParamInfo *>::const_iterator FuncArgInfoIterator;

    AStubCreater::CreateArgList(FuncInfo,
            &ArgBuffDataTypeList,
            &ArgBuffNameList);

    // 初期化処理の実装開始
    this->WriteLine("{");
    this->WriteLine(String("\tint idx = 0;"));
    this->WriteLine(String(""));
    this->WriteLine(String("\t") + CalledCountVarName + String(" = 0;"));
    this->WriteLine(String("\tfor (idx = 0; idx < ") +
            this->m_BuffSizeMacroName +
            String("; idx++) {"));
    ArgBuffNameListIterator = ArgBuffNameList.begin();
    FuncArgInfoIterator = FuncArgInfo->begin();
    while ((ArgBuffNameList.end() != ArgBuffNameListIterator) &&
            (FuncArgInfo->end() != FuncArgInfoIterator))
    {
        String InitValue;
        CParamInfo* ArgInfo = *FuncArgInfoIterator;
        if (true == ArgInfo->getIsPtr()) {
            InitValue = String("NULL");
        } else {
            InitValue = String("0");
        }
        this->WriteLine(String("\t\t") +
                *ArgBuffNameListIterator +
                String("[idx] = ") +
                InitValue +
                String(";"));
        ArgBuffNameListIterator++;
        FuncArgInfoIterator++;
    }
    this->WriteLine(String("\t\t") +
            RetVaVarName +
            String("[idx] = 0;"));
    this->WriteLine("\t}");
    this->WriteLine("}");
}

VOID CCSrcCreator::SetSectionSep(String FuncName)
{
    //実行前に、画面にログを出力する。
    cout << String("Create a stub body of ") << FuncName << endl;

    AStubCreater::SetSectionSep(FuncName);
}


/**
 * 関数の引数のデータ型と引数名を取得する。
 * このとき、引数名はベースとなる関数と同じ名前のリストを返す。
 */
VOID CCSrcCreator::CreateArgList(CParamInfo *FuncInfo,
        list<String> *ArgDataList,
        list<String> *ArgNameList)
{

    ArgDataList->clear();
    ArgNameList->clear();

    const list<CParamInfo *> *FuncArgInfo = FuncInfo->getOpt();
    list<CParamInfo *>::const_iterator ArgInfoIterator = FuncArgInfo->begin();
    while (FuncArgInfo->end() != ArgInfoIterator) {
        /*
         * ポインタ"*"、およびバッファ変数名との重複回避のために、
         * リストの内容を入れ替える。
         */
        CParamInfo *ArgInfo = *ArgInfoIterator;
        if ((ArgInfo->getDataType() == "VOID") &&
            (ArgInfo->getIsPtr() == 0))
        {
            //VOID型のデータは、スキップする。
            continue;
        }

        ArgNameList->push_back(ArgInfo->getName());
        ArgDataList->push_back(ArgInfo->getDataType());
        ArgInfoIterator++;
    }
}

/*
 * 各種引数引数のバッファのサイズを変更する。
 */
VOID CCSrcCreator::SetBuffSizeMacro(CONST String &FileName,
        int BuffSize)
{
    String FileNameUpper;
    String BuffSizeString;
    stringstream BuffSizeStream;
    String FileNameNoExt = this->RemoveExtention(FileName);
    FileNameUpper = FileNameNoExt;
    FileNameUpper += "_buf_size";

    transform(FileNameUpper.begin(),
            FileNameUpper.end(),
            FileNameUpper.begin(),
            ::toupper);

    BuffSizeStream << BuffSize;
    BuffSizeString = BuffSizeStream.str();

    this->WriteLine(String("#define ") +
            FileNameUpper +
            String("\t\t\t") +
            String("(") +
            BuffSizeString +
            String(")"));

    this->m_BuffSizeMacroName = FileNameUpper;
}
