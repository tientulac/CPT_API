using CPT_Sutures.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CPT_Sutures.Controllers
{
    public class ProductController : Controller
    {
        private LinqDataContext db = new LinqDataContext();

        // GET: Product
        public ActionResult Index()
        {
            var _data = (from a in db.Products
                         select new ProductModel
                         {
                             ProductId = a.ProductId,
                             ProductName = a.ProductName,
                             Descrip = a.Descrip,
                             Image = a.Image,
                             CategoryId = a.CategoryId,
                             TypeId = a.TypeId,
                             Price = a.Price,
                             CategoryName = db.Categories.Where(c => c.CategoryId == a.CategoryId).FirstOrDefault().CategoryName ?? "Other",
                             TypeName = db.Types.Where(c => c.TypeId == a.TypeId).FirstOrDefault().TypeName ?? "Other",
                         }).ToList();
            return Json(new { success = true, data = _data }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SearchProduct(ProductModel product)
        {
            try
            {
                var _data = (from a in db.Products
                             select new ProductModel
                             {
                                 ProductId = a.ProductId,
                                 ProductName = a.ProductName,
                                 Descrip = a.Descrip,
                                 Image = a.Image,
                                 CategoryId = a.CategoryId,
                                 TypeId = a.TypeId,
                                 Price = a.Price,
                                 CategoryName = db.Categories.Where(c => c.CategoryId == a.CategoryId).FirstOrDefault().CategoryName ?? "Other",
                                 TypeName = db.Types.Where(c => c.TypeId == a.TypeId).FirstOrDefault().TypeName ?? "Other",
                             }).ToList();

                if (!String.IsNullOrEmpty(product.ProductName))
                {
                    _data = _data.Where(x => x.ProductName.ToLower().Contains(product.ProductName.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(product.Descrip))
                {
                    _data = _data.Where(x => x.Descrip.ToLower().Contains(product.Descrip.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(product.CategoryName))
                {
                    _data = _data.Where(x => x.CategoryName.ToLower().Contains(product.CategoryName.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(product.TypeName))
                {
                    _data = _data.Where(x => x.TypeName.ToLower().Contains(product.TypeName.ToLower())).ToList();
                }
                if (product.FromPrice > 0)
                {
                    _data = _data.Where(x => x.FromPrice >= product.FromPrice).ToList();
                }
                if (product.ToPrice > 0)
                {
                    _data = _data.Where(x => x.ToPrice <= product.ToPrice).ToList();
                }

                return Json(new { success = true, data = _data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult FilterProduct(ProductModel product)
        {
            try
            {
                var _data = (from a in db.Products
                             select new ProductModel
                             {
                                 ProductId = a.ProductId,
                                 ProductName = a.ProductName,
                                 Descrip = a.Descrip,
                                 Image = a.Image,
                                 CategoryId = a.CategoryId,
                                 TypeId = a.TypeId,
                                 Price = a.Price,
                                 CategoryName = db.Categories.Where(c => c.CategoryId == a.CategoryId).FirstOrDefault().CategoryName ?? "Other",
                                 TypeName = db.Types.Where(c => c.TypeId == a.TypeId).FirstOrDefault().TypeName ?? "Other",
                             }).ToList();

                if (!String.IsNullOrEmpty(product.ProductName))
                {
                    _data = _data.Where(x => x.ProductName.ToLower().Contains(product.ProductName.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(product.Descrip))
                {
                    _data = _data.Where(x => x.Descrip.ToLower().Contains(product.Descrip.ToLower())).ToList();
                }
                if (product.CategoryId > 0)
                {
                    _data = _data.Where(x => x.CategoryId == product.CategoryId).ToList();
                }
                if (product.TypeId > 0)
                {
                    _data = _data.Where(x => x.TypeId == product.TypeId).ToList();
                }
                if (product.FromPrice > 0)
                {
                    _data = _data.Where(x => x.FromPrice >= product.FromPrice).ToList();
                }
                if (product.ToPrice > 0)
                {
                    _data = _data.Where(x => x.ToPrice <= product.ToPrice).ToList();
                }

                return Json(new { success = true, data = _data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, data = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}