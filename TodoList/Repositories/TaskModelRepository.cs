using AppTask.Models;
using AppTaskDatabase;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Repositories
{
    public class TaskModelRepository : ITaskModelRepository
    {
        private AppTaskContext _db;

        public TaskModelRepository() 
        {
            _db = new AppTaskContext();       
        }

        public IList<TaskModel> GetAll()
        {
            return _db.Task.ToList();
            throw new NotImplementedException();
        }

        public TaskModel GetById(int id)
        {
            return _db.Task.Include(a => a.SubTasks).FirstOrDefault(a => a.Id == id);
            throw new NotImplementedException();
        }

        public void Added(TaskModel model)
        {
            _db.Task.Add(model);
            _db.SaveChanges();
            throw new NotImplementedException();
        }

        public void Updated(TaskModel model)
        {
            _db.Update(model);
            _db.SaveChanges();
            throw new NotImplementedException();
        }

        public void Delete(TaskModel model)
        {
            _db.Task.Remove(model);
            _db.SaveChanges();
            throw new NotImplementedException();
        }

        

        
    }
}
