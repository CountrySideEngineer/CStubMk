/*
 * types.h
 *
 *  Created on: 2016/03/13
 *      Author: Kensuke
 */

#ifndef TYPES_H_
#define TYPES_H_
#include <string>

// 符号付のデータ型
typedef signed char         DATAS8;
typedef signed short        DATAS16;
typedef signed long         DATAS32;
typedef DATAS8              SBYTE;
typedef DATAS16             SWORD;
typedef DATAS32             SDWORD;
typedef signed int          SINT;

// 符号なしのデータ型
typedef unsigned char       DATAU8;
typedef unsigned short      DATAU16;
typedef unsigned long       DATAU32;
typedef DATAU8              UBYTE;
typedef DATAU16             UWORD;
typedef DATAU32             UDWORD;
typedef unsigned int        UINT;

// C++のデータ型
typedef std::string         String;

// その他
typedef void                VOID;

#ifndef CONST_MCR_USE_
#define CONST_MCR_USE_
#define CONST               const
#endif  /* CONST_MCR_USE_ */
#endif /* TYPES_H_ */
