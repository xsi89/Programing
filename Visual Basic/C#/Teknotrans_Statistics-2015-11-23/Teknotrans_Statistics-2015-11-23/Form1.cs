
using System.Windows.Forms;
using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using TTTeknotrans;

namespace HAL_Statistics_2015_11_10_1612
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {




        }

    }

    public class Utilities
    {

        public static List<OrderInfo> SearchOrders(System.Data.Linq.Table<OpusOrder> allorders,

                                                CompanyAttention attention,
                                                string status,
                                                string tmdoctype,
                                                string searchString,
                                                string searchStringRefNo,
                                                string startDate,
                                                string endDate,
                                                string attentionId,
                                                bool ownOnly)
        {
            List<OpusOrder> orders;
            if (ownOnly)
            {
                orders = allorders.Where(o => o.AttentionId == attention.Id && o.makulerad == false).ToList();
            }
            else
            {
                orders = allorders.Where(o => o.bolagsnr == attention.IdCompany && o.makulerad == false).ToList();
            }

            TeknotransDataContext ttdb = new TeknotransDataContext();

            var cmPostItsQuery = ttdb.PostIts.Where(p => p.Category == "CM");

            // Creater OrderInfo objects from order and postit data
            var orderInfos = orders.
                Select(o => new OrderInfo() { Order = o, PostIt = cmPostItsQuery.FirstOrDefault(p => p.ordernr == o.ordernr) }).
                ToList();

            return orderInfos.OrderByDescending(o => o.Order.ordernr).ToList();
        }
    }
}


//ORDERINFO KLASSEN
public class OrderInfo
{
    public OpusOrder Order { get; set; }
    public PostIt PostIt { get; set; }
}


