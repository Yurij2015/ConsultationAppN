using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ConsultationApp
{
    public class AboutPage : ContentPage
    {
        public AboutPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "О приложении!" }
                }
            };
        }
    }
}