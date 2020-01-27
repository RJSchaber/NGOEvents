﻿using NGOassignment.Models;
using System;
using System.Web.Mvc;

namespace NGOassignment.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserNGO users)
        {
            if (ModelState.IsValid)
            {
                String message = users.LoginProcess(users.UserID, users.Password);
                if (message.Equals("1"))
                {
                    return RedirectToAction("Index", "UserNGOes");
                }
                else if (message.Equals("2"))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.ErrorMessage = message;
            }
            return View(users);
        }
    }
}