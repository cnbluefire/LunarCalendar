using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace LunarCalendar
{
    public static class LunarExtension
    {
        public static bool GetShowLunar(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShowLunarProperty);
        }

        public static void SetShowLunar(DependencyObject obj, bool value)
        {
            obj.SetValue(ShowLunarProperty, value);
        }

        // Using a DependencyProperty as the backing store for ShowLunar.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowLunarProperty =
            DependencyProperty.RegisterAttached("ShowLunar", typeof(bool), typeof(LunarExtension), new PropertyMetadata(false, ShowLunarChanged));

        private static void ShowLunarChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CalendarViewDayItem sender)
            {
                if (e.NewValue != e.OldValue)
                {
                    if (sender.RenderSize.Width == 0 && sender.RenderSize.Height == 0)
                    {
                        sender.RegisterPropertyChangedCallback(CalendarViewDayItem.DateProperty, (s, a) =>
                        {
                            System.Diagnostics.Debug.WriteLine(sender.Date);
                            
                        });
                    }
                }
            }
        }
    }
}
