using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace CardAlignment.Converters
{
    public class HomeCardHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //user visible area item count, usually max count is 6
            //When the user is navigating from one edge of the TV screen to the other,
            //it should take no more than six clicks to simplify your UI.
            //Again, the principle of simplicity applies here.
            int numberSeries = 4;
            int numberMovie = 6;
            //item left/right margin = 20, defined in MainPage.xaml
            int itemLRMargin = 20;
            //item top/bottom margin = 20, defined in MainPage.xaml
            int itemTBMargin = 20;
            //river left/right margin = 12, defined in AdaptiveGridView
            int riverMargin = 12;

            double itemWidth = 0;
            double itemHeight = 0;

            //Item ratio
            //movie 2:3
            //series 16:9
            switch (value.ToString())
            {
                case "4":   //movie
                    itemWidth = (Window.Current.CoreWindow.Bounds.Width - riverMargin * 2 - (numberMovie) * itemLRMargin * 2) / numberMovie;
                    itemHeight = 1.3 * itemWidth * 3 / 2;
                    Debug.WriteLine("itemHeight" + itemHeight);
                    break;
                default:
                    itemWidth = (Window.Current.CoreWindow.Bounds.Width - riverMargin * 2 - (numberSeries) * itemLRMargin * 2) / numberSeries;
                    itemHeight = 1.5 * itemWidth * 9 / 16;
                    Debug.WriteLine("itemHeight" + itemHeight);
                    break;
            }

            return itemHeight;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
