namespace MRAppNotas
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.MRNotePage1), typeof(Views.MRNotePage1));
        }
    }
}
