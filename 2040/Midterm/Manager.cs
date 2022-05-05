using System;

namespace Midterm
{
    public class Manager : Employee
    {
        private string firstName, lastName, id, department, region;

        public Manager(string firstName, string lastName, string id, string dpeartment, string region) : base(firstName, lastName, id, empType.Manager){
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.department = dpeartment;
            this.region = region;
        }

        public string getDepartment(){
            return this.department;
        }

        public string getRegion(){
            return this.region;
        }

        public string setRegion(string newRegion){
            return this.region = newRegion;
        }

        public string setDepartment(string newDepartment){
            return this.department = newDepartment;
        }

    }
}