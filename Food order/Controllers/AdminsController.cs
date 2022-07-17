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
    //[Route("[controller]")]

    public class AdminsController : Controller
    {
        private FoodorderContext _dbContext;
        private List<Admin> getdetails;

        public AdminsController(FoodorderContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("AdminData/Admin")]
        [HttpGet]
        // [Route("OrderData/Orders")]
        public List<Admin> GetAdmin()
        {
            var getdatails = _dbContext.Admin.ToList();

            return getdatails;
        }

        [Route("AdminData/UserId")]
        [HttpGet]
        // [Route("OrderData/OrderById")]
        public List<Admin> GetUserId(int id)
        {

            var getdetails = _dbContext.Admin.Where(x => x.Userid == id);

            return getdetails.ToList();
        }

        [Route("AdminData/SaveAdmin")]
        [HttpPost]

        public List<Admin> SaveAdmin(Admin model)
        {
            _dbContext.Admin.Add(model);

            _dbContext.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";


            var getdetails = _dbContext.Admin.ToList();

            return getdetails;
        }

        [Route("AdminData/EditAdmin")]
        [HttpPost]

        public List<Admin> UpdateAdmin(Admin model)
        {
            var data = _dbContext.Admin.Where(x => x.Userid == model.Userid).FirstOrDefault();
            if (data != null)
            {
                data.Userid = model.Userid;
                data.Password= model.Password;
                data.FirstName = model.FirstName;
                data.LastName = model.LastName;

                _dbContext.SaveChanges();
            }

            var getdetails = _dbContext.Admin.ToList();
            return getdetails;
        }

        [Route("AdminData/DeleteAdminById")]
        [HttpGet]
        public string DeleteAdmin(int id)
        {
            var ord = _dbContext.Admin.Find(id); //Add the record
            _dbContext.Admin.Remove(ord);
            _dbContext.SaveChanges();   //it Save Changes
            return "Deleted";
        }
    }


}

