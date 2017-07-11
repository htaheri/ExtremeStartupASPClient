using System;
using System.IO;
using Nancy;

namespace NancyAspNetHost1.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
			Get["/Report"] = parameters =>
			{
				return View["index"];
			};
			
            Get["/"] = parameters => { return HandleQuery(parameters); };

        }

        private String HandleQuery(dynamic parameters)
        {
            String query = "Query: ";
            query += Request.Url.Query;


            WriteToLog(query) ;
            return query;
        }

        private void WriteToLog(string log)
        {
            string path = @"Content/request.log";

			using (StreamWriter sw = File.AppendText(path))
			{
				sw.WriteLine(log);

			}
			System.Diagnostics.Debug.WriteLine(log);
			//System.IO.File.WriteAllText(@"Content/request.log", log);
        }
    }
}