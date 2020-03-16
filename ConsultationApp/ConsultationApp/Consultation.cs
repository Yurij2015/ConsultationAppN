using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultationApp
{
    public class Consultation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public override bool Equals(object obj)
        {
            Consultation consultation = obj as Consultation;
            return this.Id == consultation.Id;
        }
    }
}
