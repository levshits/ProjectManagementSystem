using System;
using System.Collections.Generic;
using System.Threading;

namespace PMS.Web.Storages
{
    public class SelfCleanableStorage
    {
        private Timer _timer;
        private Dictionary<string, object> _values = new Dictionary<string, object>();
        private Dictionary<string, DateTime> _timeouts = new Dictionary<string, DateTime>();

        public SelfCleanableStorage()
        {
            _timer = new Timer(TimerHandler, this, TimeSpan.FromMinutes(0), TimeSpan.FromMinutes(10));
        }

        public object this[string key]
        {
            get
            {
                object value;
                if (_values.TryGetValue(key, out value))
                {
                    _timeouts[key]=DateTime.Now;
                }
                return value;
            }
            set
            {
                _timeouts[key] = DateTime.Now;
                _values[key] = value;
            }
        }
        private static void TimerHandler(object state)
        {
            SelfCleanableStorage storage = (SelfCleanableStorage) state;
            foreach (var pair in storage._timeouts)
            {
                if (DateTime.Now - pair.Value > TimeSpan.FromHours(24))
                {
                    storage._values.Remove(pair.Key);
                    storage._timeouts.Remove(pair.Key);
                }
            }
        }
    }
}