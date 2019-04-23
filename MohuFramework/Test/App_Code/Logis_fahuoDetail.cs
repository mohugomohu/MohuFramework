using System;
namespace Entity
{
    public class Logis_fahuoDetail : MohuFramework.Entity.IEntity
    {
        private int? _ID;
        public int? ID
        {
            get{ return _ID;}
            set{ _ID = value; }
        }
        private string _BillNOshouhuo;
        public string BillNOshouhuo
        {
            get{ return _BillNOshouhuo;}
            set{ _BillNOshouhuo = value; }
        }
        private int? _shouhuoHeaderID;
        public int? shouhuoHeaderID
        {
            get{ return _shouhuoHeaderID;}
            set{ _shouhuoHeaderID = value; }
        }
        private string _Note;
        public string Note
        {
            get{ return _Note;}
            set{ _Note = value; }
        }
        private int? _CooperateIDfahuoren;
        public int? CooperateIDfahuoren
        {
            get{ return _CooperateIDfahuoren;}
            set{ _CooperateIDfahuoren = value; }
        }
        private string _PhoneFahuo;
        public string PhoneFahuo
        {
            get{ return _PhoneFahuo;}
            set{ _PhoneFahuo = value; }
        }
        private int? _HeaderID;
        public int? HeaderID
        {
            get{ return _HeaderID;}
            set{ _HeaderID = value; }
        }
    }
}
