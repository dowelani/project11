using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pr10T1
{
    public class DoublyLinkedList
    {
        protected int counter;
        protected DLLCell head;        // points to first cell in the list
        protected DLLCell tail;        // points to last cell in the list

        public DoublyLinkedList()
        {
            counter = 0;
            head = null;
            tail = null;
        }

        public int Count()
        {
            return counter;
        }

        public DLLCell getFirst()
        {
            return head;
        }

        public DLLCell getLast()
        {
            return tail;
        }

        public void addFirst(Object newItem)
        /* pre:  Have object to be added to calling doubly linked list object, which may be empty.
         * post: newItem is the element of the FIRST cell of the doubly linked list.  All other existing cells of the
         *       doubly linked list retain their ordering AFTER the new first cell.
         *       The counter is modified to reflect the addition of a new cell to the doubly linked list. */
        {
            DLLCell newNode = new DLLCell(newItem);
            newNode.setNext(head);
            if (head != null)
                head.setPrevious(newNode);
            else
                tail = newNode;
            head = newNode;
            counter++;
        }

        public void addLast(Object newItem)
        /* pre:  Have object to be added to calling doubly linked list object, which may be empty.
         * post: newItem is the element of the LAST cell of the doubly linked list.  All other existing cells of the
         *       doubly linked list retain their ordering BEFORE the new last cell.
         *       The counter is modified to reflect the addition of a new cell to the doubly linked list. */
        {
            if (tail == null)
            {
                addFirst(newItem);
                return;
            }
            DLLCell newCell = new DLLCell(newItem);
            newCell.setPrevious(tail);
            tail.setNext(newCell);
            tail = newCell;
            counter++;
        }

        public DLLCell removeFirst()
        /* pre:  Have at least one cell in calling doubly linked list object.
         * post: Return the cell removed, which is the first cell in the list.
         *       The counter is modified to reflect the removal of the first cell from the doubly linked list. */
        {
            DLLCell cur = head;
            head = (DLLCell)cur.next();
            if (cur.next() != null)
            {
                ((DLLCell)cur.next()).setPrevious(null);
                cur.setNext(null);
            }
            else // only one cell in list
                tail = null;
            counter--;
            return cur;
        }

        public DLLCell removeLast()
        /* pre:  Have at least one cell in calling doubly linked list object.
         * post: Return the cell removed, which is the last cell in the list.
         *       The counter is modified to reflect the removal of the last cell from the doubly linked list. */
        {
            DLLCell cur = tail;
            if (cur.previous() == null)  // then only one cell in DLL
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = cur.previous();
                tail.setNext(null);
                cur.setPrevious(null);
            }
            counter--;
            return cur;
        }

        public void addBefore(Object newItem, DLLCell link)
        /* pre:  Have object to be added to calling doubly linked list object, and a link in the doubly linked list BEFORE
         *       which the newItem's cell must be added.
         * post: newItem is the element of the added cell of the doubly linked list.  All other existing cells of the
         *       doubly linked list retain their ordering relevant to the position of the newly added cell.
         *       The counter is modified to reflect the addition of a new cell to the doubly linked list. */
        {
            if (link == null)  // list either empty or must be added at end of list
            {
                this.addLast(newItem);
                return;
            }
            DLLCell newNode = new DLLCell(newItem);
            if (head == link)  // must be added as first cell
            {
                this.addFirst(newItem);
                return;
            }
            newNode.setPrevious(link.previous());
            newNode.setNext(link);
            link.previous().setNext(newNode);
            link.setPrevious(newNode);
            counter++;
        }

        public void addAfter(Object newItem, DLLCell link)
        /* pre:  Have object to be added to calling doubly linked list object, and a link in the doubly linked list AFTER
         *       which the newItem's cell must be added.
         * post: newItem is the element of the added cell of the doubly linked list.  All other existing cells of the
         *       doubly linked list retain their ordering relevant to the position of the newly added cell.
         *       The counter is modified to reflect the addition of a new cell to the doubly linked list. */
        {
            if (link == null)
            {
                this.addLast(newItem);
                return;
            }
            DLLCell newNode = new DLLCell(newItem);
            newNode.setNext(link.next());
            if ((DLLCell)(link.next()) != null)
                ((DLLCell)(link.next())).setPrevious(newNode);
            newNode.setPrevious(link);
            link.setNext(newNode);
            counter++;
        }

        public void Clear()
        /* pre:  Have calling doubly linked list object.
         * post: Empty the list. */
        {
            this.head = null;
            this.tail = null;
            this.counter = 0;
        }

        public DLLCell removeCell(DLLCell link)
        /* pre:  Have at least one cell in calling doubly linked list object, and link which is a valid cell in the list.
         * post: Return the cell removed.
         *       The counter is modified to reflect the removal of the cell from the doubly linked list. */
        {
            if (link == tail)
                return removeLast();
            else
                if (link == head)
                    return removeFirst();
                else
                {
                    link.previous().setNext(link.next());
                    ((DLLCell)link.next()).setPrevious(link.previous());
                    link.setNext(null);
                    link.setPrevious(null);
                    counter--;
                }
            return link;
        }
    }
}
