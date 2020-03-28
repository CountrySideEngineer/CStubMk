using CStubMKGui.Command;
using CStubMKGui.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private String stubDefFilePath;

        /// <summary>
        /// Stub output folder path.
        /// </summary>
        private String stubOutputPath;

        /// <summary>
        /// Command to create stub source and header files.
        /// </summary>
        private DelegateCommand createStubCommand;
        #endregion

        #region Constructors and the finalizer
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CStubMkGuiViewModel()
        {
            this.StubDefFilePath = "";
            this.StubOutputPath = "";
            this.createStubCommand = null;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Property to stub definition file path.
        /// </summary>
        public String StubDefFilePath
        {
            get
            {
                return this.stubDefFilePath;
            }
            set
            {
                this.stubDefFilePath = value;
                this.RaisePropertyChanged(nameof(StubDefFilePath));
            }
        }

        /// <summary>
        /// Property of stub output folder path.
        /// </summary>
        public String StubOutputPath
        {
            get
            {
                return this.stubOutputPath;
            }
            set
            {
                this.stubOutputPath = value;
                this.RaisePropertyChanged(nameof(StubOutputPath));
            }
        }

        /// <summary>
        /// Command to execute CreateStub.
        /// </summary>
        public DelegateCommand CreateStubCommand
        {
            get
            {
                if (null == this.createStubCommand)
                {
                    this.createStubCommand = new DelegateCommand(this.CreateStubExecute, this.CanCreateStubExecute);
                }
                return this.createStubCommand;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// Exeucte create stub command.
        /// </summary>
        public void CreateStubExecute()
        {
            var stubMk = new CStubMk();
            stubMk.Create(this.StubDefFilePath, this.StubOutputPath);
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
            if (((string.IsNullOrEmpty(this.StubDefFilePath)) || (string.IsNullOrWhiteSpace(this.StubDefFilePath))) ||
                ((string.IsNullOrEmpty(this.StubOutputPath)) || (string.IsNullOrWhiteSpace(this.StubOutputPath))))
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
