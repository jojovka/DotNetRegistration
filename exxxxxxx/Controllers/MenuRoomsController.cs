using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using exxxxxxx.Models;
using exxxxxxx.Data;

namespace exxxxxxx.Controllers
{
    public class MenuRoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuRoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MenuRooms
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.MenuRooms.Include(m => m.Menu).Include(m => m.Room);
            return View(await appDbContext.ToListAsync());
        }

        // GET: MenuRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuRoom = await _context.MenuRooms
                .Include(m => m.Menu)
                .Include(m => m.Room)
                .FirstOrDefaultAsync(m => m.MenuRoomId == id);
            if (menuRoom == null)
            {
                return NotFound();
            }

            return View(menuRoom);
        }

        // GET: MenuRooms/Create
        public IActionResult Create()
        {
            ViewData["MenuId"] = new SelectList(_context.Menus, "MenuId", "MenuId");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId");
            return View();
        }

        // POST: MenuRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuRoomId,MenuId,RoomId")] MenuRoom menuRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "MenuId", "MenuId", menuRoom.MenuId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", menuRoom.RoomId);
            return View(menuRoom);
        }

        // GET: MenuRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuRoom = await _context.MenuRooms.FindAsync(id);
            if (menuRoom == null)
            {
                return NotFound();
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "MenuId", "MenuId", menuRoom.MenuId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", menuRoom.RoomId);
            return View(menuRoom);
        }

        // POST: MenuRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuRoomId,MenuId,RoomId")] MenuRoom menuRoom)
        {
            if (id != menuRoom.MenuRoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuRoomExists(menuRoom.MenuRoomId))
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
            ViewData["MenuId"] = new SelectList(_context.Menus, "MenuId", "MenuId", menuRoom.MenuId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", menuRoom.RoomId);
            return View(menuRoom);
        }

        // GET: MenuRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuRoom = await _context.MenuRooms
                .Include(m => m.Menu)
                .Include(m => m.Room)
                .FirstOrDefaultAsync(m => m.MenuRoomId == id);
            if (menuRoom == null)
            {
                return NotFound();
            }

            return View(menuRoom);
        }

        // POST: MenuRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuRoom = await _context.MenuRooms.FindAsync(id);
            _context.MenuRooms.Remove(menuRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuRoomExists(int id)
        {
            return _context.MenuRooms.Any(e => e.MenuRoomId == id);
        }
    }
}
