using System;
namespace Entity
{
    [Serializable] 
    public class Monitor_GPSInToday : MohuFramework.Entity.IEntity
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
        private double? _Longitude;
        public double? Longitude
        {
            get{ return _Longitude;}
            set{ _Longitude = value; }
        }
        private double? _Latitude;
        public double? Latitude
        {
            get{ return _Latitude;}
            set{ _Latitude = value; }
        }
        private string _CarNO;
        public string CarNO
        {
            get{ return _CarNO;}
            set{ _CarNO = value; }
        }
        private int? _HeadDirection;
        public int? HeadDirection
        {
            get{ return _HeadDirection;}
            set{ _HeadDirection = value; }
        }
        private int? _Speed;
        public int? Speed
        {
            get{ return _Speed;}
            set{ _Speed = value; }
        }
        private int? _DriveState;
        public int? DriveState
        {
            get{ return _DriveState;}
            set{ _DriveState = value; }
        }
        private double? _Temperature;
        public double? Temperature
        {
            get{ return _Temperature;}
            set{ _Temperature = value; }
        }
        private int? _TemperatureState;
        public int? TemperatureState
        {
            get{ return _TemperatureState;}
            set{ _TemperatureState = value; }
        }
        private DateTime? _ServerDatetime;
        public DateTime? ServerDatetime
        {
            get{ return _ServerDatetime;}
            set{ _ServerDatetime = value; }
        }
        private double? _Temperature4;
        public double? Temperature4
        {
            get{ return _Temperature4;}
            set{ _Temperature4 = value; }
        }
        private double? _Temperature3;
        public double? Temperature3
        {
            get{ return _Temperature3;}
            set{ _Temperature3 = value; }
        }
        private double? _Temperature2;
        public double? Temperature2
        {
            get{ return _Temperature2;}
            set{ _Temperature2 = value; }
        }
        private double? _lichengshu;
        public double? lichengshu
        {
            get{ return _lichengshu;}
            set{ _lichengshu = value; }
        }
    }
}
