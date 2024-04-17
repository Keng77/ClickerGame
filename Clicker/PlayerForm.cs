using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clicker
{
    public partial class PlayerForm : Form
    {
        public PlayerForm()
        {
            InitializeComponent();
        }

        public string GetPlayer1Name()
        {
            return Player1TextBox.Text.Trim();
        }

        public string GetPlayer2Name()
        {
            return Player2TextBox.Text.Trim();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;            
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Player2TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
