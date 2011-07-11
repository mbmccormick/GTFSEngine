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
                return TransitEntityEnum<Agency>(TransitFileType.Agency, Agency.Headers, CSVRowItemToAgency);
            }
        }

        private Agency CSVRowItemToAgency(CSVRowItem item)
        {
            return new Agency(item);
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
                return TransitEntityEnum<Route>(TransitFileType.Routes, Route.Headers, CSVRowItemToRoute);
            }
        }

        private Route CSVRowItemToRoute(CSVRowItem item)
        {
            return new Route(item);
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
                return TransitEntityEnum<Trip>(TransitFileType.Trips, Trip.Headers, CSVRowItemToTrip);
            }
        }

        private Trip CSVRowItemToTrip(CSVRowItem item)
        {
            return new Trip(item);
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
                return TransitEntityEnum<Stop>(TransitFileType.Stops, Stop.Headers, CSVRowItemToStop);
            }
        }

        private Stop CSVRowItemToStop(CSVRowItem item)
        {
            return new Stop(item);
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
                return TransitEntityEnum<Calendar>(TransitFileType.Calendar, Calendar.Headers, CSVRowItemToCalendar);
            }
        }

        private Calendar CSVRowItemToCalendar(CSVRowItem item)
        {
            return new Calendar();
        }
        #endregion

        #region CalendarDates
        /// <summary>
        /// The transit calendar dates.
        /// </summary>
        public IEnumerable<CalendarDate> CalendarDates
        {
            get
            {
                return TransitEntityEnum<CalendarDate>(TransitFileType.CalendarDates, CalendarDate.Headers, CSVRowItemToCalendarDate);
            }
        }

        private CalendarDate CSVRowItemToCalendarDate(CSVRowItem item)
        {
            return new CalendarDate(item);
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
                return TransitEntityEnum<Shape>(TransitFileType.Shapes, Shape.Headers, CSVRowItemToShape);
            }
        }

        private Shape CSVRowItemToShape(CSVRowItem item)
        {
            return new Shape(item);
        }
        #endregion
    
    }
}
