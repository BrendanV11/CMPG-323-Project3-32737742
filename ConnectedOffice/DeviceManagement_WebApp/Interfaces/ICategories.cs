using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Interface
{
    public interface ICategories : IGenericRepository<Category>
    {
        //Used to determine if the category exists and if it is in use
        public bool CategoryExists(Guid id);

    }
}