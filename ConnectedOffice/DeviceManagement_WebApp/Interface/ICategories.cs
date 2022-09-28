using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Interface
{
    public interface ICategories: IGenericRepository<Category>
    {
        public bool CategoryExists(Guid id);
    }
}
