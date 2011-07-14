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
    /// This struct defines the rules for drawing lines on a map to represent a transit organization's routes. 
    /// </summary>
    public struct Shape
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

        static Shape()
        {
            sHeaders = new string[] { 
              "service_id"
            , "shape_pt_lat"
            , "shape_pt_lon"
            , "shape_pt_sequence"
            , "shape_dist_traveled"
            };
            sHeaderOptional = new bool[] { 
              false //"service_id"
            , false //"shape_pt_lat"
            , false //"shape_pt_lon"
            , false //"shape_pt_sequence"
            , true  //"shape_dist_traveled"
            };
        }
        #endregion 
        #region Declarations
        string mID;
        decimal mPtLat;
        decimal mPtLon;
        int mPtSequence;
        string mDistTraveled;
        #endregion  

        #region Constructor
        /// <summary>
        /// shape_id,shape_pt_lat,shape_pt_lon,shape_pt_sequence,shape_dist_traveled
        /// </summary>
        /// <param name="item"></param>
        public Shape(CSVRowItem item)
        {
            mID = item["shape_id"];
            mPtLat = decimal.Parse(item["shape_pt_lat"]);
            mPtLon = decimal.Parse(item["shape_pt_lon"]);
            mPtSequence = int.Parse(item["shape_pt_sequence"]);
            mDistTraveled = item["shape_dist_traveled"];
        }
        
        /// <summary>
        /// This is the constructor for the Shape.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="PtLat"></param>
        /// <param name="PtLon"></param>
        /// <param name="PtSequence"></param>
        /// <param name="DistTraveled"></param>
        public Shape(
            string ID,
            decimal PtLat,
            decimal PtLon,
            int PtSequence,
            string DistTraveled       
            )
        {
            mID=ID ;
            mPtLat=PtLat ;
            mPtLon=PtLon ;
            mPtSequence=PtSequence ;
            mDistTraveled=DistTraveled ;
        }
        #endregion  

        /// <summary>
        /// Required. The shape_id field contains an ID that uniquely identifies a shape. 
        /// </summary>
        public string ID
        {
            get { return mID; }
        }
        /// <summary>
        /// Required. The shape_pt_lat field associates a shape point's latitude with a shape ID. The field value must be a valid WGS 84 latitude. Each row in shapes.txt represents a shape point in your shape definition.
        /// </summary>
        public decimal PtLat
        {
            get { return mPtLat; }
        }
        /// <summary>
        /// Required. The shape_pt_lon field associates a shape point's longitude with a shape ID. The field value must be a valid WGS 84 longitude value from -180 to 180. Each row in shapes.txt represents a shape point in your shape definition.
        /// </summary>
        public decimal PtLon
        {
            get { return mPtLon; }
        }
        /// <summary>
        /// Required. The shape_pt_sequence field associates the latitude and longitude of a shape point with its sequence order along the shape. The values for shape_pt_sequence must be non-negative integers, and they must increase along the trip.
        /// </summary>
        public int PtSequence
        {
            get { return mPtSequence; }
        }
        /// <summary>
        /// Optional. When used in the shapes.txt file, the shape_dist_traveled field positions a shape point as a distance traveled along a shape from the first shape point. The shape_dist_traveled field represents a real distance traveled along the route in units such as feet or kilometers. This information allows the trip planner to determine how much of the shape to draw when showing part of a trip on the map. The values used for shape_dist_traveled must increase along with shape_pt_sequence: they cannot be used to show reverse travel along a route. 
        /// </summary>
        public string DistTraveled
        {
            get { return mDistTraveled; }
        }
    }
}
