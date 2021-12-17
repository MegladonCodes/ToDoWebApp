using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Pages.TaskPages
{
    public class IndexModel : PageModel
    {
        private readonly ToDoApp.Data.ToDoAppContext _context;

        //Attributes ti sort by
        public string CategorySort { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start")]
        public DateTime StartDateSort { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("End")]
        public DateTime EndDateSort { get; set; }

        public string StatusSort { get; set; }

        public IndexModel(ToDoApp.Data.ToDoAppContext context)
        {
            _context = context;
        }

        public IList<TaskItem> TaskItem { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            CategorySort = String.IsNullOrEmpty(sortOrder) ? "Category_desc" : "";

            IQueryable<TaskItem> taskIQ = from t in _context.Task select t;

            switch (sortOrder)
            {
                case "Category_desc":
                    taskIQ = taskIQ.OrderBy(t => t.Category);
                    break;
            }

            TaskItem = await taskIQ.AsNoTracking().ToListAsync();
        }
    }
}