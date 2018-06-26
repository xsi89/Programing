////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;

////namespace Test
////{
////    class Program
////    {
////        static void Main(string[] args)
////        {
////        }
////    }
////}


using System;

namespace Program1
{

    class myProgram
    {
    
        public static void Main()
        {

            Companies mc = new Companies();
            mc.CompanyName();
  
        }

    }


}
    public class Companies
    {
               public void CompanyName()
    {
            string CompanyName;
            CompanyName = "Teknotrans AB";

            Console.WriteLine(CompanyName.ToString());
    }
    



    }

