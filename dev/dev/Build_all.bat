@echo off
rem ///////////////////////////////////////////////////////////////
rem 
rem ���ׂẴr���h�pbat�t�@�C�������s���ACStubMk�̃r���h�����s����B
rem 
rem ///////////////////////////////////////////////////////////////
SETLOCAL

rem ---------------------------------------------------------------
rem ���s����bat�t�@�C���̖��O�ꗗ
rem ---------------------------------------------------------------
SET READER_BUILD_BAT_NAME=Reader_Build.bat
SET PARSER_BUILD_BAT_NAME=Parser_Build.bat
SET CODE_TEMPLATE_BUILD_BAT_NAME=CodeTemplate_Build.bat
SET CSTUBMK_BUILD_BAT_NAME=CStubMk_Build.bat

rem ---------------------------------------------------------------
rem bat�t�@�C���̃t���p�X�̐���
rem ---------------------------------------------------------------
SET TARGET_BAT_DIR=.\
SET READER_BUILD_BAT_PATH=%TARGET_BAT_DIR%%READER_BUILD_BAT_NAME%
SET PARSER_BUILD_BAT_PATH=%TARGET_BAT_DIR%%PARSER_BUILD_BAT_NAME%
SET CODE_TEMPLATE_BUILD_BAT_PATH=%TARGET_BAT_DIR%%CODE_TEMPLATE_BUILD_BAT_NAME%
SET CSTUBMK_BUILD_BAT_PATH=%TARGET_BAT_DIR%%CSTUBMK_BUILD_BAT_NAME%

rem ---------------------------------------------------------------
rem bat�t�@�C���̎��s
rem ---------------------------------------------------------------
CALL %READER_BUILD_BAT_PATH%
CALL %PARSER_BUILD_BAT_PATH%
CALL %CODE_TEMPLATE_BUILD_BAT_PATH%
CALL %CSTUBMK_BUILD_BAT_PATH%

endlocal
