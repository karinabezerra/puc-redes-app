using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Puc.Web.Data;
using Puc.Web.Entities;

namespace Puc.Web.Pages.Ativos
{
    public class DetailsModel : PageModel
    {
        private readonly Puc.Web.Data.AppDbContext _context;

        public DetailsModel(Puc.Web.Data.AppDbContext context)
        {
            _context = context;
        }

      public Ativo Ativo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ativos == null)
            {
                return NotFound();
            }

            var ativo = await _context.Ativos.FirstOrDefaultAsync(m => m.Id == id);
            if (ativo == null)
            {
                return NotFound();
            }
            else 
            {
                Ativo = ativo;
            }
            return Page();
        }
    }
}
