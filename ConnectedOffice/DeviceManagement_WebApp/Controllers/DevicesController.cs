using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        DevicesRepository devicesRepository;
      //  private readonly ConnectedOfficeContext _context;

        public DevicesController(ConnectedOfficeContext context)
        {
            devicesRepository = new DevicesRepository(context);
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            var connectedOfficeContext = devicesRepository.GetAll();
            return View(connectedOfficeContext);
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = devicesRepository.GetById((Guid)id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList((System.Collections.IEnumerable)devicesRepository.getContext(), "CategoryId", "CategoryName"); //DOUBLE CHECK THIS
            ViewData["ZoneId"] = new SelectList((System.Collections.IEnumerable)devicesRepository.getContext(), "ZoneId", "ZoneName"); //DOUBLE CHECK THIS
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            device.DeviceId = Guid.NewGuid();
            devicesRepository.Add(device);
            devicesRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = devicesRepository.GetById((Guid)id);
            if (device == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList((System.Collections.IEnumerable)devicesRepository.getContext(), "CategoryId", "CategoryName", device.CategoryId); //DOUBLE CHECK
            ViewData["ZoneId"] = new SelectList((System.Collections.IEnumerable)devicesRepository.getContext(), "ZoneId", "ZoneName", device.ZoneId); //DOUBLE CHECK
            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            if (id != device.DeviceId)
            {
                return NotFound();
            }
            try
            {
                devicesRepository.Update(device);
                devicesRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(device.DeviceId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = devicesRepository.GetById((Guid)id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var device = devicesRepository.GetById((Guid)id);
            devicesRepository.Remove(device);
            devicesRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(Guid id)
        {
            return devicesRepository.DeviceExists(id);
        }
    }
}
