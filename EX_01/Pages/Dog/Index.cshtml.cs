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
    public class IndexModel : PageModel
    {
        private readonly EX_01.Data.ApplicationDbContext _context;

        public IndexModel(EX_01.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dog> Dog { get;set; }

        public async Task OnGetAsync()
        {
            Dog = await _context.Dog.ToListAsync();
        }
    }
}
