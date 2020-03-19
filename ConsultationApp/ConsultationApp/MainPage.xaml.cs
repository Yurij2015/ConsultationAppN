using System;
using Xamarin.Forms;

namespace ConsultationApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            Title = "Запись на консультацию";
            Button toCommonPageBtn = new Button
            {
                Text = "Оформить заявку",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            toCommonPageBtn.Clicked += ToCommonPage;

            Button toAboutPageBtn = new Button
            {
                Text = "О приложении",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            toAboutPageBtn.Clicked += ToAboutPage;

            Content = new StackLayout { Children = { toCommonPageBtn, toAboutPageBtn } };

        }

        private async void ToAboutPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        private async void ToCommonPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConsultationsPage());
        }
    }
}
