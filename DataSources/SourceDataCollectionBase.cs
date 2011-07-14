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
using System.Collections.Generic;
#endregion
namespace Stancer.GTFSEngine
{
    public abstract class SourceDataCollectionBase : ISourceDataCollection
    {
        #region Declarations
        /// <summary>
        /// This dictionary holds the stream data.
        /// </summary>
        protected Dictionary<TransitFileType, Func<Stream>> mStreams;
        #endregion

        #region Constructor
        /// <summary>
        /// This is the abstract constructor.
        /// </summary>
        public SourceDataCollectionBase()
        {
            mStreams = new Dictionary<TransitFileType, Func<Stream>>();
        }
        #endregion

        #region Agency
        public Stream Agency
        {
            get { return mStreams[TransitFileType.Agency](); }
        }
        #endregion
        #region Stops
        public Stream Stops
        {
            get { return mStreams[TransitFileType.Stops](); }
        }
        #endregion
        #region Routes
        public Stream Routes
        {
            get { return mStreams[TransitFileType.Routes](); }
        }
        #endregion
        #region Trips
        public Stream Trips
        {
            get { return mStreams[TransitFileType.Trips](); }
        }
        #endregion
        #region StopTimes
        public Stream StopTimes
        {
            get { return mStreams[TransitFileType.Stop_Times](); }
        }
        #endregion
        #region Calendar
        public Stream Calendar
        {
            get { return mStreams[TransitFileType.Calendar](); }
        }
        #endregion
        #region CalendarDates
        public Stream CalendarDates
        {
            get { return mStreams[TransitFileType.Calendar_Dates](); }
        }

        public virtual bool HasCalendarDates
        {
            get { return mStreams.ContainsKey(TransitFileType.Calendar_Dates); }
            set { throw new NotSupportedException(); }
        }
        #endregion
        #region FareAttributes
        public Stream FareAttributes
        {
            get { return mStreams[TransitFileType.Fare_Attributes](); }
        }

        public virtual bool HasFareAttributes
        {
            get { return mStreams.ContainsKey(TransitFileType.Fare_Attributes); }
            set { throw new NotSupportedException(); }
        }
        #endregion
        #region FareRules
        public Stream FareRules
        {
            get { return mStreams[TransitFileType.Fare_Rules](); }
        }

        public virtual bool HasFareRules
        {
            get { return mStreams.ContainsKey(TransitFileType.Fare_Rules); }
            set { throw new NotSupportedException(); }
        }
        #endregion
        #region Shapes
        public Stream Shapes
        {
            get { return mStreams[TransitFileType.Shapes](); }
        }

        public virtual bool HasShapes
        {
            get { return mStreams.ContainsKey(TransitFileType.Shapes); }
            set { throw new NotSupportedException(); }
        }
        #endregion
        #region Frequencies
        public Stream Frequencies
        {
            get { return mStreams[TransitFileType.Frequencies](); }
        }

        public virtual bool HasFrequencies
        {
            get { return mStreams.ContainsKey(TransitFileType.Frequencies); }
            set { throw new NotSupportedException(); }
        }
        #endregion
        #region Transfers
        public Stream Transfers
        {
            get { return mStreams[TransitFileType.Transfers](); }
        }

        public virtual bool HasTransfers
        {
            get { return mStreams.ContainsKey(TransitFileType.Transfers); }
            set { throw new NotSupportedException(); }
        }
        #endregion

        #region Stream
        public Stream GetStream(TransitFileType type)
        {
            return mStreams[type]();
        }

        public virtual bool HasStream(TransitFileType type)
        {
            return mStreams.ContainsKey(type);
        }
        #endregion

    }
}
