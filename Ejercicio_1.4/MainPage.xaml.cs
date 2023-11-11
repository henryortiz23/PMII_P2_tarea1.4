using Ejercicio_1._4.Models;
using Ejercicio_1._4.Views;

namespace Ejercicio_1._4;

public partial class MainPage : ContentPage
{
    public static Imagenes imagenSeleccionado = null;

    public MainPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        list.ItemsSource = await App.Instancia.ListImagenes();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
    }

    private async void btnInsertar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.PageImagen());
    }

    private async void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Imagenes selectedPersona)
        {
            if (selectedPersona != null)
            {
                imagenSeleccionado = selectedPersona;
                mostrarImagen();
            }
        }
    }

    private async void mostrarImagen()
    {
        var pageNav = new PageModalImage();
        pageNav.BindingContext = imagenSeleccionado;
        await Navigation.PushModalAsync(pageNav, true);
    }
}