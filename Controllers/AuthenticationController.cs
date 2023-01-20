﻿using aspcoremariadb.Models;
using aspcoremariadb.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace aspcoremariadb.Controllers
{
    public class AuthenticationController : Controller
    {


        public AuthenticationController() { }

        [Route("signup")]    
            public IActionResult Signup()
        {
             return   View();
        }

        [Route("signup")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Signup(User user)
        {
            if(ModelState.IsValid)
            {
                UserRepo ur = new UserRepo();
                if(ur.Registeration(user))
                {
                    TempData["msg"] = "User Registered Successfully";
                    TempData["alert"] = "alert alert-success";
                }
                else
                {
                    TempData["msg"] = "Oopps! Failed to register the user";
                    TempData["alert"]= "alert alert-ddanger";
                }
                return RedirectToAction("signin");
            }
            return View();
        }

        [Route("signin")]
        public IActionResult SignIn()
        {
            return View();
        }


        [HttpPost]
        [Route("signin")]
        public IActionResult SignIn(User user)
        {
            if(ModelState.IsValid)
            {
                UserRepo ur = new UserRepo();
                List<User> userdata = ur.IsUserExist(user);
                if(userdata.Count>0)
                {
                    //userdata[0].password;
                    TempData["msg"] = "Logged In Successfully";

                    HttpContext.Session.SetString("username", userdata[0].Email);
                    
                    var st = HttpContext.Session.GetString("username");
                    return RedirectToAction("AddBook");


                }
                else
                {
                    TempData["msg"] = "User not found";
                    TempData["alert"] = "alert alert-danger";

                }
            }
            return View();
        }
    }
}
