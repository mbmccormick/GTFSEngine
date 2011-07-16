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
using System.Resources;

using Ximura;
using System.Globalization;
#endregion
namespace Stancer.GTFSEngine
{
    public class ResourceSourceDataCollection : SourceDataCollectionBase
    {
        ResourceManager mResMan;

        #region Constructor
        /// <summary>
        /// This is the default constructor.
        /// </summary>
        /// <param name="ass">The assembly.</param>
        /// <param name="defaultPath">This is the default path to where the files are located in the assembly.</param>
        /// <param name="compressed">This property specifies whether the files are compressed using 7zip compression.</param>
        public ResourceSourceDataCollection(ResourceManager man)
        {
            mResMan = man;

            Names
                .Where(i => mResMan.GetObject(i.Value) != null)
                .ForEach(i => mStreams.Add(i.Key, ((Func<string, Stream>)GetStream).Curry()(i.Value)));

            var missing = Required.Except(mStreams.Keys);
            if (missing.Count() > 0)
                throw new ArgumentOutOfRangeException("Missing mandatory data.");
        }
        #endregion

        private Stream GetStream(string name)
        {
            //Assembly ass = mResMan.GetType().Assembly;

            //byte[] obj = (byte[])mResMan.GetObject("calgary_transit");

            Stream strM = mResMan.GetStream(name);

            return strM;
        }
    }
}
