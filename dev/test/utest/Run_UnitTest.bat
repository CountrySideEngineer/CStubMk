@echo off
REM すべてのテストソリューション/プロジェクトをビルドして実行する。

SETLOCAL

REM batファイル内で使用するローカル変数のセット
SET MS_BUILD="C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe"
SET VSTEST="C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"

REM ソリューションのrestoreとビルドを実行
for /r %%S in (*.sln) do (
	%MS_BUILD% /restore %%S
	%MS_BUILD% /m %%S /p:Configuration=Debug /p:platform="Any CPU"
)

REM ビルドされたテストの実行
for /r %%D in (*_utest.dll) do (
	%VSTEST% %%D
)

ENDLOCAL 
