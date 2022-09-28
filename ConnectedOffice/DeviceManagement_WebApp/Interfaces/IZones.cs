using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeviceManagement_WebApp.Interface
{
    public interface IZones : IGenericRepository<Zone>
    {
        //Used to determine if the zone exisits and if it is un use
        public bool ZoneExists(Guid id);
    }

}