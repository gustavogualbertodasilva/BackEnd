using System.Windows.Forms;
using static System.Drawing.Color;

namespace Exercicio_002;

public partial class Form1 : Form
{
    private Label resultado;
    private NumericUpDown input1;
    private NumericUpDown input2;
    public Form1()
    {
        InitializeComponent();

        this.Size = new Size(300, 300);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;

        input1 = new NumericUpDown()
        {
            Maximum = 999,
            Minimum = -999,
            Width = 50,
            Left = 50,
            Top = 25
        };
        Controls.Add(input1);

        input2 = new NumericUpDown()
        {
            Maximum = 999,
            Minimum = -999,
            Width = 50,
            Left = 185,
            Top = 25
        };
        Controls.Add(input2);

        Button Somar = new Button()
        {
            Text = "Somar",
            Width = 65,
            Height = 65,
            Left = (110),
            BackColor = Blue,
        };
        Controls.Add(Somar);
        Somar.Click += SomarVoid;

        resultado = new Label()
        {
            Text = "N/A",
            Left = (300 - 100) / 2,
            Top = 150,
            Width = 100,
            Height = 100,
            BackColor = Color.LightBlue,
            TextAlign = ContentAlignment.MiddleCenter
        };
        Controls.Add(resultado);
    }

    private void SomarVoid(object sender, EventArgs e)
    {   
        resultado.Text = $"{input1.Value + input2.Value}";
    }
}
