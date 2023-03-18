using QLNS.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNS.Common.entities

{
    [Table("student")]

    public class Student {

        [Key]
       public Guid StudentID { get; set; }

        public string StudentCode { get; set; }
        public string StudentName { get; set; } 
        public Gender Gender { get; set; } 
         public DateTime DateOfBirth { get; set; }
          public string Nation { get; set; }
         public string Religion { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string IdentityNumber { get; set; }
   
        public string InsuraneCardNumber { get; set; }
        public string BankAccountNumber { get; set; }
          public string BankAccountName { get; set; }
        public string Adress { get; set; }
        public Guid StatusID { get; set; }
        public string StatusName { get; set; }
        public string Class { get; set; }
        public Guid FacultyID { get; set; }
        public string FacultyName { get; set; }
        public Guid EducationProgramID { get; set; }
        public string EducationProgramName { get; set; }
        public DateTime DayAdmission { get; set; }
        public DateTime ExpectedDateOfGraduation { get; set; }      
        public Guid ClassificationID { get; set; }
        public string ClassificationName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
