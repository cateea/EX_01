using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EX_01.Data;

namespace EX_01
{
    public class DetailsModel : PageModel
    {
        private readonly EX_01.Data.ApplicationDbContext _context;

        public DetailsModel(EX_01.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Dog Dog { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog = await _context.Dog.FirstOrDefaultAsync(m => m.Id == id);

            if (Dog == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
