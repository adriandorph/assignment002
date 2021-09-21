using System;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace app{
    public record ImmutableStudent {
        public int Id{get; init;}
        public string GivenName{get; init;}
        public string SurName{get; init;}
        public DateTime StartDate{get; init;} 
        public DateTime EndDate{get; init;} 
        public DateTime GraduationDate{get; init;}

        public Status Status{get; init;}

        public ImmutableStudent(int id, string givenName, string surName, DateTime startDate, DateTime endDate, DateTime graduationDate){
            Id = id;
            GivenName = givenName;
            SurName = surName;
            StartDate = startDate;
            EndDate = endDate;
            GraduationDate = graduationDate;
            DateTime currentTime = DateTime.Now;
            if(currentTime < this.StartDate) Status = Status.New;
            else if (currentTime < EndDate) Status = Status.Active;
            else if (GraduationDate != EndDate) Status = Status.Dropout;
            else Status = Status.Graduated;
        }
    }
}