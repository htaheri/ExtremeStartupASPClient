using System;
using System.IO;
using Nancy;

namespace NancyAspNetHost1.Modules
{
    public class IndexModule : NancyModule
    {
        static string GlobalLog;
        public IndexModule()
        {
			Get["/Home"] = parameters =>
			{
				return View["index"];
			};
			Get["/Report"] = parameters =>
            {
	            return View["report"];
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
            GlobalLog += "\\r\\n" + log;
            //string path = @"Content/request.log";

			//using (StreamWriter sw = File.AppendText(path))
			//{
			//	sw.WriteLine(log);

			//}

			System.Diagnostics.Debug.WriteLine(log);
			//System.IO.File.WriteAllText(@"Content/request.log", log);
        }
    }
}