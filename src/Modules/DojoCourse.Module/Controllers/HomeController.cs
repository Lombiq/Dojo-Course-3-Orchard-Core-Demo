using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OrchardCore.DisplayManagement.Notify;

namespace DojoCourse.Module.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer T;
        private readonly INotifier _notifier;
        private readonly IHtmlLocalizer H;
        private readonly ILogger<HomeController> _logger;


        public HomeController(
            IStringLocalizer<HomeController> stringLocalizer,
            INotifier notifier,
            IHtmlLocalizer<HomeController> htmlLocalizer,
            ILogger<HomeController> logger)
        {
            _notifier = notifier;
            _logger = logger;
            H = htmlLocalizer;
            T = stringLocalizer;
        }


        public ActionResult Index()
        {
            ViewData["Message"] = T["Hello world!"];

            _notifier.Success(H["Hello world!"]);

            _logger.LogError("Hello log!");

            return View();
        }
    }
}
