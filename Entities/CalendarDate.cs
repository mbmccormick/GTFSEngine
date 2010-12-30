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
    /// 
    /// </summary>
    public struct CalendarDate
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

        static CalendarDate()
        {
            sHeaders = new string[] { 
              "service_id"
            , "date"
            , "exception_type"
            };
            sHeaderOptional = new bool[] { 
              false//"service_id"
            , false//"date"
            , false//"exception_type"
            };
        }
        #endregion  
        #region Declarations
        string mServiceID;
        DateTime mDate;
        CalendarExceptionType mExceptionType;
        #endregion

        #region Constructor
        /// <summary>
        /// The struct constructor.
        /// </summary>
        /// <param name="ServiceID"></param>
        /// <param name="Date"></param>
        /// <param name="ExceptionType"></param>
        public CalendarDate(
            string ServiceID,
            DateTime Date,
            CalendarExceptionType ExceptionType          
            )
        {
            mServiceID = ServiceID;
            mDate=Date ;
            mExceptionType = ExceptionType;
        }
        #endregion  

        #region ServiceID
        /// <summary>
        /// Required. The service_id contains an ID that uniquely identifies a set of dates when a service exception is available for one or more routes. Each (service_id, date) pair can only appear once in calendar_dates.txt. If the a service_id value appears in both the calendar.txt and calendar_dates.txt files, the information in calendar_dates.txt modifies the service information specified in calendar.txt. This field is referenced by the trips.txt file.
        /// </summary>
        public string ServiceID { get { return mServiceID; } }
        #endregion  
        #region Date
        /// <summary>
        /// Required. The date field specifies a particular date when service availability is different than the norm. You can use the exception_type field to indicate whether service is available on the specified date.
        /// </summary>
        public DateTime Date { get{ return mDate ;}}
        #endregion  
        #region ExceptionType
        /// <summary>
        /// The exception_type indicates whether service is available on the date specified in the date field.
        /// </summary>
        public CalendarExceptionType ExceptionType { get{ return mExceptionType ;}}
        #endregion  
    }
}
