﻿/// =================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: MIT
/// ==================================

using Blazor.SPA.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blazor.SPA.Services
{
    /// <summary>
    /// Service Class for managing Cusotm Routes and Runtime Layout Changes
    /// </summary>
    public class RouteViewService
    {
        /// <summary>
        /// List of Custom Routes
        /// </summary>
        public List<CustomRouteData> Routes { get; private set; } = new List<CustomRouteData>();

        /// <summary>
        /// Runtime Layout override
        /// </summary>
        public Type Layout { get; set; }

        /// <summary>
        /// Method to get a Custom route match if one exists
        /// </summary>
        /// <param name="url"></param>
        /// <param name="routeData"></param>
        /// <returns></returns>
        public bool GetRouteMatch(string url, out RouteData routeData)
        {
            var route = Routes?.FirstOrDefault(item => item.IsMatch(url)) ?? null;
            routeData = route?.RouteData ?? null;
            return route != null;
        }
    }
}
