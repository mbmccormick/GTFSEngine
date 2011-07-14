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
#endregion
namespace Stancer.GTFSEngine
{
    /// <summary>
    /// This interface contains the data collections as a set of streams.
    /// </summary>
    public interface ISourceDataCollection
    {
        /// <summary>
        /// Returns the stream for the specific type.
        /// </summary>
        /// <param name="type">The transit file type.</param>
        /// <returns></returns>
        Stream GetStream(TransitFileType type);
        /// <summary>
        /// Specifies whether the stream is present.
        /// </summary>
        /// <param name="type">The transit file type.</param>
        /// <returns>Returns true if the file type is supported.</returns>
        bool HasStream(TransitFileType type);

        /// <summary>
        /// agency.txt - Required. This file contains information about one or more transit agencies that provide the data in this feed. 
        /// </summary>
        Stream Agency { get; }
        /// <summary>
        /// stops.txt - Required. This file contains information about individual locations where vehicles pick up or drop off passengers. 
        /// </summary>
        Stream Stops { get; }
        /// <summary>
        /// routes.txt - Required. This file contains information about a transit organization's routes. A route is a group of trips that are displayed to riders as a single service. 
        /// </summary>
        Stream Routes { get; }
        /// <summary>
        /// trips.txt - Required. This file lists all trips and their routes. A trip is a sequence of two or more stops that occurs at specific time. 
        /// </summary>
        Stream Trips { get; }
        /// <summary>
        /// stop_times.txt - Required. This file lists the times that a vehicle arrives at and departs from individual stops for each trip. 
        /// </summary>
        Stream StopTimes { get; }
        /// <summary>
        /// calendar.txt - Required. This file defines dates for service IDs using a weekly schedule. Specify when service starts and ends, as well as days of the week where service is available. 
        /// </summary>
        Stream Calendar { get; }

        /// <summary>
        /// calendar_dates.txt - Optional. This file lists exceptions for the service IDs defined in the calendar.txt file. If calendar_dates.txt includes ALL dates of service, this file may be specified instead of calendar.txt. 
        /// </summary>
        Stream CalendarDates { get; }
        /// <summary>
        /// Returns true if the optional data is present.
        /// </summary>
        bool HasCalendarDates { get; set; }

        /// <summary>
        /// fare_attributes.txt - Optional. This file defines fare information for a transit organization's routes. 
        /// </summary>
        Stream FareAttributes { get; }
        /// <summary>
        /// Returns true if the optional data is present.
        /// </summary>
        bool HasFareAttributes { get; set; }

        /// <summary>
        /// fare_rules.txt - Optional. This file defines the rules for applying fare information for a transit organization's routes. 
        /// </summary>
        Stream FareRules { get; }
        /// <summary>
        /// Returns true if the optional data is present.
        /// </summary>
        bool HasFareRules { get; set; }

        /// <summary>
        /// shapes.txt - Optional. This file defines the rules for drawing lines on a map to represent a transit organization's routes. 
        /// </summary>
        Stream Shapes { get; }
        /// <summary>
        /// Returns true if the optional data is present.
        /// </summary>
        bool HasShapes { get; set; }

        /// <summary>
        /// frequencies.txt - Optional. This file defines the headway (time between trips) for routes with variable frequency of service. 
        /// </summary>
        Stream Frequencies { get; }
        /// <summary>
        /// Returns true if the optional data is present.
        /// </summary>
        bool HasFrequencies { get; set; }

        /// <summary>
        /// transfers.txt - Optional. This file defines the rules for making connections at transfer points between routes. 
        /// </summary>
        Stream Transfers { get; }
        /// <summary>
        /// Returns true if the optional data is present.
        /// </summary>
        bool HasTransfers { get; set; }
    }
}
