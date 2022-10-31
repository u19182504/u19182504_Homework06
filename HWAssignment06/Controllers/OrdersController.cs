using HWAssignment06.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWAssignment06.Controllers
{
    public class OrdersController : Controller
    {
        BikeStoresContext db = new BikeStoresContext();

        public static List<OrderListViewModel> orderListViewModels = new List<OrderListViewModel>();
        // GET: Orders
        public ActionResult Index(DateTime? search)
        {
            orderListViewModels = new List<OrderListViewModel>();
            if (search == null)
            {
                foreach (var item in db.Orders.ToList())
                {
                    var order = new OrderListViewModel();

                    order.currentOrder = item;

                    foreach (var items in db.OrderItems.Where(x => x.OrderId == item.OrderId).Include(z => z.Product))
                    {
                        order.OrderItems.Add(items);
                    }

                    orderListViewModels.Add(order);

                }
            }
            else
            {
                foreach (var item in db.Orders.ToList().Where(x=>x.OrderDate == search))
                {
                    var order = new OrderListViewModel();

                    order.currentOrder = item;

                    foreach (var items in db.OrderItems.Where(x => x.OrderId == item.OrderId).Include(z => z.Product))
                    {
                        order.OrderItems.Add(items);
                    }

                    orderListViewModels.Add(order);

                }
            }
          

           
            return View(orderListViewModels);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orders/Edit/5
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

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
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
