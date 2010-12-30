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
#endregion 
namespace Stancer.GTFSEngine.Entities
{
    /// <summary>
    /// This struct lists the times that a vehicle arrives at and departs from individual stops for each trip. 
    /// </summary>
    public struct StopTime
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

        static StopTime()
        {
            sHeaders = new string[] { 
              "trip_id"
            , "arrival_time"
            , "departure_time"
            , "stop_id"
            , "stop_sequence"
            , "stop_headsign"
            , "pickup_type"
            , "drop_off_type"
            , "shape_dist_traveled"
            };

            sHeaderOptional = new bool[] { 
              false //"trip_id"
            , false //"arrival_time"
            , false //"departure_time"
            , false //"stop_id"
            , false //"stop_sequence"
            , true  //"stop_headsign"
            , true  //"pickup_type"
            , true  //"drop_off_type"
            , true  //"shape_dist_traveled"
            };
        }
        #endregion  
        #region Declarations
        string mTripID;
        string mArrivalTime;
        string mDepartureTime;
        string mStopID;
        int mStopSequence;
        string mStopHeadSign;
        PickUpType mPickUpType;
        DropOffType mDropOffType;
        string mShapeDistTraveled;
        #endregion  

        #region Constructor
        /// <summary>
        /// This is the default constuctor.
        /// </summary>
        /// <param name="TripID"></param>
        /// <param name="ArrivalTime"></param>
        /// <param name="DepartureTime"></param>
        /// <param name="StopID"></param>
        /// <param name="StopSequence"></param>
        /// <param name="StopHeadSign"></param>
        /// <param name="PickUpType"></param>
        /// <param name="DropOffType"></param>
        /// <param name="ShapeDistTraveled"></param>
        public StopTime(
            string TripID,
            string ArrivalTime,
            string DepartureTime,
            string StopID,
            int StopSequence,
            string StopHeadSign,
            PickUpType PickUpType,
            DropOffType DropOffType,
            string ShapeDistTraveled
            )
        {
            mTripID=TripID ;
            mArrivalTime=ArrivalTime ;
            mDepartureTime=DepartureTime ;
            mStopID=StopID ;
            mStopSequence=StopSequence ;
            mStopHeadSign=StopHeadSign ;
            mPickUpType=PickUpType ;
            mDropOffType=DropOffType ;
            mShapeDistTraveled=ShapeDistTraveled ;    
        }
        #endregion  


        /// <summary>
        /// Required. The trip_id field contains an ID that identifies a trip. This value is referenced from the trips.txt file.
        /// </summary>
        public string TripID
        {
            get { return mTripID; }
        }
        /// <summary>
        /// Required. The arrival_time specifies the arrival time at a specific stop for a specific trip on a route. The time is measured from "noon minus 12h" (effectively midnight, except for days on which daylight savings time changes occur) at the beginning of the service date. For times occurring after midnight on the service date, enter the time as a value greater than 24:00:00 in HH:MM:SS local time for the day on which the trip schedule begins. If you don't have separate times for arrival and departure at a stop, enter the same value for arrival_time and departure_time. 
        /// </summary>
        public string ArrivalTime
        {
            get { return mArrivalTime; }
        }
        /// <summary>
        /// Required. The departure_time specifies the departure time from a specific stop for a specific trip on a route. The time is measured from "noon minus 12h" (effectively midnight, except for days on which daylight savings time changes occur) at the beginning of the service date. For times occurring after midnight on the service date, enter the time as a value greater than 24:00:00 in HH:MM:SS local time for the day on which the trip schedule begins. If you don't have separate times for arrival and departure at a stop, enter the same value for arrival_time and departure_time. 
        /// </summary>
        public string DepartureTime
        {
            get { return mDepartureTime; }
        }
        /// <summary>
        /// Required. The stop_id field contains an ID that uniquely identifies a stop. Multiple routes may use the same stop. The stop_id is referenced from the stops.txt file. If location_type is used in stops.txt, all stops referenced in stop_times.txt must have location_type of 0. 
        /// </summary>
        public string StopID
        {
            get { return mStopID; }
        }
        /// <summary>
        /// Required. The stop_sequence field identifies the order of the stops for a particular trip. The values for stop_sequence must be non-negative integers, and they must increase along the trip. 
        /// </summary>
        public int StopSequence
        {
            get { return mStopSequence; }
        }
        /// <summary>
        /// Optional. The stop_headsign field contains the text that appears on a sign that identifies the trip's destination to passengers. Use this field to override the default trip_headsign when the headsign changes between stops. If this headsign is associated with an entire trip, use trip_headsign instead.
        /// </summary>
        public string StopHeadSign
        {
            get { return mStopHeadSign; }
        }
        /// <summary>
        /// Optional. The pickup_type field indicates whether passengers are picked up at a stop as part of the normal schedule or whether a pickup at the stop is not available. This field also allows the transit agency to indicate that passengers must call the agency or notify the driver to arrange a pickup at a particular stop.
        /// </summary>
        public PickUpType PickUpType
        {
            get { return mPickUpType; }
        }
        /// <summary>
        /// Optional. The drop_off_type field indicates whether passengers are dropped off at a stop as part of the normal schedule or whether a drop off at the stop is not available. This field also allows the transit agency to indicate that passengers must call the agency or notify the driver to arrange a drop off at a particular stop.
        /// </summary>
        public DropOffType DropOffType
        {
            get { return mDropOffType; }
        }
        /// <summary>
        /// Optional. When used in the stop_times.txt file, the shape_dist_traveled field positions a stop as a distance from the first shape point. The shape_dist_traveled field represents a real distance traveled along the route in units such as feet or kilometers. For example, if a bus travels a distance of 5.25 kilometers from the start of the shape to the stop, the shape_dist_traveled for the stop ID would be entered as "5.25". This information allows the trip planner to determine how much of the shape to draw when showing part of a trip on the map. The values used for shape_dist_traveled must increase along with stop_sequence: they cannot be used to show reverse travel along a route.
        /// </summary>
        public string ShapeDistTraveled
        {
            get { return mShapeDistTraveled; }
        }

    }
}
