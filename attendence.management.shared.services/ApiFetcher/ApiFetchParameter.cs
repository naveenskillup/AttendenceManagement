using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attendence.management.shared.services.ApiFetcher
{
    public class ApiFetchParameter : ICloneable
    {
        public object Clone() => MemberwiseClone();

        public HttpMethod HttpMethod { get; set; }
        public Uri Uri { get; set; }
        public HttpContent Body { get; set; }
    }
}
