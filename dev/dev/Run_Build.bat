@echo off
rem ---------------------------------------------------------------
rem 
rem MSBuildを利用して、指定された構成およびプラットフォームの
rem ビルドを実行する。
rem 
rem 引数1：ビルド対象のソリューションファイル
rem 引数2：構成(Release / Debug)
rem 引数3：プラットフォーム(Any CPU / x86 / x64)
rem ---------------------------------------------------------------
SETLOCAL

rem 引数指定項目
SET TARGET_SOLUTION_PATH=%1
SET TARGET_CONFIG=%2
SET TARGET_PLATFORM=%3

echo %TARGET_SOLUTOIN%
echo %TARGET_CONFIG%
echo %TARGET_PLATFORM%

rem ユーザの環境に合せて設定する項目
SET MS_BUILD_NAME=MSbuild.exe
SET MS_BUILD_DIR="C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin"
SET MS_BUILD_PATH=%MS_BUILD_DIR%\%MS_BUILD_NAME%

rem MSBuildによるビルドの実行
%MS_BUILD_PATH% %TARGET_SOLUTION_PATH% /t:clean;rebuild /p:Configuration=%TARGET_CONFIG%;Platform=%TARGET_PLATFORM%

endlocal