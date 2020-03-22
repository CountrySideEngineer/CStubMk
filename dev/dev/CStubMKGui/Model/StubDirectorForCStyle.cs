using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CStubMKGui.Model
{
    public class StubDirectorForCStyle
    {
        protected const String CHANGE_LINE_CODE = "\r\n";
        protected const String STUB_HEADER_PREFIX = "/*----";
        protected const String STUB_HEADER_POSTFIX = "----*/";
        protected const String BUFF_INIT_VALUE_PRIMITIVE = "0";
        protected const String BUFF_INIT_VALUE_POINTER = "null";
        protected const String BUFF_INIT_ID_VARIABLE = "id";
        protected const String BUFF_SIZE_MACRO = "STUB_BUFF_SIZE";
        protected const String BUFF_SIZE_NUM = "100";

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
            String definePart = String.Format("#define {0}\t\t\t\t({1})", BUFF_SIZE_MACRO, BUFF_SIZE_NUM);
            return this.GetCodeLine(definePart);
        }

        /// <summary>
        /// Create method brief description part of stub method.
        /// </summary>
        /// <returns>Stub method brief description.</returns>
        public String GetMethodHeader()
        {
            String stubHeaderContent = String.Format(" Start {0} stub ", this.Parameter.Name);
            int funcHeaderLineLen = stubHeaderContent.Length + STUB_HEADER_PREFIX.Length + STUB_HEADER_POSTFIX.Length;
            String stubHeader = STUB_HEADER_PREFIX;
            for (int whiteSpaceIndex = 0; whiteSpaceIndex < stubHeaderContent.Length; whiteSpaceIndex++)
            {
                stubHeader += "-";
            }
            stubHeader += (STUB_HEADER_POSTFIX + CHANGE_LINE_CODE);
            stubHeader += STUB_HEADER_PREFIX;
            for (int whiteSpaceIndex = 0; whiteSpaceIndex < stubHeaderContent.Length; whiteSpaceIndex++)
            {
                stubHeader += " ";
            }
            stubHeader += (STUB_HEADER_POSTFIX + CHANGE_LINE_CODE);
            stubHeader += STUB_HEADER_PREFIX;
            stubHeader += stubHeaderContent;
            stubHeader += (STUB_HEADER_POSTFIX + CHANGE_LINE_CODE);
            stubHeader += STUB_HEADER_PREFIX;
            for (int whiteSpaceIndex = 0; whiteSpaceIndex < stubHeaderContent.Length; whiteSpaceIndex++)
            {
                stubHeader += " ";
            }
            stubHeader += (STUB_HEADER_POSTFIX + CHANGE_LINE_CODE);
            stubHeader += STUB_HEADER_PREFIX;
            for (int whiteSpaceIndex = 0; whiteSpaceIndex < stubHeaderContent.Length; whiteSpaceIndex++)
            {
                stubHeader += "-";
            }
            stubHeader += STUB_HEADER_POSTFIX;

            return stubHeader;
        }

        /// <summary>
        /// Create code to declare buffer used to latch arguments.
        /// </summary>
        /// <returns>Code to declare buffer used to latch arguments.</returns>
        public String GetStubBufferDeclare()
        {
            String stubBufferDeclare = "";
            stubBufferDeclare += this.GetCodeLine(String.Format("int {0};", this.GetMethodCalledCounterName()));
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
            String stubBufferDec = String.Format("{0} {1}[{2}];",
                this.GetDataType(arg), this.GetArgBuffName(arg), BUFF_SIZE_MACRO);
            return stubBufferDec;
        }

        /// <summary>
        /// Create code for extern declarations of buffur variabels..
        /// </summary>
        /// <returns>Code for extern declarations of buffur.</returns>
        public String GetStubBufferExternDeclare()
        {
            String stubBufferExtern = "";
            stubBufferExtern += this.GetCodeLine(String.Format("extern int {0};", this.GetMethodCalledCounterName()));
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
            String stubBufferExtern = String.Format("extern {0} {1}[];", this.GetDataType(arg), this.GetArgBuffName(arg));
            return stubBufferExtern;
        }

        /// <summary>
        /// Create code to declare variable for the count the stub is called.
        /// </summary>
        /// <returns>Code to declare variable for called count.</returns>
        public String GetCalledCountDeclare()
        {
            return String.Format("int {0};", this.GetMethodCalledCounterName());
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
        public String GetCodeLine(String code, int indentLevel = 0)
        {
            String codeLine = "";
            for (int indentIndex = 0; indentIndex < indentLevel; indentIndex++)
            {
                codeLine += "\t";
            }
            codeLine += code;
            codeLine += CHANGE_LINE_CODE;

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
            initMethod += this.GetCodeLine(String.Format("int {0} = 0;", BUFF_INIT_ID_VARIABLE), 1);
            initMethod += this.GetCodeLine("");
            initMethod += this.GetCodeLine(String.Format(@"for ({0} = 0; {0} < {1}; {0}++) {{",
                BUFF_INIT_ID_VARIABLE, BUFF_SIZE_MACRO), 1);
            initMethod += this.GetArgInitPart();
            initMethod += this.GetRetValInitPart();
            initMethod += this.GetCodeLine("}", 1);
            initMethod += this.GetCodeLine(String.Format("{0} = 0;", this.GetMethodCalledCounterName()), 1);
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
                    argDef += "," + StubDirectorForCStyle.CHANGE_LINE_CODE;
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
            String latchPart = String.Format("{0}[{1}] = {2};", 
                this.GetArgBuffName(argument), 
                this.GetMethodCalledCounterName(),
                argument.Name);
            return latchPart;
        }

        /// <summary>
        /// Create code of entry point to initialize stub buffer.
        /// </summary>
        /// <returns>Code of entry point to initialize buffer.</returns>
        public String GetArgInitEntryPoint()
        {
            return String.Format("void {0}_init()", this.Parameter.Name);
        }

        /// <summary>
        /// Create code of extern declaration of function to initialize buffer for stub.
        /// </summary>
        /// <returns>Code of extern declaration of intialize function.</returns>
        public String GetStubInitMethodExtern()
        {
            return String.Format("extern {0};", this.GetArgInitEntryPoint());
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
            String initValue = "";
            if (0 < argument.PointerNum)
            {
                initValue = BUFF_INIT_VALUE_POINTER;
            }
            else
            {
                initValue = BUFF_INIT_VALUE_PRIMITIVE;
            }
            return String.Format("{0}[{1}] = {2};", this.GetArgBuffName(argument), BUFF_INIT_ID_VARIABLE, initValue);
        }

        /// <summary>
        /// Create code to initialize buffer which stores the return value the stub returns.
        /// </summary>
        /// <returns>Code to initialize return value buffer.</returns>
        protected String GetRetValInitPart()
        {
            String retValInitPart = "";
            if (this.HasReturnValue())
            if (0 < this.GetRetValBuffName().Length)
            {
                String retValInit = String.Format("{0}[{1}] = 0;", this.GetRetValBuffName(), BUFF_INIT_ID_VARIABLE);
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
                String latchPart = String.Format("{0} ret_val = {1}[{2}];",
                    this.Parameter.DataType,
                    this.GetRetValBuffName(),
                    this.GetMethodCalledCounterName());
                returnLatchPart = this.GetCodeLine(latchPart, 1);

            }
            return returnLatchPart;
        }

        /// <summary>
        /// Check whether the parameter the Director holds has value to return or not.
        /// </summary>
        /// <returns>Returns true if the method returns value, otherwise returns false.</returns>
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
            return String.Format("{0}_{1}", this.Parameter.Name, argument.Name);
        }

        /// <summary>
        /// Create code of data type with prefix, postfix and pointer.
        /// </summary>
        /// <param name="argument">Argument information.</param>
        /// <returns>Code of data type.</returns>
        public String GetDataType(Param argument)
        {
            String dataType = argument.DataType;
            for (int index = 0; index < argument.PointerNum; index++)
            {
                dataType += "*";
            }
            return dataType;
        }

        /// <summary>
        /// Create variable name to latch and return.
        /// </summary>
        /// <returns>Variable name to latch and return.</returns>
        public String GetRetValBuffName()
        {
            return String.Format("{0}_ret_val", this.Parameter.Name);
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
            return String.Format("{0}_called_count", this.Parameter.Name);
        }
        #endregion
    }
}
