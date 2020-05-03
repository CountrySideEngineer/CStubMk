/*
 * CCSrcCreator.h
 *
 *  Created on: 2016/05/30
 *      Author: Kensuke
 */

#ifndef CCSRCCREATOR_H_
#define CCSRCCREATOR_H_

#include "CCSrcCreator.h"

class CCSrcStubCreator: public CCSrcCreator {
public:
    CCSrcStubCreator();
    virtual ~CCSrcStubCreator();

protected:
    virtual String CreateStubFuncName(String BaseFuncName) {
        return (BaseFuncName + String("_stub"));
    }
};

#endif /* CCSRCCREATOR_H_ */
