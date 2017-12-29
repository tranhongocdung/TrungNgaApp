using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWeb.Libraries
{
    public static class Utility
    {
        public static void SetSession(string sessionName, object sessionValue)
        {
            HttpContext.Current.Session[sessionName] = sessionValue;
        }
        public static void RemoveSession(string sessionName)
        {
            HttpContext.Current.Session.Remove(sessionName);
        }
        public static object GetSession(string sessionName)
        {
            return HttpContext.Current.Session[sessionName];
        }
        public static List<int> StringToIntList(this string s)
        {
            if (s == null) return new List<int>();
            try
            {
                return s.Split(',').Select(int.Parse).ToList();
            }
            catch (Exception)
            {
                return new List<int>();
            }
        }
    }
}