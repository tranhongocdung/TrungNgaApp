using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWeb.AppDataLayer.IServices
{
    public interface IBookService
    {
        DateTime GetLatestDateHavingTransport();
    }
}