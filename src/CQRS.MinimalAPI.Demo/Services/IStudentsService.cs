using CQRS.MinimalAPI.Demo.Models;

namespace CQRS.MinimalAPI.Demo.Services;

public interface IStudentsService
{
  Task<bool> Delete(int id);

  Task<IList<Student>?> GetAll();

  Task<Student?> GetById(int id);

  Task<Student?> GetByName(string name);

  Task<Student> Create(Student student);

  Task<Student> Update(Student student);
}