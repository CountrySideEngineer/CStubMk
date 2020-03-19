################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
CPP_SRCS += \
E:/development/C/CStubMk/dev/src/CStubMakerMain/CStubMakerMain.cpp \
E:/development/C/CStubMk/dev/src/CStubMakerMain/CStubMakerMainOptIf.cpp \
E:/development/C/CStubMk/dev/src/CStubMakerMain/CStubMakerMainOptSep.cpp \
E:/development/C/CStubMk/dev/src/CStubMakerMain/CStubMakerMainOptStub.cpp 

OBJS += \
./src/src_target/CStubMakerMain/CStubMakerMain.o \
./src/src_target/CStubMakerMain/CStubMakerMainOptIf.o \
./src/src_target/CStubMakerMain/CStubMakerMainOptSep.o \
./src/src_target/CStubMakerMain/CStubMakerMainOptStub.o 

CPP_DEPS += \
./src/src_target/CStubMakerMain/CStubMakerMain.d \
./src/src_target/CStubMakerMain/CStubMakerMainOptIf.d \
./src/src_target/CStubMakerMain/CStubMakerMainOptSep.d \
./src/src_target/CStubMakerMain/CStubMakerMainOptStub.d 


# Each subdirectory must supply rules for building sources it contributes
src/src_target/CStubMakerMain/CStubMakerMain.o: E:/development/C/CStubMk/dev/src/CStubMakerMain/CStubMakerMain.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\googletest\gtest-1.7.0\include" -I"E:\development\C\CStubMk\dev\src\include" -O0 -g -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '

src/src_target/CStubMakerMain/CStubMakerMainOptIf.o: E:/development/C/CStubMk/dev/src/CStubMakerMain/CStubMakerMainOptIf.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\googletest\gtest-1.7.0\include" -I"E:\development\C\CStubMk\dev\src\include" -O0 -g -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '

src/src_target/CStubMakerMain/CStubMakerMainOptSep.o: E:/development/C/CStubMk/dev/src/CStubMakerMain/CStubMakerMainOptSep.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\googletest\gtest-1.7.0\include" -I"E:\development\C\CStubMk\dev\src\include" -O0 -g -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '

src/src_target/CStubMakerMain/CStubMakerMainOptStub.o: E:/development/C/CStubMk/dev/src/CStubMakerMain/CStubMakerMainOptStub.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\googletest\gtest-1.7.0\include" -I"E:\development\C\CStubMk\dev\src\include" -O0 -g -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


