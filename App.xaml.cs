using AppHotel.Views;

namespace AppHotel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new HiringMenu());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Height = 700;
            window.Width = 400;

            return window;
        }
    }
}