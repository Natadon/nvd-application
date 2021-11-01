using System;
using Nvd.DataAccess;
using Nvd.DataAccess.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Nvd.Data.RawProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            //var db = new NvdDataContext();
            // first, delete all existing records
            Console.WriteLine("Entering the using statement");
            using (var db = new NvdDataContext())
            {
                IList<NvdSearchResult> records = db.NvdSearchResults.ToList();

                foreach (var record in records)
                {
                    Console.WriteLine("Removing record number {0}", record.ID);
                    db.NvdSearchResults.Remove(record);
                }

                db.SaveChanges();

                IList<RawDownload> rawDownloads = db.RawDownloads.ToList();

                foreach (var item in rawDownloads)
                {
                    var result = JsonConvert.DeserializeObject<NvdSearchResult>(item.result);

                    Console.WriteLine("Processing ID number: {0}", item.ID);

                    db.NvdSearchResults.Add(result);
                    db.SaveChanges();
                }
            }
        }
    }
}
