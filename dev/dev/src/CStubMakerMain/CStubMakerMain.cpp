/*
 * CStubMakerMain.cpp
 *
 *  Created on: 2016/04/19
 *      Author: Kensuke
 */
#include <iostream>
#include <exception>
#include <sstream>
#include <iomanip>
#include "CFuncExtracter.h"
#include "CArgExtracter.h"
#include "CCSrcCreator.h"
#include "CCSrcStubCreator.h"
#include "CCSrcIFCreator.h"
#include "CCHeaderCreator.h"
#include "CCHeaderStubCreator.h"
#include "CStubMakerMain.h"

CStubMakerMain::CStubMakerMain()
    : mMacroSize(10)
    , mFileName(String(""))
{
    this->mFileDataList = new list<CFileData *>();
    this->mParamInfoList = new list<CParamInfo *>();
}
CStubMakerMain::CStubMakerMain(String FileName)
    : mMacroSize(10)
    , mFileName(FileName)
{
    this->mFileDataList = new list<CFileData *>();
    this->mParamInfoList = new list<CParamInfo *>();
}
CStubMakerMain::~CStubMakerMain()
{
    list<CParamInfo *>::iterator ParamInfoListIterator;
    ParamInfoListIterator = this->mParamInfoList->begin();
    while (this->mParamInfoList->end() != ParamInfoListIterator) {
        CParamInfo *ParamInfo = *ParamInfoListIterator;
        delete ParamInfo;
        ParamInfoListIterator++;
    }
    delete this->mParamInfoList;

    list<CFileData *>::iterator FileDatalistIterator;
    FileDatalistIterator = this->mFileDataList->begin();
    while (this->mFileDataList->end() != FileDatalistIterator) {
        CFileData *FileData = *FileDatalistIterator;
        delete FileData;
        FileDatalistIterator++;
    }
    delete this->mFileDataList;
}

#define MAJOR_VERSION           (1)
#define MINOR_VERSION           (0)
String CStubMakerMain::GetVersion()
{
    stringstream MajorStringStream;
    stringstream MinorStringStream;
    String VersionString;

    MajorStringStream << hex << uppercase << MAJOR_VERSION;
    MinorStringStream << hex << uppercase <<
            setw(2) << setfill('0') << MINOR_VERSION;

    VersionString = MajorStringStream.str() +
            String(".") +
            MinorStringStream.str();

    return (VersionString);
}

/**
 * 引数で指定されたファイルから、関数の宣言情報を抜き出す。
 */
VOID CStubMakerMain::Parse(String FileName)
{
    CFileParser FileParser;
    FileParser.Parse(FileName, this->mFileDataList);
}

/**
 * 関数宣言情報を、CParamInfoクラスに変換・格納する。
 */
VOID CStubMakerMain::Extract(VOID)
{
    CParamInfo *ParamInfo;
    AExtracter *Extracter;
    list<CFileData *>::iterator FileDataListIterator;
    FileDataListIterator = this->mFileDataList->begin();

    while (this->mFileDataList->end() != FileDataListIterator) {
        /*
         * CFileDataごとに、1関数分(引数含む)が格納されている。
         * そのため、CFileDataオブジェクトごとに、データを抜き出し、
         * CParamInfoオブジェクトに格納する。
         */
        CFileData *FileData = *FileDataListIterator;
        list<String> *Content = (list<String> *)FileData->getContent();

        ParamInfo = new CParamInfo();   //抜き出した関数情報の格納先
        //関数情報抜き出し
        Extracter = new CFuncExtracter();
        Extracter->Extract(*Content, ParamInfo);
        delete Extracter;

        //引数情報の抜き出し
        Extracter = new CArgExtracter();
        Extracter->Extract(*Content, ParamInfo);
        delete Extracter;

        this->mParamInfoList->push_back(ParamInfo);
        FileDataListIterator++;
    }
}

VOID CStubMakerMain::CreateStub(String FileName,
        list<AStubCreater *> *StubCreatorList)
{
    list<AStubCreater *>::iterator it;
    it = StubCreatorList->begin();
    while (StubCreatorList->end() != it) {
        AStubCreater *StubCreator = *it;
        StubCreator->setBuffSize(this->mMacroSize);
        StubCreator->Create(FileName, this->mParamInfoList);
        it++;
    }
}

VOID CStubMakerMain::CreateStub(String FileName)
{
    CCSrcCreator SrcCreator;
    CCHeaderCreator HeaderCreator;
    list<AStubCreater *> StubCreatorList;

    StubCreatorList.push_back((AStubCreater *)(&SrcCreator));
    StubCreatorList.push_back((AStubCreater *)(&HeaderCreator));
    this->CreateStub(FileName, &StubCreatorList);
}

VOID CStubMakerMain::RunOperation(VOID)
{
    this->RunOperation(this->mFileName);
}

VOID CStubMakerMain::RunOperation(String FileName)
{
    try {
        this->Parse(FileName);
        this->Extract();
        this->CreateStub(FileName);
    } catch (length_error &e) {
        cout << "ファイル名が不正です。" << endl;
    } catch (invalid_argument &e) {
        cout << "データが不正です。" << endl;
    }
}
