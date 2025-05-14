using Microsoft.EntityFrameworkCore;
using StoredProcedureCRUD_EF_.Data;
using StoredProcedureCRUD_EF_.Model;

namespace StoredProcedureCRUD_EF_.Services
{
    public class StudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context) => _context = context;

       
        public async Task<List<Student>> GetAllAsync()
        {
      
            return await _context.Students
                .FromSqlRaw("EXEC sp_Student_CRUD @p0", "GetAll")
                .ToListAsync();
        }

        public Task<Student?> GetByIdAsync(int id)
        {
            var student = _context.Students
                .FromSqlRaw("EXEC sp_Student_CRUD @p0, @p1", "GetById", id)
                .AsEnumerable()
                .FirstOrDefault();

            return Task.FromResult(student);
        }



        public async Task AddAsync(Student student) =>

        await _context.Database.ExecuteSqlRawAsync("EXEC sp_Student_CRUD @p0, NULL, @p1, @p2, @p3",

            "Insert", student.Name, student.Age, student.Grade);



        public async Task UpdateAsync(Student student) =>

          await _context.Database.ExecuteSqlRawAsync("EXEC sp_Student_CRUD @p0, @p1, @p2, @p3, @p4",

      "Update", student.Id, student.Name, student.Age, student.Grade);

        public async Task DeleteAsync(int id) =>
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Student_CRUD @p0, @p1", "Delete", id);
    }
}
