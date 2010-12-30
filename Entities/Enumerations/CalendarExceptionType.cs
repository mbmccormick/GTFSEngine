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
using System;
namespace Stancer.GTFSEngine
{
    /// <summary>
    /// The exception_type indicates whether service is available on the date specified in the date field.
    /// </summary>
    public enum CalendarExceptionType:int
    {
        /// <summary>
        /// Indicates that service has been added for the specified date. 
        /// </summary>
        ServiceAdded    = 1,
        /// <summary>
        /// Indicates that service has been removed for the specified date. 
        /// </summary>
        ServiceRemoved  = 2
    }
}
