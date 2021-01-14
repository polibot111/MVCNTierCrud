using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using Project.MVCUI.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository _prep;
        public ProductController()
        {
            _prep = new ProductRepository();
        }
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            _prep.Add(product);
            return RedirectToAction("AddAttribute", "Attribute");
        }

        public ActionResult ProductAndAttributeList(int? id)
        {
            ProductAttributeRepository _parep = new ProductAttributeRepository();
            ProductVM pvm = new ProductVM()
            {
                ProductAttributes = id == null ? _parep.GetActives() : _parep.Where(x => x.ProductID == id),
                Products = _prep.GetActives()
            };
            return View(pvm);
        }
    }
}