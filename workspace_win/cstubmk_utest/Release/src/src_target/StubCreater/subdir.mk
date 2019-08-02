################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
CPP_SRCS += \
E:/development/C/cstubmk/dev/src/StubCreater/AStubCreater.cpp \
E:/development/C/cstubmk/dev/src/StubCreater/CCHeaderStubCreater.cpp \
E:/development/C/cstubmk/dev/src/StubCreater/CCSrcStubCreater.cpp 

OBJS += \
./src/src_target/StubCreater/AStubCreater.o \
./src/src_target/StubCreater/CCHeaderStubCreater.o \
./src/src_target/StubCreater/CCSrcStubCreater.o 

CPP_DEPS += \
./src/src_target/StubCreater/AStubCreater.d \
./src/src_target/StubCreater/CCHeaderStubCreater.d \
./src/src_target/StubCreater/CCSrcStubCreater.d 


# Each subdirectory must supply rules for building sources it contributes
src/src_target/StubCreater/AStubCreater.o: E:/development/C/cstubmk/dev/src/StubCreater/AStubCreater.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -O3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '

src/src_target/StubCreater/CCHeaderStubCreater.o: E:/development/C/cstubmk/dev/src/StubCreater/CCHeaderStubCreater.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -O3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '

src/src_target/StubCreater/CCSrcStubCreater.o: E:/development/C/cstubmk/dev/src/StubCreater/CCSrcStubCreater.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -O3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


