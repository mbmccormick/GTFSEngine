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
using System.Text;

using Stancer.GTFSEngine.Entities;

using Ximura;
#endregion
namespace Stancer.GTFSEngine
{
    /// <summary>
    /// This class provides extension methods to help decode and convert string values to their system type.
    /// </summary>
    public static class Helper
    {
        public static string ValidateNotEmptyOrNull(this CSVRowItem item, string field)
        {
            string data = item[field];

            if (data == null || data == "")
                throw new ArgumentNullException(string.Format(@"Missing mandatory field ""{0}"" at line {1}", field, item.LineID));

            return data;
        }

        public static TimeSpan ToTimeSpan(this string item)
        {
            int hours=0, mins=0, secs=0;

            if ((item.Length == 8 && 
                (
                    int.TryParse(item.Substring(0, 2), out hours) ||
                    int.TryParse(item.Substring(3, 2), out mins) ||
                    int.TryParse(item.Substring(6, 2), out secs)
                ))
                || 
                (item.Length == 7 && 
                (
                    int.TryParse(item.Substring(0, 1), out hours) ||
                    int.TryParse(item.Substring(2, 2), out mins) ||
                    int.TryParse(item.Substring(5, 2), out secs)
                )))
                return new TimeSpan(hours, mins, secs);

            throw new ArgumentException("The string is not the correct format.");     
        }

        public static DateTime ToDate(this string item)
        {
            if (item.Length != 8)
                throw new ArgumentOutOfRangeException("The length of the string should be 8 characters.");

            return new DateTime(
                int.Parse(item.Substring(0, 4)),
                int.Parse(item.Substring(4, 2)),
                int.Parse(item.Substring(6, 2)));
        }

        public static LocationType ToLocationType(this string item)
        {
            switch (item)
            {
                case "":
                case "0":
                    return LocationType.Stop;
                case "1":
                    return LocationType.Station;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static RouteType ToRouteType(this string item)
        {
            switch (item)
            {
                case "0":
                    return RouteType.Tram;
                case "1":
                    return RouteType.Subway;
                case "2":
                    return RouteType.Rail;
                case "3":
                    return RouteType.Bus;
                case "4":
                    return RouteType.Ferry;
                case "5":
                    return RouteType.CableCar;
                case "6":
                    return RouteType.Gondala;
                case "7":
                    return RouteType.Fenicular;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("{0} is not supported for Route type.", item));
            }
        }

        public static DropOffType ToDropOffType(this string item)
        {
            switch(item)
            {
                case "0":
                    return DropOffType.RegularlyScheduled;
                case "1":
                    return DropOffType.NoPickupAvailable;
                case "2":
                    return DropOffType.MustPhone;
                case "3":
                    return DropOffType.MustAskDriver;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        public static TransferOptionsType ToTransferOptionsType(this string item)
        {
            switch (item)
            {
                case "":
                case "0":
                    return TransferOptionsType.RecommendedTransferPoint;
                case "1":
                    return TransferOptionsType.TimedTransferPoint;
                case "2":
                    return TransferOptionsType.TransferTimeRequired;
                case "3":
                    return TransferOptionsType.TransfersNotPossible;
                default:
                    throw new ArgumentOutOfRangeException("transfer_type", item);
            }

        }

        public static DirectionType? ToDirectionType(this string item)
        {
            switch (item)
            {
                case "0":
                    return DirectionType.Outbound;
                case "1":
                    return DirectionType.Inbound;
                default:
                    return null;
            }

        }

        public static PickUpType ToPickUpType(this string item)
        {
            switch (item)
            {
                case "0":
                    return PickUpType.RegularlyScheduled;
                case "1":
                    return PickUpType.NoPickupAvailable;
                case "2":
                    return PickUpType.MustPhone;
                case "3":
                    return PickUpType.MustAskDriver;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        public static CalendarExceptionType ToCalendarExceptionType(this string item)
        {
            switch (item)
            {
                case "1":
                    return CalendarExceptionType.ServiceAdded;
                case "2":
                    return CalendarExceptionType.ServiceRemoved;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static PaymentMethodType ToPaymentMethodType(this string item)
        {
            switch (item)
            {
                case "0":
                    return PaymentMethodType.PayOnboard;
                case "1":
                    return PaymentMethodType.PayBefore;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static TransferType ToTransferType(this string item)
        {
            switch (item)
            {
                case "0":
                    return TransferType.NoTransfers;
                case "1":
                    return TransferType.Once;
                case "2":
                    return TransferType.Twice;
                case "":
                    return TransferType.Unlimited;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
