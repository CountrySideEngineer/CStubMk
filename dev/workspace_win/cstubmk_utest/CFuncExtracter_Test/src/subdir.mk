################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
CPP_SRCS += \
../src/CGTestTarget.cpp \
../src/TestCode.cpp \
../src/cstubmk_utest.cpp 

OBJS += \
./src/CGTestTarget.o \
./src/TestCode.o \
./src/cstubmk_utest.o 

CPP_DEPS += \
./src/CGTestTarget.d \
./src/TestCode.d \
./src/cstubmk_utest.d 


# Each subdirectory must supply rules for building sources it contributes
src/%.o: ../src/%.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\googletest\gtest-1.7.0\include" -I"E:\development\C\cstubmk\dev\src\include" -O0 -g -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


