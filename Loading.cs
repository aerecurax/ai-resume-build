using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Creator
{
    public partial class Loading : Form
    {
        BackgroundWorker backgroundWorker;
        public Loading(BackgroundWorker b)
        {
            InitializeComponent();
            backgroundWorker = b;
        
        }

        private void Loadiinf_Load(object sender, EventArgs e)
        {
           
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();

        }
    }
}
