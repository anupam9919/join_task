using coreLayer.BusinessObject;
using dataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serviceLayer
{
    public class LeaveManager
    {
        public static void AddLeave(Leaves leave)
        {
            LeaveDB.AddLeave(leave);
        }
    }
}
