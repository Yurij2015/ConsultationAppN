using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultationApp
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        bool initialized = false;   // была ли начальная инициализация
        Consultation selectedConsultation;  // выбранная консультация
        private bool isBusy;    // идет ли загрузка с сервера

        public ObservableCollection<Consultation> Consultations { get; set; }
        ConsultationService consultationsService = new ConsultationService();
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateConsultationCommand { protected set; get; }
        public ICommand DeleteConsultationCommand { protected set; get; }
        public ICommand SaveConsultationCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        public INavigation Navigation { get; set; }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsLoaded");
            }
        }
        public bool IsLoaded
        {
            get { return !isBusy; }
        }

        public ApplicationViewModel()
        {
            Consultations = new ObservableCollection<Consultation>();
            IsBusy = false;
            CreateConsultationCommand = new Command(CreateConsultation);
            DeleteConsultationCommand = new Command(DeleteConsultation);
            SaveConsultationCommand = new Command(SaveConsultation);
            BackCommand = new Command(Back);
        }

        public Consultation SelectedConsultation
        {
            get { return selectedConsultation; }
            set
            {
                if (selectedConsultation != value)
                {
                    Consultation tempConsultation = new Consultation()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Email = value.Email,
                        Phone = value.Phone
                    };
                    selectedConsultation = null;
                    OnPropertyChanged("SelectedConsultation");
                    Navigation.PushAsync(new ConsultationPage(tempConsultation, this));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private async void CreateConsultation()
        {
            await Navigation.PushAsync(new ConsultationPage(new Consultation(), this));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }

        public async Task GetConsultations()
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<Consultation> consultations = await consultationsService.Get();

            // очищаем список
            //Consultations.Clear();
            while (Consultations.Any())
                Consultations.RemoveAt(Consultations.Count - 1);

            // добавляем загруженные данные
            foreach (Consultation c in consultations)
                Consultations.Add(c);
            IsBusy = false;
            initialized = true;
        }
        private async void SaveConsultation(object consultationObject)
        {
            Consultation consultation = consultationObject as Consultation;
            if (consultation != null)
            {
                IsBusy = true;
                // редактирование
                if (consultation.Id > 0)
                {
                    Consultation updatedConsultation = await consultationsService.Update(consultation);
                    // заменяем объект в списке на новый
                    if (updatedConsultation != null)
                    {
                        int pos = Consultations.IndexOf(updatedConsultation);
                        Consultations.RemoveAt(pos);
                        Consultations.Insert(pos, updatedConsultation);
                    }
                }
                // добавление
                else
                {
                    Consultation addedConsultation = await consultationsService.Add(consultation);
                    if (addedConsultation != null)
                        Consultations.Add(addedConsultation);
                }
                IsBusy = false;
            }
            Back();
        }
        private async void DeleteConsultation(object consultationObject)
        {
            Consultation consultation = consultationObject as Consultation;
            if (consultation != null)
            {
                IsBusy = true;
                Consultation deletedConsultation = await consultationsService.Delete(consultation.Id);
                if (deletedConsultation != null)
                {
                    Consultations.Remove(deletedConsultation);
                }
                IsBusy = false;
            }
            Back();
        }
    }
}
