/*
 * CParamInfo.cpp
 *
 *  Created on: 2016/03/13
 *      Author: Kensuke
 */
#include <iostream>
#include "CParamInfo.h"

//  コンストラクタ
CParamInfo::CParamInfo()
    :m_Type(CParamInfo::PARAM_TYPE_FUNC),
     m_Name(""),
     m_DataType(""),
     m_IsPtr(0),
     m_Opt(NULL)
{ this->Init(); }
CParamInfo::CParamInfo(PARAM_TYPE Type, String Name, String DataType, SINT IsPtr)
    :m_Type(Type),
     m_Name(Name),
     m_DataType(DataType),
     m_IsPtr(IsPtr),
     m_Opt(NULL)
{ this->Init(); }

//  デストラクタ
CParamInfo::~CParamInfo() {
    //  オプション情報を保持しているリストを削除
    if (!this->m_Opt->empty()) {
        list<CParamInfo*>::iterator it = this->m_Opt->begin();
        while (it != this->m_Opt->end()) {
            delete (*it);
            it++;
        }
        delete this->m_Opt;
    }
}


VOID CParamInfo::Init() {
    this->m_Opt = new list<CParamInfo*>();
    this->m_Opt->clear();   // 一度、中身をクリアしておく。
}

VOID CParamInfo::AddOpt(CParamInfo *Opt) {
    this->m_Opt->push_back(Opt);
}
