using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Puc.Web.Data;
using Puc.Web.Entities;

namespace Puc.Web.Pages.Ativos
{
    public class EditModel : PageModel
    {
        private readonly Puc.Web.Data.AppDbContext _context;

        public EditModel(Puc.Web.Data.AppDbContext context)
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

            var ativo =  await _context.Ativos.FirstOrDefaultAsync(m => m.Id == id);
            if (ativo == null)
            {
                return NotFound();
            }
            Ativo = ativo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ativo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtivoExists(Ativo.Id))
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

        private bool AtivoExists(int id)
        {
          return (_context.Ativos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
