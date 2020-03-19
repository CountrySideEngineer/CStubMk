################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
CPP_SRCS += \
E:/development/C/cstubmk/dev/src/FuncDef/CParamInfo.cpp 

OBJS += \
./src/src/FuncDef/CParamInfo.o 

CPP_DEPS += \
./src/src/FuncDef/CParamInfo.d 


# Each subdirectory must supply rules for building sources it contributes
src/src/FuncDef/CParamInfo.o: E:/development/C/cstubmk/dev/src/FuncDef/CParamInfo.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\C\cstubmk\dev\src\include" -O3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


