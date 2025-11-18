using Microsoft.AspNetCore.Mvc;
using Sample.Application.Students.Contracts;
using Sample.Application.Students.Contracts.Dtos;

namespace Sample.Rest;
[Route("api/[controller]")]
[ApiController]
public class StudentController (StudentService service) : ControllerBase
{
    [HttpPost]
    public async Task Add([FromBody] AddStudentDto dto)
    {
        await service.Add(dto);
    }
}