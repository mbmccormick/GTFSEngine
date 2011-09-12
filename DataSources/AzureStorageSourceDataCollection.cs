using System;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Resources;

using Ximura;
using System.Globalization;
using Microsoft.WindowsAzure.StorageClient;

namespace Stancer.GTFSEngine
{
    public class AzureStorageSourceDataCollection : SourceDataCollectionBase
    {
        CloudBlobContainer mContainer;
        string mBlobRootPath;
        
        public AzureStorageSourceDataCollection(CloudBlobContainer container, string blobRootPath)
        {
            mContainer = container;
            mBlobRootPath = blobRootPath;
            
            Names
                .Where(i => mContainer.GetBlobReference(mBlobRootPath + "/" + i.Value + ".txt") != null)
                .ForEach(i => mStreams.Add(i.Key, ((Func<string, Stream>)GetStream).Curry()(i.Value)));

            var missing = Required.Except(mStreams.Keys);
            if (missing.Count() > 0)
                throw new ArgumentOutOfRangeException("Missing mandatory data.");
        }

        private Stream GetStream(string name)
        {
            MemoryStream data = new MemoryStream();
            mContainer.GetBlobReference(mBlobRootPath + "/" + name + ".txt").DownloadToStream(data);

            data.Seek(0, SeekOrigin.Begin);

            return data;
        }
    }
}
