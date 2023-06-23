using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Puc.Web.Data;
using Puc.Web.Entities;

namespace Puc.Web.Pages.Ativos
{
    public class CreateModel : PageModel
    {
        private readonly Puc.Web.Data.AppDbContext _context;

        public CreateModel(Puc.Web.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Ativo Ativo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Ativos == null || Ativo == null)
            {
                return Page();
            }

            _context.Ativos.Add(Ativo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
