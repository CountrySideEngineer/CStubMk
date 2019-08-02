/*
 * CStubMakerMain_Test.cpp
 *
 *  Created on: 2016/04/19
 *      Author: Kensuke
 */
#include <iostream>
#include <string>
#include "types.h"
#include "CStubMakerMain.h"
#include "gtest/gtest.h"
using namespace std;

class CStubMakerMain_TestBase : public ::testing::Test
{
public:
	virtual VOID SetUp(VOID) {};
	virtual VOID TearDown(VOID) {};
};
class CStubMakerMain_GetVersion_Test : public CStubMakerMain_TestBase {};

TEST_F(CStubMakerMain_GetVersion_Test, Test_001)
{
	CStubMakerMain MakerMain;
	String VersionString = MakerMain.GetVersion();

	cout << "Version = " << VersionString << endl;
}



