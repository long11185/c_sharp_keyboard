using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyBoardUI
{
    public partial class FormMessBox : Form
    {
        public FormMessBox(string title ,string mess,MessageBoxButtons buttons)
        {
            InitializeComponent();
            this.label1.Text = title;
            this.label2.Text = mess;
            this.TopMost = true;
        }
        public static DialogResult Show(string title,string mess,MessageBoxButtons buttons)
        {
            FormMessBox box = new FormMessBox(title, mess, buttons);
            return box.ShowDialog();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormMessBox_Load(object sender, EventArgs e)
        {
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }
    }
}
