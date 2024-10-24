using AppTask.Models;
using TodoList.Repositories;

namespace TodoList.Views;

public partial class StartPage : ContentPage
{
    private ITaskModelRepository _repository;
	public StartPage()
	{
		InitializeComponent();

        //TODO - Ponto de Melhoria -> Implementar usando D.I
        _repository = new TaskModelRepository();
        
        LoadData();
	}

    private void LoadData()
    {
        var tasks = _repository.GetAll();
        CollectionViweTasks.ItemsSource = tasks;
        EmptyText.IsVisible = tasks.Count <= 0;
        //tasks.Remove();
        //(List<TaskModel>)(CollectionViweTasks.ItemsSource).
    }


    private void AddTask(object sender, EventArgs e)
    {
        _repository.Added(new TaskModel
        {
            Name = "Carro",
            Description = "Suspensões",
            IsCompleted = true,
            Create = DateTime.Now,
            FinalDate = DateTime.Now.AddDays(2)
        });


        LoadData();
		//Navigation.PushModalAsync(new AddEditTaskPage());
    }

    private void FocusEntrySearch(object sender, TappedEventArgs e)
    {
        EntrySearch.Focus();
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        //DatePicker_TaskDate.WidthRequest = width;
    }

    private async void OnImageClickedRemoveTask(object sender, TappedEventArgs e)
    {
        var task = (TaskModel)e.Parameter;
        var confirm = await DisplayAlert("Exclusão", $"Deseja Excluir a tarefa: {task} ?", "Sim", "Não");
        if (confirm)
        {
            _repository.Delete(task);
            LoadData();
        }
    }
}