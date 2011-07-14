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
    /// This interface is used by classes that supply GTFS data.
    /// </summary>
    public interface ISourceData
    {
        Stream GetStream();
    }
}
