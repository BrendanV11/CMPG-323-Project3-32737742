using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using DeviceManagement_WebApp.Interface;

namespace DeviceManagement_WebApp.Controllers
{
    public class CategoriesRepository : GenericRepository<Category>, ICategories
    {


        public CategoriesRepository(ConnectedOfficeContext context) :base(context)
        {
         
        }


        public List<Category> GetAll()
        {
            return _context.Category.ToList();
        }




        public bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }

    }
}
