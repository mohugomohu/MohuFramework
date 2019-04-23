using System;
namespace MohuFramework.Entity
{
    public class JYG_SystemFollow : MohuFramework.Entity.IEntity
    {
        private Guid _ID;
        public Guid ID
        {
            get{ return _ID;}
            set{ _ID = value; }
        }
        private string _GoodNo;
        public string GoodNo
        {
            get{ return _GoodNo;}
            set{ _GoodNo = value; }
        }
        private string _DateTimeFollow;
        public string DateTimeFollow
        {
            get{ return _DateTimeFollow;}
            set{ _DateTimeFollow = value; }
        }
        private string _Status;
        public string Status
        {
            get{ return _Status;}
            set{ _Status = value; }
        }
        private string _DateType;
        public string DateType
        {
            get{ return _DateType;}
            set{ _DateType = value; }
        }
        private string _BillNo;
        public string BillNo
        {
            get{ return _BillNo;}
            set{ _BillNo = value; }
        }
    }
}
