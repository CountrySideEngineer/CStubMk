@echo off
REM ���ׂẴe�X�g�\�����[�V����/�v���W�F�N�g���r���h���Ď��s����B

SETLOCAL

REM bat�t�@�C�����Ŏg�p���郍�[�J���ϐ��̃Z�b�g
SET MS_BUILD="C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe"
SET VSTEST="C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"

REM �\�����[�V������restore�ƃr���h�����s
for /r %%S in (*.sln) do (
	%MS_BUILD% /restore %%S
	%MS_BUILD% /m %%S /p:Configuration=Debug /p:platform="Any CPU"
)

REM �r���h���ꂽ�e�X�g�̎��s
for /r %%D in (*_utest.dll) do (
	%VSTEST% %%D
)

ENDLOCAL 
