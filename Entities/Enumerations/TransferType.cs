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
    /// The transfers field specifies the number of transfers permitted on this fare.
    /// </summary>
    public enum TransferType
    {
        /// <summary>
        /// No transfers permitted on this fare. 
        /// </summary>
        NoTransfers,
        /// <summary>
        /// Passenger may transfer once. 
        /// </summary>
        Once,
        /// <summary>
        /// Passenger may transfer twice. 
        /// </summary>
        Twice
    }
}
