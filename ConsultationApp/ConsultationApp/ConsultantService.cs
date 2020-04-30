using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationApp
{
    class ConsultantService
    {
        const string Url = "http://192.168.0.34:3000/api/consultants/";
        // настройка клиента
        private HttpClient GetConsultant()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");



            return client;
        }

        // получаем всех консультантов
        public async Task<IEnumerable<Consultant>> Get()
        {
            HttpClient client = GetConsultant();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Consultant>>(result);
        }

    }
}
