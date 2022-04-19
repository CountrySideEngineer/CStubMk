/*
 * CFileParser_Test.cpp
 *
 *  Created on: 2016/03/23
 *      Author: Kensuke
 */
#include <iostream>
#include <string>
#include <list>
#include <vector>
#include "types.h"
#include "CFileParser.h"
#include "gtest/gtest.h"

class CFileParser_Test_Base :
		public CFileParser,
		public ::testing::Test
{
public:
	virtual VOID SetUp(VOID) {};
	virtual VOID TearDown(VOID) {};
};
class CFileParser_GetFileData_Test : public CFileParser_Test_Base {};
class CFileParser_SplitLineData_Test : public CFileParser_Test_Base {};
class CFileParser_Parse_Test : public CFileParser_Test_Base {};


TEST_F(CFileParser_GetFileData_Test, TEST_001)
{
	String FileName = "E:\\development\\C\\cstubmk\\workspace_win\\cstubmk_utest\\Debug\\TestTextFile.txt";
	vector<String> LineData;

	this->GetFileData(FileName, &LineData);

	vector<String>::iterator it;
	it = LineData.begin();
	ASSERT_EQ(4, (int)LineData.size());
	ASSERT_STREQ(
			"SLONG ev3_motor_device_close();",
			((String)(*it)).c_str());
	it++;
	ASSERT_STREQ(
			"SLONG ev3_motor_device_initialize(CONST UBYTE chList, CONST VOID *opt);",
			((String)(*it)).c_str());
	it++;
	ASSERT_STREQ(
			"SLONG ev3_motor_device_write(CONST UBYTE ch, CONST VOID *data, CONST SINT data_len);",
			((String)(*it)).c_str());
	it++;
	ASSERT_STREQ(
			"SLONG ev3_motor_device_read(CONST UBYTE ch, VOID *buf, CONST SINT buf_len, SINT *read_len);",
			((String)(*it)).c_str());
	it++;
	ASSERT_TRUE(it == LineData.end());
}


TEST_F(CFileParser_SplitLineData_Test, TEST_001)
{
	String LineData = "int ShowHello(int data, char data2);";
	vector<String> LineContent;

	this->SplitLineData(LineData, &LineContent);

	ASSERT_EQ((int)LineContent.size(), 6);
	ASSERT_STREQ(LineContent[0].c_str(), "int");
	ASSERT_STREQ(LineContent[1].c_str(), "ShowHello");
	ASSERT_STREQ(LineContent[2].c_str(), "int");
	ASSERT_STREQ(LineContent[3].c_str(), "data");
	ASSERT_STREQ(LineContent[4].c_str(), "char");
	ASSERT_STREQ(LineContent[5].c_str(), "data2");
}

TEST_F(CFileParser_Parse_Test, TEST_001)
{
	String FileName = "E:\\development\\C\\cstubmk\\workspace_win\\cstubmk_utest\\CFileParser_Test\\TestTextFile.txt";
	list<String> *Content;
	list<String>::iterator ContentIterator;
	list<CFileData *>::iterator FileDataIterator;
	list<CFileData *> FileData;
	list<CFileData *> *RetFileData;

	RetFileData = this->Parse(FileName, &FileData);

	ASSERT_EQ(RetFileData, &FileData);
	ASSERT_EQ(4, (int)FileData.size());

	// 1行目のデータの確認
	FileDataIterator = FileData.begin();
	Content = (list<String> *)(*FileDataIterator)->getContent();
	ContentIterator = Content->begin();
	ASSERT_STREQ((*ContentIterator).c_str(), "SLONG");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "ev3_motor_device_close");
	ContentIterator++;
	ASSERT_TRUE(ContentIterator == Content->end());

	// 2行目のデータの確認
	FileDataIterator++;
	Content = (list<String> *)(*FileDataIterator)->getContent();
	ContentIterator = Content->begin();
	ASSERT_STREQ((*ContentIterator).c_str(), "SINT");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "ev3_motor_device_initialize");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "CONST");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "UBYTE");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "chList");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "CONST");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "VOID");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "*opt");
	ContentIterator++;
	ASSERT_TRUE(ContentIterator == Content->end());

	// 3行目のデータの確認
	FileDataIterator++;
	Content = (list<String> *)(*FileDataIterator)->getContent();
	ContentIterator = Content->begin();
	ASSERT_STREQ((*ContentIterator).c_str(), "VOID");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "ev3_motor_device_write");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "CONST");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "UBYTE");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "ch");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "CONST");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "VOID");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "*data");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "CONST");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "SINT");
	ContentIterator++;
	ASSERT_STREQ((*ContentIterator).c_str(), "data_len");
	ContentIterator++;
	ASSERT_TRUE(ContentIterator == Content->end());
}
