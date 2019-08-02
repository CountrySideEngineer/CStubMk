/*
 * AStubCreater.cpp
 *
 *  Created on: 2016/04/01
 *      Author: Kensuke
 */
#include <iostream>
#include <sstream>
#include <fstream>
#include <algorithm>
#include <list>
#include "types.h"
#include "AStubCreater.h"
using namespace std;

AStubCreater::AStubCreater() : m_FileExtention("") {}
AStubCreater::~AStubCreater() { this->CloseFile(); }

SINT AStubCreater::OpenFile(String FileName)
{
    SINT Ret = -1;

    if (FileName.empty()) {
        throw invalid_argument("FileName");
    }

    // すでにファイルを開いていた場合には、ファイルを閉じる。
    this->CloseFile();

    // ファイルの末尾をスタブに適した形式に拡張する。
    String FileNameWithExt = this->CreateFileName(FileName);
    this->m_FileStream.open(FileNameWithExt.c_str(), ios::out);
    if (!this->m_FileStream.is_open()) {
        Ret = -1;

        cout << String("ファイル : ")
                << FileNameWithExt
                << String(" can not open.") << endl;
    } else {
        Ret = 0;

        cout << String("File : ")
                << FileNameWithExt
                << String(" open succeeded.") << endl;
    }

    return (Ret);
}

VOID AStubCreater::CloseFile()
{
    if (this->m_FileStream.is_open()) {
        this->m_FileStream.close();
    }
}

VOID AStubCreater::WriteLine(String LineData)
{
    this->m_FileStream << LineData << std::endl;
}

String AStubCreater::CreateFileName(const String &FileName)
{
    return this->CreateFileName(FileName, this->m_FileExtention);
}
String AStubCreater::CreateFileName(
        const String &FileName,
        const String &Extention)
{
    String StubFileName = this->RemoveExtention(FileName);
    String StubFileNameWithExt = this->AddExtention(StubFileName,
            (String &)Extention);

    return StubFileNameWithExt;
}


String AStubCreater::RemoveExtention(const String &FileName)
{
    size_t Pos;
    String FileNameNoExt = String("");

    Pos = FileName.find_last_of(".");
    if (string::npos == Pos) {
        // 「.」なし → 拡張子なし！
        FileNameNoExt = FileName;
    } else {
        // 「.」あり → 拡張子あり！拡張子を削除する。
        FileNameNoExt = FileName.substr(0, Pos);
    }

    return (FileNameNoExt);
}

String AStubCreater::RemoveConstModifier(const String &TargetName)
{
    size_t Pos;
    String RetString;
    String LowerTargetName;
    /*
     * 型に含まれているconstの誤認回避のために、
     */
    const String ConstString = String("const ");
    LowerTargetName = TargetName;
    RetString = TargetName;

    // 小文字に変換する
    transform(LowerTargetName.begin(),
            LowerTargetName.end(),
            LowerTargetName.begin(),
            ::tolower);

    RetString = TargetName;
    Pos = LowerTargetName.find(ConstString);
    if (String::npos == Pos) {
        //const が見つからなかった場合には何もしない
    } else {
        RetString = RetString.erase(0, ConstString.length());
    }

    return (RetString);
}

VOID AStubCreater::Create(String FileName, list<CParamInfo *> *FuncInfoList)
{
    this->OpenFile(FileName);
    this->SetStartSection(FileName);
    this->CreateBody(FuncInfoList);
    this->SetEndSection(FileName);
    this->CloseFile();
}

VOID AStubCreater::CreateBody(list<CParamInfo *> *FuncInfoList)
{
    list<CParamInfo *>::iterator FuncInfoIt;

    FuncInfoIt = FuncInfoList->begin();
    while (FuncInfoList->end() != FuncInfoIt) {
        // スタブの開始箇所の実装
        CParamInfo *FuncInfo = *FuncInfoIt;
        this->SetSectionSep(FuncInfo->getName());
        this->CreateBody(*FuncInfoIt);
        FuncInfoIt++;
    }
}

VOID AStubCreater::SetSectionSep(String FuncName)
{
    int SeparatorLen = FuncName.length() + 25 - 4;
    // 25 -> 定型文字の長さ / 4 -> /* と */ を合わせた長さ
    int SeparatorEmptyLen = FuncName.length() + 7 + 6;
    // 6 -> Start と半角スペース / 5 -> stub と半角スペース
    String Separator =
            String("/*") + String(SeparatorLen, '-') + String("*/");
    String SeparatorEmpty =
            String("/*----") + String(SeparatorEmptyLen, ' ') + String("----*/");
    this->WriteLine(String(""));    //先頭に空行を追加する。
    this->WriteLine(Separator);
    this->WriteLine(SeparatorEmpty);
    this->WriteLine(String("/*---- Start ") +
            FuncName +
            String(" stub ----*/"));
    this->WriteLine(SeparatorEmpty);
    this->WriteLine(Separator);
}


VOID AStubCreater::CreateArgList(CParamInfo *FuncInfo,
        list<String> *ArgDataList,
        list<String> *ArgNameList)
{
    ArgDataList->clear();
    ArgNameList->clear();

    String StubFuncName = this->CreateStubFuncName(FuncInfo->getName());
    const list<CParamInfo *> *FuncArgInfo = FuncInfo->getOpt();
    list<CParamInfo *>::const_iterator ArgInfoIterator = FuncArgInfo->begin();
    int index = 1;

    while (FuncArgInfo->end() != ArgInfoIterator) {
        CParamInfo *ArgInfo = *ArgInfoIterator;

        //  引数名
        String ArgName = StubFuncName +
                this->AddIndex(String("_arg_"), index);
        // データ型
        String DataName = String(ArgInfo->getDataType());
        char ArgDataTail = *(--DataName.end()); //末尾の1文字を取得
        if ((true == ArgInfo->getIsPtr()) && ('*' != ArgDataTail)) {
            /*
             * ポインタ確認
             * 引数がポインタ型であった場合には、データ型に「*」を付加する。
             */
            DataName += "*";
        }

        ArgDataList->push_back(DataName);
        ArgNameList->push_back(ArgName);
        index++;
        ArgInfoIterator++;
    }
}
