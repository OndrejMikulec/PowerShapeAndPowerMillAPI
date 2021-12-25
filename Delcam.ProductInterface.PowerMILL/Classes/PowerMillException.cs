// **********************************************************************
// *         © COPYRIGHT 2018 Autodesk, Inc.All Rights Reserved         *
// *                                                                    *
// *  Use of this software is subject to the terms of the Autodesk      *
// *  license agreement provided at the time of installation            *
// *  or download, or which otherwise accompanies this software         *
// *  in either electronic or hard copy form.                           *
// **********************************************************************

using System;

namespace Autodesk.ProductInterface.PowerMILL
{
    public class PowerMillException : Exception
    {
		readonly string _reason2;
		private string _reason {
			get {
				return _reason2;
			}
		}
		readonly Version _version2;
		private Version _version {
			get {
				return _version2;
			}
		}

        public PowerMillException(Version version, string message)
        {
            _version2 = version;
            _reason2 = message;
        }

        public override string Message
        {
            get { return string.Format("PowerMill Version {0} Error: {1}", _version, _reason); }
        }
    }
}