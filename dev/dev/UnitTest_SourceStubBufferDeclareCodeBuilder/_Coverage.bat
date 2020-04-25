@echo off
REM -----------------------------------------------------------
REM Run Coverage of unit test in a project using MSTest.
REM -----------------------------------------------------------
setlocal

REM Set variable to file and directory to calcurate coverage.
set OPEN_COVER=C:\Users\USER_NAME\.nuget\packages\opencover\4.7.922\tools\OpenCover.Console.exe
set VSCOMM_IDE=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\
set MS_TEST=%VSCOMM_IDE%MSTest.exe
set VS_TEST=%VSCOMM_IDE%CommonExtensions\Microsoft\TestWindow\vstest.console.exe
set TEST_TOOL=%VS_TEST%
set NUGET_PACKAGE=C:\Users\KENSUKE\.nuget\packages\
set REPORT_GENERATOR=%NUGET_PACKAGE%reportgenerator\4.5.3\tools\netcoreapp3.0\ReportGenerator.exe

set TARGET_FOLDER=.\bin\Debug\netcoreapp3.0\
set TARGET_DIR=.\
set TARGET_FILE=UnitTest_StubSourceFile.dll
set TARGET_NAME=%TARGET_FOLDER%\%TARGET_FILE%

REM Run OpenCover
"%OPEN_COVER%" -register:user -target:"%TEST_TOOL%" -targetargs:"%TARGET_NAME%" -output:result.xml  -targetdir:"%TARGET_DIR%\" -filter:"*"

REM Run ReportGenerator
"%REPORT_GENERATOR%" -reports:result.xml -targetdir:"%TARGET_DIR%Coverage"

endlocal