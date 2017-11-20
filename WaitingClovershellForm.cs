using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Editor
{
    public partial class WaitingClovershellForm : Form
    {
        public WaitingClovershellForm()
        {
            InitializeComponent();
            timer.Enabled = true;
        }

        private void WaitingForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void WaitingForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {

        }
    }
}
