/*
 * CStubMakerMainOptIf.h
 *
 *  Created on: 2016/06/25
 *      Author: Kensuke
 */

#ifndef CSTUBMAKERMAINOPTIF_H_
#define CSTUBMAKERMAINOPTIF_H_
#include <CStubMakerMain.h>

class CStubMakerMainOptIf : public CStubMakerMain {
public:
    CStubMakerMainOptIf();
    CStubMakerMainOptIf(String FileName);
    virtual ~CStubMakerMainOptIf();

    virtual VOID CreateStub(String FileName);
};

#endif /* CSTUBMAKERMAINOPTIF_H_ */
