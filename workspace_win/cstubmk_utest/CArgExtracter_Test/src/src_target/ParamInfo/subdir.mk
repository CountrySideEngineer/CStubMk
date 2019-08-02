################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
CPP_SRCS += \
E:/development/C/cstubmk/dev/src/ParamInfo/CParamInfo.cpp 

OBJS += \
./src/src_target/ParamInfo/CParamInfo.o 

CPP_DEPS += \
./src/src_target/ParamInfo/CParamInfo.d 


# Each subdirectory must supply rules for building sources it contributes
src/src_target/ParamInfo/CParamInfo.o: E:/development/C/cstubmk/dev/src/ParamInfo/CParamInfo.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\googletest\gtest-1.7.0\include" -I"E:\development\C\cstubmk\dev\src\include" -O0 -g -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


