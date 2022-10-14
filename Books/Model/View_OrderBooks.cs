using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class View_OrderBooks
    {
        private int oDID = 0;
        private int orderState = 0;
        private int bookID = 0;
        private int orderID = 0;
        private string iSBN = "";
        private string bookTitle = "";
        private decimal bookPrice = 0;
        private decimal bookMoney = 0;
        private int oDCount = 0;

        public string ISBN { get => iSBN; set => iSBN = value; }
        public string BookTitle { get => bookTitle; set => bookTitle = value; }
        public decimal BookPrice { get => bookPrice; set => bookPrice = value; }
        public decimal BookMoney { get => bookMoney; set => bookMoney = value; }
        public int ODCount { get => oDCount; set => oDCount = value; }
        public int OrderID { get => orderID; set => orderID = value; }
        public int BookID { get => bookID; set => bookID = value; }
        public int OrderState { get => orderState; set => orderState = value; }
        public int ODID { get => oDID; set => oDID = value; }
    }
}
