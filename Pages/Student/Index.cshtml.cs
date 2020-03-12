using System;
using System.Collections.Generic;
using System.Linq;
using RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RazorPages.Data;

namespace RazorPages.Pages.Student
{ 
    public class IndexModel : PageModel
    {
        private readonly RazorPagesDbContext _context;
        public IndexModel(RazorPagesDbContext context)
        {
            _context = context;
        }

        public IList<Models.Student> Students { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searchString { get; set; }

  

        public async Task OnGetAsync()
        {
            var studs = from m in _context.Students 
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                studs = studs.Where(s => s.LastName.Contains(searchString));
            }

            Students = await studs.ToListAsync();

        }

        
        
        [BindProperty(SupportsGet = true)]
        public double GPA { get; set; }
        
        public void OnPostGreater()
        {
            var studs = from m in _context.Students
                        select m;
            if (!Double.IsNaN(GPA))
            {
                studs = studs.Where(s => s.GPA > GPA);
            }
            Students = studs.ToList();
        }

        public void OnPostLess()
        {
            var studs = from m in _context.Students
                        select m;
            if (!Double.IsNaN(GPA))
            {
                studs = studs.Where(s => s.GPA < GPA);
            }
            Students = studs.ToList();
        }

        
    }
}