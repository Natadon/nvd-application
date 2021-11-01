using System;
using RestSharp;
using Newtonsoft.Json;
using Nvd.DataAccess;
using Nvd.DataAccess.Objects;
using System.Threading;

namespace nvd_dowloader
{
    class Program
    {
        //static NvdSearchResult results;

        static void Main(string[] args)
        {
            int startIndex = 0;
            int endIndex = 100;
            int resultsPerPage = 1000;
            
            //Console.WriteLine("Hello World!");
            string url = "https://services.nvd.nist.gov/rest/json/cves/1.0?startIndex={0}&resultsPerPage={1}";

            while(startIndex < endIndex)
            {
                var client = new RestClient(string.Format(url, startIndex, resultsPerPage));
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);

                var item = JsonConvert.DeserializeObject<RawDownload_Stats>(response.Content);
                endIndex = item.totalResults;
                startIndex = startIndex + resultsPerPage;
                RawDownload rawDownload = new RawDownload();
                rawDownload.result = response.Content;
                rawDownload.resultsPerPage = item.resultsPerPage;
                rawDownload.startIndex = item.startIndex;
                rawDownload.totalResults = item.totalResults;

                NvdDataContext db = new NvdDataContext();
                db.RawDownloads.Add(rawDownload);
                db.SaveChanges();
                Console.Write("Saved index: {0} to the database", startIndex);
                //Console.WriteLine(response.Content);

                Thread.Sleep(5000);
            }
            

            //results = JsonConvert.DeserializeObject<NvdSearchResult>(response.Content);

            //NvdDataContext db = new NvdDataContext();

            //db.NvdSearchResults.Add(results);
            //db.SaveChanges();
        }
    }
}
