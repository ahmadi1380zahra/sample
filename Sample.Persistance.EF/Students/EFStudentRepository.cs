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
}