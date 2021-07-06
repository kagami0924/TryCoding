using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TryCoding.Models;
using TryCoding.Models.GenericRepository;

namespace TryCoding.Controllers
{
    public class MemberController : Controller
    {
        TryCodingDBEntities db = new TryCodingDBEntities();
        Repository<Table_Member> mb = new Repository<Table_Member>();

        // CreateMember
        [HttpPost]
        public JsonResult CreateMember(string Email, string NickName, string Password)
        {

            string result = "";
            var EmailCheck = db.Table_Member.FirstOrDefault(e => e.MEmail == Email);
            var NickNameCheck = db.Table_Member.FirstOrDefault(n => n.MName == NickName);

            if (EmailCheck != null)
            {
                if (NickNameCheck != null)
                {
                    result = "信箱及暱稱已被註冊";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                result = "信箱已被註冊";
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            if (NickNameCheck != null)
            {
                result = "此暱稱已被使用";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Table_Member m = new Table_Member()
            {
                MEmail = Email,
                MName = NickName,
                MPassword = Password
            };
            mb.create(m);
            result = "註冊成功";
            return Json(result, JsonRequestBehavior.AllowGet);    
            }           
        }


        [HttpPost]
        public JsonResult LogInCheck(string Email, string Password, bool RememberMe)
        {

            string result = "";
            var EmailCheck = db.Table_Member.FirstOrDefault(e => e.MEmail == Email);
            var PasswordCheck = EmailCheck.MPassword;

            if (EmailCheck == null)
            {
                result = "查無此帳號";
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            if (EmailCheck != null)
            {
                if (PasswordCheck == Password)
                {

                    result = "登入成功";

                    if (RememberMe == true)
                    {
                        HttpCookie cookie = new HttpCookie("User");

                        cookie["UserEmail"] = EmailCheck.MEmail;

                        cookie["UserPWD"] = EmailCheck.MPassword;

                        cookie["UserName"] = EmailCheck.MName;

                        cookie.Expires = DateTime.Now.AddDays(3);

                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        HttpCookie cookie = new HttpCookie("User");

                        cookie["UserEmail"] = "";

                        cookie["UserPWD"] = "";

                        cookie["UserName"] = EmailCheck.MName;

                        cookie.Expires = DateTime.Now.AddDays(3);

                        Response.Cookies.Add(cookie);
                    }

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                if (PasswordCheck != Password)
                {
                    result = "密碼不正確";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            return Json("");
        }

    }
}