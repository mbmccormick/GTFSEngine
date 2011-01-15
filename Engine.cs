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
using Microsoft.Devices.Sensors;
using Microsoft.Phone;

using Stancer.GTFSEngine.Entities;

using Ximura;
using System.Text;
#endregion  
namespace Stancer.GTFSEngine
{
    public partial class Engine
    {
        #region HasTransitData(TransitFileType tType)
        /// <summary>
        /// This function checks whether there is valid data for the specific transit type.
        /// </summary>
        /// <param name="tType">The transit type.</param>
        /// <returns>Returns true if there is valid data.</returns>
        private bool HasTransitData(TransitFileType tType)
        {
            return mData.ContainsKey(tType) &&
                    mData[tType].Count > 0;
        }
        #endregion

        #region TransitEntityEnum(TransitFileType tType, IEnumerable<KeyValuePair<string,bool>> headers, Func<CSVRowItem,T> conv)
        /// <summary>
        /// This method returns the entity items from the CSV data file collection.
        /// </summary>
        /// <typeparam name="T">The transit entity type.</typeparam>
        /// <param name="tType">The transit file type.</param>
        /// <param name="headersRequired">The required headers.</param>
        /// <param name="conv">The conversion function.</param>
        /// <returns>Returns an amalgamated collection of entities.</returns>
        private IEnumerable<T> TransitEntityEnum<T>(
            TransitFileType tType, IEnumerable<KeyValuePair<string,bool>> headers, Func<CSVRowItem,T> conv)
        {
            if (!HasTransitData(tType))
                yield break;

            foreach (ISourceData hd in mData[tType].Values)
            {
                using (Stream data = hd.GetStream())
                {
                    CSVStreamEnumerator<T> item = new CSVStreamEnumerator<T>(data, true, Encoding.UTF8, conv);
                    foreach (var entity in item)
                        yield return entity;
                }
            }
        }
        #endregion  
    }
}
