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
    /// The payment_method field indicates when the fare must be paid.
    /// </summary>
    public enum PaymentMethodType: int
    {
        /// <summary>
        /// Fare is paid on board. 
        /// </summary>
        PayOnboard = 0,
        /// <summary>
        /// Fare must be paid before boarding. 
        /// </summary>
        PayBefore = 1
    }
}
