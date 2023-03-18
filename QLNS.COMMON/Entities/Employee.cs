

using QLNS.Common.Enums;
using QLNS.COMMON;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QLNS.Common.entities
{
    #region
    [Table("employee")]
    public class Employee
    {

        [Key]
     
        public Guid EmployeeID { get; set; }
        
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
     
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nation { get; set; }
        public string Religion { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string IdentityNumber { get; set; }
        public string TaxCode { get; set; }
        public string InsuraneCardNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankAccountName { get; set; }
        public string Adress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid FacultyID { get; set; }
        public string FacultyName { get; set; }
        public Guid StatusEmployeeID { get; set; }
        public string StatusEmployeeName { get; set; }
        public Guid SalaryID { get; set; }
        public string SalaryName { get; set; }
        public Guid DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public Guid TrainingCertificateID { get; set; }
        public string TrainingCertificateName { get; set; }
        public string MaritalStatus { get; set; }
        
        public Guid PositionsID { get; set; }
        public string PositionsName { get; set; }
      

#endregion



    }
}
