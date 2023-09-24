using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orgoffering.Data;
using Orgoffering.Models;
using Orgoffering.Repository;

namespace Orgoffering.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public IActionResult Index()
        {
                IEnumerable<Service> services = _serviceRepository.GetAllEntities();
            return View(services);
        }

        public IActionResult Details(Guid id)
        {
            Service service = _serviceRepository.GetEntityById(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {
            try
            {
                _serviceRepository.AddEntity(service);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ServiceId", ex.Message); // Add a custom error message to ModelState.
                return View(service);
            }

        }

        public IActionResult Edit(Guid id)
        {
            Service service = _serviceRepository.GetEntityById(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        [HttpPost]
        public IActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                _serviceRepository.UpdateEntity(service);
                return RedirectToAction("Index");
            }
            return View(service);
        }

        public IActionResult Delete(Guid id)
        {
            Service service = _serviceRepository.GetEntityById(id);
            if (service == null)
            {
                return NotFound(); // Return a 404 error if the product is not found
            }
            return View(service);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _serviceRepository.DeleteEntity(id);
            return RedirectToAction("Index");
        }

        // GET: Services
        /*public async Task<IActionResult> Index()
        {
            return View(_serviceRepository.GetAll());
        }

        // GET: Services/Create
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost] // This action handles the POST request to create a new product
        public IActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                // Call the service method to add the product
                _serviceRepository.AddProduct(service);

                // Redirect to the product list or another appropriate action
                return RedirectToAction("Index");
            }

            // If the model is not valid, return to the create form with validation errors
            return View(service);
        }


    }

    public class ServicesController : Controller
    {
        private readonly DependencyDBContext _context;

        public ServicesController(DependencyDBContext context)
        {
            _context = context;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
              return _context.Services != null ? 
                          View(await _context.Services.ToListAsync()) :
                          Problem("Entity set 'DependencyDBContext.Services'  is null.");
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,ServiceName,ServiceDescription,CreatedDate")] Service service)
        {
            if (ModelState.IsValid)
            {
                service.ServiceId = Guid.NewGuid();
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ServiceId,ServiceName,ServiceDescription,CreatedDate")] Service service)
        {
            if (id != service.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.ServiceId))
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
            return View(service);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Services == null)
            {
                return Problem("Entity set 'DependencyDBContext.Services'  is null.");
            }
            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(Guid id)
        {
          return (_context.Services?.Any(e => e.ServiceId == id)).GetValueOrDefault();
        }
    }*/
    }
}
