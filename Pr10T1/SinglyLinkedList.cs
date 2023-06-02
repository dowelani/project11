using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pr10T1
{
    public class SinglyLinkedList  
    {
        // Sentinel cell
        private int counter;
        private Cell head;   // pointer to first cell in the list
        

        // NO CHANGES PERMITTED TO METHODS BELOW

        public SinglyLinkedList()
        {
            counter = 0;
            head = null;
        }

        public int Count()
        {
            return counter;
        }

        public Cell getFirst()
        {
            return head;
        }

        public void addFirst(Object newItem) // Section Adding Cells at the Beginning pp 59 - 60
        /* pre:  Have object to be added to calling singly linked list object, which may be empty.
         * post: newItem is the element of the FIRST cell of the singly linked list.  All other existing cells of the
         *       singly linked list retain their ordering AFTER the new first cell.
         *       The counter is modified to reflect the addition of a new cell to the singly linked list. */
        {
            Cell newCell = new Cell(newItem);   
            newCell.setNext(head);
            head = newCell;
            counter++;
        }

        public void addLast(Object newItem) // Section Adding Cells at the End pp 60 - 61
        /* pre:  Have object to be added to calling singly linked list object, which may be empty.
         * post: newItem is the element of the LAST cell of the singly linked list.  All other existing cells of the
         *       singly linked list retain their ordering BEFORE the new last cell.
         *       The counter is modified to reflect the addition of a new cell to the singly linked list. 
         * CAREFUL: C# has certain restrictions which do not allow direct implementation of the code as specified in the 
         *          prescribed text.  Find a way around the restriction. */
        {
            if (this.Count() == 0)
            {
                this.addFirst(newItem);   
                return;
            }

            Cell newCell = new Cell(newItem);  
            Cell cur = head;
            while (cur.next() != null)
                cur = cur.next();
            cur.setNext(newCell);
            counter++;
        }

        public Cell removeFirst()
        /* pre:  Have at least one cell in calling singly linked list object.
         * post: Return the cell removed, which is the first cell in the list.
         *       The counter is modified to reflect the removal of the first cell from the singly linked list. */
        {
            Cell cur = head;
            head = cur.next();
            cur.setNext(null);
            counter--;
            return cur;
        }

        public Cell removeLast()
        /* pre:  Have at least one cell in calling singly linked list object.
         * post: Return the cell removed, which is the last cell in the list.
         *       The counter is modified to reflect the removal of the last cell from the singly linked list. 
         * CAREFUL: C# has certain restrictions - find a way around the restriction. */
        {
            Cell cur;
            if (this.Count() == 1)
                return removeFirst();
            cur = head;
            Cell prev = head;
            while (cur.next() != null)
            {
                prev = cur;
                cur = cur.next();
            }
            prev.setNext(null);
            counter--;
            return cur;
        }

        public void addBefore(Object newItem, Cell link)
        /* pre:  Have object to be added to calling singly linked list object, and a link in the singly linked list BEFORE
         *       which the newItem's cell must be added.
         * post: newItem is the element of the added cell of the singly linked list.  All other existing cells of the
         *       singly linked list retain their ordering relevant to the position of the newly added cell.
         *       The counter is modified to reflect the addition of a new cell to the singly linked list. */
        {
            if (link == null)  
            {
                this.addLast(newItem);
                return;
            }

            Cell newCell = new Cell(newItem);  
            Cell cur = head;
            if (cur == link)                                                    
            {
                this.addFirst(newItem);
                return;
            }
            while (cur.next() != link)
                cur = cur.next();
            cur.setNext(newCell);
            newCell.setNext(link);
            counter++;
        }

        public void addAfter(Object newItem, Cell link) // Section Inserting Cells After Other Cells pp 61 - 62
        /* pre:  Have object to be added to calling singly linked list object, and a link in the singly linked list AFTER
         *       which the newItem's cell must be added.
         * post: newItem is the element of the added cell of the singly linked list.  All other existing cells of the
         *       singly linked list retain their ordering relevant to the position of the newly added cell.
         *       The counter is modified to reflect the addition of a new cell to the singly linked list. */
        {
            if (link == null)
            {
                this.addLast(newItem);
                return;
            }

            Cell newCell = new Cell(newItem);   
            newCell.setNext(link.next());
            link.setNext(newCell);
            counter++;
        }

        public void Clear()
        /* pre:  Have calling singly linked list object, which could be empty.
         * post: EFFICIENTLY clear the singly linked list. */
        {
            counter = 0;
            head = null;
        }
    }
}
