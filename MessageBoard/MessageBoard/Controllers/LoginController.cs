using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Models.ViewModel;
using MessageBoard.Models.MethodLibaray;
using System.Configuration;
using MessageBoard.Models.AccountDataModel;
namespace MessageBoard.Controllers
{
    
    public class LoginController : Controller
    {
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
                IAccountLoginService service = AccountDataControl.CreateAccountLoginService();
                //嘗試LOGIN
                Guid? guid = service.Login(userAccount);

                //guid = null 代表查無帳號資料
                if(guid == null)
                {
                    ViewBag.ErrorMsg = "帳號或密碼錯誤!";
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
                ViewBag.ErrorMsg = "資料輸入錯誤!";
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
            IAccountRegisterService service = AccountDataControl.CreateAccountRegisterService();
            //確認帳號沒重複
            if (service.HavaSameAccountName(userAccount.AccountName))
            {
                ModelState.AddModelError("AccountName", "帳號重複");
                return View();
            }

            //註冊
            bool result = service.Regeister(userAccount);

            if (result)
            {
                //成功回首頁
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMsg = "註冊錯誤!";
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