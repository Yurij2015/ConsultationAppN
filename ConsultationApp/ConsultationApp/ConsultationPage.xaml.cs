using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsultationApp
{
    public partial class ConsultationPage : ContentPage
    {
        public Consultation Model { get; private set; }
        public ConsultationViewModel ViewModel { get; private set; }
        public ConsultationPage(Consultation model, ConsultationViewModel viewModel)
        {
            InitializeComponent();
            Model = model;
            ViewModel = viewModel;
            this.BindingContext = this;
        }

        public IList<string> ConsultantList
        {
            get
            {
                return new List<string> { "Макаров О. П.", "Иванов И. Ю.", "Васильев Г. О", "Маркова И. Ю.", "Сигаев Ю. Е.", "Бессмертных Г. Б.", "Корявин К. Н.", "выберу позже" };
            }
        }
    }
}