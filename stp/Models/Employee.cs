using stp.Models.Master;
using System;
using System.Data;

namespace stp.Models
{
    internal class Employee : ModelBase
    {
        private int id;
        private string name;
        private string firstName;
        private string city;
        private DateTime? birth;
        private string email;
        private DateTime? date_of_joining;
        private string department;
        private Boolean? status;

        /// <summary>
        /// Initializes a new instance of the Employee class.
        /// </summary>
        public Employee() { }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public String FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public String City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        public DateTime? Birth
        {
            get { return birth; }
            set
            {
                birth = value;
                OnPropertyChanged("Birth");
            }
        }

        public String Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public DateTime? DateOfJoining
        {
            get { return date_of_joining; }
            set
            {
                date_of_joining = value;
                OnPropertyChanged("DateOfJoining");
            }
        }

        public string Department
        {
            get { return department; }
            set
            {
                department = value;
                OnPropertyChanged("Department");
            }
        }

        public Boolean? Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public static explicit operator Employee(DataRow source)
        {
            if (source == null)
                throw new ArgumentNullException("source", "Could not be null.");

            return (ToEmployee(source));
        }
        public static Employee ToEmployee(DataRow record)
        {
            if (record == null)
                throw new ArgumentNullException("record", "Could not be null.");

            Employee anEmployee = new Employee();

            anEmployee.Id = (int)record["ID"];

            if (!record.IsNull("firstName"))
            {
                anEmployee.FirstName = record["firstName"].ToString();
            }
            else
            {
                anEmployee.FirstName = String.Empty;
            }

            if (!record.IsNull("name"))
            {
                anEmployee.Name = record["name"].ToString();
            }
            else
            {
                anEmployee.Name = String.Empty;
            }
            
            if (!record.IsNull("city"))
            {
                anEmployee.City = record["city"].ToString();
            }
            else
            {
                anEmployee.City = String.Empty;
            }

            if (!record.IsNull("birth"))
            {
                anEmployee.Birth = Convert.ToDateTime(record["birth"].ToString());
            }
            else
            {
                anEmployee.Birth = null;
            }

            if (!record.IsNull("email"))
            {
                anEmployee.Email = record["email"].ToString();
            }
            else
            {
                anEmployee.Email = String.Empty;
            }

            if (!record.IsNull("date_of_joining"))
            {
                anEmployee.DateOfJoining = Convert.ToDateTime(record["date_of_joining"].ToString());
            }
            else
            {
                anEmployee.DateOfJoining = null;
            }

            if (!record.IsNull("status"))
            {
                anEmployee.Status = (bool)record["status"];
            }
            else
            {
                anEmployee.Status = null;
            }

            if (!record.IsNull("department"))
            {
                anEmployee.Department = record["department"].ToString();
            }
            else
            {
                anEmployee.Department = String.Empty;
            }

            return anEmployee;
        }

    }
}
