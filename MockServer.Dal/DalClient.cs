using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCBase.Data;

namespace MockServer.Dal
{
    public class DalClient
    {
        public SqlClient DataClient
        {
            get
            {
                return new SqlClient(Constants.TCFlyMock);
            }
        }
    }
}
