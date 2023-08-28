using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service.Common;
using System.Net;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public IService Service { get; set; }
        public StudentController(IService service)
        {
            Service = service;
        }
        // ---------------- GET ALL ----------------
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                List<StudentDTO> list = await Service.GetAllAsync();
                return Ok(list); 
            }
            catch (Exception x)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error for GetAllAsync: {x.Message}");
            }
        }

    }
}
