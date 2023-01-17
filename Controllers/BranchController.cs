using aspcoremariadb.Models;
using aspcoremariadb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace aspcoremariadb.Controllers
{
    public class BranchController : Controller
    {
                public BranchController()
        {
            BranchRepo br = new BranchRepo();
        }

        [HttpGet]
        [Route("addnewbranch")]
        public IActionResult AddBranch()
        {

            return View();
        }

        [HttpPost]
        [Route("addAbranch")]
        public IActionResult AddBranch(Branch branch)
        {
                    if(branch.branch_name.Length<5)
            {
                ModelState.AddModelError("branch_name","Min Branch Length 5");
            }
                if(!ModelState.IsValid)
            {

                return Json(new
                {
                    success = false,
                    errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                                 .Select(m => m.ErrorMessage).ToArray()
                });
            }

            BranchRepo br = new BranchRepo(); 
            br.AddBranchs(branch);
                
            return Json(new
            {
                success = true,
                message = "Added Your branch"
            });
        }
        
        public IActionResult Branches()
        {
            return View();
        }


        [HttpPost]
        [Route("Allbranches")]
        public IActionResult MyBranches()
        {
            BranchRepo br = new BranchRepo();
            return Json(new
            {
                success = true,
                data = br.GetAllDetails(),
                message = "Branches Fetched Successfully"
            });
        }

    }
}
