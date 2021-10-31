using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectforstudy
{
    public partial class FeedBackHistory : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;

        public student Student { get; set; }

        public FeedBackHistory()
        {
            

            InitializeComponent();
        }

        private void FeedBackHistory_Load(object sender, EventArgs e)
        {
            DataTable Feedbacks = Student.GetFeedbackHistory();
            foreach (DataRow row in Feedbacks.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < Feedbacks.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }

                materialListView4.Items.Add(item);
            }

        }

        private void materialListView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
