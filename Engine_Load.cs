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
using System.Linq;
using System.Reflection;
using System.IO.IsolatedStorage;

using Stancer.GTFSEngine.Entities;

using Ximura;
using Ximura.Data;
#endregion
namespace Stancer.GTFSEngine
{
    public partial class Engine
    {
        #region Declarations
        private object mSyncLock = new object();

        private Dictionary<TransitFileType, Dictionary<string, ISourceData>> mData = null;
        #endregion  

        #region LoadFromAssembly(TransitFileType fileType, string name, Type appType)
        /// <summary>
        /// This method loads the resource data and validates the header line.
        /// </summary>
        /// <param name="fileType">The transit file type.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="ass">The data stream.</param>
        /// <returns>Returns true if the resource is successfully resolved and validated.</returns>
        public bool LoadFromAssembly(TransitFileType fileType, string name, Assembly ass)
        {
            try
            {
                lock (mSyncLock)
                {
                    if (mData == null)
                        mData = new Dictionary<TransitFileType, Dictionary<string, ISourceData>>();

                    if (!mData.ContainsKey(fileType))
                        mData.Add(fileType, new Dictionary<string, ISourceData>());
                }

                if (mData[fileType].ContainsKey(name))
                    throw new ArgumentOutOfRangeException(string.Format("The ID '{0}' has already been added.", name));


                AssemblySourceData holder = new AssemblySourceData(ass, name);

                //Finally add the collection data.
                mData[fileType].Add(name, holder);

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion  
    }
}
