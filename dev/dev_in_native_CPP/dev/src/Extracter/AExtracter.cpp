/*
 * IExtracter.cpp
 *
 *  Created on: 2016/03/13
 *      Author: Kensuke
 */
#include <iostream>
#include <string>
#include <algorithm>
#include <cstring>
#include <list>
#include "AExtracter.h"
using namespace std;

CONST String AExtracter::MODIFIER_CONST = "const";

AExtracter::AExtracter() : m_State(0) {}

SINT AExtracter::IsModifier(String *Modifier)
{
    /*
     * 大文字/小文字を無視して比較するために、文字列を小文字に変換する。
     * 確認対象の文字列を変更しないために、文字列のコピーを作成し、小文字に
     * 変換する。
     */
    String ModifierCopy = String(*Modifier);
    transform(ModifierCopy.begin(), ModifierCopy.end(), ModifierCopy.begin(),
            ::tolower);
    SINT ret = this->IsModifier(ModifierCopy);

    return (ret);
}


SINT AExtracter::IsModifier(String Modifier)
{
    SINT ret = (Modifier == AExtracter::MODIFIER_CONST);

    return (ret);
}

SINT AExtracter::HasAsterisk(String Data) {
    if (0 == Data.size()) { throw invalid_argument("data"); }

    SINT HasAster = 0;
    DATAS8 frontChar = Data[0];
    DATAS8 tailChar = Data[Data.size() - 1];

    if (('*' == frontChar) || ('*' == tailChar)) {
        HasAster = 1;
    } else {
        HasAster = 0;
    }

    return (HasAster);
}

SINT AExtracter::IsArg(String DataType, SINT IsPtr)
{
    SINT IsArgument = 0;

    //引数名を小文字に変更
    transform(DataType.begin(), DataType.end(), DataType.begin(), ::toupper);
    if (DataType == String("VOID") && 0 == IsPtr) {
        //VOID型かつポインタ型ではない場合には、引数ではないと判断
        IsArgument = 0;
    } else {
        IsArgument = 1;
    }

    return (IsArgument);
}
