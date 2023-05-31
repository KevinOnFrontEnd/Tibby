using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tibby;

namespace WebApplication2.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ITibbyClient _client;

    public IndexModel(ILogger<IndexModel> logger, ITibbyClient client)
    {
        _logger = logger;
        _client = client;
    }

    public async Task OnGetAsync()
    {
        var (s,t) = await _client.GetRouter();
        var m = s;
    }
}