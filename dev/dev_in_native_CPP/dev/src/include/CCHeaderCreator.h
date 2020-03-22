/*
 * CCHeaderCreater.h
 *
 *  Created on: 2016/04/01
 *      Author: Kensuke
 */

#ifndef CCHEADERCREATER_H_
#define CCHEADERCREATER_H_
#include <iostream>
#include <list>
#include <AStubCreater.h>
#include "types.h"
using namespace std;

class CCHeaderCreator: public AStubCreater {
public:
    CCHeaderCreator();
    virtual ~CCHeaderCreator();
    virtual VOID CreateBody(CParamInfo *FuncInfo);

protected:
    virtual VOID SetStartSection(String FileName);
    virtual VOID SetEndSection(String FileName);
    virtual VOID SetSectionSep(String FuncName);
    virtual VOID CreateStubDec(CParamInfo *FuncInfo);
    virtual VOID CreateVariableDec(CParamInfo *FuncInfo);
    virtual VOID CreateVarGetSetMacro(CParamInfo *FuncInfo);
    virtual String CreateHeaderMacro(String FileName);

    virtual String CreateStubFuncName(String BaseFuncName) {
        return (BaseFuncName);
    }

private:
};

#endif /* CCHEADERCREATER_H_ */
