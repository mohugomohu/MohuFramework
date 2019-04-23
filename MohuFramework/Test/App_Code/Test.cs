using System;
namespace Entity
{
    public class test : MohuFramework.Entity.IEntity
    {
        private string _tbname;
        public string tbname
        {
            get{ return _tbname;}
            set{ _tbname = value; }
        }
        private string _fdname;
        public string fdname
        {
            get{ return _fdname;}
            set{ _fdname = value; }
        }
        private string _jtname;
        public string jtname
        {
            get{ return _jtname;}
            set{ _jtname = value; }
        }
    }
}
