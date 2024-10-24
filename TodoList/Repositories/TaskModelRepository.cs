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
            return _db.Task.OrderByDescending(a => a.FinalDate).ToList();
        }

        public TaskModel GetById(int id)
        {
            return _db.Task.Include(a => a.SubTasks).FirstOrDefault(a => a.Id == id);
        }

        public void Added(TaskModel model)
        {
            _db.Task.Add(model);
            _db.SaveChanges();
        }

        public void Updated(TaskModel model)
        {
            _db.Update(model);
            _db.SaveChanges();
        }

        public void Delete(TaskModel model)
        {
            _db.Task.Remove(model);
            _db.SaveChanges();
        }

        

        
    }
}
