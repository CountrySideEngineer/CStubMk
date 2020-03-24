using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CStubMKGui.Model
{
    public class StubDirectorForCStyle
    {
        protected static readonly String ChangeLineCode = "\r\n";
        protected static readonly String StubHeaderPrefix = "/*----";
        protected static readonly String StubHeaderPostfix = "----*/";
        protected static readonly String BuffInitValuePrimitive = "0";
        protected static readonly String BuffInitValuePointer = "null";
        protected static readonly String BuffInitIdVariableName = "id";
        protected static readonly String BuffSizeMacroName = "STUB_BUFF_SIZE";
        protected static readonly String BuffSizeNum = "100";

        #region Constructors and the finalizer
        /// <summary>
        /// Default constructor.
        /// </summary>
        public StubDirectorForCStyle()
        {
            this.Parameter = null;
        }

        /// <summary>
        /// Constructor with Param object to be used.
        /// </summary>
        /// <param name="param">Parameters of stub function.</param>
        public StubDirectorForCStyle(Param param)
        {
            this.Parameter = param;
        }
        #endregion

        #region Public properties
        public Param Parameter { get; set; }
        #endregion

        #region Other methods and private properties in calling order
        public String GetDefinePart()
        {
            String definePart = String.Format("#define {0}\t\t\t\t({1})", BuffSizeMacroName, BuffSizeNum);
            return this.GetCodeLine(definePart);
        }


        /// <summary>
        /// Create method brief description part of stub method.
        /// </summary>
        /// <returns>Stub method brief description.</returns>
        public String GetMethodHeader()
        {
            String stubHeaderContent = $"Start {this.Parameter.Name} stub";
            int funcHeaderLineLen = stubHeaderContent.Length + StubHeaderPrefix.Length + StubHeaderPostfix.Length;
            String stubHeader = StubHeaderPrefix;
            for (int whiteSpaceIndex = 0; whiteSpaceIndex < stubHeaderContent.Length; whiteSpaceIndex++)
            {
                stubHeader += "-";
            }
            stubHeader += (StubHeaderPostfix + ChangeLineCode);
            stubHeader += StubHeaderPrefix;
            for (int whiteSpaceIndex = 0; whiteSpaceIndex < stubHeaderContent.Length; whiteSpaceIndex++)
            {
                stubHeader += " ";
            }
            stubHeader += (StubHeaderPostfix + ChangeLineCode);
            stubHeader += StubHeaderPrefix;
            stubHeader += stubHeaderContent;
            stubHeader += (StubHeaderPostfix + ChangeLineCode);
            stubHeader += StubHeaderPrefix;
            for (int whiteSpaceIndex = 0; whiteSpaceIndex < stubHeaderContent.Length; whiteSpaceIndex++)
            {
                stubHeader += " ";
            }
            stubHeader += (StubHeaderPostfix + ChangeLineCode);
            stubHeader += StubHeaderPrefix;
            for (int whiteSpaceIndex = 0; whiteSpaceIndex < stubHeaderContent.Length; whiteSpaceIndex++)
            {
                stubHeader += "-";
            }
            stubHeader += StubHeaderPostfix;

            return stubHeader;
        }

        /// <summary>
        /// Create code to declare buffer used to latch arguments.
        /// </summary>
        /// <returns>Code to declare buffer used to latch arguments.</returns>
        public String GetStubBufferDeclare()
        {
            String stubBufferDeclare = "";
            stubBufferDeclare += this.GetCodeLine($"int {this.GetMethodCalledCounterName()};");
            foreach (var arg in this.Parameter.Parameters)
            {
                String buffDeclare = this.GetStubBufferDeclare(arg);
                stubBufferDeclare += this.GetCodeLine(buffDeclare);
            }
            return stubBufferDeclare;
        }

        /// <summary>
        /// Create code to declare buffer used to latch argument.
        /// </summary>
        /// <param name="arg">Argument of method.</param>
        /// <returns>Code to declare buffer used to latch argument.</returns>
        public String GetStubBufferDeclare(Param arg)
        {
            String stubBufferDeclare = $"{this.GetDataType(arg)} {this.GetArgBuffName(arg)}[{BuffSizeMacroName}]";
            return stubBufferDeclare;
        }

        /// <summary>
        /// Create code for extern declarations of buffur variabels..
        /// </summary>
        /// <returns>Code for extern declarations of buffur.</returns>
        public String GetStubBufferExternDeclare()
        {
            String stubBufferExtern = "";
            stubBufferExtern += this.GetCodeLine($"extern int {this.GetMethodCalledCounterName()};");
            foreach (var arg in this.Parameter.Parameters)
            {
                String buffExtern = this.GetBufferExternDeclare(arg);
                stubBufferExtern += this.GetCodeLine(buffExtern);
            }
            return stubBufferExtern;
        }

        /// <summary>
        /// Create code of extern declaration.
        /// </summary>
        /// <param name="arg">Argument of method.</param>
        /// <returns>Code of extern declaration.</returns>
        public String GetBufferExternDeclare(Param arg)
        {
            String stubBufferExtern = $"extern {this.GetDataType(arg)} {this.GetArgBuffName(arg)}";
            return stubBufferExtern;
        }

        /// <summary>
        /// Create code to declare variable for the count the stub is called.
        /// </summary>
        /// <returns>Code to declare variable for called count.</returns>
        public String GetCalledCountDeclare()
        {
            return $"int {this.GetMethodCalledCounterName()}";
        }

        /// <summary>
        /// Create stub method body.
        /// </summary>
        /// <returns>Stub body.</returns>
        public String GetStubMethod()
        {
            String stubMethod = "";
            stubMethod = this.GetCodeLine(this.GetMethodDef() + "(");
            stubMethod += this.GetCodeLine(this.GetArgDef());
            stubMethod += this.GetCodeLine(")");
            stubMethod += this.GetCodeLine("{");
            stubMethod += this.GetReturnLatchPart();
            stubMethod += this.GetArgLatchPart();
            stubMethod += this.GetCodeLine(this.GetMethodCalledCounterName() + "++;", 1);
            stubMethod += this.GetReturnPart();
            stubMethod += this.GetCodeLine("}");

            return stubMethod;
        }


        /// <summary>
        /// Create code of line.
        /// </summary>
        /// <param name="code">Code of line</param>
        /// <param name="indentLevel">Indent depth, level, of the code.</param>
        /// <returns>Code of line.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:メンバーを static に設定します", Justification = "<保留中>")]
        public String GetCodeLine(String code, int indentLevel = 0)
        {
            String codeLine = "";
            for (int indentIndex = 0; indentIndex < indentLevel; indentIndex++)
            {
                codeLine += "\t";
            }
            codeLine += code;
            codeLine += ChangeLineCode;

            return codeLine;
        }

        /// <summary>
        /// Create method to initialize buffer to latch argumet and counter.
        /// </summary>
        /// <returns>Code of method to initialize stub.</returns>
        public String GetStubInitMethod()
        {
            String initMethod = "";
            initMethod = this.GetCodeLine(this.GetArgInitEntryPoint());
            initMethod += this.GetCodeLine("{");
            initMethod += this.GetCodeLine($"int {BuffInitIdVariableName} = 0;", 1);
            initMethod += this.GetCodeLine("");
            initMethod += this.GetCodeLine(
                @$"for ({BuffInitIdVariableName} = 0; {BuffInitIdVariableName} < {BuffSizeMacroName}; {BuffInitIdVariableName}++) {{");
            initMethod += this.GetArgInitPart();
            initMethod += this.GetRetValInitPart();
            initMethod += this.GetCodeLine("}", 1);
            initMethod += this.GetCodeLine($"{this.GetMethodCalledCounterName()} = 0;");
            initMethod += this.GetCodeLine("}");

            return initMethod;
        }

        /// <summary>
        /// Create method definition part.
        /// </summary>
        /// <returns>String to define function.</returns>
        /// <remarks>
        /// The definition is in format below
        /// (Prefix) DataType(NumOfPointer) (Postfix)FunctionName
        /// </remarks>
        public String GetMethodDef()
        {
            Debug.Assert(null != Parameter);

            return this.CommonFormat(this.Parameter);
        }

        /// <summary>
        /// Create argument definition part for function, method.
        /// </summary>
        /// <returns>String of argument definition part</returns>
        public String GetArgDef()
        {
            String argDef = "";
            int paramIndex = 0;
            foreach (var param in this.Parameter.Parameters)
            {
                if (0 < paramIndex)
                {
                    argDef += "," + StubDirectorForCStyle.ChangeLineCode;
                }
                argDef += "\t";
                argDef += this.CommonFormat(param);

                paramIndex++;
            }
            return argDef;
        }

        /// <summary>
        /// Create code to latch argument value of stub.
        /// </summary>
        /// <returns>Code to latch argument value.</returns>
        public String GetArgLatchPart()
        {
            String argLatchPart = "";
            foreach (var arg in this.Parameter.Parameters)
            {
                String latchPart = this.GetArgLatchPart(arg);
                argLatchPart += this.GetCodeLine(latchPart, 1);
            }
            return argLatchPart;
        }

        /// <summary>
        /// Create code to latch argument into buffer.
        /// </summary>
        /// <param name="argument">Argument information to latch.</param>
        /// <returns>Code to latch argument into buffer.</returns>
        /// <remarks>
        /// The code is in format below:
        /// {FunctinName}_{ArgumentName}[{MethodName}_called_count] = {ArgumentName};
        /// </remarks>
        public String GetArgLatchPart(Param argument)
        {
            if (null == argument)
            {
                throw new ArgumentNullException(nameof(argument));
            }
            else
            {
                String latchPart = $"{this.GetArgBuffName(argument)}[{this.GetMethodCalledCounterName()}] = {argument.Name};";
                return latchPart;
            }
        }

        /// <summary>
        /// Create code of entry point to initialize stub buffer.
        /// </summary>
        /// <returns>Code of entry point to initialize buffer.</returns>
        public String GetArgInitEntryPoint()
        {
            Debug.Assert(null != this.Parameter);

            return $"void {this.Parameter.Name}_init()";
        }

        /// <summary>
        /// Create code of extern declaration of function to initialize buffer for stub.
        /// </summary>
        /// <returns>Code of extern declaration of intialize function.</returns>
        public String GetStubInitMethodExtern()
        {
            return $"extern {this.GetArgInitEntryPoint()};";
        }

        /// <summary>
        /// Create code of method body to initialize buffer.
        /// </summary>
        /// <returns>Code of method body to initialize buffer.</returns>
        public String GetArgInitPart()
        {
            String argInitPart = "";
            foreach (var arg in this.Parameter.Parameters)
            {
                String initPart = this.GetArgInitPart(arg);
                argInitPart += this.GetCodeLine(initPart, 2);
            }
            return argInitPart;
        }

        /// <summary>
        /// Create part of method to initialize buffer.
        /// </summary>
        /// <param name="argument">Parameter about argument of stub.</param>
        /// <returns>Part of code to initialize buffer.</returns>
        public String GetArgInitPart(Param argument)
        {
            if (null == argument)
            {
                throw new ArgumentNullException(nameof(argument));
            }
            else
            {
                String initValue = "";
                if (0 < argument.PointerNum)
                {
                    initValue = BuffInitValuePointer;
                }
                else
                {
                    initValue = BuffInitValuePrimitive;
                }
                return $"{this.GetArgBuffName(argument)}[{BuffInitIdVariableName}] = {initValue};";
            }
        }

        /// <summary>
        /// Create code to initialize buffer which stores the return value the stub returns.
        /// </summary>
        /// <returns>Code to initialize return value buffer.</returns>
        protected String GetRetValInitPart()
        {
            String retValInitPart = "";
            if (this.HasReturnValue())
            {
                String retValInit = $"{this.GetRetValBuffName()}[{BuffInitIdVariableName}] = 0;";
                retValInitPart = this.GetCodeLine(retValInit, 2);
            }
            return retValInitPart;
        }

        /// <summary>
        /// Create code to latch return value.
        /// </summary>
        /// <returns>Code to latch return value.</returns>
        /// <remarks>
        /// The code is in format below:
        /// {DataTypeOfFunction} retval = {FunctionName}_ret_val[{FunctionName}_called_count];
        /// </remarks>
        public String GetReturnLatchPart()
        {
            String returnLatchPart = "";
            if (this.HasReturnValue())
            {
                String latchPart = $"{this.Parameter.DataType} ret_val = {this.GetRetValBuffName()}[{this.GetMethodCalledCounterName()}];";
                returnLatchPart = this.GetCodeLine(latchPart, 1);

            }
            return returnLatchPart;
        }


        /// <summary>
        /// Check whether the parameter the Director holds has value to return or not.
        /// </summary>
        /// <returns>Returns true if the method returns value, otherwise returns false.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1304:CultureInfo を指定します", Justification = "<保留中>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1307:StringComparison を指定します", Justification = "<保留中>")]
        protected Boolean HasReturnValue()
        {
            /*
             * If the function data type is "void" and the pointer depth larger than 0, like "void*",
             * the method has return value.
             * So the code to latch the buffer value is needed.
             */
            Boolean isHasReturnValue =
                ((!(this.Parameter.DataType.ToLower().Equals("void"))) ||
                ((0 < this.Parameter.PointerNum)));
            return isHasReturnValue;
        }

        /// <summary>
        /// Create code to return latched return value.
        /// </summary>
        /// <returns>Code to return latched value.</returns>
        /// <remarks>
        /// If the data type of method set into this director is "void" and its number of pointer is lower,
        /// this method return empty line string.
        /// </remarks>
        public String GetReturnPart()
        {
            String returnPart = "";
            if (this.HasReturnValue())
            {
                returnPart = this.GetCodeLine("return ret_val;", 1);
            }
            return returnPart;
        }


        /// <summary>
        /// Create string in common format
        /// </summary>
        /// <param name="param">Parameter definition object</param>
        /// <returns>Declaration part for parameter.</returns>
        /// <remarks>
        /// The format is below:
        /// ({Prefix}) {DataType}({NumOfPointer}) ({Postfix}) {Name}
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:メンバーを static に設定します", Justification = "<保留中>")]
        public String CommonFormat(Param param)
        {
            String commonFormat = "";
            if (0 < param.Prefix.Length)
            {
                commonFormat += param.Prefix + " ";
            }
            commonFormat += param.DataType;
            for (int ptrIndex = 0; ptrIndex < param.PointerNum; ptrIndex++)
            {
                commonFormat += "*";
            }
            if (0 < param.Postifx.Length)
            {
                commonFormat += param.Postifx;
            }
            commonFormat += " ";
            commonFormat += param.Name;
            return commonFormat;
        }

        /// <summary>
        /// Create name of buffer to latch argument.
        /// </summary>
        /// <param name="argument">Argument information to latch.</param>
        /// <returns>Code to set argument into buffer.</returns>
        public String GetArgBuffName(Param argument)
        {
            if (null == argument)
            {
                throw new ArgumentNullException(nameof(argument));
            }
            else
            {
                return $"{this.Parameter.Name}_{argument.Name}";
            }
        }


        /// <summary>
        /// Create code of data type with prefix, postfix and pointer.
        /// </summary>
        /// <param name="argument">Argument information.</param>
        /// <returns>Code of data type.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:メンバーを static に設定します", Justification = "<保留中>")]
        public String GetDataType(Param argument)
        {
            if (null == argument)
            {
                throw new ArgumentNullException(nameof(argument));
            }
            else
            {
                String dataType = argument.DataType;
                for (int index = 0; index < argument.PointerNum; index++)
                {
                    dataType += "*";
                }
                return dataType;
            }
        }

        /// <summary>
        /// Create variable name to latch and return.
        /// </summary>
        /// <returns>Variable name to latch and return.</returns>
        public String GetRetValBuffName()
        {
            return $"{this.Parameter.Name}_ret_val";
        }

        /// <summary>
        /// Create variable name to store method called count;
        /// </summary>
        /// <returns>Variable name to store method called count</returns>
        /// <remarks>The variable name is in fomrat below:
        /// {MethodName}_called_count
        /// </remarks>
        public String GetMethodCalledCounterName()
        {
            return $"{this.Parameter.Name}_called_count";
        }
        #endregion
    }
}
