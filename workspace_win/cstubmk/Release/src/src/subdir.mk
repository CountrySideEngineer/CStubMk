################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
CPP_SRCS += \
E:/development/C/cstubmk/dev/src/cstubmk.cpp 

OBJS += \
./src/src/cstubmk.o 

CPP_DEPS += \
./src/src/cstubmk.d 


# Each subdirectory must supply rules for building sources it contributes
src/src/cstubmk.o: E:/development/C/cstubmk/dev/src/cstubmk.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\C\cstubmk\dev\src\include" -O3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


