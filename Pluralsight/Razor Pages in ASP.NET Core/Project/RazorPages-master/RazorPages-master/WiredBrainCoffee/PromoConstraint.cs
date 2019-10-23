using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WiredBrainCoffee
{
    public class PromoConstraint : IRouteConstraint
    {
        public bool Match(  HttpContext httpContext, 
                            IRouter route, 
                            string routeKey, 
                            RouteValueDictionary values, 
                            RouteDirection routeDirection)
        {
            var letterCount = 0;
            var numCount = 0;
            var sum = 0;

            foreach(var unit in values["token"].ToString())
            {
                letterCount += Char.IsLetter(unit) ? 1 : 0;
                numCount += char.IsDigit(unit) ? 1 : 0;
                sum += char.IsDigit(unit) ? int.Parse(unit.ToString()) : 0;
            }

            return letterCount == 3 && numCount == 3 && sum % 3 == 0;
        }
    }
}
