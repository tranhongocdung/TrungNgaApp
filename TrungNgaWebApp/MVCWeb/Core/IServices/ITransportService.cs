﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MVCWeb.Core.Entities;

namespace MVCWeb.Core.IServices
{
    public interface ITransportService : IWebAppService
    {
        Transport GetById(int transportId);
        DateTime GetLatestDateHavingTransport();
        ICollection<SelectListItem> GetTransportDirectionsForSelectList();
        ICollection<SelectListItem> GetTransportsForSelectList(int day, int month, int year);
    }
}