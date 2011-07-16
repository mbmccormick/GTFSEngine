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
    /// This is the agency structure.
    /// </summary>
    public struct Agency
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

        static Agency()
        {
            sHeaders = new string[] { 
              "agency_id"
            , "agency_name"
            , "agency_url"
            , "agency_timezone"
            , "agency_lang"
            , "agency_phone" 
            };

            sHeaderOptional = new bool[] { 
              true  //"agency_id"
            , false //"agency_name"
            , false //"agency_url"
            , false //"agency_timezone"
            , true  //"agency_lang"
            , true  //"agency_phone" 
            };
        }
        #endregion  

        #region Declarations
        private string mAgencyID;
        private string mName;
        private string mTimeZone;
        private string mPhone;

        private Uri mUrl;
        private string mLang;
        #endregion  

        #region Constructor
        /// <summary>
        /// This is the CSV item constructor.
        /// </summary>
        /// <param name="item">The csv item.</param>
        public Agency(CSVRowItem item)
        {
            mAgencyID = item["agency_id"];

            mName = item.ValidateNotEmptyOrNull("agency_name");
            mUrl = new Uri(item.ValidateNotEmptyOrNull("agency_url"));
            mTimeZone = item.ValidateNotEmptyOrNull("agency_timezone");

            mLang = item["agency_lang"];
            mPhone = item["agency_phone"];
        }
        /// <summary>
        /// This is the default constructor for the Agency construct.
        /// </summary>
        /// <param name="ID">The agency ID.</param>
        /// <param name="Name">The agency name.</param>
        /// <param name="TimeZone">The agency timezone description.</param>
        /// <param name="Phone">The agency phone number.</param>
        public Agency(
            string AgencyID, 
            string Name, 
            Uri Url,
            string TimeZone, 
            string Lang,
            string Phone)
        {
            mAgencyID   = AgencyID;
            mName       = Name;
            mUrl        = Url;
            mTimeZone   = TimeZone;
            mLang       = Lang;
            mPhone      = Phone;
        }
        #endregion  

        #region AgencyID
        /// <summary>
        /// Optional. The agency_id field is an ID that uniquely identifies a transit agency. A transit feed may represent data from more than one agency.
        /// The agency_id is dataset unique. This field is optional for transit feeds that only contain data for a single agency. 
        /// </summary>
        public string AgencyID { get { return mAgencyID; } }
        #endregion  
        #region Name
        /// <summary>
        /// Required. The agency_name field contains the full name of the transit agency. 
        /// </summary>
        public string Name { get { return mName; } }
        #endregion  
        #region Url
        /// <summary>
        /// Required. The agency_url field contains the URL of the transit agency.
        /// </summary>
        public Uri Url
        {
            get { return mUrl; }
        }
        #endregion  
        #region TimeZone
        /// <summary>
        /// Required. The agency_timezone field contains the timezone where the transit agency is located. 
        /// Timezone names never contain the space character but may contain an underscore. 
        /// Please refer to http://en.wikipedia.org/wiki/List_of_tz_zones for a list of valid values.
        /// </summary>
        public string TimeZone { get { return mTimeZone; } }
        #endregion  
        #region Lang
        /// <summary>
        /// Optional. The agency_lang field contains a two-letter ISO 639-1 code for the primary language used by this transit agency.
        /// </summary>
        public string Lang
        {
            get { return mLang; }
        }
        #endregion  
        #region Phone
        /// <summary>
        /// The agency phone number.
        /// </summary>
        public string Phone { get { return mPhone; } }
        #endregion  

    }
}
