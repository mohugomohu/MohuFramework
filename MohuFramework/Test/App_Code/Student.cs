using System;
namespace MohuFramework.Entity
{
    public class Student : MohuFramework.Entity.IEntity
    {
        private int? _ID;
        public int? ID
        {
            get{ return _ID;}
            set{ _ID = value; }
        }
        private string _vafd;
        public string vafd
        {
            get{ return _vafd;}
            set{ _vafd = value; }
        }
    }
}
