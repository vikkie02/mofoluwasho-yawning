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
    public class UserModels1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUser _userQuery;

        public UserModels1Controller(ApplicationDbContext context, IUser userQuery)  
        {
            _context = context;
            _userQuery = userQuery;
        }

        // GET: UserModels1
        public async Task<IActionResult> Index()
        {
            return View(await _userQuery.GetAll());
        }

        // GET: UserModels1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModel
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: UserModels1/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserModels1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,FirstName,LastName,PhoneNumber,EmailAddress,AlternativeNumber,NIN,BVN,MyAddress,EmergencyContactName,EmergencyContactNumber")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: UserModels1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModel.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

        // POST: UserModels1/Edit/5
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
                await _userQuery.Update(userModel);
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: UserModels1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModel
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // POST: UserModels1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userQuery.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(int id)
        {
            return _context.UserModel.Any(e => e.UserId == id);
        }
    }
}
