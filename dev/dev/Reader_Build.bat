@echo off
rem ///////////////////////////////////////////////////////////////
rem 
rem MSBuild�𗘗p���āACStubMk�ɕK�v��DLL�Ȃǂ��ꊇ��
rem �r���h(���r���h)����B
rem 
rem ///////////////////////////////////////////////////////////////
SETLOCAL

rem �r���h�Ώۂ̃\�����[�V�����t�@�C���̏��
SET TARGET_SOLUTION_FILE_NAME=Reader.sln
SET TARGET_SOLUTION_DIR=.\

rem �r���h�Ώېݒ� - DEBUG/RELEASE
SET BUILD_CONFIG=release

rem �r���h�Ώۃv���b�g�t�H�[��
rem Any CPU / x86 / x64
SET BUILD_PLATFORM="Any CPU"

rem ---------------------------------------------------------------
rem �����Ƃ��ēn���ϐ��𐶐�����B
rem ---------------------------------------------------------------
SET SOLUTION_PATH=%TARGET_SOLUTION_DIR%%TARGET_SOLUTION_FILE_NAME%

rem ---------------------------------------------------------------
rem �r���h�̎��s
rem ---------------------------------------------------------------
SET RUN_BUILD_BAT_PATH=.\Run_Build.bat
CALL %RUN_BUILD_BAT_PATH% %SOLUTION_PATH% %BUILD_CONFIG% %BUILD_PLATFORM%

endlocal
