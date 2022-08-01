using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Areas.Identity.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoesController : Controller
    {
        //private ToDoListContext db= new ToDoListContext();
        private readonly ToDoListContext _context;

        public ToDoesController(ToDoListContext context)
        {
            _context = context;
        }

        //public
        //public async Task<IActionResult> _ToDoTable()
        //{
        //    return _context.ToDos != null ?
        //                View(await _context.ToDos.ToListAsync()) :
        //                Problem("Entity set 'ToDoListContext.ToDos'  is null.");
        //}

        // GET: ToDoes
        public async Task<IActionResult> Index()
        {
              return _context.ToDos != null ? 
                          View(await _context.ToDos.ToListAsync()) :
                          Problem("Entity set 'ToDoListContext.ToDos'  is null.");
        }

        // GET: ToDoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // GET: ToDoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,IsDone")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                //string currentUerId = User.Identity.GetUserId;
                //ToDoListUser currentUser = db.UsersFirstOrDefault
                //    (u => u.Id == currentUerId);
                //    toDo.User = currentUser;


                _context.Add(toDo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDo);
        }

        //Tạo Creat kiểu mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AJAXCreate([Bind("Id,Description")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                //string currentUerId = User.Identity.GetUserId;
                //ToDoListUser currentUser = db.UsersFirstOrDefault
                //    (u => u.Id == currentUerId);
                //    toDo.User = currentUser;
                toDo.IsDone = false;


                _context.Add(toDo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDo);
        }


        // GET: ToDoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return View(toDo);
        }

        // POST: ToDoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,IsDone")] ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.Id))
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
            return View(toDo);
        }

        // GET: ToDoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // POST: ToDoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ToDos == null)
            {
                return Problem("Entity set 'ToDoListContext.ToDos'  is null.");
            }
            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo != null)
            {
                _context.ToDos.Remove(toDo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoExists(int id)
        {
          return (_context.ToDos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
