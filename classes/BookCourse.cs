using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksFinal
{
    class BookCourse
    {
        private string courseNo, iSBN, title, publisher;

        //constructor
        public BookCourse(string cNo, string isbn, string bName, string pub)
        {
            courseNo = cNo;
            iSBN = isbn;
            title = bName;
            publisher = pub;
        }

        //props
        public string CourseNo
        {
            get
            {
                return courseNo;
            }
        }

        public string ISBN
        {
            get
            {
                return iSBN;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
        }

        public string Publisher
        {
            get
            {
                return publisher;
            }
        }

        //override tostring
        public override string ToString()
        {
            return courseNo + " / " + iSBN + " / " + title + " / " + publisher;
        }

    }//end class
}//end namespace
