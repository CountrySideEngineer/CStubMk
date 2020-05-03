/*
 * CStubMakerMain.h
 *
 *  Created on: 2016/04/19
 *      Author: Kensuke
 */

#ifndef CSTUBMAKERMAIN_H_
#define CSTUBMAKERMAIN_H_
#include <iostream>
#include <list>
#include "CFileParser.h"
#include "CFileData.h"
#include "CParamInfo.h"
#include "AStubCreater.h"
using namespace std;

class CStubMakerMain {
public:
    CStubMakerMain();
    CStubMakerMain(String FileName);
    virtual ~CStubMakerMain();

    VOID RunOperation();
    VOID RunOperation(String FileName);
    static String GetVersion();

    virtual VOID CreateStub(String FileName);
    virtual VOID CreateStub(String FileName,
            list<AStubCreater *> *StubCreatorList);

    int getMacroSize() const { return mMacroSize; }
    VOID setMacroSize(int macroSize) { mMacroSize = macroSize; }

private:
    VOID Parse(String FileName);
    VOID Extract();

    int mMacroSize;
    String mFileName;
    list<CFileData *> *mFileDataList;
    list<CParamInfo *> *mParamInfoList;
};

#endif /* CSTUBMAKERMAIN_H_ */
