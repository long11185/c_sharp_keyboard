using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace KeyBoardUI
{
    public partial class FormKeyBoard : Form
    {
        private const int WS_EX_TOOLWINDOW = 0x00000080;
        private const int WS_EX_NOACTIVATE = 0x08000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= (WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW);
                cp.Parent = IntPtr.Zero; // Keep this line only if you used UserControl
                return cp;
                //return base.CreateParams;
            }
        }
        private static FormKeyBoard frm = null;
        public static FormKeyBoard CreateInstrance()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FormKeyBoard();
            }
            return frm;
        }
        public FormKeyBoard()
        {
            InitializeComponent();
            this.TopMost = true;
            UC_KeyBoard uc_keyBoard = new UC_KeyBoard();
            uc_keyBoard.EventToCloseForm += new UC_KeyBoard.delegatToCloseForm(ToCloseThisForm);
            this.panelKeyBoard.Controls.Add(uc_keyBoard);
            panelKeyBoard.Controls[0].Location = new Point((panelKeyBoard.Width - panelKeyBoard.Controls[0].Width) / 2, panelKeyBoard.Controls[0].Location.Y);
        }
        private void ToCloseThisForm()
        {
        DialogResult dr=FormMessBox.Show("提示", "是否确认退出！",  MessageBoxButtons.YesNo);
            if (dr==DialogResult.OK|| dr == DialogResult.Yes)
            {
                this.Close();
            }
            
        }
        private void FormKeyBoard_Load(object sender, EventArgs e)
        {
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }
    }
}
