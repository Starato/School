using System;

namespace Midterm
{
    public class Employee
    {
        private string firstName, lastName, id;
        private empType employeeType;

        public Employee(string firstName, string lastName, string id, empType employeeType){
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.employeeType = employeeType;
        }

        public void getEmployeeInfo(){
            Console.WriteLine($"Name: {this.firstName} {this.lastName}");
            Console.WriteLine($"ID: {this.id}");
            Console.WriteLine($"Type: {this.employeeType}");
        }

        public string getFirstName(){
            return this.firstName;
        }

        public string setFirstName(string newFirstName){
            return this.firstName = newFirstName;
        }

        public string getlastName(){
            return this.lastName;
        }

        public string setLastName(string newLastName){
            return this.lastName = newLastName;
        }

        public empType getEmpType(){
            return this.employeeType;
        }

        public empType setEmpType(empType newEmployeeType){
            return this.employeeType = newEmployeeType;
        }

        public string getId(){
            return this.id;
        }

    }
}