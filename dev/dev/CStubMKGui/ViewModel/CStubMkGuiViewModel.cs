using CStubMKGui.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.ViewModel
{
    /// <summary>
    /// ViewModel class for CStubMkGui main window.
    /// </summary>
    public class CStubMkGuiViewModel : ViewModelCommonBase
    {
        #region Private fields and constants.
        /// <summary>
        /// Stub definition file path.
        /// </summary>
        protected String _StubDefFilePath;

        /// <summary>
        /// Stub output folder path.
        /// </summary>
        protected String _StubOutputPath;

        protected DelegateCommand _CreateStubCommand;
        #endregion

        #region Constructors and the finalizer
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CStubMkGuiViewModel()
        {
            this._StubDefFilePath = "";
            this._StubOutputPath = "";
            this._CreateStubCommand = null;
        }
        #endregion

        #region MyRegion
        /// <summary>
        /// Property to stub definition file path.
        /// </summary>
        public String StubDefFilePath
        {
            get
            {
                return this._StubDefFilePath;
            }
            set
            {
                this._StubDefFilePath = value;
                this.RaisePropertyChanged("StubDefFilePath");
            }
        }

        /// <summary>
        /// Property of stub output folder path.
        /// </summary>
        public String StubOutputPath
        {
            get
            {
                return this._StubOutputPath;
            }
            set
            {
                this._StubDefFilePath = value;
                this.RaisePropertyChanged(StubOutputPath);
            }
        }

        /// <summary>
        /// Command to execute CreateStub.
        /// </summary>
        public DelegateCommand CreateStubCommand
        {
            get
            {
                if (null == this._CreateStubCommand)
                {
                    this._CreateStubCommand = new DelegateCommand(this.CreateStubExecute, this.CanCreateStubExecute);
                }
                return this._CreateStubCommand;
            }
        }

        /// <summary>
        /// Exeucte create stub command.
        /// </summary>
        public void CreateStubExecute()
        {

        }

        /// <summary>
        /// Return whether the CreateStub command can execute or not.
        /// </summary>
        /// <returns>
        /// Returns true if the stub definition file path and output folder path
        /// has been set, otherwise false.
        /// </returns>
        protected Boolean CanCreateStubExecute()
        {
            if ((0 == this._StubDefFilePath.Length) || (0 == this._StubOutputPath.Length))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
