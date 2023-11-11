using Plugin.Media;

namespace Ejercicio_1._4.Views;

public partial class PageImagen : ContentPage
{
    private Plugin.Media.Abstractions.MediaFile image = null;

    public PageImagen()
    {
        InitializeComponent();
    }

    public string ImageToBase64()
    {
        if (image != null)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                Stream stream = image.GetStream();
                stream.CopyTo(memory);
                byte[] data = memory.ToArray();
                string base64 = Convert.ToBase64String(data);

                return base64;
            }
        }

        return null;
    }

    public byte[] ImageToArrayByte()
    {
        if (image != null)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                Stream stream = image.GetStream();
                stream.CopyTo(memory);
                byte[] data = memory.ToArray();

                return data;
            }
        }

        return null;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
    }

    private async void btnfoto_Clicked(object sender, EventArgs e)
    {
        image = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
        {
            Directory = "MIALBUM",
            Name = "Foto.jpg",
            SaveToAlbum = true
        });

        if (image != null)
        {
            foto.Source = ImageSource.FromStream(() =>
            {
                return image.GetStream();
            });
        }
    }

    private async void btnagregar_Clicked(object sender, EventArgs e)
    {
        if (image != null)
        {
            var imagen = new Models.Imagenes
            {
                imagen = ImageToArrayByte(),
                descripcion = txtDescripcion.Text
            };
            if (await App.Instancia.AddImagen(imagen) > 0)
            {
                await DisplayAlert("Aviso", "Imagen guardada correctamente", "Ok");
            }
            else
            {
                await DisplayAlert("Aviso", "Ocurrio un error", "Ok");
            }
        }
        else
        {
            await DisplayAlert("Aviso", "Se debe agregar una fotografia", "Ok");
        }
    }

    private async void btnSavar_Clicked(object sender, EventArgs e)
    {
        if (image != null)
        {
            var imagen = new Models.Imagenes
            {
                imagen = ImageToArrayByte(),
                descripcion = txtDescripcion.Text
            };

            if (await App.Instancia.AddImagen(imagen) > 0)
            {
                await DisplayAlert("Aviso", "Imagen guardad correctamente", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Aviso", "Ocurrio un error", "Ok");
            }
        }
        else
        {
            await DisplayAlert("Sin imagen", "Debe tomar una fotografia para guardar la informacion", "Ok");
        }
    }
}