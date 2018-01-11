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
using ProjApp.Models.BrandViewModels;

namespace ProjApp.Controllers
{
    public class BrandsController : Controller
    {
        private readonly ProjAppContext _context;
        private readonly IMapper _mapper;

        public BrandsController(ProjAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Brands
        public async Task<IActionResult> Index()
        {
            var brands = await _context.Brand
            .Select(m => _mapper.Map<BrandViewModel>(m)).ToListAsync();
            return View(brands);
        }

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var brand = await _context.Brand
                .SingleOrDefaultAsync(m => m.BrandId == id);
            if (brand == null)
            {
                return View("NotFound");
            }
            var viewModel = _mapper.Map<DetailsBrandViewModel>(brand);
            return View(viewModel);

        }
  

    
        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBrandViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var brand = new Brand { Name = model.Name };
            _context.Add(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var brand = await _context.Brand.SingleOrDefaultAsync(m => m.BrandId == id);
            if (brand == null)
            {
                return View("NotFound");
            }
            var viewModel = _mapper.Map<EditBrandViewModel>(brand);
            return View(viewModel);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditBrandViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var brand = await _context.Brand
                    .SingleOrDefaultAsync(m => m.BrandId == model.BrandId);
                brand.Name = model.Name;
                _context.Update(brand);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(model.BrandId))
                {
                    return View("NotFound");
                }

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var brand = await _context.Brand
                .SingleOrDefaultAsync(m => m.BrandId == id);
            if (brand == null)
            {
                return View("NotFound");
            }

            var viewModel = _mapper.Map<DeleteBrandViewModel>(brand);
            return View(viewModel);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteBrandViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var brand = await _context.Brand
                .SingleOrDefaultAsync(m => m.BrandId == model.BrandId);
            _context.Brand.Remove(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool BrandExists(string id)
        {
            return _context.Brand.Any(e => e.BrandId == id);
        }
    }
}
