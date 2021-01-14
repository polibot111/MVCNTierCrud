using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class AttributeController : Controller
    {
        AttributeRepository _arep;

        public AttributeController()
        {
            
            _arep = new AttributeRepository();
        }
        public ActionResult AddAttribute()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAttribute(PAttribute pAttribute)
        {
            _arep.Add(pAttribute);
            return RedirectToAction("AddAttribute");
        }
    }
}