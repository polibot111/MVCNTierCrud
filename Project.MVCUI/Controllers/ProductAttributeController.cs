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
    public class ProductAttributeController : Controller
    {
        ProductAttributeRepository _parep;

        public ProductAttributeController()
        {
            _parep = new ProductAttributeRepository();
        }
        public ActionResult AddAttributeToProduct()
        {
            ProductRepository _prep = new ProductRepository();
            AttributeRepository _arep = new AttributeRepository();
            ProductVM pvm = new ProductVM()
            {
                Products = _prep.GetActives(),
                PAttributes = _arep.GetActives(),
            };
            return View(pvm);
        }

        [HttpPost]
        public ActionResult AddAttributeToProduct(ProductAttribute productAttribute)
        {
            _parep.Add(productAttribute);
            return View("AddAttributeToProduct");
        }
    }
}