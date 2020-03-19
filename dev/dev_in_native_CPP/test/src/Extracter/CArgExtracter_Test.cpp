/*
 * CArgExtracter_Test.cpp
 *
 *  Created on: 2016/03/26
 *      Author: Kensuke
 */
#include <iostream>
#include <string>
#include <list>
#include "gtest/gtest.h"
#include "types.h"
#include "CArgExtracter.h"
#include "CParamInfo.h"

using namespace std;

class CArgExtracter_TestBase :
		public CArgExtracter,
		public ::testing::Test
{
public:
	virtual VOID SetUp(VOID) {};
	virtual VOID TearDown(VOID) {};
};
class CArgExtracter_IsModifier_Test : public CArgExtracter_TestBase {};
class CArgExtracter_GetArgStart_Test : public CArgExtracter_TestBase {};
class CArgExtracter_Extract_Test : public CArgExtracter_TestBase {};

TEST_F(CArgExtracter_IsModifier_Test, TEST_001)
{
	SINT Ret = -1;
	String Modifier = "static";

	Ret = this->IsModifier(Modifier);

	ASSERT_FALSE(Ret = 0);
}
TEST_F(CArgExtracter_IsModifier_Test, TEST_002)
{
	SINT Ret = -1;
	String Modifier = "extern";

	Ret = this->IsModifier(Modifier);

	ASSERT_FALSE(Ret = 0);
}
TEST_F(CArgExtracter_IsModifier_Test, TEST_003)
{
	SINT Ret = -1;
	String Modifier = "const";

	Ret = this->IsModifier(Modifier);

	ASSERT_FALSE(Ret == 0);
}
TEST_F(CArgExtracter_IsModifier_Test, TEST_004)
{
	SINT Ret = -1;
	String Modifier = "nont_const";

	Ret = this->IsModifier(Modifier);

	ASSERT_TRUE(Ret == 0);
}
TEST_F(CArgExtracter_GetArgStart_Test, TEST_001)
{
	list<String> src;
	src.push_back("FuncDataType");
	src.push_back("FuncName");
	src.push_back("ArgDataType");
	src.push_back("ArgName");
	list<String>::iterator Ret;

	Ret = this->GetArgStart(src);

	ASSERT_FALSE(Ret == src.end());
	ASSERT_STREQ("ArgDataType", (*Ret).c_str());
}
TEST_F(CArgExtracter_Extract_Test, TEST_001)
{
	list<String> src;
	list<String>::iterator Ret;
	src.push_back("FuncDataType");
	src.push_back("FuncName");
	src.push_back("ArgDataType");
	src.push_back("ArgName");
	CParamInfo ParamInfo;
	list<CParamInfo *> *OptList;
	CParamInfo *Opt;

	Ret = this->Extract(src, &ParamInfo);

	OptList = const_cast<list<CParamInfo *> *>(ParamInfo.getOpt());
	Opt = *(OptList->begin());

	ASSERT_TRUE(Ret == src.end());
	ASSERT_TRUE(ParamInfo.getDataType().empty());
	ASSERT_TRUE(ParamInfo.getName().empty());
	ASSERT_STREQ(Opt->getName().c_str(), "ArgName");
	ASSERT_STREQ(Opt->getDataType().c_str(), "ArgDataType");
}
TEST_F(CArgExtracter_Extract_Test, TEST_002)
{
	list<String> src;
	list<String>::iterator Ret;
	src.push_back("FuncDataType");
	src.push_back("FuncName");
	src.push_back("ArgDataType1");
	src.push_back("ArgName1");
	src.push_back("ArgDataType2");
	src.push_back("ArgName2");
	CParamInfo ParamInfo;
	list<CParamInfo *> *OptList;
	list<CParamInfo *>::iterator OptIt;

	Ret = this->Extract(src, &ParamInfo);

	OptList = const_cast<list<CParamInfo *> *>(ParamInfo.getOpt());
	OptIt = OptList->begin();

	ASSERT_TRUE(Ret == src.end());
	ASSERT_TRUE(ParamInfo.getDataType().empty());
	ASSERT_TRUE(ParamInfo.getName().empty());
	ASSERT_STREQ((*OptIt)->getName().c_str(), "ArgName1");
	ASSERT_STREQ((*OptIt)->getDataType().c_str(), "ArgDataType1");
	OptIt++;
	ASSERT_STREQ((*OptIt)->getName().c_str(), "ArgName2");
	ASSERT_STREQ((*OptIt)->getDataType().c_str(), "ArgDataType2");
}
TEST_F(CArgExtracter_Extract_Test, TEST_003)
{
	list<String> src;
	list<String>::iterator Ret;
	src.push_back("FuncDataType");
	src.push_back("FuncName");
	CParamInfo ParamInfo;
	list<CParamInfo *> *OptList;
	list<CParamInfo *>::iterator OptIt;

	Ret = this->Extract(src, &ParamInfo);

	OptList = const_cast<list<CParamInfo *> *>(ParamInfo.getOpt());
	OptIt = OptList->begin();

	ASSERT_TRUE(Ret == src.end());
	ASSERT_TRUE(ParamInfo.getDataType().empty());
	ASSERT_TRUE(ParamInfo.getName().empty());
	ASSERT_TRUE(OptList->empty());
}
TEST_F(CArgExtracter_Extract_Test, TEST_004)
{
	list<String> src;
	list<String>::iterator Ret;
	src.push_back("FuncDataType");
	src.push_back("FuncName");
	src.push_back("VOID");
	CParamInfo ParamInfo;
	list<CParamInfo *> *OptList;
	list<CParamInfo *>::iterator OptIt;

	Ret = this->Extract(src, &ParamInfo);

	OptList = const_cast<list<CParamInfo *> *>(ParamInfo.getOpt());
	OptIt = OptList->begin();

	ASSERT_TRUE(Ret == src.end());
	ASSERT_TRUE(ParamInfo.getDataType().empty());
	ASSERT_TRUE(ParamInfo.getName().empty());
	ASSERT_TRUE(OptList->empty());
}
