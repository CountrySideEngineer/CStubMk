/*
 * CStubMakerMainOptStub.cpp
 *
 *  Created on: 2016/06/06
 *      Author: Kensuke
 */
#include <iostream>
#include <exception>
#include <sstream>
#include <iomanip>
#include <list>
#include "AStubCreater.h"
#include "CCSrcStubCreator.h"
#include "CCHeaderStubCreator.h"
#include "CStubMakerMainOptStub.h"
using namespace std;

CStubMakerMainOptStub::CStubMakerMainOptStub() {}
CStubMakerMainOptStub::CStubMakerMainOptStub(String FileName)
    : CStubMakerMain(FileName)
{}
CStubMakerMainOptStub::~CStubMakerMainOptStub() {}

VOID CStubMakerMainOptStub::CreateStub(String FileName)
{
	CCSrcStubCreator SrcStubCreator;
	CCHeaderStubCreator HdrStubCreator;
	list<AStubCreater *> StubCreatorList;

	StubCreatorList.push_back((AStubCreater *)(&SrcStubCreator));
	StubCreatorList.push_back((AStubCreater *)(&HdrStubCreator));

	CStubMakerMain::CreateStub(FileName, &StubCreatorList);
}
