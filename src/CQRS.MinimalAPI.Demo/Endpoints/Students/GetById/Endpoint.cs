using CQRS.MinimalAPI.Demo.Models;
using CQRS.MinimalAPI.Demo.Services;

namespace CQRS.MinimalAPI.Demo.Endpoints.Students.GetById;

public static class Endpoint
{
    public static WebApplication MapGetByIdStudent(this WebApplication app)
    {
        app.MapGet("student/get-by-id", async (int id, IStudentsService studentService) =>
        {
            try
            {
                Student? existingStudent = await studentService.GetById(id).ConfigureAwait(false);
                return existingStudent != null ? Results.Ok(existingStudent) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });
        return app;
    }
}