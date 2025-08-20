using CoreMVCSendMail.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCSendMail.Controllers
{

    public class StudentController : Controller
    {
        CiitsocialDbContext db;
        public StudentController(CiitsocialDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {

            return View(db.Tblstudents.ToList());
        }
    }
}
