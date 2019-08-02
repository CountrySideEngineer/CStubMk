################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
CPP_SRCS += \
E:/development/C/CStubMk/test/src/StubCreater/CCSrcStubCreater_Test.cpp 

OBJS += \
./src/src/StubCreater/CCSrcStubCreater_Test.o 

CPP_DEPS += \
./src/src/StubCreater/CCSrcStubCreater_Test.d 


# Each subdirectory must supply rules for building sources it contributes
src/src/StubCreater/CCSrcStubCreater_Test.o: E:/development/C/CStubMk/test/src/StubCreater/CCSrcStubCreater_Test.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\googletest\gtest-1.7.0\include" -I"E:\development\C\CStubMk\dev\src\include" -O0 -g -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


