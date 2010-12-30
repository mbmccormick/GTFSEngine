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
    /// Stations may have different properties from stops when they are represented on a map or used in trip planning. 
    /// </summary>
    public enum LocationType:int
    {
        /// <summary>
        /// Stop. A location where passengers board or disembark from a transit vehicle. 
        /// </summary>
        Stop = 0,
        /// <summary>
        /// Station. A physical structure or area that contains one or more stop. 
        /// </summary>
        Station = 1
    }
}
