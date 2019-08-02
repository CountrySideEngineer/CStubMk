/*
 * CCHeaderIFCreator.h
 *
 *  Created on: 2016/06/25
 *      Author: Kensuke
 */

#ifndef CCHEADERIFCREATOR_H_
#define CCHEADERIFCREATOR_H_
#include <iostream>
#include <list>
#include <AStubCreater.h>
#include <CCHeaderCreator.h>

class CCHeaderIFCreator: public CCHeaderCreator {
public:
    CCHeaderIFCreator();
    virtual ~CCHeaderIFCreator();
    virtual VOID CreateBody(CParamInfo *FuncInfo);

protected:
    virtual VOID CreateStubDec(CParamInfo *FuncInfo);
};

#endif /* CCHEADERIFCREATOR_H_ */
