﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MVCWeb.Core;
using MVCWeb.Core.Entities;

namespace MVCWeb.Libraries
{
    public static class Extension
    {
        public static string GetLast(this string source, int tailLength)
        {
            return tailLength >= source.Length ? source : source.Substring(source.Length - tailLength);
        }
        public static void CopyPropertiesTo(this object source, object destination)
        {
            PropertyInfo[] myObjectFields = source.GetType().GetProperties(
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Where(o=>!o.GetMethod.IsVirtual).ToArray();

            foreach (PropertyInfo fi in myObjectFields)
            {
                fi.SetValue(destination, fi.GetValue(source));
            }
        }
        public static ReturnLabel ToReturnLabel(this Customer source, bool full = true)
        {
            var label = new ReturnLabel
            {
                Id = source.Id.ToString(),
                Label = source.CustomerName +
                        (!string.IsNullOrEmpty(source.PhoneNo) ? " - " + source.PhoneNo : "") +
                        (!string.IsNullOrEmpty(source.Email) ? " - " + source.Email : "")
            };
            if (full)
            {
                label.Label +=
                    (!string.IsNullOrEmpty(source.Region) ? " - " + source.Region : "") +
                    (!string.IsNullOrEmpty(source.Area) ? " - " + source.Area : "");
            }
            return label;
        }
    }
}