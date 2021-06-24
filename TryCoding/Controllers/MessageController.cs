using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TryCoding.Models;
using TryCoding.Models.GenericRepository;

namespace TryCoding.Controllers
{
    public class MessageController : Controller
    {
        TryCodingDBEntities db = new TryCodingDBEntities();
        Repository<Table_message> ta = new Repository<Table_message>();

        public JsonResult GetMessages() {
                var messages = db.Table_message.OrderByDescending(d=> d.mTime).ToList();
                return new JsonResult { Data = messages, JsonRequestBehavior = JsonRequestBehavior.AllowGet };   
        }

        public JsonResult SearchMember(string member) {
            var list = ta.getAll().Where(m => m.mMember == member).Select(m => new 
            {
                Member = m.mMember,
                Message = m.mMessage,
                Time = m.mTime,
            });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}