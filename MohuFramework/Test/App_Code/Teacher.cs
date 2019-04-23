using System;
namespace MohuFramework.Entity
{
    public class Teacher : MohuFramework.Entity.IEntity
    {
        private int? _ID;
        public int? ID
        {
            get{ return _ID;}
            set{ _ID = value; }
        }
        private string _asdf;
        public string asdf
        {
            get{ return _asdf;}
            set{ _asdf = value; }
        }
    }
}
