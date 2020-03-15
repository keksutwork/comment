using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Models;
using MessageBoard.Models.ViewModel;
using MessageBoard.Models.CRUDlib;
using MessageBoard.Models.Interfaces;
namespace MessageBoard.Controllers
{
    
    public class LoginController : Controller
    {
        string eniv = "LocalTest";
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Post : Login
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginViewModel userAccount)
        {
            if (ModelState.IsValid)
            {
                IAccountService service = AccountServiceFactory.CreateAccountService(eniv);
                Guid? guid = service.Login(userAccount);
                if(guid == null)
                {
                    ViewBag.Errmsg = "查無資料!";
                    return View();
                }
                else
                {
                    Session["UserId"] = guid.Value;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Errmsg = "資料輸入錯誤!";
                return View();
            }
        }

        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //Post : Register
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(LoginViewModel userAccount)
        {
            IAccountService service = AccountServiceFactory.CreateAccountService(eniv);
            
            if (service.HavaSameAccountName(userAccount.AccountName))
            {
                ViewBag.Errmsg = "帳號重複!";
                return View();
            }

            bool res = service.Regeister(userAccount);
            
            if (res)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Errmsg = "註冊錯誤!";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            Session["UserId"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}