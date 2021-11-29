using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySudan.Client.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace PaySudan.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        [HttpPost]
        public ActionResult<PaymentResponse> Post([FromBody] string model)
        {
            var keysize = Aes.KeySize.Bits256;

            byte[] plainText = new byte[16];
            byte[] cipherText = new byte[16];

            plainText = Encoding.Unicode.GetBytes(model);

            var aes = new Aes(keysize, new byte[16]);

            aes.InvCipher(plainText, cipherText);

            var response = Encoding.Unicode.GetString(cipherText);
            var message =   JsonConvert.DeserializeObject<CardModel>(response);
            return Ok(new PaymentResponse() { Message = response });
        }

        public string PaymentGetWay(string caridt_card)
        {
            return "payment not success";
        }
    }
}
