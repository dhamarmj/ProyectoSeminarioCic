using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSeminarioCic.Services
{
    public interface ICodeScanningService
    {
        Task<string> ScanAsync();
    }
}
