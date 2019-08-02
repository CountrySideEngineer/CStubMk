/*
 * IParser.h
 *
 *  Created on: 2016/03/20
 *      Author: Kensuke
 */

#ifndef IPARSER_H_
#define IPARSER_H_
#include <iostream>
#include <list>
#include <string>
#include "types.h"
#include "CFileData.h"

using namespace std;

class IParser {
public:
    IParser() {};
    virtual ~IParser() {};

    virtual list<CFileData *>* Parse(String FileName, list<CFileData *>* FileData) = 0;
};

#endif /* IPARSER_H_ */
