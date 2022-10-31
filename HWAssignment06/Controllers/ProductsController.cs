using HWAssignment06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HWAssignment06.Controllers
{
    public partial class ProductsController : Controller
    {
        BikeStoresContext db = new BikeStoresContext();
        static List<product2> productsViewModel = new List<product2>();
        public static List<detailsvm> detailsvms = new List<detailsvm>();
        // GET: Products
        public ActionResult Index(string Search)
        {

            detailsvms = new List<detailsvm>();
            productsViewModel = new List<product2>();
            List<Brands> brands = db.Brands.ToList();
            List<Categories> cats = db.Categories.ToList();
            List<Stores> stores = db.Stores.ToList();
            List<Stocks> stocks = db.Stocks.ToList();
            foreach (var item in db.Products.ToList())
            {
                var thing = new product2();
                thing.id = item.ProductId;
                thing.BrandName = brands.FirstOrDefault(x => x.BrandId == item.BrandId).BrandName;
                thing.CategoryName = cats.FirstOrDefault(x => x.CategoryId == item.CategoryId).CategoryName;
                thing.ListPrice = item.ListPrice;
                thing.ModelYear = item.ModelYear;
                thing.ProductName = item.ProductName;
                thing.brandID = item.BrandId;
                thing.categoryID = item.CategoryId;
                
                foreach (var things in stores)
                {
                    if (stocks.FirstOrDefault(x=>x.ProductId == item.ProductId && x.StoreId == things.StoreId)!=null)
                    {
                        detailsvms.Add(new detailsvm
                        {
                            productid = item.ProductId,
                            store = things.StoreName,
                            quant = (int)stocks.FirstOrDefault(x => x.ProductId == item.ProductId && x.StoreId == things.StoreId).Quantity
                        });


                    }
                }

                  thing.detailsvms = detailsvms;

                    productsViewModel.Add(thing);
            }



            if(Search!=null)
            {
                return View(productsViewModel.Where(x => x.ProductName.ToLower().Contains(Search.ToLower())));
            }
           

            return View(productsViewModel);
        }

        [HttpGet]
        public JsonResult GetBrands()
        {

            var examples = db.Brands.ToList();
            return Json(examples, JsonRequestBehavior.AllowGet); 
        }


        [HttpGet]
        public JsonResult GetID(int id)
        {
            var examples = productsViewModel.FirstOrDefault(x => x.id == id);

            return Json(examples, JsonRequestBehavior.AllowGet); 

        }

        [HttpGet]
        public JsonResult delete(int id)
        {
            var deleteobj = db.Products.FirstOrDefault(x => x.ProductId == id);
            db.Products.Remove(deleteobj);
            db.SaveChanges();
            productsViewModel.Remove(productsViewModel.First(x => x.id == id));
            return Json(productsViewModel, JsonRequestBehavior.AllowGet); 
        }

        [HttpGet]
        public JsonResult GetCategories()
        {
            //----------- Edit Here -----------

            var examples = db.Categories.ToList();
            return Json(examples, JsonRequestBehavior.AllowGet); // <<<<<<<<< You will need to change this to a Json return.
        }

        [HttpPost]
        public ActionResult Create(string Name, string id, string  price, int brandId, int categoryID, string year)
        {
            //----------- Edit Here -----------

            if (id == "")
            {
                var product = new Products()
                {
                    ProductName = Name,
                    ListPrice = Convert.ToDecimal(price),
                    BrandId = brandId,
                    CategoryId = categoryID,
                    ModelYear = (short)Convert.ToInt32(year)

                };

                db.Products.Add(product);
                db.SaveChanges();
            }
            else
            {
                int ID = Convert.ToInt32(id);
                var item =db.Products.FirstOrDefault(x => x.ProductId == ID);
                item.ProductName = Name;
                item.ListPrice = Convert.ToDecimal(price.Replace(".", ","));
                item.BrandId = Convert.ToInt32(brandId);
                item.CategoryId = Convert.ToInt32(categoryID);
                item.ModelYear = (short)Convert.ToInt32(year);
                db.SaveChanges();
            }

            //ExampleTable obj = new ExampleTable();

            //obj.SimpleAttribute = SimpleAttribute;
            //db.ExampleTables.Add(obj);
            //await db.SaveChangesAsync();
            var examples = db.Products.ToList();
            return Json(examples, JsonRequestBehavior.AllowGet);
        }


        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

   

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
