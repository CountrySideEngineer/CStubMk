/*
 * CCSrcCreator.cpp
 *
 *  Created on: 2016/05/30
 *      Author: Kensuke
 */
#include <iostream>
#include <sstream>
#include <string>
#include <algorithm>
#include "CCSrcStubCreator.h"
using namespace std;

CCSrcStubCreator::CCSrcStubCreator() { setFileExtention(String("_stub.c")); }
CCSrcStubCreator::~CCSrcStubCreator() {}
