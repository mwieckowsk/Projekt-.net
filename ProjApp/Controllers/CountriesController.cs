using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ProjApp.Data;
using ProjApp.Models;
using ProjApp.Models.CountryViewModels;

namespace ProjApp.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ProjAppContext _context;
        private readonly IMapper _mapper;

        public CountriesController(ProjAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
            var countries = await _context.Country
            .Select(m => _mapper.Map<CountryViewModel>(m)).ToListAsync();
            return View(countries);
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var country = await _context.Country
                .SingleOrDefaultAsync(m => m.CountryId == id);
            if (country == null)
            {
                return View("NotFound");
            }
            var viewModel = _mapper.Map<DetailsCountryViewModel>(country);
            return View(viewModel);

        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCountryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var country = new Country { Name = model.Name };
            _context.Add(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var country = await _context.Country.SingleOrDefaultAsync(m => m.CountryId == id);
            if (country == null)
            {
                return View("NotFound");
            }
            var viewModel = _mapper.Map<EditCountryViewModel>(country);
            return View(viewModel);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCountryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var country = await _context.Country
                    .SingleOrDefaultAsync(m => m.CountryId == model.CountryId);
                country.Name = model.Name;
                _context.Update(country);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(model.CountryId))
                {
                    return View("NotFound");
                }

                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Country
                .SingleOrDefaultAsync(m => m.CountryId == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteCountryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var country = await _context.Country
                .SingleOrDefaultAsync(m => m.CountryId == model.CountryId);
            _context.Country.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(string id)
        {
            return _context.Country.Any(e => e.CountryId == id);
        }
    }
}
