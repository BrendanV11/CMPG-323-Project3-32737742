using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;

namespace DeviceManagement_WebApp.Interface
{
    public interface IDevices : IGenericRepository<Device>
    {
        //Used to determine if the device exisits and if it is un use
        bool DeviceExists(Guid id);

        public IIncludableQueryable<Device, Zone> Use();
    }
}