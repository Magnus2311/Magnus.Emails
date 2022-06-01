using Magnus.Emails.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Magnus.Emails.Interfaces
{
    public interface IViewRenderService
    {
        Task<string> RenderToStringAsync<T>(string viewName, T model);
    }
}
