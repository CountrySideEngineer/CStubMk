/*
 * CFileData.h
 *
 *  Created on: 2016/03/20
 *      Author: Kensuke
 */

#ifndef CFILEDATA_H_
#define CFILEDATA_H_
#include <iostream>
#include <string>
#include <list>
#include "types.h"

using namespace std;

class CFileData {
public:
    CFileData();
    CFileData(SINT ListSize);
    virtual ~CFileData();

    virtual VOID addItem(String Item);
    const list<String>* getContent() const { return m_Content; };

protected:
    list<String>* m_Content;

private:

};
#endif /* CFILEDATA_H_ */
