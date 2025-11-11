using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AutoClicker1
{
    public class FormHotkeyCapture : Form
    {
        // Não deixe o designer tentar serializar/mostrar essas propriedades
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Keys CapturedKey { get; private set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CtrlPressed { get; private set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AltPressed { get; private set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShiftPressed { get; private set; }

        private Label labelInfo;

        public FormHotkeyCapture()
        {
            this.Text = "Pressione uma tecla...";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Width = 360;
            this.Height = 120;
            this.KeyPreview = true;

            labelInfo = new Label
            {
                Text = "Pressione a combinação de teclas ou uma tecla:",
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            Controls.Add(labelInfo);

            // Handler sem nullable mismatch
            this.KeyDown += OnKeyDown;
            this.MouseDown += OnMouseDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            CtrlPressed = e.Control;
            AltPressed = e.Alt;
            ShiftPressed = e.Shift;
            CapturedKey = e.KeyCode;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            // Mapeia botões de mouse para Keys (ou escolha outra representação)
            switch (e.Button)
            {
                case MouseButtons.Left:
                    CapturedKey = Keys.LButton; // existe Keys.LButton
                    break;
                case MouseButtons.Right:
                    CapturedKey = Keys.RButton;
                    break;
                case MouseButtons.Middle:
                    CapturedKey = Keys.MButton;
                    break;
                default:
                    CapturedKey = Keys.None;
                    break;
            }

            CtrlPressed = false;
            AltPressed = false;
            ShiftPressed = false;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
