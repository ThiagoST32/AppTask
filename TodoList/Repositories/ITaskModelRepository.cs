using AppTask.Models;

namespace TodoList.Repositories
{
    public interface ITaskModelRepository
    {
        //CRUD

        IList<TaskModel> GetAll();
        TaskModel GetById(int id);
        void Added(TaskModel model);
        void Updated(TaskModel model);
        void Delete(TaskModel model);


    }
}
