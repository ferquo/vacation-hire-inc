﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace VacationHireInc.API.Controllers;

[Route("api/orders")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public Task<IActionResult> Get()
    {
        throw new Exception("this should fail");
    }
}

