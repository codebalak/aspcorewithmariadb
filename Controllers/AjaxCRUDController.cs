using Microsoft.AspNetCore.Mvc;
using aspcoremariadb.Repository;

namespace aspcoremariadb.Controllers
{
    public class AjaxCRUDController : Controller
    {
        public JsonResult getbooks()
        {
            DemoCrudRepo d = new DemoCrudRepo();

            

            return Json(d.GetAllDetails());
            //return View();
        }
        public JsonResult getbook(int id)
        {
            DemoCrudRepo d = new DemoCrudRepo();

            return Json(d.GetSingleBook(id));
        }
    }
}
