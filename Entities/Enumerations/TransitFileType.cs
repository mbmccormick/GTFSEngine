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
#endregion  
namespace Stancer.GTFSEngine
{
    /// <summary>
    /// This enumeration contains the supported transit files type .
    /// </summary>
    public enum TransitFileType
    {
        /// <summary>
        /// This file contains information about one or more transit agencies that provide the data in this feed. 
        /// </summary>
        Agency,
        /// <summary>
        /// This file contains information about individual locations where vehicles pick up or drop off passengers.
        /// </summary>
        Stops,
        /// <summary>
        /// This file contains information about a transit organization's routes. A route is a group of trips that are displayed to riders as a single service. 
        /// </summary>
        Routes,
        /// <summary>
        /// This file lists all trips and their routes. A trip is a sequence of two or more stops that occurs at specific time. 
        /// </summary>
        Trips,
        /// <summary>
        /// This file lists the times that a vehicle arrives at and departs from individual stops for each trip. 
        /// </summary>
        Stop_Times,
        /// <summary>
        /// This file defines dates for service IDs using a weekly schedule. Specify when service starts and ends, as well as days of the week where service is available. 
        /// </summary>
        Calendar,
        /// <summary>
        /// This file lists exceptions for the service IDs defined in the calendar.txt file. If calendar_dates.txt includes ALL dates of service, this file may be specified instead of calendar.txt. 
        /// </summary>
        Calendar_Dates,
        /// <summary>
        /// This file defines fare information for a transit organization's routes. 
        /// </summary>
        Fare_Attributes,
        /// <summary>
        /// This file defines the rules for applying fare information for a transit organization's routes. 
        /// </summary>
        Fare_Rules,
        /// <summary>
        /// This file defines the rules for drawing lines on a map to represent a transit organization's routes. 
        /// </summary>
        Shapes,
        /// <summary>
        /// This file defines the headway (time between trips) for routes with variable frequency of service. 
        /// </summary>
        Frequencies,
        /// <summary>
        /// This file defines the rules for making connections at transfer points between routes. 
        /// </summary>
        Transfers
    }
}
