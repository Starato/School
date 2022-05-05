using System;

namespace crimeAnalyzer
{
    public class Crime
    {
        private int year, population, violentCrime, murder, rape, robbery, aggrAssault, prptyCrime, burglary, theft, motorTheft;

        public Crime(int year, int population, int violentCrime, int murder, int rape, int robbery, int aggrAssault, int prptyCrime, int burglary, int theft, int motorTheft){
            this.year = year;
            this.population = population;
            this.violentCrime = violentCrime;
            this.murder = murder;
            this.rape = rape;
            this.robbery = robbery;
            this.aggrAssault = aggrAssault;
            this.prptyCrime = prptyCrime;
            this.burglary = burglary;
            this.theft = theft;
            this.motorTheft = motorTheft;
        }

        public int getYear(){return this.year;}
        public int getPop(){ return this.population;}
        public int getViolentCrime(){return this.violentCrime;}
        public int getMurder(){return this.murder;}
        public int getRape(){return this.rape;}
        public int getRobbery(){return this.robbery;}
        public int getAggrAssualt(){return this.aggrAssault;}
        public int getPrptyCrime(){return this.prptyCrime;}
        public int getBurglary(){return this.burglary;}
        public int getTheft(){return this.theft;}
        public int getMotorTheft(){return this.motorTheft;}
    }


}