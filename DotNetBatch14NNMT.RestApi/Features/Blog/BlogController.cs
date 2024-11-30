using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14NNMT.RestApi.Features.Blog;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{

    [HttpGet]
     public IActionResult GetBlog()
    {
        return Ok("Hello world");
    }

    //[HttpGet]
    //public IActionResult GetBlog()
    //{
    //    return Ok();
    //}


    [HttpPost]
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateBlog()
    {
        return Ok();
    }

    [HttpPatch]
    public IActionResult PatchBlog()
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteBlog()
    {
        return Ok();
    }

   

  
}
