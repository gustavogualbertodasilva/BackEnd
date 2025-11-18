using static System.Drawing.Color;
namespace Calculadora;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        this.Text = "Calculator";
        this.Size = new System.Drawing.Size(300,400);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;


        BorderedLabel Display = new BorderedLabel()
        {
            Width = 284,
            Height = 50,
            Top = 30,
            BackColor = Color.FromArgb(51, 51, 255)
        };
        Controls.Add(Display);
    }
}