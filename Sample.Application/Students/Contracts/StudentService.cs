using Sample.Application.Students.Contracts.Dtos;

namespace Sample.Application.Students.Contracts;

public interface StudentService
{
    Task Add(AddStudentDto dto);
}