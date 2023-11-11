namespace Ejercicio_1._4.Views;

public partial class PageModalImage : ContentPage
{
    public PageModalImage()
    {
        InitializeComponent();
    }

    private async void btnCerrar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}