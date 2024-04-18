using Microsoft.AspNetCore.Mvc.RazorPages;
using NLog;

namespace task.Pages
{
    public class BaseModel :PageModel
    {
        public void Warning(string message)
        {
            TempData["WarningMessage"] = message;
        }

        public void Success(string message)
        {
            TempData["SuccessMessage"] = message;
        }

        public static Logger log = LogManager.GetLogger("task");
    }
}
