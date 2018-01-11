using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ProjApp.Data;
using ProjApp.Helpers;
using ProjApp.Models;
using ProjApp.Models.CarViewModels;


namespace ProjApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly ProjAppContext _context;
        private readonly IMapper _mapper;

        public CarsController(ProjAppContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        private IQueryable<Car> GetCarsGreedy()
        {
            return _context.Car
                .Include(u => u.Brand)
                .Include(u => u.Country);
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var cars = await GetCarsGreedy()
                .Select(m => _mapper.Map<CarViewModel>(m))
                .ToListAsync();

            ViewData["CarCount"] = cars.Count;
            return View(cars);
        }


        // GET: Cars/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var car = await GetCarsGreedy()
                .SingleOrDefaultAsync(m => m.CarId == id);

            if (car == null)
            {
                return View("NotFound");
            }

            await _context.SaveChangesAsync();

            var viewModel = _mapper.Map<DetailsCarViewModel>(car);

            return View(viewModel);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            var viewModel = new CreateCarViewModel
            {
                Brands = _context.Brand,
                Countries = _context.Country
            };

            return View(viewModel);
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCarViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Brands = _context.Brand;
                model.Countries = _context.Country;
                return View(model);
            }
            var car = new Car
            {
                Brand = await _context.Brand.SingleOrDefaultAsync(c => c.BrandId == model.BrandId),
                Type = model.Type,
                ReleaseDate = model.ReleaseDate,
                Built = model.Built,
                Country = await _context.Country.SingleOrDefaultAsync(c => c.CountryId == model.CountryId)
            };

            _context.Add(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var car = await GetCarsGreedy()
                .SingleOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return View("NotFound"); ;
            }
            var viewModel = _mapper.Map<DetailsCarViewModel>(car);

            return View(viewModel);
        }
        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CarId,Type,ReleaseDate,Built")] Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarId))
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
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var car = await _context.Car
                .SingleOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return View("NotFound");
            }

            var viewModel = _mapper.Map<DeleteCarViewModel>(car);
            return View(viewModel);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteCarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var car = await _context.Car
                .SingleOrDefaultAsync(m => m.CarId == model.CarId);
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(string id)
        {
            return _context.Car.Any(e => e.CarId == id);
        }
    }
}
