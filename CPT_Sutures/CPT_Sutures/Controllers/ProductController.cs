using CPT_Sutures.Models;
using System;
using System.Collections.Generic;
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
            return Json(new { success = true, data = GetList() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FilterProduct(ProductModel product)
        {
            try
            {
                var _data = GetList();

                if (!String.IsNullOrEmpty(product.ProductName))
                {
                    _data = _data.Where(x => CompareString(x.ProductName, product.ProductName)).ToList();
                }
                if (!String.IsNullOrEmpty(product.Descrip))
                {
                    _data = _data.Where(x => CompareString(x.Descrip, product.Descrip)).ToList();
                }
                if (!String.IsNullOrEmpty(product.CategoryName))
                {
                    _data = _data.Where(x => CompareString(x.CategoryName, product.CategoryName)).ToList();
                }
                if (!String.IsNullOrEmpty(product.TypeName))
                {
                    _data = _data.Where(x => CompareString(x.TypeName, product.TypeName)).ToList();
                }
                if (product.FromPrice > 0)
                {
                    _data = _data.Where(x => x.FromPrice >= product.FromPrice).ToList();
                }
                if (product.ToPrice > 0)
                {
                    _data = _data.Where(x => x.ToPrice <= product.ToPrice).ToList();
                }
                if (product.CategoryId > 0)
                {
                    _data = _data.Where(x => x.CategoryId == product.CategoryId).ToList();
                }
                if (product.TypeId > 0)
                {
                    _data = _data.Where(x => x.TypeId == product.TypeId).ToList();
                }

                return Json(new { success = true, data = _data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult SearchProduct(string searchString)
        {
            try
            {
                var _data = GetList();

                if (!String.IsNullOrEmpty(searchString))
                {
                    _data = _data.Where(x => CompareString(x.ProductName, searchString) ||
                                CompareString(x.Descrip, searchString) ||
                                CompareString(x.CategoryName, searchString) ||
                                CompareString(x.TypeName, searchString)
                                ).ToList();
                }

                return Json(new { success = true, data = _data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, data = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }

        public List<ProductModel> GetList()
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
            return _data;
        }

        public string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
            "đ",
            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
            "í","ì","ỉ","ĩ","ị",
            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
            "ý","ỳ","ỷ","ỹ","ỵ",};
                    string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
            "d",
            "e","e","e","e","e","e","e","e","e","e","e",
            "i","i","i","i","i",
            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
            "u","u","u","u","u","u","u","u","u","u","u",
            "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }

        public bool CompareString(string str1, string str2)
        {
            var check = (RemoveUnicode(str1).ToLower().Contains(RemoveUnicode(str2).ToLower()));
            return check;
        }
    }
}