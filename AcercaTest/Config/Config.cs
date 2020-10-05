using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcercaTest.Config {
  public static class Config {
    public static string GetBaseFilePath() {
      return System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Vehicles");
    }
  }
}