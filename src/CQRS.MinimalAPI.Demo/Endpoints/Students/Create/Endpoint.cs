using CQRS.MinimalAPI.Demo.Models;
using CQRS.MinimalAPI.Demo.Services;
using MiniValidation;

namespace CQRS.MinimalAPI.Demo.Endpoints.Students.Create;

public static class Endpoint
{
  public static WebApplication MapPostCreateStudent(this WebApplication app)
  {
    app.MapPost("student/create", async (Student student, IStudentsService studentService) =>
        !MiniValidator.TryValidate(student, out IDictionary<string, string[]>? errors)
            ? Results.ValidationProblem(errors)
            : Results.Ok(await studentService.Create(student).ConfigureAwait(false)));
    return app;
  }
}