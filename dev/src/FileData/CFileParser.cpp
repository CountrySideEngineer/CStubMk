/*
 * CFileParser.cpp
 *
 *  Created on: 2016/03/23
 *      Author: Kensuke
 */
#include <iostream>
#include <fstream>
#include "CFileParser.h"
#include "CFileData.h"

CFileParser::CFileParser() {}
CFileParser::~CFileParser() {}

list<CFileData *>* CFileParser::Parse(String FileName,
        list<CFileData *>* FileData)
{
    vector<String> LineData;
    vector<String> LineContent;
    vector<String>::iterator LineDataIterator;
    vector<String>::iterator LineContentIterator;
    CFileData *FileDataItem;

    // 引数確認
    if (FileName.empty()) { throw length_error("FileName"); }
    if (NULL == FileData) { throw invalid_argument("FileData"); }

    // ファイル内の行を読み出す。
    cout << String("Read lines from ") << FileName << endl;
    this->GetFileData(FileName, &LineData);
    // 各行のデータを分割する。
    LineDataIterator = LineData.begin();
    while (LineData.end() !=  LineDataIterator) {
        this->SplitLineData(*LineDataIterator, &LineContent);
        LineContentIterator = LineContent.begin();
        FileDataItem = new CFileData();
        while (LineContent.end() != LineContentIterator) {
            FileDataItem->addItem(*LineContentIterator);
            LineContentIterator++;
        }
        FileData->push_back(FileDataItem);
        LineDataIterator++;
    }

    return FileData;
}

VOID CFileParser::GetFileData(String FileName, vector<String> *LineData)
{
    String ReadLine;

    if (NULL == LineData) throw invalid_argument("LineData");

    //読み出し前に、一度全てのデータをクリアする。
    LineData->clear();

    ifstream ifs(FileName.c_str());
    while (getline(ifs, ReadLine)) { LineData->push_back(ReadLine); }
    ifs.close();
}

VOID CFileParser::SplitLineData(String LineData, vector<String> *LineContent)
{
    if (0 >= LineData.size()) { throw length_error("LineData"); }
    if (NULL == LineContent) { throw invalid_argument("LineContent"); }

    // パース実行前に、リストの内容を空にする。
    LineContent->clear();

    string::iterator LineDataIterator = LineData.begin();
    while (LineData.end() != LineDataIterator) {
        string::iterator LastIt = LineDataIterator;
        while ((LineData.end() != LastIt) && (' ' != *LastIt)
                && ('(' != *LastIt) && (')' != *LastIt)
                && (',' != *LastIt) && (';' != *LastIt))
        {
            LastIt++;   //  区切り文字列が見つかるまで、文字を進める。
        }
        // 区切り文字を見つけたら、そこまでの文字列を抜き出す。
        String LineItem = String(LineDataIterator, LastIt);
        if (!LineItem.empty()) {
            // 空文字確認 -> 値がセットされていた場合には、追加
            LineContent->push_back(String(LineDataIterator, LastIt));
        }
        if (LineData.end() != LastIt) {
            LastIt++;   // 区切り文字をスキップする。
        }
        LineDataIterator = LastIt;  // 検索開始位置の更新
    }
}
