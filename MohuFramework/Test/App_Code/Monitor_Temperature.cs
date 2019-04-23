using System;
namespace Entity
{
    public class Monitor_Temperature : MohuFramework.Entity.IEntity
    {
        private int? _ID;
        public int? ID
        {
            get{ return _ID;}
            set{ _ID = value; }
        }
        private DateTime? _DateHappen;
        public DateTime? DateHappen
        {
            get{ return _DateHappen;}
            set{ _DateHappen = value; }
        }
        private double? _Temperature;
        public double? Temperature
        {
            get{ return _Temperature;}
            set{ _Temperature = value; }
        }
        private DateTime? _ServerDatetime;
        public DateTime? ServerDatetime
        {
            get{ return _ServerDatetime;}
            set{ _ServerDatetime = value; }
        }
        private string _BoxSN;
        public string BoxSN
        {
            get{ return _BoxSN;}
            set{ _BoxSN = value; }
        }
    }
}
