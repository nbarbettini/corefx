// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.ComponentModel
{
    /// <summary>
    /// The exception that is thrown for a Win32 error code.
    /// </summary>
    public partial class Win32Exception : ExternalException, ISerializable
    {
        private const int E_FAIL = unchecked((int)0x80004005);

        /// <summary>
        /// Initializes a new instance of the <see cref='System.ComponentModel.Win32Exception'/> class with the last Win32 error 
        /// that occurred.
        /// </summary>
        public Win32Exception() : this(Marshal.GetLastWin32Error())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref='System.ComponentModel.Win32Exception'/> class with the specified error.
        /// </summary>
        public Win32Exception(int error) : this(error, GetErrorMessage(error))
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref='System.ComponentModel.Win32Exception'/> class with the specified error and the 
        /// specified detailed description.
        /// </summary>
        public Win32Exception(int error, string message) : base(message)
        {
            NativeErrorCode = error;
        }

        /// <summary>
        /// Initializes a new instance of the Exception class with a specified error message.
        /// </summary>
        public Win32Exception(string message) : this(Marshal.GetLastWin32Error(), message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Exception class with a specified error message and a 
        /// reference to the inner exception that is the cause of this exception.
        /// </summary>
        public Win32Exception(string message, Exception innerException) : base(message, innerException)
        {
            NativeErrorCode = Marshal.GetLastWin32Error();
        }

        protected Win32Exception(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Represents the Win32 error code associated with this exception. This field is read-only.
        /// </summary>
        public int NativeErrorCode { get; }
    }
}
