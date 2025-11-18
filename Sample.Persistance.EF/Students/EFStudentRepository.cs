using Microsoft.EntityFrameworkCore;
using Sample.Application.Students.Contracts;
using Sample.Entities;

namespace Sample.Persistance.EF.Students;

public class EFStudentRepository (EFDataContext dataContext) :StudentRepository
{
    public void Add(Student student)
    {
        dataContext.Set<Student>().Add(student);
    }

    public async Task Save()
    {
        await dataContext.SaveChangesAsync();
    }
    public async Task Get(int pageNumber, int pageSize)
    {
        await dataContext.Set<Student>()
            .Skip((pageNumber-1)*pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}