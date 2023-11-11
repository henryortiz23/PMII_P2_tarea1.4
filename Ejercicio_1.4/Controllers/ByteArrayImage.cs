using System.Globalization;

namespace Ejercicio_1._4.Controllers
{
    internal class ByteArrayImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameters, CultureInfo culture)
        {
            ImageSource image = null;
            if (value != null)
            {
                byte[] bytes = (byte[])value;
                var stream = new MemoryStream(bytes);
                image = ImageSource.FromStream(() => stream);
            }
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}