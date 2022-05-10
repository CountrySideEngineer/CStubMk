@echo off
rem ///////////////////////////////////////////////////////////////
rem 
rem すべてのビルド用batファイルを実行し、CStubMkのビルドを実行する。
rem 
rem ///////////////////////////////////////////////////////////////
SETLOCAL

rem ---------------------------------------------------------------
rem 実行するbatファイルの名前一覧
rem ---------------------------------------------------------------
SET READER_BUILD_BAT_NAME=Reader_Build.bat
SET PARSER_BUILD_BAT_NAME=Parser_Build.bat
SET CODE_TEMPLATE_BUILD_BAT_NAME=CodeTemplate_Build.bat
SET CSTUBMK_BUILD_BAT_NAME=CStubMk_Build.bat

rem ---------------------------------------------------------------
rem batファイルのフルパスの生成
rem ---------------------------------------------------------------
SET TARGET_BAT_DIR=.\
SET READER_BUILD_BAT_PATH=%TARGET_BAT_DIR%%READER_BUILD_BAT_NAME%
SET PARSER_BUILD_BAT_PATH=%TARGET_BAT_DIR%%PARSER_BUILD_BAT_NAME%
SET CODE_TEMPLATE_BUILD_BAT_PATH=%TARGET_BAT_DIR%%CODE_TEMPLATE_BUILD_BAT_NAME%
SET CSTUBMK_BUILD_BAT_PATH=%TARGET_BAT_DIR%%CSTUBMK_BUILD_BAT_NAME%

rem ---------------------------------------------------------------
rem batファイルの実行
rem ---------------------------------------------------------------
CALL %READER_BUILD_BAT_PATH%
CALL %PARSER_BUILD_BAT_PATH%
CALL %CODE_TEMPLATE_BUILD_BAT_PATH%
CALL %CSTUBMK_BUILD_BAT_PATH%

endlocal
