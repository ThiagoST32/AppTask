using AppTask.Models;
using System.Text;
using TodoList.Repositories;

namespace TodoList.Views;

public partial class AddEditTaskPage : ContentPage
{
    private TaskModel _task;

    private ITaskModelRepository _taskModelRepository;
	public AddEditTaskPage()
	{
		InitializeComponent();
        _task = new TaskModel();
        _taskModelRepository = new TaskModelRepository();
        BindableLayout.SetItemsSource(BindableLayout_Steps, _task.SubTasks);
	}


    private void CloseModal(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }

    private void SaveData(object sender, EventArgs e)
    {
        //Obter os Dados
        GetDataFromForm();

        //Validar os Dados
        ValidateData();

        //Salvar os Dados
        if (ValidateData()) SaveInDataBase();

        //Fechar a tela
        Navigation.PopModalAsync();

        //Atualizar Listagem de dados
        UpdateListOnStartPage();
    }

    private void UpdateListOnStartPage()
    {
        // NavigationPage > StartPage > LoadData();

        var navPage = (NavigationPage)App.Current.MainPage;
        var startPage = (StartPage)navPage.CurrentPage;
        startPage.LoadData();

    }

    private void SaveInDataBase()
    {

        _taskModelRepository.Added(_task);
    }

    private bool ValidateData()
    {
        bool validResult = true;
        LblTaskDescriptionInvalid.IsVisible = false;
        LblTaskNameInvalid.IsVisible = false;

        if (string.IsNullOrWhiteSpace(_task.Name)) LblTaskNameInvalid.IsVisible = true; validResult = false; 
        if (string.IsNullOrWhiteSpace(_task.Description)) LblTaskDescriptionInvalid.IsVisible = true; validResult = false; 


        return validResult;
    }

    private void GetDataFromForm()
    {
        _task.Name = Entry_TaskName.Text;
        _task.Description = Editor_TaskDescription.Text;
        _task.FinalDate = Date_PickerTaskDate.Date;

        _task.FinalDate = _task.FinalDate.AddHours(23);
        _task.FinalDate = _task.FinalDate.AddMinutes(23);
        _task.FinalDate = _task.FinalDate.AddSeconds(23);

        _task.Create = DateTime.Now;
        _task.IsCompleted = false;
    }

    private async void AddStep(object sender, EventArgs e)
    {
        var stepName = await DisplayPromptAsync("Etapa", "Digite um nome da etapa(subtarefa)",
            "Adicionar", "Cancelar");

        if (!string.IsNullOrEmpty(stepName))
        {
            _task.SubTasks.Add(new SubTaskModel { Name = stepName, IsCompleted = false });
        }

    }

    private void OnTapDelete(object sender, TappedEventArgs e)
    {
        _task.SubTasks.Remove((SubTaskModel)e.Parameter);
    }
}