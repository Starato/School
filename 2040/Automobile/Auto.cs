using System;

namespace Automobile
{

public class Auto
{
    private string make, model, vin, color;
    private int year;
    private autoType type;    

    public Auto(string make, string model, int year, string vin, string color, autoType type){
        this.make = make;
        this.model = model;
        this.vin = vin;
        this.color = color;
        this.year = year;
        this.type = type;
    }

    public autoType getType(){
        return this.type;
    }
    public string getMake(){
        return this.make;
    }

    public string getModel(){
        return this.model;
    }

    public string getVin(){
        return this.vin;
    }

    public string getColor(){
        return this.color;
    }
    public string setColor(string newColor){
        return this.color = newColor;
    }

    public int getYear(){
        return this.year;
    }

    public int getAutoAge(){
        int currentYear = DateTime.Now.Year;
        return currentYear - this.year;
    }
}




}