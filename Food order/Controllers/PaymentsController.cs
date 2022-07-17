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

    public class PaymentsController : Controller
    {
        private FoodorderContext _dbContext;
        private List<Payment> getdetails;

        public PaymentsController(FoodorderContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("PaymentData/Payment")]
        [HttpGet]
        public List<Payment> GetPayment()
        {
            var getdatails = _dbContext.Payment.ToList();

            return getdatails;
        }

        [Route("PaymentData/PaymentId")]
        [HttpGet]
        public List<Payment> GetPaymentid(int id)
        {

            var getdetails = _dbContext.Payment.Where(x => x.Paymentid == id);

            return getdetails.ToList();
        }

        [Route("PaymentData/SavePayment")]
        [HttpPost]

        public List<Payment> SavePayment(Payment model)
        {
            _dbContext.Payment.Add(model);

            _dbContext.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";


            var getdetails = _dbContext.Payment.ToList();

            return getdetails;
        }

        [Route("PaymentData/EditPayment")]
        [HttpPost]

        public List<Payment> UpdatePayment(Payment model)
        {
            var data = _dbContext.Payment.Where(x => x.Paymentid == model.Paymentid).FirstOrDefault();
            if (data != null)
            {
                data.Paymentid = model.Paymentid;
                data.Orderid = model.Orderid;
                data.TotalAmount = model.TotalAmount;
                data.PaidBy = model.PaidBy;
                data.Status = model.Status;
                _dbContext.SaveChanges();
            }

            var getdetails = _dbContext.Payment.ToList();
            return getdetails;
        }

        [Route("PaymentData/DeletePaymentById")]
        [HttpGet]
        public string DeletePayment(int id)
        {
            var ord = _dbContext.Payment.Find(id); //Add the record
            _dbContext.Payment.Remove(ord);
            _dbContext.SaveChanges();   //it Save Changes
            return "Deleted";
        }
    }


}
