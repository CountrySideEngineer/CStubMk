################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
CPP_SRCS += \
E:/development/C/CStubMk/dev/src/FileData/CFileData.cpp \
E:/development/C/CStubMk/dev/src/FileData/CFileParser.cpp \
E:/development/C/CStubMk/dev/src/FileData/IParser.cpp 

OBJS += \
./src/src/FileData/CFileData.o \
./src/src/FileData/CFileParser.o \
./src/src/FileData/IParser.o 

CPP_DEPS += \
./src/src/FileData/CFileData.d \
./src/src/FileData/CFileParser.d \
./src/src/FileData/IParser.d 


# Each subdirectory must supply rules for building sources it contributes
src/src/FileData/CFileData.o: E:/development/C/CStubMk/dev/src/FileData/CFileData.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\C\CStubMk\dev\src\include" -O3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '

src/src/FileData/CFileParser.o: E:/development/C/CStubMk/dev/src/FileData/CFileParser.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\C\CStubMk\dev\src\include" -O3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '

src/src/FileData/IParser.o: E:/development/C/CStubMk/dev/src/FileData/IParser.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\C\CStubMk\dev\src\include" -O3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


