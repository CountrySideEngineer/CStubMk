/*
 * CStubMakerMainOptSep.cpp
 *
 *  Created on: 2016/06/25
 *      Author: Kensuke
 */
#include <iostream>
#include <exception>
#include <sstream>
#include <iomanip>
#include "AStubCreater.h"
#include "CCSrcStubCreator.h"
#include "CCSrcIFCreator.h"
#include "CCHeaderCreator.h"
#include "CCHeaderStubCreator.h"
#include "CCHeaderIFCreator.h"
#include "CStubMakerMainOptSep.h"

CStubMakerMainOptSep::CStubMakerMainOptSep() {}
CStubMakerMainOptSep::CStubMakerMainOptSep(String FileName)
    : CStubMakerMain(FileName)
{}
CStubMakerMainOptSep::~CStubMakerMainOptSep() {}
VOID CStubMakerMainOptSep::CreateStub(String FileName)
{
    CCSrcIFCreator SrcIfCreator;
    CCSrcStubCreator SrcStubCreator;
    CCHeaderIFCreator HdrIfCreator;
    CCHeaderStubCreator HdrStubCreator;
    list<AStubCreater *> StubCreatorList;
    StubCreatorList.push_back((AStubCreater *)(&SrcIfCreator));
    StubCreatorList.push_back((AStubCreater *)(&SrcStubCreator));
    StubCreatorList.push_back((AStubCreater *)(&HdrIfCreator));
    StubCreatorList.push_back((AStubCreater *)(&HdrStubCreator));

    CStubMakerMain::CreateStub(FileName, &StubCreatorList);
}
