@echo off
rem ---------------------------------------------------------------
rem 
rem MSBuild�𗘗p���āA�w�肳�ꂽ�\������уv���b�g�t�H�[����
rem �r���h�����s����B
rem 
rem ����1�F�r���h�Ώۂ̃\�����[�V�����t�@�C��
rem ����2�F�\��(Release / Debug)
rem ����3�F�v���b�g�t�H�[��(Any CPU / x86 / x64)
rem ---------------------------------------------------------------
SETLOCAL

rem �����w�荀��
SET TARGET_SOLUTION_PATH=%1
SET TARGET_CONFIG=%2
SET TARGET_PLATFORM=%3

echo %TARGET_SOLUTOIN%
echo %TARGET_CONFIG%
echo %TARGET_PLATFORM%

rem ���[�U�̊��ɍ����Đݒ肷�鍀��
SET MS_BUILD_NAME=MSbuild.exe
SET MS_BUILD_DIR="C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin"
SET MS_BUILD_PATH=%MS_BUILD_DIR%\%MS_BUILD_NAME%

rem MSBuild�ɂ��r���h�̎��s
%MS_BUILD_PATH% %TARGET_SOLUTION_PATH% /t:clean;rebuild /p:Configuration=%TARGET_CONFIG%;Platform=%TARGET_PLATFORM%

endlocal