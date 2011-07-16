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
    /// This field is not used in routing; it provides a way to separate trips by direction when publishing time tables. You can specify names for each direction with the trip_headsign field. 
    /// </summary>
    public enum DirectionType: int
    {
        /// <summary>
        /// 0 - travel in one direction (e.g. outbound travel) 
        /// </summary>
        Outbound = 0,
        /// <summary>
        /// 1 - travel in the opposite direction (e.g. inbound travel) 
        /// </summary>
        Inbound = 1
    }
}
