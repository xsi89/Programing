using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MyProgram
{
}
class Program
{
    static void Main(string[] args)
    {
        {
            // How do I alert the list "company" here but the content from the class

            //myList ttc = new myList();
            CompanyMain CompMa = new CompanyMain();
            foreach (var c in CompMa.Company)
            {
                Console.WriteLine(c);
            }

        }
    }

    public class myList : IEnumerable <myList>
    {
        public List<myList> CompanyInfo { get; set; }
        public IEnumerator<myList> GetEnumerator()
        {
            return CompanyInfo.GetEnumerator();
        }
         List<string> CompanyInfo()
        {
            List<string> CompanyInformation = new List<string>();
            CompanyInformation.Add("test1");
            return CompanyInformation;
        }
    }

    public class CompanyMain
    {

        public myList Company = new myList();
    }
}