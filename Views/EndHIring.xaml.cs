using AppHotel.Models;

namespace AppHotel.Views;

public partial class EndHIring : ContentPage
{
	public EndHIring()
	{
		InitializeComponent();
	}

    #region GoBack
	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private async void GoBack_Click(object sender, EventArgs e)
    {
		try
		{
			await Navigation.PopAsync();
		}
		catch (Exception ex)
		{
			await DisplayAlert("Erro", $"{ex.Message}, {ex.StackTrace}, {ex.HelpLink}", "Fechar");
			throw;
		}
    }
    #endregion
}