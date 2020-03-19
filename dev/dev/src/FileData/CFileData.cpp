/*
 * CFileData.cpp
 *
 *  Created on: 2016/03/20
 *      Author: Kensuke
 */

#include <iostream>
#include <string>
#include <list>
#include "types.h"
#include "CFileData.h"

using namespace std;

CFileData::CFileData() {
    this->m_Content = new list<String>;
    this->m_Content->clear();
}
CFileData::CFileData(SINT ListSize) {
    this->m_Content = new list<String>;
    this->m_Content->resize(ListSize);
    this->m_Content->clear();
}
CFileData::~CFileData() {}
VOID CFileData::addItem(String Item) { m_Content->push_back(Item); }
