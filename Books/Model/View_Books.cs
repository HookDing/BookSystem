using Books.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class View_Books: Books.Model.Mod_Books
    {
        public int? BLID { get; set; }
        public string BLName { get; set; }
        public string BSName { get; set; }
    }
}
