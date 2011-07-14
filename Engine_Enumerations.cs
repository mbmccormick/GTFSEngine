#region Copyright
// *******************************************************************************
// Copyright (c) 2000-2011 Paul Stancer.
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
using System.IO;
using System.Collections;
using System.Collections.Generic;

using Stancer.GTFSEngine.Entities;

using Ximura;
#endregion
namespace Stancer.GTFSEngine
{
    public partial class Engine
    {
        #region Agencies
        /// <summary>
        /// This is a collection of the agency entities.
        /// </summary>
        public IEnumerable<Agency> Agencies
        {
            get
            {
                return TransitEntityEnum<Agency>(TransitFileType.Agency, Agency.Headers, (c)=>new Agency(c));
            }
        }
        #endregion

        #region Routes
        /// <summary>
        /// The transit routes.
        /// </summary>
        public IEnumerable<Route> Routes
        {
            get
            {
                return TransitEntityEnum<Route>(TransitFileType.Routes, Route.Headers, (i) => new Route(i));
            }
        }
        #endregion

        #region Trips
        /// <summary>
        /// The transit trips.
        /// </summary>
        public IEnumerable<Trip> Trips
        {
            get
            {
                return TransitEntityEnum<Trip>(TransitFileType.Trips, Trip.Headers, (c) => new Trip(c));
            }
        }
        #endregion

        #region Stops
        /// <summary>
        /// The transit stops.
        /// </summary>
        public IEnumerable<Stop> Stops
        {
            get
            {
                return TransitEntityEnum<Stop>(TransitFileType.Stops, Stop.Headers, (c)=>new Stop(c));
            }
        }
        #endregion

        #region Calendars
        /// <summary>
        /// The transit calendar.
        /// </summary>
        public IEnumerable<Calendar> Calendars
        {
            get
            {
                return TransitEntityEnum<Calendar>(TransitFileType.Calendar, Calendar.Headers, (c)=>new Calendar(c));
            }
        }
        #endregion

        #region Calendar_Dates
        /// <summary>
        /// The transit calendar dates.
        /// </summary>
        public IEnumerable<CalendarDate> Calendar_Dates
        {
            get
            {
                return TransitEntityEnum<CalendarDate>(TransitFileType.Calendar_Dates
                    , CalendarDate.Headers, (c)=>new CalendarDate(c));
            }
        }
        #endregion  

        #region Fare_Attributes
        /// <summary>
        /// The transit calendar dates.
        /// </summary>
        public IEnumerable<FareAttribute> Fare_Attributes
        {
            get
            {
                return TransitEntityEnum<FareAttribute>(TransitFileType.Fare_Attributes
                    , FareAttribute.Headers, (c) => new FareAttribute(c));
            }
        }
        #endregion  

        #region Shapes
        /// <summary>
        /// The transit routes.
        /// </summary>
        public IEnumerable<Shape> Shapes
        {
            get
            {
                return TransitEntityEnum<Shape>(TransitFileType.Shapes, Shape.Headers, (c)=>new Shape(c));
            }
        }
        #endregion
    
    }
}
