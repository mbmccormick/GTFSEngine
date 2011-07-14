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
    /// This enumeration defines the transfer options between two routes.
    /// </summary>
    public enum TransferOptionsType
    {
        /// <summary>
        /// This is a recommended transfer point between two routes. 
        /// </summary>
        RecommendedTransferPoint,
        /// <summary>
        /// This is a timed transfer point between two routes. The departing 
        /// vehicle is expected to wait for the arriving one, with 
        /// sufficient time for a passenger to transfer between routes 
        /// </summary>
        TimedTransferPoint,
        /// <summary>
        /// This transfer requires a minimum amount of time between arrival 
        /// and departure to ensure a connection. The time required to 
        /// transfer is specified by min_transfer_time.
        /// </summary>
        TransferTimeRequired,
        /// <summary>
        /// Transfers are not possible between routes at this location.
        /// </summary>
        TransfersNotPossible
    }
}
