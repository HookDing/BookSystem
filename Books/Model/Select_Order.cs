using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Select_Order : proc_page
    {
        private int _OrderID=0;
        public int OrderID { get { return _OrderID; } set { _OrderID = value; } }
        
        private string _UserName = "";
        public string UserName { get { return _UserName; } set { _UserName = value; } }

        private int _OrderState=0;
        public int OrderState { get { return _OrderState; } set { _OrderState = value; } }

        private DateTime _OrderDateStart =new DateTime();
        public DateTime OrderDateStart { get { return _OrderDateStart; } set { _OrderDateStart = value; } }

        private DateTime _OrderDateEnd =new DateTime();
        public DateTime OrderDateEnd { get { return _OrderDateEnd; } set { _OrderDateEnd = value; } }

    }
}
