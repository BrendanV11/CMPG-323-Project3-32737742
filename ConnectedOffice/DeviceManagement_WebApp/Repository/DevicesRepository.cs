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
using Microsoft.EntityFrameworkCore.Query;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesRepository : GenericRepository<Device>, IDevices
    {

        public DevicesRepository(ConnectedOfficeContext context) : base(context)
        {

        }

        public IIncludableQueryable<Device,Zone> Index()
        {
            return _context.Device.Include(d => d.Category).Include(d => d.Zone);
        }

        public bool DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }
    }
}
