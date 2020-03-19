/*
 * CCHeaderStubCreator.h
 *
 *  Created on: 2016/05/30
 *      Author: Kensuke
 */

#ifndef CCHEADERSTUBCREATOR_H_
#define CCHEADERSTUBCREATOR_H_

#include "CCHeaderCreator.h"
//#include <CCHeaderStubCreator.h>

class CCHeaderStubCreator: public CCHeaderCreator {
public:
    CCHeaderStubCreator();
    virtual ~CCHeaderStubCreator();

protected:
    virtual String CreateHeaderMacro(String FileName);
    virtual String CreateStubFuncName(String BaseFuncName) {
        return (BaseFuncName + String("_stub"));
    }
};

#endif /* CCHEADERSTUBCREATOR_H_ */
