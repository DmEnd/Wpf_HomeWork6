using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public enum WindDirection
    {
        n, ne, e, es, s, sw, w, wn
    }
    public enum Precipitation
    {
        sunny,
        cloudy,
        rain,
        snow
    }

    public class WeatherControl : DependencyObject
    {
        //Поля
        //private int temp;
        //private WindDirection windDirection;
        //private int windSpeed;
        //private Precipitation precipitation;

        //Свойства
        public static WindDirection WindDirection { get; set; }
        public static int WindSpeed { get; set; }
        public static Precipitation Precipitation { get; set; }
        //Обертка из свойства над свойством зависимостью
        public int Temp
        {
            get { return (int)GetValue(TempProperty); }
            set { SetValue(TempProperty, value); }
        }

        //Конструктор
        public WeatherControl(int temp, WindDirection windDir, int windSp, Precipitation precip)
        {
            Temp = temp;
            //this.windDirection=windDirection;
            //this.windSpeed=windSpeed;
            //this.precipitation=precipitation;
            WindDirection = windDir;
            WindSpeed = windSp;
            Precipitation = precip;
        }
        //Свойство зависмость
        public static readonly DependencyProperty TempProperty;

        //Задание свойство зависмости
        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                "Temp",
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.Journal
                    ),
                new ValidateValueCallback(tempValidation)
                );
        }

        //Метод валидации
        private static bool tempValidation(object value)
        {
            if (-50 <= (int)value && (int)value <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
