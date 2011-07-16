#region Copyright
// *******************************************************************************
// Copyright (c) 2010-2011 Paul Stancer.
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
using System.Collections;
using System.Collections.Generic;
using Ximura;
#endregion 
namespace Stancer.GTFSEngine.Entities
{
    /// <summary>
    /// This struct defines the headway (time between trips) for routes with variable frequency of service. 
    /// </summary>
    public struct Frequency
    {
        #region Static constructor and properties
        private static readonly string[] sHeaders;
        private static readonly bool[] sHeaderOptional;

        /// <summary>
        /// This is an enumeration of the header name and its mandatory status.
        /// </summary>
        public static IEnumerable<KeyValuePair<string,bool>> Headers
        {
            get
            {
                for (int i=0; i < sHeaders.Length; i++)
                    yield return new KeyValuePair<string, bool>(sHeaders[i],sHeaderOptional[i]);
            }
        }

        static Frequency()
        {
            sHeaders = new string[] { 
              "trip_id"
            , "start_time"
            , "end_time"
            , "headway_secs"
            };
            sHeaderOptional = new bool[] { 
              false//"trip_id"
            , false//"start_time"
            , false//"end_time"
            , false//"headway_secs"
            };
        }
        #endregion 
        #region Declarations
        string mTripID;
        TimeSpan mStartTime;
        TimeSpan mEndTime;
        int mHeadwaySecs;
        #endregion

        #region Constructor
        public Frequency(CSVRowItem item) 
        {
            mTripID = item["trip_id"];
            mStartTime = item["start_time"].ToTimeSpan();
            mEndTime = item["end_time"].ToTimeSpan();
            mHeadwaySecs = int.Parse(item["headway_secs"]);       
        }
        /// <summary>
        /// This is the default constructor.
        /// </summary>
        /// <param name="TripID"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="HeadwaySecs"></param>
        public Frequency(
            string TripID,
            TimeSpan StartTime,
            TimeSpan EndTime,
            int HeadwaySecs           
            )
        {
            mTripID=TripID;
            mStartTime=StartTime;
            mEndTime=EndTime;
            mHeadwaySecs=HeadwaySecs;

        }
        #endregion  

        #region TripID
        /// <summary>
        /// Required. The trip_id contains an ID that identifies a trip on which the specified frequency of service applies. Trip IDs are referenced from the trips.txt file. 
        /// </summary>
        public string TripID
        {
            get { return mTripID; }
        }
        #endregion
        #region StartTime
        /// <summary>
        /// Required. The start_time field specifies the time at which service begins with the specified frequency. The time is measured from "noon minus 12h" (effectively midnight, except for days on which daylight savings time changes occur) at the beginning of the service date. For times occurring after midnight, enter the time as a value greater than 24:00:00 in HH:MM:SS local time for the day on which the trip schedule begins. E.g. 25:35:00. 
        /// </summary>
        public TimeSpan StartTime
        {
            get { return mStartTime; }
        }
        #endregion
        #region EndTime
        /// <summary>
        /// Required. The end_time field indicates the time at which service changes to a different frequency (or ceases) at the first stop in the trip. The time is measured from "noon minus 12h" (effectively midnight, except for days on which daylight savings time changes occur) at the beginning of the service date. For times occurring after midnight, enter the time as a value greater than 24:00:00 in HH:MM:SS local time for the day on which the trip schedule begins. E.g. 25:35:00. 
        /// </summary>
        public TimeSpan EndTime
        {
            get { return mEndTime; }
        }
        #endregion
        #region HeadwaySecs
        /// <summary>
        /// Required. The headway_secs field indicates the time between departures from the same stop (headway) for this trip type, during the time interval specified by start_time and end_time. The headway value must be entered in seconds. 
        /// </summary>
        public int HeadwaySecs
        {
            get { return mHeadwaySecs; }
        }
        #endregion

    }
}
