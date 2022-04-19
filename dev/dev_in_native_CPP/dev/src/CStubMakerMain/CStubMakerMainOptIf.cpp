/*
 * CStubMakerMainOptIf.cpp
 *
 *  Created on: 2016/06/25
 *      Author: Kensuke
 */
#include <iostream>
#include <exception>
#include <sstream>
#include <iomanip>
#include "AStubCreater.h"
#include "CCSrcIFCreator.h"
#include "CCHeaderIFCreator.h"
#include "CStubMakerMainOptIf.h"

CStubMakerMainOptIf::CStubMakerMainOptIf() {}
CStubMakerMainOptIf::CStubMakerMainOptIf(String FileName)
    : CStubMakerMain(FileName)
{}
CStubMakerMainOptIf::~CStubMakerMainOptIf() {}

VOID CStubMakerMainOptIf::CreateStub(String FileName)
{
    CCSrcIFCreator SrcIfCreator;
    CCHeaderIFCreator HdrIfCreator;
    list<AStubCreater *> StubCreatorList;
    StubCreatorList.push_front((AStubCreater *)(&SrcIfCreator));
    StubCreatorList.push_front((AStubCreater *)(&HdrIfCreator));

    CStubMakerMain::CreateStub(FileName, &StubCreatorList);
}
