using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSeminarioCic.Models
{
    public class ContentClass
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string userName { get; set; }
        public string issued { get; set; }
        public string expires { get; set; }

        public ContentClass()
        {
            access_token = token_type = userName = string.Empty;
            expires_in = 0;
            issued = expires = string.Empty;
        }
        public ContentClass(string accesT)
        {

            access_token = accesT;
            token_type = userName = string.Empty;
            expires_in = 0;
            issued = expires = string.Empty;
        }
    }
}
