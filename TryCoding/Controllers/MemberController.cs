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
        public JsonResult CreateMember(string Email, string NickName, string Password) {

            string result = "";
            var EmailCheck = db.Table_Member.FirstOrDefault(e => e.MEmail == Email);
            var NickNameCheck = db.Table_Member.FirstOrDefault(n => n.MName == NickName);

            if (EmailCheck != null) {
                if (NickNameCheck != null) {
                    result = "信箱及暱稱已被註冊";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                result = "信箱已被註冊";
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            if (NickNameCheck != null) {
                result = "此暱稱已被使用";
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            Table_Member m = new Table_Member() {
                MEmail = Email,
                MName = NickName,
                MPassword = Password
            };
            mb.create(m);
            result = "註冊成功";
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult LogInCheck(string Email, string Password, bool RememberMe) {

            string result = "";
            var EmailCheck = db.Table_Member.FirstOrDefault(e => e.MEmail == Email);
            var PasswordCheck = db.Table_Member.FirstOrDefault(p => p.MPassword == Password);

            if (EmailCheck != null) {
                if (PasswordCheck != null) {
                    result = "信箱及暱稱已被註冊";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                result = "信箱已被註冊";
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            if (PasswordCheck != null) {
                result = "此暱稱已被使用";
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return
        }

    }
}