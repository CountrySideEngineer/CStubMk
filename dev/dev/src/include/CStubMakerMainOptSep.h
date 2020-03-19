/*
 * CStubMakerMainOptSep.h
 *
 *  Created on: 2016/06/25
 *      Author: Kensuke
 */

#ifndef CSTUBMAKERMAINOPTSEP_H_
#define CSTUBMAKERMAINOPTSEP_H_

#include <CStubMakerMain.h>

class CStubMakerMainOptSep: public CStubMakerMain {
public:
    CStubMakerMainOptSep();
    CStubMakerMainOptSep(String FileName);
    virtual ~CStubMakerMainOptSep();

    virtual VOID CreateStub(String FileName);
};

#endif /* CSTUBMAKERMAINOPTSEP_H_ */
