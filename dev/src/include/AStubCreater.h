/*
 * AStubCreater.h
 *
 *  Created on: 2016/04/01
 *      Author: Kensuke
 */

#ifndef ASTUBCREATER_H_
#define ASTUBCREATER_H_
#include <iostream>
#include <fstream>
#include <sstream>
#include <list>
#include "types.h"
#include "CParamInfo.h"
using namespace std;

class AStubCreater {
public:
    AStubCreater();
    virtual ~AStubCreater();

    virtual VOID Create(
            String FileName,
            list<CParamInfo *> *ParamInfoList);
    virtual VOID CreateBody(list<CParamInfo *> *FuncInfoList);
    virtual VOID CreateBody(CParamInfo *FuncInfo) = 0;

    const String& getFileExtention() const { return m_FileExtention; }
    void setFileExtention(const String& Value) { m_FileExtention = Value; }

    const ofstream& getFileStream() const { return m_FileStream; }

    int getBuffSize() const { return m_BuffSize; }
    VOID setBuffSize(int buffSize) { m_BuffSize = buffSize; }

protected:
    SINT OpenFile(String FileName);
    VOID CloseFile();
    VOID WriteLine(String LineData);
    virtual String CreateFileName(const String &FileName);
    virtual String CreateFileName(const String &FileName,
            const String &Extention);
    virtual String RemoveExtention(const String &FileName);
    virtual String RemoveConstModifier(const String &TargetName);
    virtual VOID CreateArgList(CParamInfo *FuncInfo,
            list<String> *ArgDataList,
            list<String> *ArgNameList);
    virtual VOID SetStartSection(String FileName) {}
    virtual VOID SetEndSection(String FileName) {}
    virtual VOID SetSectionSep(String FuncName);

    /* ======================================= */
    /*                                         */
    /* inline 化を期待する、小さいメンバー関数 */
    /*                                         */
    /* ======================================= */
    virtual String AddExtention(String &FileName) {
        return this->AddExtention(FileName, this->m_FileExtention);
    }
    virtual String AddExtention(String &FileName, String &Extention) {
        return (FileName + Extention);
    }
    virtual String AddIndex(String BaseWord, int index) {
        stringstream IndexString;
        IndexString << index;
        return (BaseWord + IndexString.str());
    }
    virtual String CreateStubFuncName(String BaseFuncName) {
        return (BaseFuncName);
    }
    virtual String CreateInitialFuncName(String BaseFuncName) {
        return (BaseFuncName + String("_init"));
    }
    virtual String CreateCalledCountVarName(String StubFuncName) {
        return (StubFuncName + "_called_count");
    }
    virtual String CreateRetValArrayName(String StubFuncName) {
        return (StubFuncName + "_ret_val");
    }

protected:
    int m_BuffSize;

private:
    ofstream m_FileStream;
    String m_FileExtention;
};

#endif /* ASTUBCREATER_H_ */
