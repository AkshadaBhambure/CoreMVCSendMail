using Microsoft.AspNetCore.Mvc;
using CoreMVCSendMail.Models;
using CoreMVCSendMail.Services;
using NuGet.Configuration;
namespace CoreMVCSendMail.Controllers
{
    public class SampleController : Controller
    {
        IExtraService extraService;
        public SampleController(IExtraService extraService)
        {
            this.extraService = extraService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(EmailModel model)
        {
            extraService.SendEmail(model);
            ModelState.Clear();
            ViewBag.msg = "Email Sent Successfully";
            return View();
        }
    }
}
