namespace MRAppNotas.Views;

public partial class MRAllNotesPage : ContentPage
{
    public MRAllNotesPage()
    {
        InitializeComponent();
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        notesCollection.SelectedItem = null;
    }
}
