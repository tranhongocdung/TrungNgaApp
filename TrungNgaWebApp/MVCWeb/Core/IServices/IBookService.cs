using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWeb.Core.IServices
{
    public interface IBookService
    {
        DateTime GetLatestDateHavingTransport();
    }
}