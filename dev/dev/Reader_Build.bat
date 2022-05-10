@echo off
rem ///////////////////////////////////////////////////////////////
rem 
rem MSBuildを利用して、CStubMkに必要なDLLなどを一括で
rem ビルド(リビルド)する。
rem 
rem ///////////////////////////////////////////////////////////////
SETLOCAL

rem ビルド対象のソリューションファイルの情報
SET TARGET_SOLUTION_FILE_NAME=Reader.sln
SET TARGET_SOLUTION_DIR=.\

rem ビルド対象設定 - DEBUG/RELEASE
SET BUILD_CONFIG=release

rem ビルド対象プラットフォーム
rem Any CPU / x86 / x64
SET BUILD_PLATFORM="Any CPU"

rem ---------------------------------------------------------------
rem 引数として渡す変数を生成する。
rem ---------------------------------------------------------------
SET SOLUTION_PATH=%TARGET_SOLUTION_DIR%%TARGET_SOLUTION_FILE_NAME%

rem ---------------------------------------------------------------
rem ビルドの実行
rem ---------------------------------------------------------------
SET RUN_BUILD_BAT_PATH=.\Run_Build.bat
CALL %RUN_BUILD_BAT_PATH% %SOLUTION_PATH% %BUILD_CONFIG% %BUILD_PLATFORM%

endlocal
