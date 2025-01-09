using League.Data;
using League.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace League.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly LeagueContext _context;

        public IndexModel(LeagueContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        public List<Player> Players { get; set; }

        public async Task OnGetAsync(string search)
        {
            IQueryable<Player> players = _context.Players.Select(p => p);

            if (!string.IsNullOrEmpty(search))
            {
                //Search = search;
                players = players.Where(p => p.Name.Contains(search));
            }

            Players = await players.ToListAsync();
        }
    }
}
