using Microsoft.AspNetCore.Mvc;

namespace CoreMVCSendMail.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
