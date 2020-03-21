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
    public partial class ConsultationsPage : ContentPage
    {
        ConsultationViewModel viewModel;
        public ConsultationsPage()
        {
            InitializeComponent();
            viewModel = new ConsultationViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetConsultations();
            base.OnAppearing();
        }
    }
}