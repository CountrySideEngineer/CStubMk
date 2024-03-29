﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
    /// <summary>
    /// Function or argument.
    /// </summary>
    public class Param
    {
        #region Private fields and constants
        public enum AccessMode
        {
            In,     //Input
            Out,    //Output
            Both,   //Input and Output
            None,   //No access, error mode.
        }

        protected static string ModeInput = "in";
        protected static string ModeOutput = "out";
        protected static string ModeBoth = "both";
        #endregion

        #region Constructors and the finalizer
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Param()
        {
            this.Name = "";
            this.Description = "";
            this.DataType = "";
            this.Prefix = "";
            this.Postifx = "";
            this.PointerNum = 0;
            this.Parameters = null;
            this.Mode = AccessMode.None;
        }

        /// <summary>
        /// Copy constuctor.
        /// </summary>
        /// <param name="src">Source Parameter object.</param>
        public Param(Param src)
        {
            this.Name = src.Name;
            this.Description = src.Description;
            this.DataType = src.DataType;
            this.Prefix = src.Prefix;
            this.Postifx = src.Postifx;
            this.PointerNum = src.PointerNum;
            this.Parameters = src.Parameters;
            this.Mode = src.Mode;
        }
		#endregion

		#region Public methods.
        public override string ToString()
		{
            string toString = "";
            if ((!string.IsNullOrEmpty(this.Prefix)) || 
                (!string.IsNullOrWhiteSpace(this.Prefix)))
            {
                toString += (this.Prefix + " ");
			}
            toString += this.DataType;
            if (!(string.IsNullOrEmpty(this.Postifx)) ||
                !(string.IsNullOrWhiteSpace(this.Postifx)))
            {
                toString += (" " + this.Postifx);
            }
            for (int index = 0; index < this.PointerNum; index++)
			{
                toString += "*";
			}
            toString += (" " + this.Name);

            return toString;
        }

        #endregion

        #region Public properties
        /// <summary>
        /// Function or argument name.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Description about function or argument.
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Type of value.
        /// If function, data type of return value.
        /// </summary>
        public String DataType { get; set; }

        /// <summary>
        /// Actual, true data type.
        /// This property returns data type with pre/post fix like const and pointer.
        /// </summary>
        public String ActualDataType
		{
            get
			{
                String dataType = "";
                if ((!(String.IsNullOrWhiteSpace(this.Prefix))) ||
                    (!(String.IsNullOrEmpty(this.Prefix))))
				{
                    dataType += (this.Prefix + " ");
				}
                dataType += this.DataType;
                for (int index = 0; index < this.PointerNum; index++)
				{
                    dataType += "*";
				}
                if ((!(String.IsNullOrWhiteSpace(this.Postifx))) ||
                    (!(String.IsNullOrEmpty(this.Postifx))))
                {
                    dataType += (" " + this.Postifx);
                }
                return dataType;
			}
		}

        /// <summary>
        /// Prefix for data type.
        /// It assumes words "static" or "const" 
        /// </summary>
        public String Prefix { get; set; }

        /// <summary>
        /// Prefix for data type.
        /// It assumes words "const" only.
        /// And set when only argumetn.
        /// </summary>
        public String Postifx { get; set; }

        /// <summary>
        /// Number of pointer.
        /// Single, double, or more.
        /// For example, in a case that the function or argument does not pointer, this value is 0,
        /// in single pointer, this value is 1.
        /// </summary>
        public Byte PointerNum { get; set; }

        /// <summary>
        /// Collection of sub data.
        /// </summary>
        public IEnumerable<Param> Parameters { get; set; }

        /// <summary>
        /// Access mode, input, output, or both.
        /// </summary>
        public AccessMode Mode { get; set; }

        /// <summary>
        /// Convert string into value in AccessMode data type.
        /// </summary>
        /// <param name="mode">String to convert into the AccessMode,</param>
        /// <returns>AccessMode conveted.</returns>
        /// <exception cref="InvalidOperationException">The source string is invalid.</exception>
        public static AccessMode ToMode(string mode)
        {
            AccessMode accessMode = AccessMode.None;
            if (0 == string.Compare(mode, Param.ModeInput, true))
            {
                accessMode = AccessMode.In;
            }
            else if (0 == string.Compare(mode, Param.ModeOutput, true))
            {
                accessMode = AccessMode.Out;
            }
            else if (0 == string.Compare(mode, Param.ModeBoth, true))
            {
                accessMode = AccessMode.Both;
            }
            else
            {
                throw new InvalidOperationException(nameof(ToMode));
            }
            return accessMode;
        }
        #endregion

    }
}
