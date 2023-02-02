using Microsoft.AspNetCore.Mvc;

namespace Practice.Controllers;

[ApiController]
public class ExceptionHandleController : ControllerBase
{

    [Route("exception")]
    [HttpGet]
    public IActionResult Get(int a)
    {
        try
        {
            if (a == 0)
            {
                throw new NullReferenceException("Invalid input");
            }

            if (a == 1)
            {
                throw new Exception();
            }

        }
        catch (NullReferenceException e)
        {
            return StatusCode(400, "Invalid Input");

        }
        catch (Exception e)
        {
            return StatusCode(500, "int server err");

        }


        return Content("works");
    }


    [Route("test")]
    [HttpPost]
    public string Post()
    {
        return "post";
    }

    [Route("add")]
    [HttpGet]
    public int Add(int x, int y)
    {
        return (x + y);
    }
}

