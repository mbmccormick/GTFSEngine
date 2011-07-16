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
    /// The fare_rules struct allows you to specify how fares in fare_attributes.txt apply to an itinerary.
    /// </summary>
    public struct FareRule
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

        static FareRule()
        {
            sHeaders = new string[] { 
              "fare_id"
            , "route_id"
            , "origin_id"
            , "destination_id"
            , "contains_id"
            };

            sHeaderOptional = new bool[] { 
              false //"fare_id"
            , true  //"route_id"
            , true  //"origin_id"
            , true  //"destination_id"
            , true  //"contains_id"
            };
        }
        #endregion 

        #region Declarations
        string mFareID;
        string mRouteID;
        string mOriginID;
        string mDestinationID;
        string mContainsID;
        #endregion  

        #region Constructor
        /// <summary>
        /// This constructor sets the default values from the CSVRowItem.
        /// </summary>
        /// <param name="item">The item.</param>
        public FareRule(CSVRowItem item)
        {
            mFareID = item.ValidateNotEmptyOrNull("fare_id");

            mRouteID = item["route_id"];
            mOriginID = item["origin_id"];
            mDestinationID = item["destination_id"];
            mContainsID = item["contains_id"];

        }
        /// <summary>
        /// This is the default constructor.
        /// </summary>
        /// <param name="FareID"></param>
        /// <param name="RouteID"></param>
        /// <param name="OriginID"></param>
        /// <param name="DestinationID"></param>
        /// <param name="ContainsID"></param>
        public FareRule(
            string FareID,
            string RouteID,
            string OriginID,
            string DestinationID,
            string ContainsID         
            )
        {
            mFareID=FareID ;
            mRouteID=RouteID ;
            mOriginID=OriginID ;
            mDestinationID=DestinationID ;
            mContainsID=ContainsID ;
        }
        #endregion  

        /// <summary>
        /// Required. The fare_id field contains an ID that uniquely identifies a fare class. 
        /// </summary>
        public string FareID
        {
            get { return mFareID; }
        }
        /// <summary>
        /// Optional. The route_id field associates the fare ID with a route. Route IDs are referenced from the routes.txt file. If you have several routes with the same fare attributes, create a row in fare_rules.txt for each route. 
        /// </summary>
        public string RouteID
        {
            get { return mRouteID; }
        }
        /// <summary>
        /// Optional. The origin_id field associates the fare ID with an origin zone ID. Zone IDs are referenced from the stops.txt file. If you have several origin IDs with the same fare attributes, create a row in fare_rules.txt for each origin ID.
        /// </summary>
        public string OriginID
        {
            get { return mOriginID; }
        }
        /// <summary>
        /// Optional. The destination_id field associates the fare ID with a destination zone ID. Zone IDs are referenced from the stops.txt file. If you have several destination IDs with the same fare attributes, create a row in fare_rules.txt for each destination ID.
        /// </summary>
        public string DestinationID
        {
            get { return mDestinationID; }
        }
        /// <summary>
        /// Optional. The contains_id field associates the fare ID with a zone ID, referenced from the stops.txt file. The fare ID is then associated with itineraries that pass through every contains_id zone. 
        /// </summary>
        public string ContainsID
        {
            get { return mContainsID; }
        }
    }
}
