//============================================================================
// Name        : cstubmk.cpp
// Author      : K.Morimoto
// Version     :
// Copyright   : Your copyright notice
// Description : Hello World in C++, Ansi-style
//============================================================================
#include <iostream>
#include <cstdlib>
#include "CFileParser.h"
#include "CFileData.h"
#include "CParamInfo.h"
#include "CFuncExtracter.h"
#include "CArgExtracter.h"
#include "CCSrcCreator.h"
#include "CCHeaderStubCreator.h"
#include "CStubMakerMain.h"
#include "CStubMakerMainOptStub.h"
#include "CStubMakerMainOptIf.h"
#include "CStubMakerMainOptSep.h"
using namespace std;

int main(int argc, char **argv)
{
    int isRun = 1;  // 0:処理は実行しない 0以外：処理を実行する
    /*
     * IFファイルのみ、スタブファイルのみは、同時に選択できないようにする。
     * 両方出力するためには、-sep オプションを指定する。
     * これらのオプションが同時に指定された場合には、最後に指定されたものを
     * 採用する。
     */
    int isIf = 0;   //IFファイルのみ作成のフラグ
    int isStub = 0; //スタブファイルのみ作成のフラグ
    int isSep = 0;  //stub と IF を別々のファイルで主力する。
    int BuffSize = 10;
    String FileName = String("");

    // 引数の確認
    if (argc < 2) {
        cout << String("ファイル名が指定されていません。") << endl;

        return 0;
    }

    argc--;
    argv++;
    while (argc > 0) {
        String Argv = String(*argv);
        if (Argv == String("-v")) {
            isRun = 0;

            cout << String("StubMaker Version ")
                    << CStubMakerMain::GetVersion() << endl;

            break;
        } else if (Argv == String("-f")) {
            argc--;
            argv++;
            if (argc <= 0) {
                cout << String("Invalid number of arguemnts.") << endl;
                cout << String("-f InputFileName.Ext") << endl;

                isRun = 0;
                break;
            }
            FileName = String(*argv);
        } else if (Argv == String("-if")) {
            //IFファイルのみ作成
            isIf = 1;
            isStub = 0;
            isSep = 0;
        } else if (Argv == String("-stub")) {
            //スタブファイルのみ作成
            isIf = 0;
            isStub = 1;
            isSep = 0;
        } else if (Argv == String("-sep")) {
            //IFとスタブを別ファイルに出力する
            isIf = 0;
            isStub = 0;
            isSep = 1;
        } else if ((Argv == String("-s")) || (Argv == String("--size")))  {
            argc--;
            argv++;
            if (argc <= 0) {
                cout << String("Invalid number of arguments.") << endl;
                cout << String("-s SizeOfBuffer") << endl;

                isRun = 0;
                break;
            }
            BuffSize = std::atoi(*argv);
        } else {
            cout << String("Invalid argument has been specified.") << endl;
            cout << Argv << String(" is invalid") << endl;

            isRun = 0;
            break;
        }
        argc--;
        argv++;
    }

    if (0 == isRun) {
        //実行することがない場合
    } else {
        CStubMakerMain* StubMakerMain;
        if (1 == isIf) {
            StubMakerMain = new CStubMakerMainOptIf(FileName);
        } else if (1 == isStub) {
            StubMakerMain = new CStubMakerMainOptStub(FileName);
        } else if (1 == isSep) {
            StubMakerMain = new CStubMakerMainOptSep(FileName);
        } else {
            StubMakerMain = new CStubMakerMain(FileName);
        }
        cout << String("FileName = ") << FileName << endl;
        StubMakerMain->setMacroSize(BuffSize);
        StubMakerMain->RunOperation();
        delete StubMakerMain;
    }

    return 0;
}
