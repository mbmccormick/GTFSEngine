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
using System.Reflection;
using System.Linq;

using Ximura;
#endregion
namespace Stancer.GTFSEngine
{
    /// <summary>
    /// This private class is used to store the header data.
    /// </summary>
    public class AssemblySourceData : ISourceData
    {
        #region Constructor
        /// <summary>
        /// This is the default constructor.
        /// </summary>
        /// <param name="ass"></param>
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
