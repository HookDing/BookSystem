using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Select_Book :proc_page
    {
        private string _BookTitle = "";
        public string BookTitle
        {
            get { return _BookTitle; }
            set { _BookTitle = value; }
        }
        private int _BLID = -1;
        public int BLID
        {
            get { return _BLID; }
            set { _BLID = value; }
        }
        private int _BSID= -1;
        public int BSID
        {
            get { return _BSID; }
            set { _BSID = value; }
        }
        private string _BookPublish = "";
        public string BookPublish
        {
            get { return _BookPublish; }
            set { _BookPublish = value; }
        }
        private int _BookIsHot= -1;
        public int BookIsHot
        {
            get { return _BookIsHot; }
            set { _BookIsHot = value; }
        }
        private int _BookIsBuy= -1;
        public int BookIsBuy
        {
            get { return _BookIsBuy; }
            set { _BookIsBuy = value; }
        }
    }
}
