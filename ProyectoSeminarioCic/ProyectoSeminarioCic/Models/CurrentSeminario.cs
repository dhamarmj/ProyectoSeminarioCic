using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    public class CurrentSeminario
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string TerciaryColor { get; set; }
        public string AccentColor1 { get; set; }
        public string AccentColor2 { get; set; }
        public string HeaderPath { get; set; }
        public string IconPath { get; set; }

        public CurrentSeminario()
        {
            if (!string.IsNullOrEmpty(Settings.idSeminario))
                Id = Convert.ToInt32(Settings.idSeminario);
            Titulo = "Impacta";
            PrimaryColor = "#0B5575";
            SecondaryColor = "#FF7300";
            TerciaryColor = "#FFFFFF";
            AccentColor1 = "#F1F1F2";
            AccentColor2 = "#3A3A3A";
        }



    }
}
