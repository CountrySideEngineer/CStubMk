/*
 * TestCode.cpp
 *
 *  Created on: 2016/03/23
 *      Author: Kensuke
 */
#include <iostream>
#include "gtest/gtest.h"
#include "CGTestTarget.h"
using namespace std;

class ev3_utest_common_base : public ::testing::Test {
public:
	virtual void SetUp(void) {}
};
class CTestTargetTest : public ev3_utest_common_base {};
TEST(CTestTargetTest, Test001) {
	//	入力変数
	int n1;
	int n2;
	int actual;
	int expect;
	CGTestTarget target;

	//	入力値の設定
	n1 = 2;
	n2 = 3;
	expect = 5;

	//	テストの実効
	actual = target.TestFunction(n1, n2);

	//	結果の確認
	ASSERT_EQ(actual, expect);
}



