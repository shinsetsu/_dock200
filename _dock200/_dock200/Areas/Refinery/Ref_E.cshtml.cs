using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _dock200.Data;
using _dock200.Models;

namespace _dock200.Areas.Refinery
{
    public class Ref_EModel : PageModel
    {
        private readonly _dock200.Data._DBC _context;

        public Ref_EModel(_dock200.Data._DBC context)
        {
            _context = context;
        }

        [BindProperty]
        public RefEmpAp_M RefEmpAp_M { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RefEmpAp_M = await _context.RefEmpAp_M.FirstOrDefaultAsync(m => m.id == id);

            if (RefEmpAp_M == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RefEmpAp_M).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefEmpAp_MExists(RefEmpAp_M.id))
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

        private bool RefEmpAp_MExists(int id)
        {
            return _context.RefEmpAp_M.Any(e => e.id == id);
        }
    }
}
