using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsultationApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultantsListPage : ContentPage
    {
        ConsultantViewModel viewModel;

        public ConsultantsListPage()
        {
            InitializeComponent();
            viewModel = new ConsultantViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetConsultants();
            base.OnAppearing();
        }

        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Consultant selectedConsultant = e.Item as Consultant;
            if (selectedConsultant != null)
                await DisplayAlert("Консультант\n", $"{selectedConsultant.Name}\n{selectedConsultant.Phone}\n{selectedConsultant.Email}\n{selectedConsultant.Services}\n{selectedConsultant.Portfolio}", "OK");
        }

    }
}