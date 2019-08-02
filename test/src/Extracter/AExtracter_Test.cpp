/*
 * AExtracter_Test.cpp
 *
 *  Created on: 2016/03/25
 *      Author: Kensuke
 */
#include <iostream>
#include <string>
#include <list>
#include "types.h"
#include "AExtracter.h"
#include "gtest/gtest.h"
using namespace std;

class AExtarcter_TestBase :
		public AExtracter,
		public ::testing::Test
{
public:
	virtual VOID SetUp(VOID) {};
	virtual VOID TearDown(VOID) {};
	virtual list<String>::iterator Extract(list<String>& src,
			CParamInfo *dst)
	{ return (list<String>::iterator)0; };

};
class AExtracter_IsModifier_Test : public AExtarcter_TestBase {};
class AExtracter_HasAsterisk : public AExtarcter_TestBase {};

TEST_F(AExtracter_IsModifier_Test, TEST_001)
{
	String Modifier = String("const");
	SINT Ret = 0;	// False

	Ret = this->IsModifier(Modifier);

	ASSERT_NE(Ret, 0);
}
TEST_F(AExtracter_IsModifier_Test, TEST_002)
{
	String Modifier = String("not_const");
	SINT Ret = 0;	// False

	Ret = this->IsModifier(Modifier);

	ASSERT_EQ(Ret, 0);
}
TEST_F(AExtracter_IsModifier_Test, TEST_003)
{
	String Modifier = String("CONST");
	SINT Ret = 0;	// False

	Ret = this->IsModifier(Modifier);

	ASSERT_EQ(Ret, 0);
}
TEST_F(AExtracter_IsModifier_Test, TEST_004)
{
	String Modifier = String("Const");
	SINT Ret = 0;	// False

	Ret = this->IsModifier(Modifier);

	ASSERT_EQ(Ret, 0);
}
TEST_F(AExtracter_IsModifier_Test, TEST_005)
{
	String Modifier = String("consT");
	SINT Ret = 0;	// False

	Ret = this->IsModifier(Modifier);

	ASSERT_EQ(Ret, 0);
}
TEST_F(AExtracter_IsModifier_Test, TEST_006)
{
	String Modifier = String("const");
	SINT Ret = 0;	// False

	Ret = this->IsModifier(&Modifier);

	ASSERT_NE(Ret, 0);
}
TEST_F(AExtracter_IsModifier_Test, TEST_007)
{
	String Modifier = String("CONST");
	SINT Ret = 0;	// False

	Ret = this->IsModifier(&Modifier);

	ASSERT_NE(Ret, 0);
}
TEST_F(AExtracter_IsModifier_Test, TEST_008)
{
	String Modifier = String("const");
	SINT Ret = 0;	// False

	Ret = this->IsModifier(&Modifier);

	ASSERT_NE(Ret, 0);
}
TEST_F(AExtracter_IsModifier_Test, TEST_009)
{
	String Modifier = String("none_const");
	SINT Ret = 0;	// False

	Ret = this->IsModifier(&Modifier);

	ASSERT_EQ(Ret, 0);
}

TEST_F(AExtracter_HasAsterisk, TEST_001)
{
	String Data = "*Data";
	SINT Ret = 0;	// False

	Ret = this->HasAsterisk(Data);

	ASSERT_NE(Ret, 0);
}
TEST_F(AExtracter_HasAsterisk, TEST_002)
{
	String Data = "Data*";
	SINT Ret = 0;	// False

	Ret = this->HasAsterisk(Data);

	ASSERT_NE(Ret, 0);
}
TEST_F(AExtracter_HasAsterisk, TEST_003)
{
	String Data = "Data";
	SINT Ret = 0;	// False

	Ret = this->HasAsterisk(Data);

	ASSERT_EQ(Ret, 0);
}
TEST_F(AExtracter_HasAsterisk, TEST_004)
{
	String Data = "";

	ASSERT_THROW(this->HasAsterisk(Data), invalid_argument);
}
