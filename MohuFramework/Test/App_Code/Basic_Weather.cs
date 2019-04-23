using System;
namespace Entity
{
    [Serializable]
    public class Basic_Weather : MohuFramework.Entity.IEntity
    {
        private int? _ID;
        public int? ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _DateHappen;
        public string DateHappen
        {
            get { return _DateHappen; }
            set { _DateHappen = value; }
        }
        private string _HighTemperature;
        public string HighTemperature
        {
            get { return _HighTemperature; }
            set { _HighTemperature = value; }
        }
        private string _LowTemperature;
        public string LowTemperature
        {
            get { return _LowTemperature; }
            set { _LowTemperature = value; }
        }
        private string _mudidi;
        public string mudidi
        {
            get { return _mudidi; }
            set { _mudidi = value; }
        }
        private string _Weather;
        public string Weather
        {
            get { return _Weather; }
            set { _Weather = value; }
        }
    }
}
