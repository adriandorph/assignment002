using System;

namespace app
{
    public enum Status
    {
        New, 
        Active,
        Dropout,
        Graduated
    }
    public class Student
    {
        private int _id;
        public int Id
        {
            get {return _id;}
        }
        public string GivenName{set; get;}
        public string SurName{ set; get; }

        private Status _status;
        public Status Status{
            get{
                CalculateStatus(DateTime.Now);
                return _status;
                }
        }
        public DateTime StartDate{set; get;} 
        public DateTime EndDate{set; get;} 
        public DateTime GraduationDate{set;get;}

        public Student(int Id, string GivenName, string SurName, DateTime StartDate, DateTime EndDate, DateTime GraduationDate){
            _id = Id;
            this.GivenName = GivenName;
            this.SurName = SurName;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.GraduationDate = GraduationDate;
            CalculateStatus(DateTime.Now);
        }

        public override String ToString() {
            return Id + " " + GivenName + " " + SurName + " " + Status + " " + StartDate + " " + EndDate + " " + GraduationDate;
        }

        private void CalculateStatus(DateTime currentTime) {
            if(currentTime < this.StartDate) _status = Status.New;
            else if (currentTime < EndDate) _status = Status.Active;
            else if (GraduationDate != EndDate) _status = Status.Dropout;
            else _status = Status.Graduated;
        }
    }
}