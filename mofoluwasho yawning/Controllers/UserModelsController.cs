using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mofoluwasho_yawning.Data;
using mofoluwasho_yawning.Models;
using mofoluwasho_yawning.Services;

namespace mofoluwasho_yawning.Controllers
{
    public class UserModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IInterface2 _interfaceQuery;
        

        public UserModelsController(ApplicationDbContext context, IInterface2 InterfaceQuery)
        {
            _context = context;
            _interfaceQuery = InterfaceQuery;

        }

        // GET: UserModels
        public async Task<IActionResult> Index()
        {
            return View(await _interfaceQuery.GetAll());
        }

        // GET: UserModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userModel = await _interfaceQuery.GetById((int)id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: UserModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                await _interfaceQuery.Add(userModel);
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: UserModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _interfaceQuery.GetById((int)id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

        // POST: UserModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,FirstName,LastName,PhoneNumber,EmailAddress,AlternativeNumber,NIN,BVN,MyAddress,EmergencyContactName,EmergencyContactNumber")] UserModel userModel)
        {
            if (id != userModel.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _interfaceQuery.Edit(userModel);
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: UserModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            UserModel del = await _context.UserModel.FindAsync(id);
            _context.UserModel.Remove(del);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
