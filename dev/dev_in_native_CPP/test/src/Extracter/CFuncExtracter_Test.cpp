/*
 * CFuncExtracter_Test.cpp
 *
 *  Created on: 2016/03/25
 *      Author: Kensuke
 */
#include <iostream>
#include <string>
#include <list>
#include "types.h"
#include "CFuncExtracter.h"
#include "gtest/gtest.h"
using namespace std;

class CFuncExtracter_TestBase :
		public CFuncExtracter,
		public ::testing::Test
{
public:
	virtual VOID SetUp(VOID) {};
	virtual VOID TearDown(VOID) {};
};

class CFuncExtracter_IsModifier_Test : public CFuncExtracter_TestBase {};
class CFuncExtracter_Extract_Test : public CFuncExtracter_TestBase {};

TEST_F(CFuncExtracter_IsModifier_Test, TEST_001)
{
	String Modifier = "const";
	SINT Ret = 0;

	Ret = this->IsModifier(Modifier);

	ASSERT_NE(Ret, 0);
}
TEST_F(CFuncExtracter_IsModifier_Test, TEST_002)
{
	String Modifier = "extern";
	SINT Ret = 0;

	Ret = this->IsModifier(Modifier);

	ASSERT_NE(Ret, 0);
}
TEST_F(CFuncExtracter_IsModifier_Test, TEST_003)
{
	String Modifier = "static";
	SINT Ret = 0;

	Ret = this->IsModifier(Modifier);

	ASSERT_NE(Ret, 0);
}
TEST_F(CFuncExtracter_IsModifier_Test, TEST_004)
{
	String Modifier = "none_const";
	SINT Ret = 0;

	Ret = this->IsModifier(Modifier);

	ASSERT_EQ(Ret, 0);
}
TEST_F(CFuncExtracter_IsModifier_Test, TEST_005)
{
	String Modifier = "none_extern";
	SINT Ret = 0;

	Ret = this->IsModifier(Modifier);

	ASSERT_EQ(Ret, 0);
}
TEST_F(CFuncExtracter_IsModifier_Test, TEST_006)
{
	String Modifier = "none_static";
	SINT Ret = 0;

	Ret = this->IsModifier(Modifier);

	ASSERT_EQ(Ret, 0);
}
TEST_F(CFuncExtracter_Extract_Test, TEST_001)
{
	list<String> Src;
	list<String>::iterator Ret;
	CParamInfo Dst;

	// 引数セット
	Src.push_back("SINT");
	Src.push_back("Hello");
	Src.push_back("SINT");
	Src.push_back("Argument");

	Ret = this->Extract(Src, &Dst);

	ASSERT_FALSE(Ret == Src.begin());
	ASSERT_EQ(Dst.getType(), CParamInfo::PARAM_TYPE_FUNC);
	ASSERT_STREQ(Dst.getDataType().c_str(), "SINT");
	ASSERT_STREQ(Dst.getName().c_str(), "Hello");
	ASSERT_STREQ((*Ret).c_str(), "Hello");
}
TEST_F(CFuncExtracter_Extract_Test, TEST_002)
{
	list<String> Src;
	list<String>::iterator Ret;
	CParamInfo Dst;

	// 引数セット
	Src.push_back("extern");
	Src.push_back("SINT");
	Src.push_back("Hello");
	Src.push_back("VOID*");
	Src.push_back("Argument");

	Ret = this->Extract(Src, &Dst);

	ASSERT_FALSE(Ret == Src.begin());
	ASSERT_EQ(Dst.getType(), CParamInfo::PARAM_TYPE_FUNC);
	ASSERT_STREQ(Dst.getDataType().c_str(), "extern SINT");
	ASSERT_STREQ(Dst.getName().c_str(), "Hello");
	ASSERT_STREQ((*Ret).c_str(), "Hello");
}
TEST_F(CFuncExtracter_Extract_Test, TEST_003)
{
	list<String> Src;
	list<String>::iterator Ret;
	CParamInfo Dst;

	// 引数セット
	Src.push_back("CONST");
	Src.push_back("extern");
	Src.push_back("SINT");
	Src.push_back("Hello");
	Src.push_back("VOID*");
	Src.push_back("Argument");

	Ret = this->Extract(Src, &Dst);

	ASSERT_FALSE(Ret == Src.begin());
	ASSERT_EQ(Dst.getType(), CParamInfo::PARAM_TYPE_FUNC);
	ASSERT_STREQ(Dst.getDataType().c_str(), "CONST extern SINT");
	ASSERT_STREQ(Dst.getName().c_str(), "Hello");
	ASSERT_STREQ((*Ret).c_str(), "Hello");
}
TEST_F(CFuncExtracter_Extract_Test, TEST_004)
{
	list<String> Src;
	list<String>::iterator Ret;
	CParamInfo Dst;

	// 引数セット
	Src.push_back("EXTERN");
	Src.push_back("CONST");
	Src.push_back("SINT*");
	Src.push_back("Hello");
	Src.push_back("VOID*");
	Src.push_back("Argument");

	Ret = this->Extract(Src, &Dst);

	ASSERT_FALSE(Ret == Src.begin());
	ASSERT_EQ(Dst.getType(), CParamInfo::PARAM_TYPE_FUNC);
	ASSERT_STREQ(Dst.getDataType().c_str(), "EXTERN CONST SINT*");
	ASSERT_STREQ(Dst.getName().c_str(), "Hello");
	ASSERT_STREQ((*Ret).c_str(), "Hello");
}
TEST_F(CFuncExtracter_Extract_Test, TEST_005)
{
	list<String> Src;
	list<String>::iterator Ret;
	CParamInfo Dst;

	// 引数セット
	Src.push_back("EXTERN");
	Src.push_back("CONST");
	Src.push_back("SINT");
	Src.push_back("*HELLO");
	Src.push_back("VOID*");
	Src.push_back("Argument");

	Ret = this->Extract(Src, &Dst);

	ASSERT_FALSE(Ret == Src.begin());
	ASSERT_EQ(Dst.getType(), CParamInfo::PARAM_TYPE_FUNC);
	ASSERT_STREQ(Dst.getDataType().c_str(), "EXTERN CONST SINT");
	ASSERT_STREQ(Dst.getName().c_str(), "*HELLO");
	ASSERT_STREQ((*Ret).c_str(), "*HELLO");
}
