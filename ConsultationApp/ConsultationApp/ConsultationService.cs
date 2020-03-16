using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationApp
{
    class ConsultationService
    {
        const string Url = "http://192.168.0.106:3000/api/consultations/";
        // настройка клиента
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        // получаем все заявки
        public async Task<IEnumerable<Consultation>> Get()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Consultation>>(result);
        }

        // добавляем заявку
        public async Task<Consultation> Add(Consultation consultation)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(consultation),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Consultation>(
                await response.Content.ReadAsStringAsync());
        }
        // обновляем друга
        public async Task<Consultation> Update(Consultation consultation)
        {
            HttpClient client = GetClient();
            var response = await client.PutAsync(Url + "/" + consultation.Id,
                new StringContent(
                    JsonConvert.SerializeObject(consultation),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Consultation>(
                await response.Content.ReadAsStringAsync());
        }
        // удаляем друга
        public async Task<Consultation> Delete(int id)
        {
            HttpClient client = GetClient();
            var response = await client.DeleteAsync(Url + "/" + id);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Consultation>(
               await response.Content.ReadAsStringAsync());
        }
    }
}
