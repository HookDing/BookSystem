using Books.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class View_BookAppraise: Mod_BookAppraise
    {
        private string userNick = "";
        private int bookID = 0;

        public string UserNick { get => userNick; set => userNick = value; }
        public int BookID { get => bookID; set => bookID = value; }
    }
}
