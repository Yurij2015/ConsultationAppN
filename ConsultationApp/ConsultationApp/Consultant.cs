using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultationApp
{
    public class Consultant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Portfolio { get; set; }
        public string Services { get; set; }

        public override bool Equals(object obj)
        {
            Consultant consultant = obj as Consultant;
            return this.Id == consultant.Id;
        }
    }
}
