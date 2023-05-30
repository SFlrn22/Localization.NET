using System.Diagnostics;

namespace Localization.NET;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void ButtonClicked(object sender, EventArgs e)
    {
        Models.Location locationCoords = await GetLocation();
        BindingContext = locationCoords;
    }

    private async Task<Models.Location> GetLocation()
    {
        Models.Location coordinates = new Models.Location();
        try
        {
            var request = new Xamarin.Essentials.GeolocationRequest(Xamarin.Essentials.GeolocationAccuracy.Medium);
            var location = await Xamarin.Essentials.Geolocation.GetLocationAsync(request);

            if (location != null)
            {
                coordinates.Latitude = location.Latitude;
                coordinates.Longitude = location.Longitude;
            }
            else
            {
                coordinates.Latitude = 0;
                coordinates.Longitude = 0;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }

        return coordinates;
    }
}

