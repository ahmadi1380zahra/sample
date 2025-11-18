using Sample.Entities;

namespace Sample.Application.Students.Contracts;

public interface StudentRepository
{
    void Add(Student student);
    Task Save();
}