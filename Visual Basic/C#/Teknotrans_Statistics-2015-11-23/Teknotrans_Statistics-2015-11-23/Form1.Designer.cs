using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HAL_Statistics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            // System.Console.WriteLine(string.Join<HAL_Statistics>("\n", myList));

            Companies();


        }

        public void Companies()
        {


            DataClasses1DataContext db = new DataClasses1DataContext();
            var CompanyandID =
                from CompanyMain in db.CompanyMains
                where CompanyMain.Name != ""
                select CompanyMain.Name;


            foreach (var s in CompanyandID)
            {

                System.Console.WriteLine(s);

            }

        }

        public class myList
        {

            List<CompanyMain> _companyMain;
            public List<CompanyMain> CompanyMain
            {
                get { return _companyMain; }
                set { _companyMain = value; }

            }

        }

    }
}

