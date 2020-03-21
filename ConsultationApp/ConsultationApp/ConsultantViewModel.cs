using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultationApp
{
    class ConsultantViewModel
    {
        bool initialized = false;   // была ли начальная инициализация
        private bool isBusy;    // идет ли загрузка с сервера

        public ObservableCollection<Consultant> Consultants { get; set; }
        ConsultantService consultantService = new ConsultantService();


        public INavigation Navigation { get; set; }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
            }
        }
        public bool IsLoaded
        {
            get { return !isBusy; }
        }

        public ConsultantViewModel()
        {
            Consultants = new ObservableCollection<Consultant>();
            IsBusy = false;

        }


        public async Task GetConsultants()
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<Consultant> consultants = await consultantService.Get();

            // очищаем список
            //Consultations.Clear();
            while (Consultants.Any())
                Consultants.RemoveAt(Consultants.Count - 1);

            // добавляем загруженные данные
            foreach (Consultant c in consultants)
                Consultants.Add(c);
            IsBusy = false;
            initialized = true;
        }
    }
}
