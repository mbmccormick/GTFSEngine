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
    /// This struct lists a trips and its route. A trip is a sequence of two or more stops that occurs at specific time. 
    /// </summary>
    public struct Trip
    {
        #region Static constructor and properties
        private static readonly string[] sHeaders;
        private static readonly bool[] sHeaderOptional;

        /// <summary>
        /// This is an enumeration of the header name and its mandatory status.
        /// </summary>
        public static IEnumerable<KeyValuePair<string, bool>> Headers
        {
            get
            {
                for (int i = 0; i < sHeaders.Length; i++)
                    yield return new KeyValuePair<string, bool>(sHeaders[i], sHeaderOptional[i]);
            }
        }

        static Trip()
        {
            sHeaders = new string[] { 
              "route_id"
            , "service_id"
            , "trip_id"
            , "trip_headsign"
            , "trip_short_name"
            , "direction_id"
            , "block_id"
            , "shape_id"
            };

            sHeaderOptional = new bool[] { 
              false //"route_id"
            , false //"service_id"
            , false //"trip_id"
            , true  //"trip_headsign"
            , true  //"trip_short_name"
            , true  //"direction_id"
            , true  //"block_id"
            , true  //"shape_id"
            };
        }
        #endregion  

        #region Declarations
        private string mID;
        private string mRouteID;
        private string mServiceID;
        private string mHeadSign;
        private string mShortName;

        private DirectionType? mDirectionID;
        private string mBlockID;
        private string mShapeID;
        #endregion  
        #region Constructor
        /// <summary>
        /// The CSV item constructor.
        /// </summary>
        /// <param name="item">The CSV row item.</param>
        public Trip(CSVRowItem item)
        {
            mID = item["trip_id"];
            mRouteID = item["route_id"];
            mServiceID = item["service_id"];
            mHeadSign = item["trip_headsign"];
            mShortName = item["trip_short_name"];

            switch (item["direction_id"])
            {
                case "0":
                    mDirectionID = DirectionType.Forwards;
                    break;
                case "1":
                    mDirectionID = DirectionType.Backwards;
                    break;
                default:
                    mDirectionID = null;
                    break;
            }

            mBlockID = item["block_id"];
            mShapeID = item["shape_id"];
        }
        /// <summary>
        /// This is the struct constructor.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="RouteID"></param>
        /// <param name="ServiceID"></param>
        /// <param name="HeadSign"></param>
        /// <param name="ShortName"></param>
        /// <param name="DirectionID"></param>
        /// <param name="BlockID"></param>
        /// <param name="ShapeID"></param>
        public Trip(
            string ID,
            string RouteID,
            string ServiceID,
            string HeadSign,
            string ShortName,
            DirectionType? DirectionID,
            string BlockID,
            string ShapeID
            )
        {
            mID= ID;
            mRouteID= RouteID;
            mServiceID= ServiceID;
            mHeadSign = HeadSign;
            mShortName = ShortName;
            mDirectionID = DirectionID;
            mBlockID= BlockID;
            mShapeID= ShapeID;
        }
        #endregion  

        #region RouteID
        /// <summary>
        /// Required. The route_id field contains an ID that uniquely identifies a route. 
        /// This value is referenced from the routes.txt file.
        /// </summary>
        public string RouteID { get{ return mRouteID ;}}
        #endregion  
        #region ServiceID
        /// <summary>
        /// Required. The service_id contains an ID that uniquely identifies a set of 
        /// dates when service is available for one or more routes. 
        /// This value is referenced from the calendar.txt or calendar_dates.txt file.
        /// </summary>
        public string ServiceID { get{ return mServiceID ;}}
        #endregion  
        #region ID
        /// <summary>
        /// Required. The trip_id field contains an ID that identifies a trip. 
        /// The trip_id is dataset unique. 
        /// </summary>
        public string ID { get{ return mID ;}}
        #endregion  
        #region HeadSign
        /// <summary>
        /// Optional. The trip_headsign field contains the text that appears on a sign that 
        /// identifies the trip's destination to passengers. 
        /// Use this field to distinguish between different patterns of service in the same route. 
        /// If the headsign changes during a trip, you can override the trip_headsign by specifying 
        /// values for the the stop_headsign field in stop_times.txt.
        /// </summary>
        public string HeadSign { get{ return mHeadSign ;}}
        #endregion  
        #region ShortName
        /// <summary>
        /// Optional. The trip_short_name field contains the text that appears in schedules 
        /// and sign boards to identify the trip to passengers, for example, to identify train numbers for commuter rail trips. 
        /// If riders do not commonly rely on trip names, please leave this field blank. 
        /// </summary>
        public string ShortName
        {
            get { return mShortName; }
        }
        #endregion  
        #region DirectionID
        /// <summary>
        /// Optional. The direction_id field contains a binary value that indicates the direction of travel for a trip. 
        /// Use this field to distinguish between bi-directional trips with the same route_id. 
        /// This field is not used in routing; it provides a way to separate trips by direction when publishing time tables. 
        /// You can specify names for each direction with the trip_headsign field. 
        /// </summary>
        public DirectionType? DirectionID { get{ return mDirectionID ;}}
        #endregion  
        #region BlockID
        /// <summary>
        /// Optional. The block_id field identifies the block to which the trip belongs. 
        /// A block consists of two or more sequential trips made using the same vehicle, 
        /// where a passenger can transfer from one trip to the next just by staying in the vehicle. 
        /// The block_id must be referenced by two or more trips in trips.txt. 
        /// </summary>
        public string BlockID { get{ return mBlockID ;}}
        #endregion  
        #region ShapeID
        /// <summary>
        /// Optional. The shape_id field contains an ID that defines a shape for the trip. This value is referenced from the shapes.txt file. 
        /// The shapes.txt file allows you to define how a line should be drawn on the map to represent a trip. 
        /// </summary>
        public string ShapeID { get{ return mShapeID ;}}
        #endregion  
    }
}
