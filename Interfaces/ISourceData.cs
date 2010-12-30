using System;
using System.IO;
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
