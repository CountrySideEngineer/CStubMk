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
./src/src/CStubMakerMain/CStubMakerMain.o \
./src/src/CStubMakerMain/CStubMakerMainOptIf.o \
./src/src/CStubMakerMain/CStubMakerMainOptSep.o \
./src/src/CStubMakerMain/CStubMakerMainOptStub.o 

CPP_DEPS += \
./src/src/CStubMakerMain/CStubMakerMain.d \
./src/src/CStubMakerMain/CStubMakerMainOptIf.d \
./src/src/CStubMakerMain/CStubMakerMainOptSep.d \
./src/src/CStubMakerMain/CStubMakerMainOptStub.d 


# Each subdirectory must supply rules for building sources it contributes
src/src/CStubMakerMain/CStubMakerMain.o: E:/development/C/CStubMk/dev/src/CStubMakerMain/CStubMakerMain.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\C\CStubMk\dev\src\include" -O3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '

src/src/CStubMakerMain/CStubMakerMainOptIf.o: E:/development/C/CStubMk/dev/src/CStubMakerMain/CStubMakerMainOptIf.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\C\CStubMk\dev\src\include" -O3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '

src/src/CStubMakerMain/CStubMakerMainOptSep.o: E:/development/C/CStubMk/dev/src/CStubMakerMain/CStubMakerMainOptSep.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\C\CStubMk\dev\src\include" -O3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '

src/src/CStubMakerMain/CStubMakerMainOptStub.o: E:/development/C/CStubMk/dev/src/CStubMakerMain/CStubMakerMainOptStub.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cygwin C++ Compiler'
	g++ -I"E:\development\C\CStubMk\dev\src\include" -O3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


