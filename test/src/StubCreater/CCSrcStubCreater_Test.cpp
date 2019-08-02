/*
 * CCSrcStubCreater_Test.cpp
 *
 *  Created on: 2016/04/09
 *      Author: Kensuke
 */
#include <iostream>
#include <string>
#include "types.h"
#include "CCSrcStubCreater.h"
#include "CParamInfo.h"
#include "gtest/gtest.h"
using namespace std;

class CCSrcStubCreater_TestBase : public CCSrcCreator, public ::testing::Test
{
public:
	virtual VOID SetUp(VOID) {};
	virtual VOID TearDown(VOID) {};
};
class CCSrcStubCreater_SetBuffVarDeclare_Test :
		public CCSrcStubCreater_TestBase {};
class CCSrcStubCreater_SetStubBody_Test :
		public CCSrcStubCreater_TestBase {};
class CCSrcStubCreater_CreateBody_Test :
		public CCSrcStubCreater_TestBase {};

TEST_F(CCSrcStubCreater_SetBuffVarDeclare_Test, Test_001)
{
	String FileName = String("CCSrcStubCreater_SetBuffVarDeclare_Test1.txt");
	CParamInfo ParamInfo;
	ParamInfo.setDataType("TestDataType");
	ParamInfo.setName("TestFuncName");
	ParamInfo.AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"TestArgName",
			"TestArgType",
			false));
	ParamInfo.AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"TestArgName2",
			"TestArgType2*",
			true));
	ParamInfo.AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"*TestArgName3",
			"TestArgType3",
			true));

	this->OpenFile(FileName);
	this->SetBuffSizeMacro(FileName);
	this->SetBuffVarDeclare(&ParamInfo);
	this->CloseFile();
}
TEST_F(CCSrcStubCreater_SetBuffVarDeclare_Test, Test_002)
{
	String FileName = String("CCSrcStubCreater_SetBuffVarDeclare_Test2.txt");
	CParamInfo ParamInfo;
	ParamInfo.setDataType("TestDataType");
	ParamInfo.setName("TestFuncName");

	this->OpenFile(FileName);
	this->SetBuffSizeMacro(FileName);
	this->SetBuffVarDeclare(&ParamInfo);
	this->CloseFile();
}
TEST_F(CCSrcStubCreater_SetStubBody_Test, Test_001)
{
	String FileName = String("CCSrcStubCreater_SetStubBody_Test_Test1.txt");
	CParamInfo ParamInfo;
	ParamInfo.setDataType("TestDataType");
	ParamInfo.setName("TestFuncName");
	ParamInfo.AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"TestArgName",
			"TestArgType",
			false));
	ParamInfo.AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"TestArgName2",
			"TestArgType2*",
			true));
	ParamInfo.AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"*TestArgName3",
			"TestArgType3",
			true));

	this->OpenFile(FileName);
	this->SetBuffSizeMacro(FileName);
	this->SetBody(&ParamInfo);
	this->CloseFile();
}
TEST_F(CCSrcStubCreater_SetStubBody_Test, Test_002)
{
	String FileName = String("CCSrcStubCreater_SetStubBody_Test_Test2.txt");
	CParamInfo ParamInfo;
	ParamInfo.setDataType("TestDataType");
	ParamInfo.setName("TestFuncName");

	this->OpenFile(FileName);
	this->SetBuffSizeMacro(FileName);
	this->SetBody(&ParamInfo);
	this->CloseFile();
}
TEST_F(CCSrcStubCreater_CreateBody_Test, Test_001)
{
	String FileName = String("CCSrcStubCreater_CreateBody_Test_Test_001.txt");
	list<CParamInfo *> ParamInfoList;
	CParamInfo ParamInfo;
	ParamInfo.setDataType("TestDataType");
	ParamInfo.setName("TestFuncName");
	ParamInfo.AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"TestArgName",
			"TestArgType",
			false));
	ParamInfo.AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"TestArgName2",
			"TestArgType2*",
			true));
	ParamInfo.AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"*TestArgName3",
			"TestArgType3",
			true));
	ParamInfoList.push_back(&ParamInfo);

	this->Create(FileName, &ParamInfoList);
}
TEST_F(CCSrcStubCreater_CreateBody_Test, Test_002)
{
	String FileName = String("CCSrcStubCreater_CreateBody_Test_Test_002.txt");
	list<CParamInfo *> ParamInfoList;
	CParamInfo *ParamInfo = new CParamInfo(
			CParamInfo::PARAM_TYPE_FUNC,
			String("TestFuncName1"),
			String("TestDataType1"),
			false);
	ParamInfo->AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"TestArgName1",
			"TestArgType1",
			false));
	ParamInfo->AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"TestArgName2",
			"TestArgType2*",
			true));
	ParamInfo->AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"*TestArgName3",
			"TestArgType3",
			true));
	ParamInfoList.push_back(ParamInfo);
	ParamInfo = new CParamInfo(
			CParamInfo::PARAM_TYPE_FUNC,
			String("TestFuncName2"),
			String("TestDataType2"),
			false);
	ParamInfo->AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"TestArgName2_1",
			"TestArgType2_1",
			false));
	ParamInfo->AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"TestArgName2_2",
			"TestArgType2_2*",
			true));
	ParamInfo->AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"*TestArgName2_3",
			"TestArgType2_3",
			true));
	ParamInfoList.push_back(ParamInfo);

	this->Create(FileName, &ParamInfoList);
}


