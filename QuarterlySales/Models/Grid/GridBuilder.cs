using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace QuarterlySales.Models
{
    public class GridBuilder
    {
        protected const string RouteKey = "currentroute";

        protected RouteDictionary routes { get; set; }
        protected ISession session { get; set; }

        public GridBuilder(ISession sess)
        {
            session = sess;
            routes = session.GetObject<RouteDictionary>(RouteKey) ?? new RouteDictionary();
        }

        public GridBuilder(ISession sess, GridDTO values, string defaultSortField)
        {
            session = sess;

            routes = new RouteDictionary();
            routes.SortField = values.SortField ?? defaultSortField;
            routes.SortDirection = values.SortDirection;

            SaveRouteSegments();
        }

        public void SaveRouteSegments() => session.SetObject<RouteDictionary>(RouteKey, routes);

        public RouteDictionary CurrentRoute => routes;
    }
}
