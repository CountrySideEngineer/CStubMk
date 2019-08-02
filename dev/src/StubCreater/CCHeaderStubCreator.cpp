/*
 * CCHeaderStubCreator.cpp
 *
 *  Created on: 2016/05/30
 *      Author: Kensuke
 */
#include <iostream>
#include <sstream>
#include <string>
#include <algorithm>
#include "CCHeaderStubCreator.h"

CCHeaderStubCreator::CCHeaderStubCreator()
{
    setFileExtention(String("_stub.h"));
}
CCHeaderStubCreator::~CCHeaderStubCreator() {}

String CCHeaderStubCreator::CreateHeaderMacro(String FileName)
{
    String HeaderDefineMacro;
    HeaderDefineMacro = FileName + "_stub_h_";

    //  文字を全て大文字にする。
    transform(HeaderDefineMacro.begin(),
            HeaderDefineMacro.end(),
            HeaderDefineMacro.begin(),
            ::toupper);

    return HeaderDefineMacro;
}

