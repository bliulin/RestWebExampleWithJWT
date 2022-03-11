using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationJwtAuth.Models
{
    public class Token
    {
        public string TokenValue { get; set; }
        public string RefreshToken { get; set; }
    }
}
