using Books.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class View_OrderDetail : Mod_OrderDetail
    {
        //OrderNum,OrderDate,OrderMoney,OrderState,UserName,AMUser,AMTel,AMAddress,BookTitle,BookMoney,ODCount
        public string OrderNum { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? OrderMoney { get; set; }
        public int? OrderState { get; set; }
        public string UserName { get; set; }
        public string AMUser { get; set; }
        public string AMTel { get; set; }
        public string AMAddress { get; set; }
        public string BookTitle { get; set; }
        public decimal? BookMoney { get; set; }
    }
}
