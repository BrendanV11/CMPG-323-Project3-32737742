using DeviceManagement_WebApp.Models;
using System;

namespace DeviceManagement_WebApp.Interface
{
    public interface IDevices : IGenericRepository<Device>
    {
        //Used to determine if the device exisits and if it is un use
        bool DeviceExists(Guid id);
    }
}