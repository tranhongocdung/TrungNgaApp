using System;

namespace MVCWeb.Core.IServices
{
    public interface IBookService : IWebAppService
    {
        DateTime GetLatestDateHavingTransport();
    }
}