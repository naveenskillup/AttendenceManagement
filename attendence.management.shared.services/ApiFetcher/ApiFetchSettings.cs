using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attendence.management.shared.services.ApiFetcher
{
    public class ApiFetchSettings
    {
        public int RequestTimeout { get; set; } = -1;
        public int Retries { get; set; } = 1;
        public int Interval { get; set; } = 0;
    }
}
