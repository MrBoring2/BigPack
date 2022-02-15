using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using TestDemPodgotovka.Data;

namespace TestDemPodgotovka.Resources.Converters
{
    public class LIstViewRowColorFromCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            using (var db = new TestDemContext())
            {
                var material = db.Material.Find(System.Convert.ToInt32(value));
                if (material.CountInStock < material.MinCount)
                {
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f19292"));
                }
                else if (material.CountInStock >= material.MinCount * 300 / 100)
                {
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffba01"));
                }
                else return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
