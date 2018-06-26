using System;
using TTTeknotrans;
using System.Linq;
using System.Data.Linq;

class program
{
        static void Main()
        {



            TeknotransDataContext context = new TeknotransDataContext();

            var model = context.Mapping;

            //get all tables 
            foreach (var mt in model.GetTables())
            {
                Console.WriteLine("Getting data " + mt.TableName);

                //generate a sql statment for each table - just grab the first 20
                string sql = String.Format("SELECT Id FROM  CompanyMain");
                var data = context.ExecuteQuery(mt.RowType. sql);

                //data is here now. Lets print it on the console
                foreach (var item in data)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.ReadLine();

        }




}
