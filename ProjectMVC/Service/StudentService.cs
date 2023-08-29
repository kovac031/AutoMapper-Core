using Model;
using Repository.Common;
using Service.Common;

namespace Service
{
    public class StudentService : IService
    {
        public IRepository Repository { get; set; }
        public StudentService(IRepository repository)
        {
            Repository = repository;
        }
        public async Task<List<StudentDTO>> GetAllAsync()
        {
            List<StudentDTO> list = await Repository.GetAllAsync();
            return list;
        }
    }
}