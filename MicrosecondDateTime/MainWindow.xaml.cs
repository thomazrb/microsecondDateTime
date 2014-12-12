using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MicrosecondDateTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTcapture_Click(object sender, RoutedEventArgs e)
        {
            Int64 numOfTicks;
            numOfTicks = DateTime.Now.Ticks;
            TBcapture.Text = numOfTicks.ToString();
        }

        private void BTrebuild_Click(object sender, RoutedEventArgs e)
        {
            DateTime CompleteDate = new DateTime(Convert.ToInt64(TBcapture.Text));
            int day = CompleteDate.Day;
            int month = CompleteDate.Month;
            int year = CompleteDate.Year;
            int hour = CompleteDate.Hour;
            int minute = CompleteDate.Minute;
            int second = CompleteDate.Second;
            int millisecond = CompleteDate.Millisecond;
            
            DateTime withoutMicrosecondDate = new DateTime(year, month, day, hour, minute, second, millisecond);
            
            TBrebuild.Text = withoutMicrosecondDate.Ticks.ToString();
            double microsecond = (double)(CompleteDate.Ticks - withoutMicrosecondDate.Ticks) / (TimeSpan.TicksPerMillisecond / 1000);

            double microsecondFromFunction = microsecondDateTime(CompleteDate);

            TBlog.Text = "-= rebuilding the date, we don't use the microseconds, but they are in the ticks =-" + System.Environment.NewLine + System.Environment.NewLine;
            TBlog.Text = TBlog.Text + "Ticks per Millisecond: " + TimeSpan.TicksPerMillisecond.ToString() + System.Environment.NewLine;
            TBlog.Text = TBlog.Text + "Ticks Difference: " + (CompleteDate.Ticks - withoutMicrosecondDate.Ticks).ToString() + System.Environment.NewLine;
            TBlog.Text = TBlog.Text + "Days: " + day.ToString() + System.Environment.NewLine;
            TBlog.Text = TBlog.Text + "Months: " + month.ToString() + System.Environment.NewLine;
            TBlog.Text = TBlog.Text + "Years: " + year.ToString() + System.Environment.NewLine;
            TBlog.Text = TBlog.Text + "Hours: " + hour.ToString() + System.Environment.NewLine;
            TBlog.Text = TBlog.Text + "Minutes: " + minute.ToString() + System.Environment.NewLine;
            TBlog.Text = TBlog.Text + "Seconds: " + second.ToString() + System.Environment.NewLine;
            TBlog.Text = TBlog.Text + "Milliseconds: " + millisecond.ToString() + System.Environment.NewLine;
            TBlog.Text = TBlog.Text + "Microseconds: " + microsecond.ToString() + System.Environment.NewLine;
            TBlog.Text = TBlog.Text + "Microseconds by the function: " + microsecondFromFunction.ToString() + System.Environment.NewLine;
        }

        double microsecondDateTime(DateTime date)
        {
            DateTime withoutMicrosecondDate = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
            return (double)(date.Ticks - withoutMicrosecondDate.Ticks) / (TimeSpan.TicksPerMillisecond / 1000);
        }
    }
}
