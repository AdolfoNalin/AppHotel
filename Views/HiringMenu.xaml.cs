using AppHotel.Models;

namespace AppHotel.Views;

public partial class HiringMenu : ContentPage
{

    public List<Accommodation> accommodations { get; set; }

    public HiringMenu()
	{
		InitializeComponent();
        //pckRoom.ItemsSource = accommodations;


        accommodations = new List<Accommodation>()
        {
            new Accommodation()
            {
                Description = "NQ: 1, 1 suíte simples",
                PriceAdult = 80,
                PriceKids = 55.0,
            },
            new Accommodation()
            {
                Description = "NQ: 2, 1 Suíte c/ Cozinha",
                PriceAdult = 110.5,
                PriceKids = 55.0,
            },
            new Accommodation()
            {
                Description = "NQ: 3, 2 Suítes Simples",
                PriceAdult = 100.5,
                PriceKids = 50.0,
            },
            new Accommodation()
            {
                Description = "NQ: 4, 2 Suítes c/ Cozinha",
                PriceAdult = 150.5,
                PriceKids = 70.0,
            },
            new Accommodation()
            {
                Description = "NQ: 5, 1 Suíte c/ Cozinha, c/ Varanda",
                PriceAdult = 160.0,
                PriceKids = 90.0,
            },
            new Accommodation()
            {
                Description = "NQ: 6, 2 Suítes c/ Cozinha, c/ Varanda",
                PriceAdult = 180,
                PriceKids = 100,
            }
        };

        BindingContext = this;

        dpStartDate.MinimumDate = DateTime.Now;
        dpStartDate.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);
        dpEndDate.MinimumDate = dpStartDate.Date.Value.AddDays(1);
        dpEndDate.MaximumDate = dpStartDate.Date.Value.AddMonths(6);
        
	}

    #region Calculation
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Calculation(object sender, EventArgs e)
    {
		try
		{
            if(sptAdult.Value == 0)
            {
                throw new ArgumentException("O Valor adulto não pode ser 0");
            }
            else if(sptAdult.Value == 0 && sptKids.Value > 0)
            {
                throw new ArgumentException("É necessário 1 Adulto");
            }

            Accommodation ac = pckRoom.SelectedItem as Accommodation
                ?? throw new ArgumentNullException("Selecione a configuração da acomodação!");

			Accommodation accommodation = new Accommodation()
			{
                Description = ac.Description,
				StartDate = (DateTime)dpStartDate.Date,
				EndDate = (DateTime)dpEndDate.Date,
                AmountAdult = sptAdult.Value,
                AmountKids = sptKids.Value,
                PriceAdult = ac.PriceAdult,
                PriceKids = ac.PriceKids,
			};

			await Navigation.PushAsync(new EndHIring()
            {
                BindingContext = accommodation
            });
		}
        catch(ArgumentNullException ane)
        {
            await DisplayAlert("Erro", ane.ParamName, "Fechar");
        }
        catch(ArgumentException ae)
        {
            await DisplayAlert("Error", ae.Message, "Fechar");
        }
		catch (Exception ex)
		{
			await DisplayAlert("Erro", $"{ex.Message}, {ex.StackTrace}, {ex.HelpLink}", "OK");
		}
    }
    #endregion

    #region
    private void dpStartDate_DateSelected(object sender, DateChangedEventArgs e)
    {
        try
        {
            DateTime? dateTimeElement = e.NewDate;
            dpEndDate.MaximumDate = dateTimeElement.Value.AddDays(1);
            dpEndDate.MaximumDate = dateTimeElement.Value.AddMonths(6);

            if (dpEndDate.MinimumDate < dpStartDate.Date)
            {
                dpEndDate.MinimumDate = dpStartDate.Date?.AddDays(1);
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    #endregion
}