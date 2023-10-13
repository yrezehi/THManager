using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THManager.Events
{
    public class OnFinishArguments : EventArgs
    {
        public DateTime FinishTime { get; set; }
    }
}
