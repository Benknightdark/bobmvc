﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BOB_MVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").
                    Include("~/Scripts/jquery-1.*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").
                Include("~/Scripts/bootstrap*"));
            bundles.Add(new StyleBundle("~/Content/bootstrapcss").
                Include("~/Content/bootstrap*"));
            
        }
    }
}