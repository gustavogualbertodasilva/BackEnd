using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AutoClicker1
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer? updateTimer;
        private CancellationTokenSource? cts = null;

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;

        public static decimal cps = 1;
        private Button? onButton;
        private Button? okButton;
        private NumericUpDown? cpsInput;
        private bool autoClickAtivo = false;
        private TextBox? hotkeyBox;
        private string hotkeyString = "";

        public static void AutoClick(CancellationToken token)
        {
            Thread.Sleep(500);

            while (!token.IsCancellationRequested)
            {
                int clickDelayMs = Convert.ToInt32(1000 / cps);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                Thread.Sleep(clickDelayMs);
            }
        }

        public Form1()
        {
            InitializeComponent();

            this.ClientSize = new Size(300, 150);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.Text = "Auto Clicker";

            Label cpsLabel = new Label
            {
                Text = "CPS:",
                Left = 20,
                Top = 18,
                Width = 30
            };
            this.Controls.Add(cpsLabel);

            cpsInput = new NumericUpDown
            {
                Name = "cpsInput",
                Minimum = 1,
                Maximum = 50,
                Value = 1,
                Left = 50,
                Top = 18,
                Width = 60
            };
            cpsInput.ValueChanged += CpsInput_ValueChanged;
            this.Controls.Add(cpsInput);

            hotkeyBox = new TextBox
            {
                ReadOnly = true,
                Left = 130,
                Top = 18,
                Width = 120,
                Text = "Definir tecla..."
            };
            hotkeyBox.Click += HotkeyBox_Click;
            this.Controls.Add(hotkeyBox);
        }

        private void HotkeyBox_Click(object? sender, EventArgs e)
        {
            using (FormHotkeyCapture capture = new FormHotkeyCapture())
            {
                if (capture.ShowDialog() == DialogResult.OK)
                {
                    string combo = "";
                    if (capture.CtrlPressed) combo += "Ctrl + ";
                    if (capture.AltPressed) combo += "Alt + ";
                    if (capture.ShiftPressed) combo += "Shift + ";

                    combo += capture.CapturedKey.ToString();

                    hotkeyString = combo;
                    if (hotkeyBox != null)
                        hotkeyBox.Text = hotkeyString;
                }
            }
        }

        private void CpsInput_ValueChanged(object? sender, EventArgs e)
        {
            cps = cpsInput!.Value;
        }
    }
}