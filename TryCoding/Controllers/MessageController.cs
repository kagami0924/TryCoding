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

        public JsonResult GetMessages()
        {
            var messages = db.Table_message.OrderByDescending(d => d.mTime).ToList();
            return new JsonResult { Data = messages, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult SearchMember(string member)
        {

            if (member == "")
            {
                var list = db.Table_message.OrderByDescending(d => d.mTime).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var list = ta.getAll().Where(m => m.mMember.Contains(member)).Select(m => new
                {
                    Id = m.mId,
                    Member = m.mMember,
                    Message = m.mMessage,
                    Time = m.mTime,
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }

        }


        public void CreateMessage(string member, string message)
        {
            Table_message Message = new Table_message();
            Message.mMember = member;
            Message.mMessage = message;
            Message.mTime = DateTime.Now;

            ta.create(Message);
        }

        [HttpPost]
        public void UpdateMessage(int Id, string message)
        {
            var data = db.Table_message.Where(m => m.mId == Id).FirstOrDefault();
            if (data != null)
            {
                data.mMessage = message;
                db.SaveChanges();
            }
        }

        [HttpGet]
        public void DeletMessage(int Id)
        {
            var message = db.Table_message.Where(m => m.mId == Id).FirstOrDefault();
            if (message != null)
            {
                db.Table_message.Remove(message);
                db.SaveChanges();
            }
        }

    }
}