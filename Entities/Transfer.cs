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
    /// This struct defines the rules for making connections at transfer points between routes. 
    /// </summary>
    public struct Transfer
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

        static Transfer()
        {
            sHeaders = new string[] { 
              "from_stop_id"
            , "to_stop_id"
            , "transfer_type"
            , "min_transfer_time"
            };            
            
            sHeaderOptional = new bool[] { 
              false //"from_stop_id"
            , false //"to_stop_id"
            , false //"transfer_type"
            , true  //"min_transfer_time"
            };
        }
        #endregion  
        #region Declarations
        string mFromStopID;
        string mToStopID;
        TransferType mTransferType;
        int mMinTransferTime;
        #endregion  

        #region Constructor
        public Transfer(CSVRowItem item)
        {
            //from_stop_id,to_stop_id,transfer_type,min_transfer_time

            mFromStopID = item["from_stop_id"];
            mToStopID = item["to_stop_id"];

            switch (item["transfer_type"])
            {
                case "0":
                    mTransferType= GTFSEngine.TransferType.NoTransfers ;
                    break;
                case "1":
                    mTransferType= GTFSEngine.TransferType.Once ;
                    break;
                case "2":
                    mTransferType= GTFSEngine.TransferType.Twice ;
                    break;
                case "3":
                    mTransferType= GTFSEngine.TransferType.NoTransfers ;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("transfer_type",item["transfer_type"]);
            }

            mMinTransferTime = int.Parse(item["min_transfer_time"]); 
        }
        /// <summary>
        /// This is the default constructor.
        /// </summary>
        /// <param name="FromStopID"></param>
        /// <param name="ToStopID"></param>
        /// <param name="TransferType"></param>
        /// <param name="MinTransferTime"></param>
        public Transfer(
            string FromStopID,
            string ToStopID,
            TransferType TransferType,
            int MinTransferTime       
            )
        {
            mFromStopID=FromStopID ;
            mToStopID=ToStopID ;
            mTransferType=TransferType ;
            mMinTransferTime=MinTransferTime ;   
        }
        #endregion  

        /// <summary>
        /// Required. The from_stop_id field contains a stop ID that identifies a stop or station where a connection between routes begins. Stop IDs are referenced from the stops.txt file. If the stop ID refers to a station that contains multiple stops, this transfer rule applies to all stops in that station. 
        /// </summary>
        public string FromStopID
        {
            get { return mFromStopID; }
        }
        /// <summary>
        /// Required. The to_stop_id field contains a stop ID that identifies a stop or station where a connection between routes ends. Stop IDs are referenced from the stops.txt file. If the stop ID refers to a station that contains multiple stops, this transfer rule applies to all stops in that station. 
        /// </summary>
        public string ToStopID
        {
            get { return mToStopID; }
        }
        /// <summary>
        /// Required. The transfer_type field specifies the type of connection for the specified (from_stop_id, to_stop_id) pair.
        /// </summary>
        public TransferType TransferType
        {
            get { return mTransferType; }
        }
        /// <summary>
        /// Optional. When a connection between routes requires an amount of time between arrival and departure (transfer_type=2), the min_transfer_time field defines the amount of time that must be available in an itinerary to permit a transfer between routes at these stops. The min_transfer_time must be sufficient to permit a typical rider to move between the two stops, including buffer time to allow for schedule variance on each route. 
        /// </summary>
        public int MinTransferTime
        {
            get { return mMinTransferTime; }
        }
    }
}
