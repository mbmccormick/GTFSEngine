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
    public class AssemblySourceDataCollection : SourceDataCollectionBase
    {
        #region Declarations
        /// <summary>
        /// This is the assembly that contains the fields.
        /// </summary>
        Assembly mAss;
        /// <summary>
        /// This is the default path to where the files are located in the assembly.
        /// </summary>
        string mDefaultPath;
        /// <summary>
        /// This property specifies whether the files are compressed using 7zip compression.
        /// </summary>
        bool mCompressed;
        #endregion
        #region Constructor
        /// <summary>
        /// This is the default constructor.
        /// </summary>
        /// <param name="ass">The assembly.</param>
        /// <param name="defaultPath">This is the default path to where the files are located in the assembly.</param>
        /// <param name="compressed">This property specifies whether the files are compressed using 7zip compression.</param>
        public AssemblySourceDataCollection(Assembly ass, string defaultPath, bool compressed)
        {
            mAss = ass;
            mDefaultPath = defaultPath;
            mCompressed = compressed;

            Enum.GetValues(typeof(TransitFileType))
                .Cast<TransitFileType>()
                .ForEach( i => base.mStreams.Add(i, 
                    ((Func<string,Stream>)GetAssemblyStream).Curry()("."+i.ToString().ToLowerInvariant()+".txt")));

        }
        #endregion

        private Stream GetAssemblyStream(string name)
        {
            return mAss.GetManifestResourceStream(mDefaultPath+name);
        }

        public override bool HasCalendarDates
        {
            get;
            set;
        }

        public override bool HasFareAttributes
        {
            get;
            set;
        }

        public override bool HasFareRules
        {
            get;
            set;
        }

        public override bool HasFrequencies
        {
            get;
            set;
        }

        public override bool HasShapes
        {
            get;
            set;
        }

        public override bool HasTransfers
        {
            get;
            set;
        }

        public override bool HasStream(TransitFileType type)
        {
            switch(type)
            {
                case TransitFileType.Calendar_Dates:
                    return HasCalendarDates;
                case TransitFileType.Fare_Attributes:
                    return HasFareAttributes;
                case TransitFileType.Fare_Rules:
                    return HasFareRules;
                case TransitFileType.Frequencies:
                    return HasFrequencies;
                case TransitFileType.Transfers:
                    return HasTransfers;
                case TransitFileType.Shapes:
                    return HasShapes;
                default:
                    return true;
            }
        }
    }
}
