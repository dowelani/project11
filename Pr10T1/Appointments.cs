using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr10T1
{
    public class Appointments
    {
        public SinglyLinkedList Appointees;         // list of tutors unique on name of tutor with list 
                                                    // grouped on qualification code, with the smallest qualification code
                                                    // at the start of the list and the largest qualification code 
                                                    // at the end of the list
        private double AvailableBudget;             // current available budget which may not be exceeded
        public DoublyLinkedList Terminations;       // list of tutors whose service is to be terminated

        // PRACTICAL 10 TASK 1

        public void displayAppointees()
        /* pre:  Have list of appointed tutors (Appointees), which 
         *       may be empty.
         * post: RECURSIVELY display for each tutor the tutor name, 
         *       number of days and sessions appointed for and total 
         *       time worked per week (in hours and minutes).   */
        {

            // ADD CODE FOR METHOD displayAppointees BELOW
            Cell c = Appointees.getFirst();
            d(c);
        }
        private void d(Cell c)
        {
            if (c == null)
            { return; }
            else
            {
                Tutor cc = (Tutor)c.value();
                cc.disp();
                c = c.next();
                d(c);
            }

        }

        public void identifyTerminations(int hours, int minutes)
        /* pre:  Have list of appointed tutors (Appointees), which 
         *       may be empty, and a value for hours (hours) and minutes (minutes) worked.
         * post: Using ONLY RECURSION, add those appointed tutors with at most
         *       the specified hours and minutes worked per day to the end  
         *       of the list of tutors to be terminated (doubly linked list Terminations), 
         *       and then display the list of tutors to be terminated (only name and hours and minutes worked per day).
         *       The Appointees list remains unchanged.*/
        {
            Cell c = Appointees.getFirst();
            T(c, hours, minutes);
            Cell cc = Terminations.getFirst();
            dis(cc);

        }
        private void T(Cell c,int h, int m)
        {
            if (c.next()==null)
            { return; }
            else
            {
                Tutor cc = (Tutor)c.value();
                int ch=cc.hrs();
                double cm = cc.mi();
                if(((ch*60)+cm)<=((h*60)+m))
                {
                    
                    Terminations.addLast(c.value());
                  
                    T(c.next(), h, m);
                }
                
                T(c.next(), h, m);

            }
        }
        private void dis(Cell c)
        {
            if (c.next() == null) { return; }
            else
            {

                Tutor cc = (Tutor)c.value();

                Console.WriteLine("Name: {0} works {1} hours and {2:f0} minutes per day", cc.Name, cc.hrs(), cc.mi());
           
                dis(c.next());
            }
        }


        // DO NOT MAKE CHANGES TO THE METHODS BELOW

        public Appointments(double initialBudget)
        /* post: Constructor. */
        {
            Appointees = new SinglyLinkedList();
            AvailableBudget = initialBudget;
            Terminations = new DoublyLinkedList();
        }

        public void makeAppointment(Tutor newTutor)
        /* pre:  Have a list of tutors (Appointees) which may be empty, 
         *       the available budget (AvailableBudget) and the details
         *       of an applicant (newTutor).
         *       Note the order of the tutors in the list (see description of 
         *       Appointees above).
         * post: If the applicant is already appointed (tutors are unique on name),
         *       display an appropriate message, otherwise add the applicant (newTutor)
         *       at the end of the qualification code group for which the applicant is
         *       appointed, but only if there is sufficient budget to allow the
         *       appointment.  On a successful appointment, modify the available budget.
         *       If there is insufficient budget for the appointment, display an appropriate 
         *       message. 
         *       Upon an addition of a tutor, the list is always ordered correctly.  
         *       No sorting of the list is required at any time.
         *       NOTE:  Penalties apply if inefficient programming techniques are used. */
        {
            if (newTutor.getSalary() > AvailableBudget)
                return;
            else
            {
                Cell cur = Appointees.getFirst();
                while (cur != null)
                {
                    Tutor curTutor = (Tutor)cur.value();
                    if (curTutor.Equals(newTutor))
                        return;
                    cur = cur.next();
                }
                AvailableBudget -= newTutor.getSalary();
                cur = Appointees.getFirst();
                while ((cur != null) && (((Tutor)cur.value()).QualificationCode <= newTutor.QualificationCode))
                    cur = cur.next();
                if (cur == null)
                    Appointees.addLast(newTutor);
                else
                    Appointees.addBefore(newTutor, cur);
            }
        }
    }
}
