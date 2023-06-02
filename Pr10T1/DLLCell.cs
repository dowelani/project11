using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pr10T1
{
    public class DLLCell : Cell                                                                     // NO CODE IN THIS CLASS MAY BE CHANGED
    {
        private DLLCell BackLink;

        public DLLCell(Object theElement, DLLCell theLink, DLLCell theBackLink)
            : base(theElement, theLink)
        {
            BackLink = theBackLink;
        }

        public DLLCell(Object theElement)
            : base(theElement)
        {
            BackLink = null;
        }

        public DLLCell()
            : base()
        {
            BackLink = null;
        }

        public DLLCell previous()
        {
            return BackLink;
        }

        public void setPrevious(DLLCell theLink)
        {
            BackLink = theLink;
        }
    }
}
