using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using IdentityCustom.Constant;
namespace IdentityCustom.Controllers
{
    public class RoleController : Controller
    {
        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult Index()
        {
            return View();
        }
        //[Authorize(Roles = "Administrator, Manager")]
        [Authorize(Roles = $"{Constant.Constants.Roles.Administrator},{Constant.Constants.Roles.Manager}")]
        public IActionResult Manager()
        {
            return View();
        }
        //[Authorize(Policy = "RequireAdmin")]
        [Authorize(Roles = $"{Constant.Constants.Roles.Administrator}")]
        public IActionResult Admin()
        {
            return View();
        }
    }
}
