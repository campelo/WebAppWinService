using Microsoft.AspNetCore.Mvc;

namespace WebAppWinService.Controllers;

[ApiController]
[Route("[controller]")]
public class MachineController : ControllerBase
{
    [HttpGet(Name = "Name")]
    public string GetName()
    {
        // TODO: Add your logic here
        return Environment.MachineName;
    }
}
