/*
 * CCSrcStubCreater.h
 *
 *  Created on: 2016/04/07
 *      Author: Kensuke
 */

#ifndef CCSRCSTUBCREATOR_H_
#define CCSRCSTUBCREATOR_H_
#include <iostream>
#include <fstream>
#include <sstream>
#include <list>
#include "types.h"
#include <AStubCreater.h>
using namespace std;

class CCSrcCreator: public AStubCreater {
public:
    CCSrcCreator();
    CCSrcCreator(int BuffSize);
    virtual ~CCSrcCreator();
    virtual VOID CreateBody(CParamInfo *FuncInfo);

    virtual int getBuffSize() const { return m_BuffSize; }
    VOID setBuffSize(int buffSize) { m_BuffSize = buffSize; }

protected:
    virtual VOID SetBuffSizeMacro(CONST String &FileName, int BuffSize = 10);
    virtual VOID CreateArgList(CParamInfo *FuncInfo,
            list<String> *ArgDataList,
            list<String> *ArgNameList);
    virtual VOID SetStartSection(String FileName);
    virtual VOID SetSectionSep(String FuncName);
    virtual VOID SetBuffVarDeclare(CParamInfo *FuncInfo);
    virtual VOID SetDec(CParamInfo *FuncInfo);
    virtual VOID SetBody(CParamInfo *FuncInfo);
    virtual VOID SetInitDec(CParamInfo *FuncInfo);
    virtual VOID SetInitBody(CParamInfo *FuncInfo);

private:
    String m_BuffSizeMacroName;
};

#endif /* CCSRCSTUBCREATOR_H_ */
