using System;
using Nancy;

namespace NancyAspNetHost1.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters => { return handleQuery(parameters); };

            //Get["/"] = parameters =>
            //{
            //    return View["index"];
            //};


        }
        private String handleQuery(dynamic parameters)
        {
            String query = "Query: ";
            query += Request.Url.Query;

            System.Diagnostics.Debug.WriteLine(query);
            //Debug.WriteLine(query);
            return query;
        }

    }
}