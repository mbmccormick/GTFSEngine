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
    /// This struct defines dates for service IDs using a weekly schedule. 
    /// Specify when service starts and ends, as well as days of the week where service is available. 
    /// </summary>
    public struct Calendar
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

        static Calendar()
        {
            sHeaders = new string[] { 
              "service_id"
            , "monday"
            , "tuesday"
            , "wednesday"
            , "thursday"
            , "friday"
            , "saturday"
            , "sunday"
            , "start_date"
            , "end_date"
            };

            sHeaderOptional = new bool[] { 
              false //"service_id"
            , false //"monday"
            , false //"tuesday"
            , false //"wednesday"
            , false //"thursday"
            , false //"friday"
            , false //"saturday"
            , false //"sunday"
            , false //"start_date"
            , false //"end_date"
            };
        }
        #endregion  
        #region Declarations
        string mServiceID;

        bool mMonday;
        bool mTuesday;
        bool mWednesday;
        bool mThursday;
        bool mFriday;
        bool mSaturday;
        bool mSunday;

        DateTime mDateStart;
        DateTime mDateEnd;
        #endregion  

        #region Constructor
        public Calendar(CSVRowItem item)
        {
            mServiceID = item["service_id"];
            mMonday = item["monday"] == "1";
            mTuesday = item["tuesday"] == "1";
            mWednesday = item["wednesday"] == "1";
            mThursday = item["thursday"] == "1";
            mFriday = item["friday"] == "1";
            mSaturday = item["saturday"] == "1";
            mSunday = item["sunday"] == "1"; 
            mDateStart = DateTime.MinValue;
            mDateEnd = DateTime.MinValue;

        }
        /// <summary>
        /// This is the default constructor for the Calendar entry.
        /// </summary>
        /// <param name="ServiceID"></param>
        /// <param name="Monday"></param>
        /// <param name="Tuesday"></param>
        /// <param name="Wednesday"></param>
        /// <param name="Thursday"></param>
        /// <param name="Friday"></param>
        /// <param name="Saturday"></param>
        /// <param name="Sunday"></param>
        /// <param name="DateStart"></param>
        /// <param name="DateEnd"></param>
        public Calendar(
            string ServiceID,
            bool Monday,
            bool Tuesday,
            bool Wednesday,
            bool Thursday,
            bool Friday,
            bool Saturday,
            bool Sunday,
            DateTime DateStart,
            DateTime DateEnd
        )
        {
            mServiceID= ServiceID;
            mMonday= Monday;
            mTuesday= Tuesday;
            mWednesday= Wednesday;
            mThursday= Thursday;
            mFriday= Friday;
            mSaturday= Saturday;
            mSunday= Sunday;
            mDateStart= DateStart;
            mDateEnd= DateEnd;
        }
        #endregion  


        #region ServiceID
        /// <summary>
        /// Required. The service_id contains an ID that uniquely identifies a set of dates when service is available for one or more routes. 
        /// Each service_id value can appear at most once in a calendar.txt file. This value is dataset unique. 
        /// It is referenced by the trips.txt file.
        /// </summary>
        public string ServiceID { get { return mServiceID; } }
        #endregion  

        /// <summary>
        /// Active on Monday.
        /// </summary>
        public bool Monday { get { return mMonday ; }  }
        /// <summary>
        /// Active on Tuesday.
        /// </summary>
        public bool Tuesday { get { return mTuesday ; }  }
        /// <summary>
        /// Active on Wednesday.
        /// </summary>
        public bool Wednesday { get { return mWednesday ; }  }
        /// <summary>
        /// Active on Thursday.
        /// </summary>
        public bool Thursday { get { return mThursday ; }  }
        /// <summary>
        /// Active on Friday.
        /// </summary>
        public bool Friday { get { return mFriday ; }  }
        /// <summary>
        /// Active on Saturday.
        /// </summary>
        public bool Saturday { get { return mSaturday ; }  }
        /// <summary>
        /// Active on Sunday.
        /// </summary>
        public bool Sunday { get { return mSunday ; }  }

        /// <summary>
        /// Required. The start_date field contains the start date for the service.
        /// </summary>
        public DateTime DateStart { get { return mDateStart ; }  }
        /// <summary>
        /// Required. The end_date field contains the end date for the service. This date is included in the service interval.
        /// </summary>
        public DateTime DateEnd { get { return mDateEnd ; }  }


    }
}
