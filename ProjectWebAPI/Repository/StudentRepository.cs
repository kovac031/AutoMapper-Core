using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI;

namespace Repository
{
    public class StudentRepository : IRepository
    {
        //public readonly IMapper _mapper; // AutoMapper
        public JustStudentsContext Context { get; set; }
        public StudentRepository(JustStudentsContext context) // IMapper dodao za AutoMapper
        {
            Context = context;
            //_mapper = mapper;
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

            //return await _mapper.ProjectTo<StudentDTO>(student).ToListAsync();
        }
    }
}
