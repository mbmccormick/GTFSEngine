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
    /// This struct contains information about a transit organization's route. A route is a group of trips that are displayed to riders as a single service. 
    /// </summary>
    public struct Route
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

        static Route()
        {
            sHeaders = new string[] { 
              "route_id"
            , "agency_id"
            , "route_short_name"
            , "route_long_name"
            , "route_desc"
            , "route_type"
            , "route_url"
            , "route_color"
            , "route_text_color"
            };

            sHeaderOptional = new bool[] { 
              false //"route_id"
            , true  //"agency_id"
            , false //"route_short_name"
            , false //"route_long_name"
            , true  //"route_desc"
            , false //"route_type"
            , true  //"route_url"
            , true  //"route_color"
            , true  //"route_text_color"
            };
        }
        #endregion  

        #region Declarations
        private string mRouteID;
        private string mAgencyID;
        private string mShortName;
        private string mLongName;
        private string mDesc;
        private RouteType mRouteType;
        private Uri mRouteUrl;
        private string mRouteColor;
        private string mRouteTextColor;
        #endregion  

        #region Constructor
        /// <summary>
        /// This is the CSV row item constructor.
        /// </summary>
        /// <param name="item">The CSV row item.</param>
        public Route(CSVRowItem item)
        {
            mRouteID = item.ValidateNotEmptyOrNull("route_id");

            mAgencyID = item["agency_id"];

            mLongName = item["route_long_name"];
            mShortName = item["route_short_name"];

            if ((mShortName == null || mShortName == "") && (mLongName == null || mLongName == ""))
                throw new ArgumentException("Must specify either route_long_name or route_short_name");

            if (mShortName == null || mShortName == "")
                mShortName = mLongName;
            else if (mLongName == null || mLongName == "")
                mLongName = mShortName;

            mDesc = item["route_desc"];

            mRouteType=item["route_type"].ToRouteType();

            string url = item["route_url"];
            mRouteUrl = url == null || url ==""?null:new Uri(url);

            mRouteColor = item["route_color"];
            mRouteTextColor = item["route_text_color"];
        }
        /// <summary>
        /// This is the required constructor for the type.
        /// </summary>
        /// <param name="RouteID"></param>
        /// <param name="AgencyID"></param>
        /// <param name="NameShort"></param>
        /// <param name="NameLong"></param>
        /// <param name="Description"></param>
        /// <param name="RouteType"></param>
        /// <param name="RouteColor"></param>
        /// <param name="RouteTextColor"></param>
        /// <param name="RouteUrl"></param>
        public Route(
            string RouteID,
            string AgencyID,
            string NameShort,
            string NameLong,
            string Description,
            RouteType RouteType,
            string RouteColor,
            string RouteTextColor,
            Uri RouteUrl          
            )
        {
            mRouteID=RouteID ;
            mAgencyID = AgencyID;

            mShortName=NameShort ;
            mLongName=NameLong ;
            mDesc=Description ;

            mRouteType=RouteType ;
            mRouteUrl=RouteUrl ;
            mRouteColor=RouteColor ;
            mRouteTextColor=RouteTextColor ;
        }
        #endregion  

        #region RouteID
        /// <summary>
        /// Required. The route_id field contains an ID that uniquely identifies a route. The route_id is dataset unique.
        /// </summary>
        public string RouteID
        {
            get { return mRouteID; }
        }
        #endregion  
        #region AgencyID
        /// <summary>
        /// Optional. The agency_id field defines an agency for the specified route. This value is referenced from the agency.txt file. Use this field when you are providing data for routes from more than one agency. 
        /// </summary>
        public string AgencyID
        {
            get { return mAgencyID; }
        }
        #endregion  

        #region ShortName
        /// <summary>
        /// Required. The route_short_name contains the short name of a route. 
        /// This will often be a short, abstract identifier like "32", "100X", or "Green" that riders use to identify a route, 
        /// but which doesn't give any indication of what places the route serves. 
        /// If the route does not have a short name, 
        /// please specify a route_long_name and use an empty string as the value for this field. 
        /// </summary>
        public string ShortName
        {
            get { return mShortName; }
        }
        #endregion  
        #region LongName
        /// <summary>
        /// Required. The route_long_name contains the full name of a route. 
        /// This name is generally more descriptive than the route_short_name 
        /// and will often include the route's destination or stop. 
        /// If the route does not have a long name, please specify a 
        /// route_short_name and use an empty string as the value for this field.
        /// </summary>
        public string LongName
        {
            get { return mLongName; }
        }
        #endregion  
        #region Desc
        /// <summary>
        /// Optional. The route_desc field contains a description of a route. Please provide useful, quality information. Do not simply duplicate the name of the route. For example, "A trains operate between Inwood-207 St, Manhattan and Far Rockaway-Mott Avenue, Queens at all times. Also from about 6AM until about midnight, additional A trains operate between Inwood-207 St and Lefferts Boulevard (trains typically alternate between Lefferts Blvd and Far Rockaway)." 
        /// </summary>
        public string Desc
        {
            get { return mDesc; }
        }
        #endregion  

        #region RouteType
        /// <summary>
        /// Required. The route_type field describes the type of transportation used on a route.
        /// </summary>
        public RouteType RouteType
        {
            get { return mRouteType; }
        }
        #endregion  
        #region RouteUrl
        /// <summary>
        /// Optional. The route_url field contains the URL of a web page about that particular route. 
        /// This should be different from the agency_url.
        /// </summary>
        public Uri RouteUrl
        {
            get { return mRouteUrl; }
        }
        #endregion  
        #region RouteColor
        /// <summary>
        /// Optional. In systems that have colors assigned to routes, the route_color field defines a color that corresponds to a route. The color must be provided as a six-character hexadecimal number, for example, 00FFFF. If no color is specified, the default route color is white (FFFFFF).
        /// </summary>
        public string RouteColor
        {
            get { return mRouteColor; }
        }
        #endregion  
        #region RouteTextColor
        /// <summary>
        /// Optional. The route_text_color field can be used to specify a legible color to use for text drawn against a background of route_color. The color must be provided as a six-character hexadecimal number, for example, FFD700. If no color is specified, the default text color is black (000000).
        /// </summary>
        public string RouteTextColor
        {
            get { return mRouteTextColor; }
        }
        #endregion  
    }
}
