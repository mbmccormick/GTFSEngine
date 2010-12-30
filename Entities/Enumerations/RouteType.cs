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
    /// The route_type field describes the type of transportation used on a route.
    /// </summary>
    public enum RouteType:int
    {
        /// <summary>
        /// Tram, Streetcar, Light rail. Any light rail or street level system within a metropolitan area. 
        /// </summary>
        Tram = 0,
        /// <summary>
        /// Subway, Metro. Any underground rail system within a metropolitan area. 
        /// </summary>
        Subway = 1,
        /// <summary>
        /// Rail. Used for intercity or long-distance travel. 
        /// </summary>
        Rail = 2,
        /// <summary>
        /// Bus. Used for short- and long-distance bus routes. 
        /// </summary>
        Bus = 3,
        /// <summary>
        /// Ferry. Used for short- and long-distance boat service. 
        /// </summary>
        Ferry = 4,
        /// <summary>
        /// Cable car. Used for street-level cable cars where the cable runs beneath the car. 
        /// </summary>
        CableCar = 5,
        /// <summary>
        /// Gondola, Suspended cable car. Typically used for aerial cable cars where the car is suspended from the cable. 
        /// </summary>
        Gondala = 6,
        /// <summary>
        /// Funicular. Any rail system designed for steep inclines. 
        /// </summary>
        Fenicular = 7
    }
}
