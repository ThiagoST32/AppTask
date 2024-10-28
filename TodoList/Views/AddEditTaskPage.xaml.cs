using AppTask.Models;
using System.Text;

namespace TodoList.Views;

public partial class AddEditTaskPage : ContentPage
{
    private TaskModel _task;
	public AddEditTaskPage()
	{
		InitializeComponent();
        _task = new TaskModel();
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

        //Fechar a tela

        //Atualizar Listagem de dados
        Navigation.PopModalAsync();
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