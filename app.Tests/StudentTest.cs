using System;
using System.ComponentModel;
using System.Reflection;
using Xunit;

namespace app.Tests
{
    public class StudentTest
    {
        [Fact]
        public void Constructor()
        {
            //Arrange
            int id = 1;
            string GivenName = "givenname";
            string Surname = "surname";
            DateTime startDate = new DateTime(2020, 8, 24);
            DateTime endDate = new DateTime(2023, 6, 25);
            DateTime graduationDate = new DateTime(2023, 6, 26);
            
            
            //Act
            Student student = new Student(1, "givenname", "surname", new DateTime(2020, 8, 24), new DateTime(2023, 6, 25), new DateTime(2023, 6, 26));
            
            //Assert
            Assert.Equal(id, student.Id);
            Assert.Equal(GivenName, student.GivenName);
            Assert.Equal(Surname, student.SurName);
            Assert.Equal(startDate, student.StartDate);
            Assert.Equal(endDate, student.EndDate);
            Assert.Equal(graduationDate, student.GraduationDate);
        }

        [Fact]
        public void Status_Is_New_If_CurrentTime_Less_StartDate()
        {
            //Arrange
            int id = 1;
            string GivenName = "givenname";
            string Surname = "surname";
            DateTime startDate = new DateTime(2033, 11, 11);
            DateTime endDate = new DateTime(2033, 11, 12);
            DateTime graduationDate = new DateTime(2033, 11, 12);
            
            Status status = Status.New;
            
            //Act
            Student student = new Student(1, "givenname", "surname", startDate, endDate, graduationDate);
            
            //Assert
            Assert.Equal(status, student.Status);
        }

          [Fact]
        public void Status_Is_Dropout_If_CurrentTime_Later_StartDate_And_GraduationDate_Is_Not_Same_As_EndDate()
        {
            //Arrange
            int id = 1;
            string GivenName = "givenname";
            string Surname = "surname";
            DateTime startDate = new DateTime(2015, 12, 25);
            DateTime endDate = new DateTime(2017, 12, 25);
            DateTime graduationDate = new DateTime(2018, 12, 25);
            
            
            //Act
            Student student = new Student(1, "givenname", "surname", startDate, endDate, graduationDate);
        

            //Assert
            Assert.Equal(Status.Dropout, student.Status);
        }
        
        [Fact]
        public void Status_Is_Active_If_CurrentTime_Is_higher_than_startDate_and_Less_than_endDate(){
            //Arrange
            int id = 1;
            string GivenName = "givenname";
            string Surname = "surname";
            DateTime startDate = new DateTime(2020, 8, 24);
            DateTime endDate = new DateTime(2023, 6, 25);
            DateTime graduationDate = new DateTime(2023, 6, 25);
            
            
            //Act
            Student student = new Student(1, "givenname", "surname", startDate, endDate, graduationDate);
        

            //Assert
            Assert.Equal(student.Status, Status.Active);

        }

        [Fact]
        public void Status_Is_Graduated_If_CurrentTime_Greater_StartDate_and_GraduateTime_is_the_same_as_EndDate()
        {
            //Arrange
            int id = 1;
            string GivenName = "givenname";
            string Surname = "surname";
            DateTime startDate = new DateTime(2012, 11, 11);
            DateTime endDate = new DateTime(2012, 11, 12);
            DateTime graduationDate = new DateTime(2012, 11, 12);
            
            Status status = Status.Graduated;
            
            //Act
            Student student = new Student(1, "givenname", "surname", startDate, endDate, graduationDate);
            
            //Assert
            Assert.Equal(status, student.Status);
        }
        [Fact]
        public void ToString_given_student_returns_string(){
            //Arrange
            int id = 1;
            string GivenName = "givenname";
            string Surname = "surname";
            DateTime startDate = new DateTime(2012, 11, 11);
            DateTime endDate = new DateTime(2012, 11, 12);
            DateTime graduationDate = new DateTime(2012, 11, 13);
            Student student = new Student(id, GivenName, Surname, startDate, endDate, graduationDate);
            //Act
            string str = student.ToString();
            String[] strArr = str.Split(" ");
            //Assert
            Assert.Equal(id.ToString(), strArr[0]);
            Assert.Equal(GivenName, strArr[1] );
            Assert.Equal(Surname, strArr[2]);
            Assert.Equal(Status.Dropout +"", strArr[3]);
            Assert.Equal(startDate.ToString(), strArr[4]+" "+ strArr[5]);
            Assert.Equal(endDate.ToString(), strArr[6]+" "+ strArr[7]);
            Assert.Equal(graduationDate.ToString(), strArr[8]+" "+ strArr[9]);
        }
    }
}
