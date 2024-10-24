namespace TodoList.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

    private void AddTask(object sender, EventArgs e)
    {
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
}