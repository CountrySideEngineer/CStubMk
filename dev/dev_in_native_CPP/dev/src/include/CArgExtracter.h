/*
 * CArgExtracter.h
 *
 *  Created on: 2016/03/18
 *      Author: Kensuke
 */

#ifndef CARGEXTRACTER_H_
#define CARGEXTRACTER_H_
#include "types.h"
#include "CFuncExtracter.h"

class CArgExtracter: public CFuncExtracter {
public:
    CArgExtracter() {};
    virtual ~CArgExtracter() {};
    virtual list<String>::iterator Extract(list<String>& src, CParamInfo *dst);

protected:
    virtual SINT IsModifier(String Modifier);
    virtual list<String>::iterator GetArgStart(list<String>& src);

private:
    enum {
        ARG_EXTRACTER_STATE_ARG_DATA_TYPE = 0,
        ARG_EXTRACTER_STATE_ARG_NAME,
    };
    enum {
        ARG_EXTRACTER_STATE_SKIP_FUNC_DATA_TYPE = 0,
        ARG_EXTRACTER_STATE_SKIP_FUNC_NAME,
    };
    static CONST String MODIFIER_STATIC;
    static CONST String MODIFIER_EXTERN;
};

#endif /* CARGEXTRACTER_H_ */
