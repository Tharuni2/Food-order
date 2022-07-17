using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_order.Models;
using Food_order.Controllers;

namespace Food_order.Controllers
{
    [ApiController]

    public class OrdersController : Controller
    {
        private FoodorderContext _dbContext;
        private List<Order> getdetails;

        public OrdersController(FoodorderContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("OrderData/Order")]
        [HttpGet]
        public List<Order> GetOrder()
        {
            var getdetails = _dbContext.Order.ToList();

            return getdetails;
        }

        [Route("OrderData/OrderId")]
        [HttpGet]
        public List<Order> GetOrderid(int id)
        {

            var getdetails = _dbContext.Order.Where(x => x.Orderid == id);

            return getdetails.ToList();
        }

        [Route("OrderData/SaveOrder")]
        [HttpPost]

        public List<Order> SaveOrder(Order model)
        {
            _dbContext.Order.Add(model);

            _dbContext.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";


            var getdetails = _dbContext.Order.ToList();

            return getdetails;
        }

        [Route("OrderData/EditOrder")]
        [HttpPost]

        public List<Order> UpdateOrder(Order model)
        {
            var data = _dbContext.Order.Where(x => x.Orderid == model.Orderid).FirstOrDefault();
            if (data != null)
            {
                data.Orderid = model.Orderid;
                data.OrderDate = model.OrderDate;
                data.TotalAmount = model.TotalAmount;
                data.Customerid = model.Customerid;
                data.OrderStatus = model.OrderStatus;
                _dbContext.SaveChanges();
            }

            var getdetails = _dbContext.Order.ToList();
            return getdetails;
        }

        [Route("OrderData/DeleteOrderById")]
        [HttpGet]
        public string DeleteOrder(int id)
        {
            var ord = _dbContext.Order.Find(id); //Add the record
            _dbContext.Order.Remove(ord);
            _dbContext.SaveChanges();   //it Save Changes
            return "Deleted";
        }
    }


}