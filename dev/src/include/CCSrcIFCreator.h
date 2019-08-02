/*
 * CCSrcIFCreator.h
 *
 *  Created on: 2016/05/28
 *      Author: Kensuke
 */

#ifndef CCSRCIFCREATOR_H_
#define CCSRCIFCREATOR_H_
#include <iostream>
#include <fstream>
#include <sstream>
#include <list>
#include "CCSrcCreator.h"
using namespace std;

class CCSrcIFCreator : public CCSrcCreator {
public:
    CCSrcIFCreator();
    virtual ~CCSrcIFCreator();
    virtual VOID CreateBody(CParamInfo *FuncInfo);

protected:
    virtual VOID SetStartSection(String FileName);
    virtual VOID SetDec(CParamInfo *FuncInfo);
    virtual VOID SetBody(CParamInfo *FuncInfo);
    virtual SINT HasReturn(CParamInfo *Info);
    virtual VOID SetSectionSep(String FuncName);

    virtual String CreateStubFuncName(String BaseFuncName) {
        return (BaseFuncName + String("_stub"));
    }
};

#endif /* CCSRCIFCREATOR_H_ */
