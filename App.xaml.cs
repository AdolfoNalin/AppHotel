using AppHotel.View;
using Microsoft.Extensions.DependencyInjection;

namespace AppHotel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Menu();
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