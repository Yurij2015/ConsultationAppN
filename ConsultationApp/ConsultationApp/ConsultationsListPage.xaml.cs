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
        ApplicationViewModel viewModel;
        public ConsultationsPage()
        {
            InitializeComponent();
            viewModel = new ApplicationViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetConsultations();
            base.OnAppearing();
        }
    }
}