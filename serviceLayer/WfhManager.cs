using coreLayer.BusinessObject;
using dataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serviceLayer
{
    public class WfhManager
    {
        public static void AddWfh(Wfh wfh)
        {
            WfhDB.AddWfh(wfh);
        }

        public void RemoveWfh(int id)

        {
            WfhDB.RemoveWfh(id);
        }
    }
}
