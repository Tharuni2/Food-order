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

    public class MenusController : Controller
    {
        private FoodorderContext _dbContext;
        private List<Menu> getdetails;

        public MenusController(FoodorderContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("MemuData/Menu")]
        [HttpGet]
        public List<Menu> GetMenu()
        {
            var getdetails = _dbContext.Menu.ToList();

            return getdetails;
        }

        [Route("MenuData/Menuid")]
        [HttpGet]
        public List<Menu> GetMenuid(int id)
        {

            var getdetails = _dbContext.Menu.Where(x => x.Menuid == id);

            return getdetails.ToList();
        }

        [Route("MenuData/SaveMenu")]
        [HttpPost]

        public List<Menu> SaveCustomer(Menu model)
        {
            _dbContext.Menu.Add(model);

            _dbContext.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";


            var getdetails = _dbContext.Menu.ToList();
            return getdetails;
        }

        [Route("MenuData/EditMenu")]
        [HttpPost]

        public List<Menu> UpdateCustomer(Menu model)
        {
            var data = _dbContext.Menu.Where(x => x.Menuid == model.Menuid).FirstOrDefault();
            if (data != null)
            {
                data.Menuid = model.Menuid;
                data.MenuName = model.MenuName;
                data.Quantity = model.Quantity;
                data.Price = model. Price;
                data.FoodCategory = model.FoodCategory;
                _dbContext.SaveChanges();
            }

            var getdetails = _dbContext.Menu.ToList();
            return getdetails;
        }

        [Route("MenuData/DeleteMenuById")]
        [HttpGet]
        public string DeleteMenu(int id)
        {
            var ord = _dbContext.Menu.Find(id); //Add the record
            _dbContext.Menu.Remove(ord);
            _dbContext.SaveChanges();   //it Save Changes
            return "Deleted";
        }
    }


}

