using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Model
{
    /// <summary>
    /// Books数据模型对象
    /// </summary>
    [Serializable]
    public partial class Mod_Books
    {
        /// <summary>
        /// 初始化Books数据模型对象
        /// </summary>
        public Mod_Books()
        {
            
        }
        /// <summary>
        /// 初始化Books数据模型对象并给在SQL中不能为空的字段赋值
        /// </summary>
        /// <param name="bookID">BookID</param>
        public Mod_Books(int bookID)
        {
            //给BookID字段赋值
            this.BookID = bookID;
        }
        /// <summary>
        /// 初始化Books数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="bookID">BookID</param>
        /// <param name="bSID">BSID</param>
        /// <param name="bookTitle">BookTitle</param>
        /// <param name="bookAuthor">BookAuthor</param>
        /// <param name="bookPublish">BookPublish</param>
        /// <param name="iSBN">ISBN</param>
        /// <param name="bookCount">BookCount</param>
        /// <param name="bookMoney">BookMoney</param>
        /// <param name="bookPrice">BookPrice</param>
        /// <param name="bookDesc">BookDesc</param>
        /// <param name="bookAuthorDesc">BookAuthorDesc</param>
        /// <param name="bookComm">BookComm</param>
        /// <param name="bookContent">BookContent</param>
        /// <param name="bookSale">BookSale</param>
        /// <param name="bookDeport">BookDeport</param>
        /// <param name="bookIsBuy">BookIsBuy</param>
        /// <param name="bookIsHot">BookIsHot</param>
        /// <param name="bookIsDelete">BookIsDelete</param>
        /// <param name="bookBuyDate">BookBuyDate</param>
        /// <param name="bookHotDate">BookHotDate</param>
        public Mod_Books(int bookID,int? bSID,string bookTitle,string bookAuthor,string bookPublish,string iSBN,int? bookCount,decimal? bookMoney,decimal? bookPrice,string bookDesc,string bookAuthorDesc,string bookComm,string bookContent,int? bookSale,int? bookDeport,bool? bookIsBuy,bool? bookIsHot,bool? bookIsDelete,DateTime? bookBuyDate,DateTime? bookHotDate)
        {
            //给BookID字段赋值
            this.BookID = bookID;
            //给BSID字段赋值
            this.BSID = bSID;
            //给BookTitle字段赋值
            this.BookTitle = bookTitle;
            //给BookAuthor字段赋值
            this.BookAuthor = bookAuthor;
            //给BookPublish字段赋值
            this.BookPublish = bookPublish;
            //给ISBN字段赋值
            this.ISBN = iSBN;
            //给BookCount字段赋值
            this.BookCount = bookCount;
            //给BookMoney字段赋值
            this.BookMoney = bookMoney;
            //给BookPrice字段赋值
            this.BookPrice = bookPrice;
            //给BookDesc字段赋值
            this.BookDesc = bookDesc;
            //给BookAuthorDesc字段赋值
            this.BookAuthorDesc = bookAuthorDesc;
            //给BookComm字段赋值
            this.BookComm = bookComm;
            //给BookContent字段赋值
            this.BookContent = bookContent;
            //给BookSale字段赋值
            this.BookSale = bookSale;
            //给BookDeport字段赋值
            this.BookDeport = bookDeport;
            //给BookIsBuy字段赋值
            this.BookIsBuy = bookIsBuy;
            //给BookIsHot字段赋值
            this.BookIsHot = bookIsHot;
            //给BookIsDelete字段赋值
            this.BookIsDelete = bookIsDelete;
            //给BookBuyDate字段赋值
            this.BookBuyDate = bookBuyDate;
            //给BookHotDate字段赋值
            this.BookHotDate = bookHotDate;
        }
        
		//属性存储数据的变量
        private int _bookID;
        private int? _bSID;
        private string _bookTitle;
        private string _bookAuthor;
        private string _bookPublish;
        private string _iSBN;
        private int? _bookCount;
        private decimal? _bookMoney;
        private decimal? _bookPrice;
        private string _bookDesc;
        private string _bookAuthorDesc;
        private string _bookComm;
        private string _bookContent;
        private int? _bookSale;
        private int? _bookDeport;
        private bool? _bookIsBuy;
        private bool? _bookIsHot;
        private bool? _bookIsDelete;
        private DateTime? _bookBuyDate;
        private DateTime? _bookHotDate;
        
        /// <summary>
        /// BookID
        /// </summary>
        public int BookID
        {
            get { return this._bookID; }
            set { this._bookID = value; }
        }
        /// <summary>
        /// BSID
        /// </summary>
        public int? BSID
        {
            get { return this._bSID; }
            set { this._bSID = value; }
        }
        /// <summary>
        /// BookTitle
        /// </summary>
        public string BookTitle
        {
            get { return this._bookTitle; }
            set { this._bookTitle = value; }
        }
        /// <summary>
        /// BookAuthor
        /// </summary>
        public string BookAuthor
        {
            get { return this._bookAuthor; }
            set { this._bookAuthor = value; }
        }
        /// <summary>
        /// BookPublish
        /// </summary>
        public string BookPublish
        {
            get { return this._bookPublish; }
            set { this._bookPublish = value; }
        }
        /// <summary>
        /// ISBN
        /// </summary>
        public string ISBN
        {
            get { return this._iSBN; }
            set { this._iSBN = value; }
        }
        /// <summary>
        /// BookCount
        /// </summary>
        public int? BookCount
        {
            get { return this._bookCount; }
            set { this._bookCount = value; }
        }
        /// <summary>
        /// BookMoney
        /// </summary>
        public decimal? BookMoney
        {
            get { return this._bookMoney; }
            set { this._bookMoney = value; }
        }
        /// <summary>
        /// BookPrice
        /// </summary>
        public decimal? BookPrice
        {
            get { return this._bookPrice; }
            set { this._bookPrice = value; }
        }
        /// <summary>
        /// BookDesc
        /// </summary>
        public string BookDesc
        {
            get { return this._bookDesc; }
            set { this._bookDesc = value; }
        }
        /// <summary>
        /// BookAuthorDesc
        /// </summary>
        public string BookAuthorDesc
        {
            get { return this._bookAuthorDesc; }
            set { this._bookAuthorDesc = value; }
        }
        /// <summary>
        /// BookComm
        /// </summary>
        public string BookComm
        {
            get { return this._bookComm; }
            set { this._bookComm = value; }
        }
        /// <summary>
        /// BookContent
        /// </summary>
        public string BookContent
        {
            get { return this._bookContent; }
            set { this._bookContent = value; }
        }
        /// <summary>
        /// BookSale
        /// </summary>
        public int? BookSale
        {
            get { return this._bookSale; }
            set { this._bookSale = value; }
        }
        /// <summary>
        /// BookDeport
        /// </summary>
        public int? BookDeport
        {
            get { return this._bookDeport; }
            set { this._bookDeport = value; }
        }
        /// <summary>
        /// BookIsBuy
        /// </summary>
        public bool? BookIsBuy
        {
            get { return this._bookIsBuy; }
            set { this._bookIsBuy = value; }
        }
        /// <summary>
        /// BookIsHot
        /// </summary>
        public bool? BookIsHot
        {
            get { return this._bookIsHot; }
            set { this._bookIsHot = value; }
        }
        /// <summary>
        /// BookIsDelete
        /// </summary>
        public bool? BookIsDelete
        {
            get { return this._bookIsDelete; }
            set { this._bookIsDelete = value; }
        }
        /// <summary>
        /// BookBuyDate
        /// </summary>
        public DateTime? BookBuyDate
        {
            get { return this._bookBuyDate; }
            set { this._bookBuyDate = value; }
        }
        /// <summary>
        /// BookHotDate
        /// </summary>
        public DateTime? BookHotDate
        {
            get { return this._bookHotDate; }
            set { this._bookHotDate = value; }
        }
        
        /// <summary>
        /// 对比两个Books数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的Books数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成Books数据模型对象
            Mod_Books booksMod = obj as Mod_Books;
            //判断是否转换成功
            if (booksMod == null) return false;
            //进行匹配属性的值
            return
                //判断BookID是否一致
                this.BookID == booksMod.BookID &&
                //判断BSID是否一致
                this.BSID == booksMod.BSID &&
                //判断BookTitle是否一致
                this.BookTitle == booksMod.BookTitle &&
                //判断BookAuthor是否一致
                this.BookAuthor == booksMod.BookAuthor &&
                //判断BookPublish是否一致
                this.BookPublish == booksMod.BookPublish &&
                //判断ISBN是否一致
                this.ISBN == booksMod.ISBN &&
                //判断BookCount是否一致
                this.BookCount == booksMod.BookCount &&
                //判断BookMoney是否一致
                this.BookMoney == booksMod.BookMoney &&
                //判断BookPrice是否一致
                this.BookPrice == booksMod.BookPrice &&
                //判断BookDesc是否一致
                this.BookDesc == booksMod.BookDesc &&
                //判断BookAuthorDesc是否一致
                this.BookAuthorDesc == booksMod.BookAuthorDesc &&
                //判断BookComm是否一致
                this.BookComm == booksMod.BookComm &&
                //判断BookContent是否一致
                this.BookContent == booksMod.BookContent &&
                //判断BookSale是否一致
                this.BookSale == booksMod.BookSale &&
                //判断BookDeport是否一致
                this.BookDeport == booksMod.BookDeport &&
                //判断BookIsBuy是否一致
                this.BookIsBuy == booksMod.BookIsBuy &&
                //判断BookIsHot是否一致
                this.BookIsHot == booksMod.BookIsHot &&
                //判断BookIsDelete是否一致
                this.BookIsDelete == booksMod.BookIsDelete &&
                //判断BookBuyDate是否一致
                this.BookBuyDate == booksMod.BookBuyDate &&
                //判断BookHotDate是否一致
                this.BookHotDate == booksMod.BookHotDate;
        }
        /// <summary>
        /// 将当前Books数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将Books数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将BookID进行按位异或运算处理
                this.BookID.GetHashCode() ^
                //将BSID进行按位异或运算处理
                (this.BSID == null ? 2147483647 : this.BSID.GetHashCode()) ^
                //将BookTitle进行按位异或运算处理
                (this.BookTitle == null ? 2147483647 : this.BookTitle.GetHashCode()) ^
                //将BookAuthor进行按位异或运算处理
                (this.BookAuthor == null ? 2147483647 : this.BookAuthor.GetHashCode()) ^
                //将BookPublish进行按位异或运算处理
                (this.BookPublish == null ? 2147483647 : this.BookPublish.GetHashCode()) ^
                //将ISBN进行按位异或运算处理
                (this.ISBN == null ? 2147483647 : this.ISBN.GetHashCode()) ^
                //将BookCount进行按位异或运算处理
                (this.BookCount == null ? 2147483647 : this.BookCount.GetHashCode()) ^
                //将BookMoney进行按位异或运算处理
                (this.BookMoney == null ? 2147483647 : this.BookMoney.GetHashCode()) ^
                //将BookPrice进行按位异或运算处理
                (this.BookPrice == null ? 2147483647 : this.BookPrice.GetHashCode()) ^
                //将BookDesc进行按位异或运算处理
                (this.BookDesc == null ? 2147483647 : this.BookDesc.GetHashCode()) ^
                //将BookAuthorDesc进行按位异或运算处理
                (this.BookAuthorDesc == null ? 2147483647 : this.BookAuthorDesc.GetHashCode()) ^
                //将BookComm进行按位异或运算处理
                (this.BookComm == null ? 2147483647 : this.BookComm.GetHashCode()) ^
                //将BookContent进行按位异或运算处理
                (this.BookContent == null ? 2147483647 : this.BookContent.GetHashCode()) ^
                //将BookSale进行按位异或运算处理
                (this.BookSale == null ? 2147483647 : this.BookSale.GetHashCode()) ^
                //将BookDeport进行按位异或运算处理
                (this.BookDeport == null ? 2147483647 : this.BookDeport.GetHashCode()) ^
                //将BookIsBuy进行按位异或运算处理
                (this.BookIsBuy == null ? 2147483647 : this.BookIsBuy.GetHashCode()) ^
                //将BookIsHot进行按位异或运算处理
                (this.BookIsHot == null ? 2147483647 : this.BookIsHot.GetHashCode()) ^
                //将BookIsDelete进行按位异或运算处理
                (this.BookIsDelete == null ? 2147483647 : this.BookIsDelete.GetHashCode()) ^
                //将BookBuyDate进行按位异或运算处理
                (this.BookBuyDate == null ? 2147483647 : this.BookBuyDate.GetHashCode()) ^
                //将BookHotDate进行按位异或运算处理
                (this.BookHotDate == null ? 2147483647 : this.BookHotDate.GetHashCode());
        }
        /// <summary>
        /// 将当前Books数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前Books数据模型对象转换成字符串副本
            return
                "[" +
                //将BookID转换成字符串
                this.BookID +
                "]";
        }
    }
}
