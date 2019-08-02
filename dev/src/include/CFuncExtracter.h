/*
 * CFuncExtracter.h
 *
 *  Created on: 2016/03/15
 *      Author: Kensuke
 */

#ifndef CFUNCEXTRACTER_H_
#define CFUNCEXTRACTER_H_
#include "types.h"
#include <list>
#include <AExtracter.h>
using namespace std;

class CFuncExtracter: public AExtracter {
public:
    CFuncExtracter();
    virtual ~CFuncExtracter() {};
    virtual list<String>::iterator Extract(list<String>& src, CParamInfo *dst);

protected:
    virtual SINT IsModifier(String Modifier);

private:
    enum {
        FUNC_EXTRACTER_STATE_DATA_TYPE = 0,
        FUNC_EXTRACTER_STATE_FUNC_NAME,
    };
    static CONST String MODIFIER_STATIC;
    static CONST String MODIFIER_EXTERN;
};

#endif /* CFUNCEXTRACTER_H_ */
