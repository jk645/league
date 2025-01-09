using League.Data;
using League.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace League.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly LeagueContext _context;

        public IndexModel(LeagueContext context)
        {
            _context = context;    
        }

        public List<Team> Teams { get; set; }

        public async Task OnGetAsync()
        {
            Teams = await _context.Teams.ToListAsync();
        }
    }
}
