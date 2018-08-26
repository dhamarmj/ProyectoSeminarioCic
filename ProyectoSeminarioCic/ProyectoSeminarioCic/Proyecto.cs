using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic
{
    public class Proyecto
    {
        private static Models.CurrentSeminario _currentSeminar;
        public static Models.CurrentSeminario CurrrentSeminar
        {
            get
            {
                if (_currentSeminar == null)
                    _currentSeminar = new Models.CurrentSeminario();

                return _currentSeminar;

            }
            set
            {
                _currentSeminar = value;
            }
        }
    }
}
