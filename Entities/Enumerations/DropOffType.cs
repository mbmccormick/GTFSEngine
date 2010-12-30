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
    /// The drop_off_type field indicates whether passengers are dropped off at a stop as part of the normal schedule or whether a drop off at the stop is not available.
    /// </summary>
    public enum DropOffType
    {
        /// <summary>
        /// Regularly scheduled pickup
        /// </summary>
        RegularlyScheduled = 0,
        /// <summary>
        /// No pickup available
        /// </summary>
        NoPickupAvailable = 1,
        /// <summary>
        /// Must phone agency to arrange pickup
        /// </summary>
        MustPhone = 2,
        /// <summary>
        /// Must coordinate with driver to arrange pickup
        /// </summary>
        MustAskDriver = 3
    }
}
