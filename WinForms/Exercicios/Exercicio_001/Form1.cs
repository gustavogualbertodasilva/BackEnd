using System.Windows.Forms;

namespace Exercicio_001;

public partial class Form1 : Form
{
    private Label label1;
    private Button button1;
    private Button button2;
    public Form1()
    {
        InitializeComponent();

        button1 = new Button()
        {
            Text = "Botão1",
            Left = 20,
            Width = 100,
            Height = 50,
        };
        Controls.Add(button1);
        button1.Click += button1_Click;


        label1 = new Label()
        {
            Text = "Sou tipo uma div de HTML5, Meu nome é label",
            Left = 150,
            Width = 100,
            Height = 120,
            BackColor = System.Drawing.Color.LightPink
        };
        Controls.Add(label1);
    }

    private void button1_Click(object? sender, EventArgs e)
    {
        Controls.Remove(label1);
        label1.Dispose();
    }
}
