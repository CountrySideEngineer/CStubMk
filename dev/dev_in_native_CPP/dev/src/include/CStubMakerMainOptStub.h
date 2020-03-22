/*
 * CStubMakerMainOptStub.h
 *
 *  Created on: 2016/06/06
 *      Author: Kensuke
 */

#ifndef CSTUBMAKERMAINOPTSTUB_H_
#define CSTUBMAKERMAINOPTSTUB_H_

#include <CStubMakerMain.h>

class CStubMakerMainOptStub: public CStubMakerMain {
public:
    CStubMakerMainOptStub();
    CStubMakerMainOptStub(String FileName);
    virtual ~CStubMakerMainOptStub();

    virtual VOID CreateStub(String FileName);
};

#endif /* CSTUBMAKERMAINOPTSTUB_H_ */
