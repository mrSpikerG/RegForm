using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegForm.View
{
    public partial class TheWorstTrackBarWhichIKnewForm : Form
    {
        private DateTime Time;
        public DateTime EndTime;
        private Button Button_Button;
        private Timer Timer_Timer;
        private TextBox Text_TextBox;
        public TheWorstTrackBarWhichIKnewForm()
        {
            InitializeComponent();

            //
            //  Config
            //
            this.ClientSize = new Size(500, 500);
            this.CenterToScreen();
            this.Time = new DateTime(2000, 1, 1);

            //
            //  Buttons
            //
            this.Button_Button = new Button();
            this.Button_Button.MouseDown += changeEvent;
            this.Button_Button.MouseUp += endTimerEvent;
            this.Button_Button.Location = new Point(200, 200);
          
            //
            //  Timer
            //
            this.Timer_Timer = new Timer();
            this.Timer_Timer.Interval = 100;
            this.Timer_Timer.Tick += testUpd;
            
            //
            //  TextBox
            // 
            this.Text_TextBox = new TextBox();
            this.Text_TextBox.Location = new Point(250, 0);
            this.Text_TextBox.Text = "test";

            this.Controls.Add(Text_TextBox);
            this.Controls.Add(Button_Button);
        }
        private void testUpd(object sender, EventArgs e)
        {
            int curX = Cursor.Position.X - this.Location.X;

            int x = curX - Cursor.Size.Width - this.Button_Button.Width / 2;
            if (x < 200) { x = 200; }
            if (x > 400) { x = 400; }

            int y = (int)Math.Sqrt(100 * 100 - (x - 300) * (x - 300)) + 300;
            if (Cursor.Position.Y >= 300)
            {
                this.Button_Button.Location = new Point(x, y);
            }
            else
            {
                y = -(int)Math.Sqrt(100 * 100 - (x - 300) * (x - 300)) + 300;
                this.Button_Button.Location = new Point(x, y);
            }
         
            this.Text_TextBox.Text = this.Time.AddDays(this.Button_Button.Location.X + this.Button_Button.Location.Y - 200).ToShortDateString();
            this.EndTime = this.Time.AddDays(this.Button_Button.Location.X + this.Button_Button.Location.Y - 200);

        }

        private void endTimerEvent(object sender, MouseEventArgs e)
        {
            this.Timer_Timer.Stop();
        }

        
        private void changeEvent(object sender, MouseEventArgs e)
        {
           // this.button.Location = new Point(this.button.Location.X + 1, this.button.Location.Y);
            Timer_Timer.Start();
        }
    }
}
