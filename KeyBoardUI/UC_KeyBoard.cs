using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace KeyBoardUI
{
    public partial class UC_KeyBoard : UserControl
    {
        [DllImport("user32.dll", EntryPoint = "keybd_event")]

        public static extern void keybd_event(

          byte bVk,    //虚拟键值

          byte bScan,// 一般为0

          int dwFlags,  //这里是整数类型  0 为按下，2为释放

          int dwExtraInfo  //这里是整数类型 一般情况下设成为 0

      );
        [DllImport("user32.dll", EntryPoint = "GetKeyboardState")]
        public static extern int GetKeyboardState(byte[] pbKeyState);



        public static bool CapsLockStatus
        {
            get
            {
                byte[] bs = new byte[256];
                GetKeyboardState(bs);
                return (bs[0x14] == 1);
            }
        }

        public delegate void delegatToCloseForm();
       public  event delegatToCloseForm EventToCloseForm;
        private bool NowIsCaps = false;
        private void EventToFoucus()
        {
            ;
        }

        public UC_KeyBoard()
        {
            InitializeComponent();
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        //大小写切换
        private void Caps_Lock(bool isCapsNow)
        {
           
            if (isCapsNow)
            {
                buttonA.BackgroundImage = KeyBoardUI.Properties.Resources.A_大写标准;
                buttonB.BackgroundImage = KeyBoardUI.Properties.Resources.B_大写标准;
                buttonC.BackgroundImage = KeyBoardUI.Properties.Resources.C_大写标准;
                buttonD.BackgroundImage = KeyBoardUI.Properties.Resources.D_大写标准;
                buttonE.BackgroundImage = KeyBoardUI.Properties.Resources.E_大写标准;
                buttonF.BackgroundImage = KeyBoardUI.Properties.Resources.F_大写标准;
                buttonG.BackgroundImage = KeyBoardUI.Properties.Resources.G_大写标准;
                buttonH.BackgroundImage = KeyBoardUI.Properties.Resources.H_大写标准;
                buttonI.BackgroundImage = KeyBoardUI.Properties.Resources.I_大写标准;
                buttonJ.BackgroundImage = KeyBoardUI.Properties.Resources.J_大写标准;
                buttonK.BackgroundImage = KeyBoardUI.Properties.Resources.K_大写标准;
                buttonL.BackgroundImage = KeyBoardUI.Properties.Resources.L_大写标准;
                buttonM.BackgroundImage = KeyBoardUI.Properties.Resources.M_大写标准;
                buttonN.BackgroundImage = KeyBoardUI.Properties.Resources.N_大写标准;
                buttonO.BackgroundImage = KeyBoardUI.Properties.Resources.O_大写标准;
                buttonP.BackgroundImage = KeyBoardUI.Properties.Resources.P_大写标准;
                buttonQ.BackgroundImage = KeyBoardUI.Properties.Resources.Q_大写标准;
                buttonR.BackgroundImage = KeyBoardUI.Properties.Resources.R_大写标准;
                buttonS.BackgroundImage = KeyBoardUI.Properties.Resources.S_大写标准;
                buttonT.BackgroundImage = KeyBoardUI.Properties.Resources.T_大写标准;
                buttonU.BackgroundImage = KeyBoardUI.Properties.Resources.U_大写标准;
                buttonV.BackgroundImage = KeyBoardUI.Properties.Resources.V_大写标准;
                buttonW.BackgroundImage = KeyBoardUI.Properties.Resources.W_大写标准;
                buttonX.BackgroundImage = KeyBoardUI.Properties.Resources.X_大写标准;
                buttonY.BackgroundImage = KeyBoardUI.Properties.Resources.Y_大写标准;
                buttonZ.BackgroundImage = KeyBoardUI.Properties.Resources.Z_大写标准;
            }
            else
            {
                buttonA.BackgroundImage = KeyBoardUI.Properties.Resources.a_小写标准;
                buttonB.BackgroundImage = KeyBoardUI.Properties.Resources.b_小写标准;
                buttonC.BackgroundImage = KeyBoardUI.Properties.Resources.c_小写标准;
                buttonD.BackgroundImage = KeyBoardUI.Properties.Resources.d_小写标准;
                buttonE.BackgroundImage = KeyBoardUI.Properties.Resources.e_小写标准;
                buttonF.BackgroundImage = KeyBoardUI.Properties.Resources.f_小写标准;
                buttonG.BackgroundImage = KeyBoardUI.Properties.Resources.g_小写标准;
                buttonH.BackgroundImage = KeyBoardUI.Properties.Resources.h_小写标准;
                buttonI.BackgroundImage = KeyBoardUI.Properties.Resources.i_小写标准;
                buttonJ.BackgroundImage = KeyBoardUI.Properties.Resources.j_小写标准;
                buttonK.BackgroundImage = KeyBoardUI.Properties.Resources.k_小写标准;
                buttonL.BackgroundImage = KeyBoardUI.Properties.Resources.l_小写标准;
                buttonM.BackgroundImage = KeyBoardUI.Properties.Resources.m_小写标准;
                buttonN.BackgroundImage = KeyBoardUI.Properties.Resources.n_小写标准;
                buttonO.BackgroundImage = KeyBoardUI.Properties.Resources.o_小写标准;
                buttonP.BackgroundImage = KeyBoardUI.Properties.Resources.p_小写标准;
                buttonQ.BackgroundImage = KeyBoardUI.Properties.Resources.q_小写标准;
                buttonR.BackgroundImage = KeyBoardUI.Properties.Resources.r_小写标准;
                buttonS.BackgroundImage = KeyBoardUI.Properties.Resources.s_小写标准;
                buttonT.BackgroundImage = KeyBoardUI.Properties.Resources.t_小写标准;
                buttonU.BackgroundImage = KeyBoardUI.Properties.Resources.u_小写标准;
                buttonV.BackgroundImage = KeyBoardUI.Properties.Resources.v_小写标准;
                buttonW.BackgroundImage = KeyBoardUI.Properties.Resources.w_小写标准;
                buttonX.BackgroundImage = KeyBoardUI.Properties.Resources.x_小写标准;
                buttonY.BackgroundImage = KeyBoardUI.Properties.Resources.y_小写标准;
                buttonZ.BackgroundImage = KeyBoardUI.Properties.Resources.z_小写标准;
            }

        }

        [DllImport("user32.dll", EntryPoint = "ShowCursor", CharSet = CharSet.Auto)]
        public extern static void ShowCursor(int status);
        private void UC_KeyBoard_Load(object sender, EventArgs e)
        {
          // ShowCursor(0);
            if (CapsLockStatus)
            {
                NowIsCaps = true;
                Caps_Lock(true);
            }
            else
            {
                NowIsCaps = false;
                Caps_Lock(false);
            }
        }

        #region 按键使能
        private void buttonLOCK_Click(object sender, EventArgs e)
        {
            keybd_event((byte)Keys.CapsLock, 0, 0, 0);
            keybd_event((byte)Keys.CapsLock, 0, 2, 0);
            if (NowIsCaps)
            {
                Caps_Lock(false);
                NowIsCaps = false;
            }
            else
            {
                Caps_Lock(true);
                NowIsCaps = true;
            }

        }
        private void buttonQ_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.Q, 0, 0, 0);
            keybd_event((byte)Keys.Q, 0, 2, 0);
        }

        private void buttonW_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.W, 0, 0, 0);
            keybd_event((byte)Keys.W, 0, 2, 0);
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.E, 0, 0, 0);
            keybd_event((byte)Keys.E, 0, 2, 0);
        }

        private void buttonR_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.R, 0, 0, 0);
            keybd_event((byte)Keys.R, 0, 2, 0);
        }

        private void buttonT_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.T, 0, 0, 0);
            keybd_event((byte)Keys.T, 0, 2, 0);
        }

        private void buttonY_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.Y, 0, 0, 0);
            keybd_event((byte)Keys.Y, 0, 2, 0);
        }

        private void buttonU_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.U, 0, 0, 0);
            keybd_event((byte)Keys.U, 0, 2, 0);
        }

        private void buttonI_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.I, 0, 0, 0);
            keybd_event((byte)Keys.I, 0, 2, 0);
        }

        private void buttonO_Click_1(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.O, 0, 0, 0);
            keybd_event((byte)Keys.O, 0, 2, 0);
        }

        private void buttonP_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.P, 0, 0, 0);
            keybd_event((byte)Keys.P, 0, 2, 0);
        }

        private void buttonDEL_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.Back, 0, 0, 0);
            keybd_event((byte)Keys.Back, 0, 2, 0);
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.A, 0, 0, 0);
            keybd_event((byte)Keys.A, 0, 2, 0);
        }

        private void buttonS_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.S, 0, 0, 0);
            keybd_event((byte)Keys.S, 0, 2, 0);
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.D, 0, 0, 0);
            keybd_event((byte)Keys.D, 0, 2, 0);
        }
        private void buttonF_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.F, 0, 0, 0);
            keybd_event((byte)Keys.F, 0, 2, 0);
        }

        private void buttonG_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.G, 0, 0, 0);
            keybd_event((byte)Keys.G, 0, 2, 0);
        }
        private void buttonH_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.H, 0, 0, 0);
            keybd_event((byte)Keys.H, 0, 2, 0);
        }

        private void buttonJ_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.J, 0, 0, 0);
            keybd_event((byte)Keys.J, 0, 2, 0);
        }

        private void buttonK_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.K, 0, 0, 0);
            keybd_event((byte)Keys.K, 0, 2, 0);
        }

        private void buttonL_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.L, 0, 0, 0);
            keybd_event((byte)Keys.L, 0, 2, 0);
        }

        private void buttonZ_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.Z, 0, 0, 0);
            keybd_event((byte)Keys.Z, 0, 2, 0);
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.X, 0, 0, 0);
            keybd_event((byte)Keys.X, 0, 2, 0);
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.C, 0, 0, 0);
            keybd_event((byte)Keys.C, 0, 2, 0);
        }

        private void buttonV_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.V, 0, 0, 0);
            keybd_event((byte)Keys.V, 0, 2, 0);
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.B, 0, 0, 0);
            keybd_event((byte)Keys.B, 0, 2, 0);
        }

        private void buttonN_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.N, 0, 0, 0);
            keybd_event((byte)Keys.N, 0, 2, 0);
        }

        private void buttonM_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.M, 0, 0, 0);
            keybd_event((byte)Keys.M, 0, 2, 0);
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.Left, 0, 0, 0);
            keybd_event((byte)Keys.Left, 0, 2, 0);
        }

        private void buttonRigth_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.Right, 0, 0, 0);
            keybd_event((byte)Keys.Right, 0, 2, 0);
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.Multiply, 0, 0, 0);
            keybd_event((byte)Keys.Multiply, 0, 2, 0);
        }

        private void buttonSpace_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.Space, 0, 0, 0);
            keybd_event((byte)Keys.Space, 0, 2, 0);
        }

        private void buttonCOMPELET_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.Enter, 0, 0, 0);
            keybd_event((byte)Keys.Enter, 0, 2, 0);
        }

        private void buttonSHIFT0_Click(object sender, EventArgs e)
        {
            keybd_event((byte)Keys.ControlKey, 0, 0, 0);
            keybd_event((byte)Keys.ShiftKey, 0, 0, 0);
            keybd_event((byte)Keys.ControlKey, 0, 2, 0);
            keybd_event((byte)Keys.ShiftKey, 0, 2, 0);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.D1, 0, 0, 0);
            keybd_event((byte)Keys.D1, 0, 2, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.D2, 0, 0, 0);
            keybd_event((byte)Keys.D2, 0, 2, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.D3, 0, 0, 0);
            keybd_event((byte)Keys.D3, 0, 2, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.D4, 0, 0, 0);
            keybd_event((byte)Keys.D4, 0, 2, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.D5, 0, 0, 0);
            keybd_event((byte)Keys.D5, 0, 2, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.D6, 0, 0, 0);
            keybd_event((byte)Keys.D6, 0, 2, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.D7, 0, 0, 0);
            keybd_event((byte)Keys.D7, 0, 2, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.D8, 0, 0, 0);
            keybd_event((byte)Keys.D8, 0, 2, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.D8, 0, 0, 0);
            keybd_event((byte)Keys.D8, 0, 2, 0);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.D0, 0, 0, 0);
            keybd_event((byte)Keys.D0, 0, 2, 0);
        }

        private void button00_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.D0, 0, 0, 0);
            keybd_event((byte)Keys.D0, 0, 2, 0);
            keybd_event((byte)Keys.D0, 0, 0, 0);
            keybd_event((byte)Keys.D0, 0, 2, 0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.Back, 0, 0, 0);
            keybd_event((byte)Keys.Back, 0, 2, 0);
        }
        private void buttonCompa_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.Enter, 0, 0, 0);
            keybd_event((byte)Keys.Enter, 0, 2, 0);
        }
        private void buttonTab_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.Tab, 0, 0, 0);
            keybd_event((byte)Keys.Tab, 0, 2, 0);
        }
        private void button__Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.Subtract, 0, 0, 0);
            keybd_event((byte)Keys.Subtract, 0, 2, 0);
        }

        private void buttonDont_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.Decimal, 0, 0, 0);
            keybd_event((byte)Keys.Decimal, 0, 2, 0);
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            EventToFoucus();
            keybd_event((byte)Keys.Enter, 0, 0, 0);
            keybd_event((byte)Keys.Enter, 0, 2, 0);
        }
        #endregion

        private void buttonCloseThis_Click(object sender, EventArgs e)
        {
            EventToCloseForm();
        }
    }
}
