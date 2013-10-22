using System;
using System.Diagnostics;
using System.Messaging;
using System.Windows.Forms;
using WindowsInput;

namespace WebKeyboardDesktop
{
    public partial class Form1 : Form
    {
        string path = @".\Private$\WebKeyboard1";
        MessageQueue msgQ;
        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Text = "WebKeyboard - Desktop";
            if (!MessageQueue.Exists(path))
                MessageQueue.Create(path);
            msgQ = new MessageQueue(path);
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
        }

        void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            infoTextBox.Text += MakeHumanString(e.ProgressPercentage) + Environment.NewLine;
            infoTextBox.ScrollToCaret();
            notifyIcon1.ShowBalloonTip(100, "Media event", ((VirtualKeyCode)e.ProgressPercentage).ToString(), ToolTipIcon.Info);
        }

        string MakeHumanString(int keycode)
        {
            return string.Format("{0} {1} {2}", DateTime.Now, keycode, ((VirtualKeyCode)keycode).ToString());

        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Debug.WriteLine("Starting background worker");
            while (!backgroundWorker1.CancellationPending)
            {
                System.Messaging.Message msg = msgQ.Receive();
                if (msg.Label == "One")
                {
                    msg.Formatter = new XmlMessageFormatter(new Type[1] { typeof(int) });
                    Debug.WriteLine(msg.Body);
                    int t = (int)msg.Body;
                    backgroundWorker1.ReportProgress(t);
                    InputSimulator.SimulateKeyPress((VirtualKeyCode)t);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            infoTextBox.Text = "";
        }

    }
}
