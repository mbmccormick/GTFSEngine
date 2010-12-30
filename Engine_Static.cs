#region Copyright
// *******************************************************************************
// Copyright (c) 2000-2011 Paul Stancer.
// All rights reserved. This program and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html
//
// Contributors:
//     Paul Stancer - initial implementation
// *******************************************************************************
#endregion
#region using
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Devices.Sensors;
using Microsoft.Phone;

using Stancer.GTFSEngine.Entities;

using Ximura;
using Ximura.Data;
#endregion
namespace Stancer.GTFSEngine
{
    public partial class Engine
    {
        /// <summary>
        /// This private class is used to store the header data.
        /// </summary>
        private class AssemblySourceData : ISourceData
        {
            #region Constructor
            /// <summary>
            /// This is the default constructor.
            /// </summary>
            /// <param name="type"></param>
            /// <param name="resourceID"></param>
            public AssemblySourceData(Assembly ass, string resourceID)
            {
                this.Assembly = ass;
                this.ResourceID = resourceID;
            }
            #endregion  

            #region GetStream()
            /// <summary>
            /// This method return a stream containing the data.
            /// </summary>
            public virtual Stream GetStream()
            {
                return this.Assembly.GetManifestResourceStream(ResourceID);
            }
            #endregion  

            #region Assembly
            /// <summary>
            /// The assembly that contains the data.
            /// </summary>
            public Assembly Assembly
            {
                get;
                private set;
            }
            #endregion  

            #region ResourceID
            /// <summary>
            /// The resource identifier for the file.
            /// </summary>
            public string ResourceID
            {
                get;
                private set;
            }
            #endregion  
        }
    }
}
