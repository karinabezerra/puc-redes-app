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
    public class DeleteModel : PageModel
    {
        private readonly Puc.Web.Data.AppDbContext _context;

        public DeleteModel(Puc.Web.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Ativos == null)
            {
                return NotFound();
            }
            var ativo = await _context.Ativos.FindAsync(id);

            if (ativo != null)
            {
                Ativo = ativo;
                _context.Ativos.Remove(Ativo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
