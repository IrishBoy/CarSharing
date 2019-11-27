using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.GraphUI
{
    public class CommonComponent
    {
        private int _counter;

        public event Action<int> CounterChanged;

        public void IncreseCounter()
        {
            _counter++;
            CounterChanged?.Invoke(_counter);
        }
    }
}
