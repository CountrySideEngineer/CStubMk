/*
 * IExtracter.h
 *
 *  Created on: 2016/03/13
 *      Author: Kensuke
 */
#ifndef IEXTRACTER_H_
#define AEXTRACTER_H_
#include <iostream>
#include <string>
#include <list>
#include "types.h"
#include "CParamInfo.h"
using namespace std;

// 抽象クラス
class AExtracter {
public:
    AExtracter();
    virtual ~AExtracter() {};
    virtual std::list<String>::iterator Extract(list<String>& src, CParamInfo *dst) = 0;
    virtual SINT IsModifier(String *modifier);
    virtual SINT HasAsterisk(String data);
    virtual SINT IsArg(String Argument, SINT IsPtr);

protected:
    // データの処理状態
    enum {
        ARG_EXTRACTER_EXTRACT_DATA_TYPE = 0, // 型の抜き出し中
        ARG_EXTRACTER_EXTRACT_DATA_NAME      // 名前(変数/関数)抜き出し中
    };
    virtual SINT IsModifier(String modifier);
    VOID AddTypeString(String src, String *dst) {
        /**
         *  修飾子 + 型を示す文字列を結合する。
         *  すでに修飾子を取得・結合済みの場合には、空白スペースを追加
         *  してから、文字列の結合を実施する。
         */
        if (0 != dst->length()) { *dst += " "; }
        *dst += src;
    };
    SINT m_State;


private:
    static CONST String MODIFIER_CONST; // 関数/引数共通の修飾子
};

#endif /* IEXTRACTER_H_ */
