using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Pages.TaskPages
{
    public class DeleteModel : PageModel
    {
        private readonly ToDoApp.Data.ToDoAppContext _context;

        public DeleteModel(ToDoApp.Data.ToDoAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaskItem TaskItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskItem = await _context.Task.FirstOrDefaultAsync(m => m.ID == id);

            if (TaskItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskItem = await _context.Task.FindAsync(id);

            if (TaskItem != null)
            {
                _context.Task.Remove(TaskItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
