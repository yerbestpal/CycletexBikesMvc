// name: Ross McLean
// date: 16/05/20

using System.Web.Mvc;

namespace CycletexBikesMvc.Controllers
{
    /// <summary>
    /// Home controller
    /// Manages functionality related to the Index page
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns the Index view
        /// </summary>
        /// <returns>Index view</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}