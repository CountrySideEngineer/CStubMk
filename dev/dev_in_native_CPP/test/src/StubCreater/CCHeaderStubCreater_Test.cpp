/*
 * CCHeaderStubCreater_Test.cpp
 *
 *  Created on: 2016/04/02
 *      Author: Kensuke
 */
#include <iostream>
#include <string>
#include "types.h"
#include "CCHeaderStubCreater.h"
#include "CParamInfo.h"
#include "gtest/gtest.h"
using namespace std;

class CCHeaderStubCreater_TestBase :
		public CCHeaderStubCreater,
		public ::testing::Test
{
public:
	virtual VOID SetUp(VOID) {};
	virtual VOID TearDown(VOID) {};
};

class CCHeaderStubCreater_SetStartSection_Test :
		public CCHeaderStubCreater_TestBase {};

TEST_F(CCHeaderStubCreater_SetStartSection_Test, Test_001)
{
	String FileName = String("TestFileName.txt");
	this->OpenFile(FileName);
	this->SetStartSection(FileName);
	this->SetEndSection(FileName);
	this->CloseFile();
}
TEST_F(CCHeaderStubCreater_SetStartSection_Test, Test_002)
{
	String FileName = String("TestFileName2.txt");
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
	this->SetStartSection(FileName);
	this->CreateBody(&ParamInfo);
	this->SetEndSection(FileName);
	this->CloseFile();
}
TEST_F(CCHeaderStubCreater_SetStartSection_Test, Test_003)
{
	String FileName = String("TestFileName3.txt");
	CParamInfo ParamInfo;
	ParamInfo.setName("TestFuncName");
	ParamInfo.AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"TestArgName",
			"TestArgType",
			false));
	ParamInfo.AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"TestArgName1",
			"TestArgType2*",
			true));
	ParamInfo.AddOpt(new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
			"*TestArgName3",
			"TestArgType3",
			true));
	list<String> ArgDataList;
	list<String> ArgNameList;
	this->OpenFile(FileName);



	this->CreateArgList(&ParamInfo, &ArgDataList, &ArgNameList);

	list<String>::iterator it = ArgDataList.begin();
	list<String>::iterator it2 = ArgNameList.begin();
	while (ArgDataList.end() != it) {
		cout << "DataType = " << *it << endl;
		cout << "DataName = " << *it2 << endl;
		it++;
		it2++;
	}
}
TEST_F(CCHeaderStubCreater_SetStartSection_Test, Test_004)
{
	String FileName = String("TestFileName4");
	list<CParamInfo *> FuncInfoList;
	CParamInfo *ParamInfo;
	// 関数その1
	ParamInfo = new CParamInfo(
			CParamInfo::PARAM_TYPE_FUNC,
			"TestFuncName1", "TestDataType1", 0);
	ParamInfo->AddOpt(
			new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
					"TestArgName1_1", "TestDataType1_1", 0));
	ParamInfo->AddOpt(
			new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
					"TestArgName1_2", "TestDataType1_2", 0));
	FuncInfoList.push_back(ParamInfo);
	// 関数その2
	ParamInfo = new CParamInfo(
			CParamInfo::PARAM_TYPE_FUNC,
			"TestFuncName2", "TestDataType2", 0);
	FuncInfoList.push_back(ParamInfo);
	// 関数その3
	ParamInfo = new CParamInfo(
			CParamInfo::PARAM_TYPE_FUNC,
			"*TestFuncName2", "TestDataType3", 0);
	ParamInfo->AddOpt(
			new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
					"TestArgName3_1", "TestDataType3_1*", 0));
	FuncInfoList.push_back(ParamInfo);
	// 関数その4
	ParamInfo = new CParamInfo(
			CParamInfo::PARAM_TYPE_FUNC,
			"TestFuncName4", "TestDataType3", 0);
	ParamInfo->AddOpt(
			new CParamInfo(CParamInfo::PARAM_TYPE_ARG,
					"*TestArgName4_1", "TestDataType4_1", 0));
	FuncInfoList.push_back(ParamInfo);

	this->Create(FileName, &FuncInfoList);
}
