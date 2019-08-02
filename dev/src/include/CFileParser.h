/*
 * CFileParser.h
 *
 *  Created on: 2016/03/23
 *      Author: Kensuke
 */

#ifndef CFILEPARSER_H_
#define CFILEPARSER_H_
#include <iostream>
#include <string>
#include <list>
#include <vector>
#include "IParser.h"
using namespace std;

class CFileParser: public IParser {
public:
    CFileParser();
    virtual ~CFileParser();

    virtual list<CFileData *>* Parse(String FileName, list<CFileData *>* FileData);

protected:
    virtual VOID GetFileData(String FileName, vector<String> *LineData);
    virtual VOID SplitLineData(String LineData, vector<String> *LineContent);
};

#endif /* CFILEPARSER_H_ */
