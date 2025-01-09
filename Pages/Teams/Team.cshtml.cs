using League.Data;
using League.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace League.Pages.Teams
{
    public class TeamModel : PageModel
    {
        private readonly LeagueContext _context;

        public TeamModel(LeagueContext context)
        {
            _context = context;
        }

        public Team Team { get; set; }

        public async Task<ActionResult> OnGetAsync(string teamid)
        {
            Team = await _context.Teams
                .FirstOrDefaultAsync(t => t.TeamId == teamid);

            if (Team == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
