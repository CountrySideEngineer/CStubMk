################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
CPP_SRCS += \
E:/development/C/cstubmk/test/src/StubCreater/CCSrcStubCreater_Test.cpp 

OBJS += \
./src/src/StubCreater/CCSrcStubCreater_Test.o 

CPP_DEPS += \
./src/src/StubCreater/CCSrcStubCreater_Test.d 


# Each subdirectory must supply rules for building sources it contributes
src/src/StubCreater/CCSrcStubCreater_Test.o: E:/development/C/cstubmk/test/src/StubCreater/CCSrcStubCreater_Test.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -O3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


