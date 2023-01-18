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


        //for ajax call
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

        [Route("branches")]
        public IActionResult Branches()
        {
            return View();
        }

        //for ajax call
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

        [HttpPost]
        [Route("singlebranch")]
        public IActionResult GetSingleBranchDetails(Branch branch)
        {
            BranchRepo br = new BranchRepo();
            var blist = br.GetSingleBranch(branch.Id);
            if (blist != null)
            {
                return Json(new
                {
                    success = true,
                    data = blist,
                    message = "Record Fetched Successfully"
                }); ;
            }
            else
            {
                return Json(new
                {
                    success = false,
                    messagge="Not found"
                });
            }
        }


        [HttpPost]
        [Route("UpdateAbranch")]
        public IActionResult EditBranch(Branch branch)
        {
            if (branch.branch_name.Length < 5)
            {
                ModelState.AddModelError("branch_name", "Min Branch Length 5");
            }
            if (!ModelState.IsValid)
            {

                return Json(new
                {
                    success = false,
                    errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                                 .Select(m => m.ErrorMessage).ToArray()
                });
            }

            BranchRepo br = new BranchRepo();
            br.UpdateBranch(branch);

            return Json(new
            {
                success = true,
                message = "Updated Your branch"
            });
        }
        [HttpPost]
        [Route("destroy")]
                public IActionResult RemoveBranch(Branch branchreq)
        {
            BranchRepo br = new BranchRepo();
            if(br.Destroy(branchreq.Id))
            {
                return Json(new
                {
                    success = true,
                    message = "Branch Removed Successfully"

                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    message="Not found your branch"
                });
            }
        }


    }
}
