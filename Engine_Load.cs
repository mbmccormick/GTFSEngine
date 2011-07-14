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
using System.Linq;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Stancer.GTFSEngine.Entities;

using Ximura;
using Ximura.Data;
#endregion
namespace Stancer.GTFSEngine
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Engine
    {
        #region Declarations
        private object mSyncLock = new object();

        private ISourceDataCollection mData;
        #endregion  

        #region Load(Dictionary<TransitFileType, ISourceData> data)
        /// <summary>
        /// This method initializes the engine.
        /// </summary>
        public void Load(ISourceDataCollection data)
        {
            lock (mSyncLock)
            {
                mData = data;
            }
        }
        #endregion

    }
}
