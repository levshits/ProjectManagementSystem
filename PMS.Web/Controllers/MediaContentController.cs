using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Levshits.Web.Common.Controllers;

namespace PMS.Web.Controllers
{
    public class MediaContentController: PrivateController
    {
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), Guid.NewGuid().ToString());
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }
    }
}