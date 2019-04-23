using System;
namespace Entity
{
    public class Basic_Box : MohuFramework.Entity.IEntity
    {
        private int? _ID;
        public int? ID
        {
            get{ return _ID;}
            set{ _ID = value; }
        }
        private string _BoxSN;
        public string BoxSN
        {
            get{ return _BoxSN;}
            set{ _BoxSN = value; }
        }
        private string _Standard;
        public string Standard
        {
            get{ return _Standard;}
            set{ _Standard = value; }
        }
        private DateTime? _DateHappen;
        public DateTime? DateHappen
        {
            get{ return _DateHappen;}
            set{ _DateHappen = value; }
        }
        private int? _BoxID;
        public int? BoxID
        {
            get{ return _BoxID;}
            set{ _BoxID = value; }
        }
        private int? _UseState;
        public int? UseState
        {
            get{ return _UseState;}
            set{ _UseState = value; }
        }
    }
}
