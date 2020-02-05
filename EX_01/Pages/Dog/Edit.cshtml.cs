using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EX_01.Data;

namespace EX_01
{
    public class EditModel : PageModel
    {
        private readonly EX_01.Data.ApplicationDbContext _context;

        public EditModel(EX_01.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(Dog.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DogExists(string id)
        {
            return _context.Dog.Any(e => e.Id == id);
        }
    }
}
