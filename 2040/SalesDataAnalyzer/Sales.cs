using System;

namespace SalesDataAnalyzer
{
    public class Sales
    {
        private string invoice, branch, city, customer, gender, product, date, payment;
        private int quantity;
        private float rating, unit;

        public Sales(string invoice, string branch, string city, string customer, string gender, string product, float unit, int quantity, string date, string payment, float rating){
            this.invoice = invoice;
            this.branch = branch;
            this.city = city;
            this.customer = customer;
            this.gender = gender;
            this.product = product;
            this.unit = unit;
            this.quantity = quantity;
            this.date = date;
            this.payment = payment;
            this.rating = rating;
        }

        public string getInvoice(){return this.invoice;}
        public string getBranch(){return this.branch;}
        public string getCity(){return this.city;}
        public string getCustomer(){return this.customer;}
        public string getGender(){return this.gender;}
        public string getProduct(){return this.product;}
        public string getDate(){return this.date;}
        public string getPayment(){return this.payment;}
        public float getUnit(){return this.unit;}
        public int getQuantity(){return this.quantity;}
        public float getRating(){return this.rating;}

    }




}