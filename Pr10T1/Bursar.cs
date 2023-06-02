using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr10T1
{
    public class Bursar : Tutor         
    {
        public string Sponsor;          // source of bursary
        public int Value;               // value of bursary

        public Bursar(string N, int Q, double Sal, int Days, int Sessions, string S, int Val)
            : base(N, Q, Sal, Days, Sessions)
        {
            Sponsor = S;
            Value = Val;
        }

        public override int ObligatoryHours()
        {
            double theHours = Value*1.0 / 30000;
            return Math.Min(90, (int)(theHours*90));
        }

        // ADD ANY ADDITIONAL METHODS BELOW
        public override int hours()
        {
            int h = Days * Sessions;
            double m = 25 * Sessions * Days;
            if (m >= 60)
            {
                m = Math.Floor(m / 60);
                int fh = (int)m + h;
                return fh;
            }
           
            return h;
        }
        public override double min()
        {
            double m = 25 * Sessions * Days;
            if (m >= 60)
            {
                double mm = (m / (60 * 1.0));
                m = Math.Floor(m / 60);
                m = (mm - m) * 60;

                return m;
            }
            return m;
        }
        public override void disp()
        {
            base.disp();
        }
        public override int hrs()
        {
            return hours()/Days;
        }
        public override double mi()
        {
            double minu = (double)hours() / Days * 1.0;
            minu = (minu - hrs()) * 60;
            return minu+ (min() / Days);
        }
      



    }
}
