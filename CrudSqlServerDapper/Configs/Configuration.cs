using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSqlServerDapper.Configs
{
    public class Configuration
    {
        #region Properties
        public string Connectionstring
        {
            get
            {
                return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBClients;Integrated Security=True;";
            }

        }
        #endregion
    }
}
