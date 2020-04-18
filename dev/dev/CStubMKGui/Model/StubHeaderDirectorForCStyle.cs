using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CStubMKGui.Model
{
	public class StubHeaderDirectorForCStyle : StubDirectorForCStyle
	{
        #region Constructors and the finalizer
        /// <summary>
        /// Default constructor.
        /// </summary>
        public StubHeaderDirectorForCStyle() : base() { }

        /// <summary>
        /// Constructor with Param object to be used.
        /// </summary>
        /// <param name="param">Parameters of stub function.</param>
        public StubHeaderDirectorForCStyle(Param param) : base(param) { }
        #endregion

        #region Method to create code declaring method header
        /// <summary>
        /// Returns the start section in header file.
        /// </summary>
        /// <returns>
        /// Code of start section.
        /// Returns no code.
        /// </returns>
        public override String GetStartPart()
        {
            return "";
        }

        /// <summary>
        /// Create code to declare with "extern".
        /// </summary>
        /// <param name="arg">Argument of method.</param>
        /// <returns>Code of declaration with </returns>
        protected override string GetStubBufferDeclare(Param arg)
        {
            string stubBufferDeclare = $"extern {this.GetDataType(arg)} {this.GetArgBuffName(arg)}[];";
            return stubBufferDeclare;
        }
        #endregion

        #region Create code of stub body.
        /// <summary>
        /// Create stub method body.
        /// </summary>
        /// <returns>Stub body.</returns>
        public override string StubBodySection()
        {
            return "";
        }
        #endregion

        #region Create code of method to init buffers.
        public override string GetStubInitMethod()
        {
            string initMethod = "";
            initMethod = this.GetArgInitEntryPoint();

            return initMethod;
        }

        /// <summary>
        /// Create code to 
        /// </summary>
        /// <returns></returns>
        protected override string GetArgInitEntryPoint()
        {
            return $"extern {base.GetArgInitEntryPoint()};";
        }




        #endregion
    }
}
