using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using ProyectoSeminarioCic.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof(ProyectoSeminarioCic.iOS.Services.CodeScanningService))]

namespace ProyectoSeminarioCic.iOS.Services
{
    public class CodeScanningService : ICodeScanningService
    {
        public async Task<string> ScanAsync()
        {
            var scanner = new MobileBarcodeScanner();
            var scanResults = await scanner.Scan();
            //Fix by Ale
            return (scanResults != null) ? scanResults.Text : string.Empty;
        }
    }
}