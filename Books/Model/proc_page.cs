using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    
    [Serializable]
    public class proc_page
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string TableName { get; set; }
        public string KeyName { get; set; }
        public string Filter { get; set; }
        public string Where { get; set; }
        public string Order { get; set; }
        public int DataCount { get; set; }

    }
}
