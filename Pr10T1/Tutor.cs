using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr10T1
{
    public class Tutor   
    {
        public string Name;            // name of tutor
        public int QualificationCode;   // code of qualification for which tutor is appointed
        private double MonthlySal;      // monthly salary
        public int Days;               // number of days working per week
        public int Sessions;           // number of sessions working per day

        public Tutor(string N, int Q, double Sal, int Days, int Sessions)
        {
            Name = N;
            QualificationCode = Q;
            MonthlySal = Sal;
            this.Days = Days;
            this.Sessions = Sessions;
        }
        // ADD ANY ADDITIONAL METHODS BELOW
        public virtual int hours()
        {
            int h = Days * Sessions;
            double m = 10 * Sessions*Days;
            if(m>=60)
            {
                m = Math.Floor(m / 60);
                int fh = (int)m + h;
                return fh;
            }
            return h;
           
        }
        public virtual double min()
        {
            double m = 10 * Sessions * Days;
            if(m>=60)
            {
                double mm = (m /(60*1.0));
                m = Math.Floor(m / 60);
                m = (mm - m) * 60;
                return m;
            }
            return m;
        }
        public virtual int hrs()
        {
            return hours()/Days;
        }
        public virtual double mi()
        {
            double minu =(double)hours() / Days*1.0;
            minu = (minu - hrs()) * 60;
            return minu+(min()/Days);
        }

        public virtual void disp()
        {
            Console.WriteLine("Name: {0} appointed for {1} days, {2} sessions per day works for {3} and {4:f0} minutes per week",Name,Days,Sessions,hours(),min());
        }





        // DO NOT MAKE CHANGES TO METHODS BELOW

        public bool Equals(Object temp)
        {
            Tutor cur = (Tutor)temp;
            return this.Name.Equals(cur.Name);
        }

        public double getSalary()
        {
            return MonthlySal;
        }

        public virtual int ObligatoryHours()    
        {
            return 0;
        }

    }
}
