using AppTask.Models;
using TodoList.Repositories;

namespace TodoList.Views;

public partial class StartPage : ContentPage
{
    private readonly TaskModelRepository _repository;
	public StartPage()
	{
		InitializeComponent();

        //TODO - Ponto de Melhoria -> Implementar usando D.I
        _repository = new TaskModelRepository();
        
        LoadData();
	}

    public void LoadData()
    {
        var tasks = _repository.GetAll();
        EmptyText.IsVisible = tasks.Count <= 0;
    }


    private void AddTask(object sender, EventArgs e)
    {
        LoadData();
		Navigation.PushModalAsync(new AddEditTaskPage());
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
        var confirm = await DisplayAlert("Exclusão", $"Deseja Excluir a tarefa: {task.Name} ?", "Sim", "Não");
        if (confirm)
        {
            _repository.Delete(task);
            LoadData();
        }
    }

    private void OnTapChangeToTaskComplete(object sender, TappedEventArgs e)
    {
        var task = (TaskModel)e.Parameter;
        var checkbox = ((CheckBox)sender);
        task.IsCompleted = checkbox.IsChecked;
        _repository.Updated(task);
        Console.WriteLine(task.IsCompleted);
    }
}