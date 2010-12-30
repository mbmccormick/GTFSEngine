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
    /// This struct contains information about individual locations where vehicles pick up or drop off passengers. 
    /// </summary>
    public struct Stop
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

        static Stop()
        {
            sHeaders = new string[] { 
              "stop_id"
            , "stop_code"
            , "stop_name"
            , "stop_desc"
            , "stop_lat"
            , "stop_lon"
            , "zone_id"
            , "stop_url"
            , "location_type"
            , "parent_station"
            };

            sHeaderOptional = new bool[] { 
              false //"stop_id"
            , true  //"stop_code"
            , false //"stop_name"
            , true  //"stop_desc"
            , false //"stop_lat"
            , false //"stop_lon"
            , true  //"zone_id"
            , true  //"stop_url"
            , true  //"location_type"
            , true  //"parent_station"
            };
        }
        #endregion  

        #region Declarations
        string mID;
        string mCode;

        string mName;
        string mDesc;
        decimal? mLat;
        decimal? mLon;
        string mZoneID;
        string mUrl;

        LocationType? mLocationType;
        string mParentStation;
        #endregion

        #region Constructor
        public Stop(CSVRowItem item)
        {
            mID = item["stop_id"];
            mCode = item["stop_code"];
            mName = item["stop_name"];
            mDesc = item["stop_desc"];
            mLon = decimal.Parse(item["stop_lon"]);
            mLat = decimal.Parse(item["stop_lat"]);
            mZoneID = item["zone_id"];

            //string url = item["stop_url"];
            //mUrl = (url == null || url == "") ? (Uri)null : new Uri(url);

            mUrl = item["stop_url"];
            if (item["location_type"]=="1")
                mLocationType = Stancer.GTFSEngine.LocationType.Station;
            else
                mLocationType = Stancer.GTFSEngine.LocationType.Stop;

            mParentStation = item["parent_station"];
        }
        /// <summary>
        /// This struct contains information about individual locations where vehicles pick up or drop off passengers. 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Code"></param>
        /// <param name="Name"></param>
        /// <param name="Desc"></param>
        /// <param name="Lon"></param>
        /// <param name="Lat"></param>
        /// <param name="ZoneID"></param>
        /// <param name="Url"></param>
        /// <param name="LocationType"></param>
        /// <param name="ParentStation"></param>
        public Stop(
            string ID,
            string Code,
            string Name,
            string Desc,
            decimal? Lon,
            decimal? Lat,
            string ZoneID,
            string Url,
            LocationType? LocationType,
            string ParentStation
            )
        {
            mID=ID ;
            mCode = Code;
            mName = Name;
            mDesc = Desc;
            mLon=Lon ;
            mLat=Lat ;
            mZoneID = ZoneID;
            mUrl=Url ;
            mLocationType = LocationType;
            mParentStation = ParentStation;
        }
        #endregion  

        #region ID
        /// <summary>
        /// Required. The stop_id field contains an ID that uniquely identifies a stop or station. Multiple routes may use the same stop. 
        /// The stop_id is dataset unique.
        /// </summary>
        public string ID { get{ return mID ;}}
        #endregion  
        #region Code
        /// <summary>
        /// Optional. The stop_code field contains short text or a number that uniquely identifies the stop for passengers. 
        /// Stop codes are often used in phone-based transit information systems or printed on stop signage to make it easier 
        /// for riders to get a stop schedule or real-time arrival information for a particular stop. 
        /// </summary>
        public string Code
        {
            get { return mCode; }
        }
        #endregion  

        #region Name
        /// <summary>
        /// Required. The stop_name field contains the name of a stop or station. 
        /// Please use a name that people will understand in the local and tourist vernacular. 
        /// </summary>
        public string Name { get{ return mName ;}}
        #endregion  
        #region Desc
        /// <summary>
        /// Optional. The stop_desc field contains a description of a stop. Please provide useful, quality information. 
        /// Do not simply duplicate the name of the stop.
        /// </summary>
        public string Desc { get{ return mDesc ;}}
        #endregion  
        #region Lon
        /// <summary>
        /// Required. The stop_lon field contains the longitude of a stop or station.
        /// The field value must be a valid WGS 84 longitude value from -180 to 180.
        /// </summary>
        public decimal? Lon { get{ return mLon ;}}
        #endregion  
        #region Lat
        /// <summary>
        /// Required. The stop_lat field contains the latitude of a stop or station. 
        /// The field value must be a valid WGS 84 latitude.
        /// </summary>
        public decimal? Lat { get{ return mLat ;}}
        #endregion  
        #region ZoneID
        /// <summary>
        /// Optional. The zone_id field defines the fare zone for a stop ID. Zone IDs are required if you want to provide fare information using fare_rules.txt. 
        /// If this stop ID represents a station, the zone ID is ignored. 
        /// </summary>
        public string ZoneID { get{ return mZoneID ;}}
        #endregion  
        #region Url
        /// <summary>
        /// Optional. The stop_url field contains the URL of a web page about a particular stop. 
        /// This should be different from the agency_url and the route_url fields. 
        /// </summary>
        public string Url { get{ return mUrl ;}}
        #endregion  

        #region LocationType
        /// <summary>
        /// Optional. The location_type field identifies whether this stop ID represents a stop or station. 
        /// If no location type is specified, or the location_type is blank, stop IDs are treated as stops. 
        /// Stations may have different properties from stops when they are represented on a map or used in trip planning. 
        /// </summary>
        public LocationType? LocationType
        {
            get { return mLocationType; }
        }
        #endregion  
        #region ParentStation
        /// <summary>
        /// Optional. For stops that are physically located inside stations, 
        /// the parent_station field identifies the station associated with the stop. 
        /// To use this field, stops.txt must also contain a row where this stop ID is assigned location type=1. 
        /// </summary>
        public string ParentStation
        {
            get { return mParentStation; }
        }
        #endregion  
    }
}
