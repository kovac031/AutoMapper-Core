using Microsoft.AspNetCore.Mvc;
using Model;
using Service.Common;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        public string Index()
        {
            return "Provjera";
        }
        public IActionResult ViewMethod()
        {
            return View();
        }
        //
        public IService Service { get; set; }
        public StudentController(IService service)
        {
            Service = service;
        }
        // ---------------- GET ALL ----------------        
        public async Task<ActionResult> ListStudents()
        {
            List<StudentDTO> listDTO = await Service.GetAllAsync();
            List<StudentView> listView = new List<StudentView>();

            foreach (StudentDTO studentDTO in listDTO)
            {
                StudentView studentView = new StudentView();

                studentView.Id = studentDTO.Id;
                studentView.FirstName = studentDTO.FirstName;
                studentView.LastName = studentDTO.LastName;
                studentView.DateOfBirth = studentDTO.DateOfBirth;
                studentView.EmailAddress = studentDTO.EmailAddress;
                studentView.RegisteredOn = studentDTO.RegisteredOn;

                listView.Add(studentView);
            }
            return View(listView);
        }
        public async Task<ActionResult> Mama()
        {
            return View();
        }

    }
}
