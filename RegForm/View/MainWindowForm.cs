using RegForm.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace RegForm
{
    public partial class MainWindowForm : Form
    {
      
        private EventsControl EventsRealization;
        private Timer Update_Timer;
        public MainWindowForm()
        {
            InitializeComponent();
            //
            //  Config
            //
            this.ClientSize = new Size(450, 500);
            this.CenterToScreen();

            //
            //  Controls
            //
            this.EventsRealization = new EventsControl();

            //
            //  Timer
            //
            this.Update_Timer = new Timer();
            this.Update_Timer.Interval = 100;
            this.Update_Timer.Tick += TickUpdateEvent;
            this.Update_Timer.Start();
        }

        private void TickUpdateEvent(object sender, EventArgs e)
        {
            this.DateBox.Text = this.EventsRealization.Date.ToShortDateString();
        }

        private void DateBox_Click(object sender, EventArgs e)
        {
            this.EventsRealization.OpenDateChose();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if(this.materialSingleLineTextField1.Text!=String.Empty && this.materialSingleLineTextField2.Text != String.Empty)
            {
                this.EventsRealization.SaveData(this.materialSingleLineTextField1.Text, this.materialSingleLineTextField2.Text);
            }
        }
    }
}
