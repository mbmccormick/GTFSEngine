using System;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Resources;

using Ximura;
using System.Globalization;
using Microsoft.WindowsAzure.StorageClient;
using System.Collections.Generic;

namespace Stancer.GTFSEngine
{
    public class DictionarySourceDataCollection : SourceDataCollectionBase
    {
        Dictionary<string, Stream> mData;

        public DictionarySourceDataCollection(Dictionary<string, Stream> data)
        {
            mData = data;

            Names
                .Where(i => mData.Keys.Contains(i.Value) == true)
                .ForEach(i => mStreams.Add(i.Key, ((Func<string, Stream>)GetStream).Curry()(i.Value)));

            var missing = Required.Except(mStreams.Keys);
            if (missing.Count() > 0)
            {
                if (!(missing.Count() == 1 && missing.Contains(TransitFileType.Calendar) == true))
                    throw new ArgumentOutOfRangeException("Missing mandatory data.");
            }
        }

        private Stream GetStream(string name)
        {
            return mData[name];
        }
    }
}
