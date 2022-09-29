using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Interface;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class DevicesRepository : GenericRepository<Device>, IDevices
    {
        public DevicesRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        //Used to get both the zone and the category when creating a device
        public IIncludableQueryable<Device,Zone> Use()
        {
            return _context.Device.Include(x => x.Category).Include(x => x.Zone);
        }

        //Used to determine if the device is not null or exists
        public bool DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.CategoryId == id);
        }
    }
}