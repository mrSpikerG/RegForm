using RegForm.View;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace RegForm.Control
{
    public class EventsControl
    {
        public DateTime Date { get; set; }
        private TheWorstTrackBarWhichIKnewForm Date_Form;
        public void OpenDateChose()
        {
            this.Date = new DateTime(2000, 1, 1);
            this.Date_Form = new TheWorstTrackBarWhichIKnewForm();
            this.Date_Form.Show();
            this.Date_Form.FormClosed += SaveDateFromForm;
        }

        private void SaveDateFromForm(object sender, FormClosedEventArgs e)
        {
            this.Date = (sender as TheWorstTrackBarWhichIKnewForm).EndTime;
        }

        public void SaveData(string Name, string Password)
        {
            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }
            File.WriteAllText($"Data/{Name}.txt", $"{Name} {this.hash(Password)} {this.Date.ToShortDateString()}");
        }

        private string hash(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            var result = new SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }
    }
}
