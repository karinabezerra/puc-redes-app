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
    public class IndexModel : PageModel
    {
        private readonly Puc.Web.Data.AppDbContext _context;

        public IndexModel(Puc.Web.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Ativo> Ativo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Ativos != null)
            {
                Ativo = await _context.Ativos.ToListAsync();
            }
        }
    }
}
