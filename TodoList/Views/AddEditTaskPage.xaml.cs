namespace TodoList.Views;

public partial class AddEditTaskPage : ContentPage
{
	public AddEditTaskPage()
	{
		InitializeComponent();
	}

    private void CloseModal(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }

    private void SaveData(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private async void AddStep(object sender, EventArgs e)
    {
        var stepName = await DisplayPromptAsync("Etapa", "Digite um nome da etapa(subtarefa)",
            "Adicionar", "Cancelar");
    }
}