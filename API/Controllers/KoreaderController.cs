using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using API.DTOs.Koreader;

namespace API.Controllers;

#nullable enable

// Koreader uses a different form of athentication. It stores the user name
// and password in headers.
[AllowAnonymous]
public class KoreaderController : BaseApiController
{

    public KoreaderController()
    {
    }

    // We won't allow users to be created from Koreader. Rather, they
    // must already have an account.
    /*
    [HttpPost("/users/create")]
    public IActionResult CreateUser(CreateUserRequest request)
    {
    }
    */

    [HttpGet("{apiKey}/users/auth")]
    public IActionResult Authenticate(string apiKey)
    {
        return Ok(new { username = "Username" });
    }


    [HttpPut("{apiKey}/syncs/progress")]
    public IActionResult UpdateProgress(string apiKey, KoreaderBookDto request)
    {
        var response = new
        {
            document = request.Document,
            timestamp = DateTime.Now
        };
        return Ok(response);
    }

    [HttpGet("{apiKey}/syncs/progress/{ebookHash}")]
    public IActionResult GetProgress(string apiKey, string ebookHash)
    {
        var response = new KoreaderBookDto();
        return Ok(response);

    }

}
