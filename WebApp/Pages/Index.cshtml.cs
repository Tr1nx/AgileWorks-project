using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;


    public IndexModel(AppDbContext context)
    {
        _context = context;
    }
    
    public IList<Request> Request { get; set; } = new List<Request>();
    
    

    public void OnGet()
    {
        Request = _context.Requests.OrderByDescending(r => r.Deadline).Where(r => !r.Resolved).ToList();
    }
    
    public async Task<IActionResult> OnPostAsync(List<Guid> selectedRequests, List<bool> resolvedStates)
    {
        if (selectedRequests != null && selectedRequests.Any())
        {
            for (int i = 0; i < selectedRequests.Count; i++)
            {
                var request = await _context.Requests.FindAsync(selectedRequests[i]);
            
                if (request != null)
                {
                    request.Resolved = true;
                    // _context.Requests.Remove(request);
                }
            }
            await _context.SaveChangesAsync();
        }

        return RedirectToPage();
    }
    
}