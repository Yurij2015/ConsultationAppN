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

            Label header = new Label();
            this.Content = header;

            FormattedString formattedString = new FormattedString();
            formattedString.Spans.Add(new Span
            {
                Text = "Юридическая консультация онлайн от LawyerConsulting  ",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold

            });

            formattedString.Spans.Add(new Span
            {
                Text = "- это современный подход к юридическим услугам, " +
                    "благодаря которому каждый человек может получить доступную и квалифицированную правовую помощь, не выходя из дома, на работе или в " +
                    "путешествии." +
                    "\n\nЧТО ВЫ ПОЛУЧИТЕ, ОБРАТИВШИСЬ В LawyerConsulting?" +
                    "\n\nПОДБОР ЮРИСТА Ваша задача будет обработана профилирующим юристом ЮК" +
                    " 'LawyerConsulting', которая входят в ТОП 20 ведущих компаний на рынке " +
                    "\n\nТАЙМ-МЕНЕДЖМЕНТ Мы консолидируем весь процесс на базе одной" +
                    " структуры , что позволяет контролировать качество услуги и оперативно предоставлять решения " +
                    "\n\nКОММУНИКАЦИЯ Мы держим вас в курсе" +
                    " о ходе выполнения задач через смс-статусы. " +
                    "\n\nПОНЯТНЫЙ КОНЕЧНЫЙ РЕЗУЛЬТАТ В течении 24 часов Вы получаете план пошаговых " +
                    "действий, который изложен понятным языком Получить онлайн консультацию просто – нужно лишь оставить заявку",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))

            });
            header.FontSize = 26;
            header.FormattedText = formattedString;

        }
    }
}