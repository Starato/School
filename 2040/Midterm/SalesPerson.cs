using System;

namespace Midterm
{
    public class SalesPerson : Employee{

        private string firstName, lastName, id, department;
        private float sales;

        public SalesPerson(string firstName, string lastName, string id, string department, float sales) : base(firstName, lastName, id, empType.Sales){
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.department = department;
            this.sales = sales;
        }
        
        public string GetSalesLevel(){
            if(sales < 10000){return "Bronze";}
            if(sales >= 10000 && sales <= 19999.99){return "Silver";}
            if(sales >= 20000 && sales <= 29999.99){return "Gold";}
            if(sales >= 30000 && sales <= 39999.99){return "Diamond";}
            if(sales > 40000){return "Platinum";}
            return null;
        }

        public float getSales(){
            return this.sales;
        }

        public float updateSales(float newSales){
            return this.sales += newSales;
        }
    }
}