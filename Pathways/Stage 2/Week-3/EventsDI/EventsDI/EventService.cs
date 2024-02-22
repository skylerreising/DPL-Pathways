using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDI
{
    public class EventService: ILogger
    {
        private readonly ILogger _logger;

        public EventService(ILogger logger)
        {
            _logger = logger;
        }
        public void Log(string message)
        {
            _logger.Log(message);
        }
    }
}
