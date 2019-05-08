using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerTest.Server.Connector;

namespace ServerTest
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Connector.ServerStart();
            Start.Text = "OK!";
            Start.Enabled = false;
        }


        private void UI_Load(object sender, EventArgs e)
        {
           //ConnectionProgress.Value = Program.ServerStart;
        }

    }

}
