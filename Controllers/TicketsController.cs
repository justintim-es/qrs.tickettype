using QRCoder;
using Microsoft.AspNetCore.Mvc;

namespace qrc.Controllers;
    [Route("[controller]")]
    public class TicketsController : ControllerBase {
        [HttpGet("{ticket}")]
        public IActionResult line(string ticket) {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(ticket, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(20);
            return File(qrCodeAsPngByteArr, "image/jpg");
        }

    }
