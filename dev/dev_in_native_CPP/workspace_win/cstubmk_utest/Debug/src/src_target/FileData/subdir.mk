################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
CPP_SRCS += \
E:/development/C/CStubMk/dev/src/FileData/CFileData.cpp \
E:/development/C/CStubMk/dev/src/FileData/CFileParser.cpp \
E:/development/C/CStubMk/dev/src/FileData/IParser.cpp 

OBJS += \
./src/src_target/FileData/CFileData.o \
./src/src_target/FileData/CFileParser.o \
./src/src_target/FileData/IParser.o 

CPP_DEPS += \
./src/src_target/FileData/CFileData.d \
./src/src_target/FileData/CFileParser.d \
./src/src_target/FileData/IParser.d 


# Each subdirectory must supply rules for building sources it contributes
src/src_target/FileData/CFileData.o: E:/development/C/CStubMk/dev/src/FileData/CFileData.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\googletest\gtest-1.7.0\include" -I"E:\development\C\CStubMk\dev\src\include" -O0 -g -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '

src/src_target/FileData/CFileParser.o: E:/development/C/CStubMk/dev/src/FileData/CFileParser.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\googletest\gtest-1.7.0\include" -I"E:\development\C\CStubMk\dev\src\include" -O0 -g -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '

src/src_target/FileData/IParser.o: E:/development/C/CStubMk/dev/src/FileData/IParser.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\googletest\gtest-1.7.0\include" -I"E:\development\C\CStubMk\dev\src\include" -O0 -g -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


