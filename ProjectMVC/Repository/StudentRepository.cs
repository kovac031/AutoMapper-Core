using Microsoft.EntityFrameworkCore;
using Model;
using MVC;
using Repository.Common;

namespace Repository
{
    public class StudentRepository : IRepository
    {
        public JustStudentsContext Context { get; set; }
        public StudentRepository(JustStudentsContext context)
        {
            Context = context;
        }
        //----------------- GET ALL --------------
        public async Task<List<StudentDTO>> GetAllAsync()
        {
            IQueryable<Student> student = Context.Students;

            List<StudentDTO> list = await student.Select(x => new StudentDTO()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
                EmailAddress = x.EmailAddress,
                RegisteredOn = x.RegisteredOn
            }).ToListAsync<StudentDTO>();

            return list;
        }
    }
}