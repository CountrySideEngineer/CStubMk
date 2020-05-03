/*
 * CParamInfo.h
 *
 *  Created on: 2016/03/13
 *      Author: Kensuke
 */

#ifndef CPARAMINFO_H_
#define CPARAMINFO_H_
#include <string>
#include <list>
#include "types.h"

using namespace std;

class CParamInfo {
public:
    enum PARAM_TYPE {
        PARAM_TYPE_FUNC = 0,
        PARAM_TYPE_ARG,
    };
    CParamInfo();
    CParamInfo(PARAM_TYPE Type, String Name, String DataType, SINT IsPtr);
    virtual ~CParamInfo();

    virtual VOID AddOpt(CParamInfo *Opt);

    //  Getters/Setters
    CONST String& getName() CONST { return m_Name; };
    VOID setName(CONST String& name) { m_Name = name; };
    PARAM_TYPE getType() CONST { return m_Type; }
    VOID setType(PARAM_TYPE type) { m_Type = type; }
    CONST String& getDataType() CONST { return m_DataType; };
    VOID setDataType(CONST String& dataType) { m_DataType = dataType; };
    SINT getIsPtr() CONST { return m_IsPtr; };
    VOID setIsPtr(SINT IsPtr) { m_IsPtr = IsPtr; }
    CONST list<CParamInfo*>* getOpt() { return m_Opt; };

private:
    VOID Init(VOID);

    PARAM_TYPE m_Type;
    String m_Name;
    String m_DataType;
    SINT m_IsPtr;
    list<CParamInfo*> *m_Opt;
};

#endif /* CPARAMINFO_H_ */
