using Sample.Application.Students.Contracts;
using Sample.Application.Students.Contracts.Dtos;
using Sample.Entities;

namespace Sample.Application.Students;

public class StudentAppService (StudentRepository repository): StudentService
{
    public async Task Add(AddStudentDto dto)
    {
        var student = new Student
        {
            FirstName = dto.Title
        };
        repository.Add(student);
       await repository.Save();
    }
}