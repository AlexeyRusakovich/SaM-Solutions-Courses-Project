using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace IntershipProject.Converters
{
    public class DataGridCellStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string status = (string)value;
            if (status.Equals("Выполняется"))
                return new SolidColorBrush(Color.FromRgb(0x3C, 0xA5, 0x5C));
            else if (status.Equals("Приостановлен"))
                return new SolidColorBrush(Color.FromArgb(0xFF, 0xDE, 0x69, 0x18));
            else if (status.Equals("Выполнен"))
                return new SolidColorBrush(Color.FromArgb(0xFF, 0x23, 0x7A, 0xE2));
            else if (status.Equals("Отменен"))
                return new SolidColorBrush(Color.FromArgb(0xFF, 0xFB, 0x37, 0x37));

            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
