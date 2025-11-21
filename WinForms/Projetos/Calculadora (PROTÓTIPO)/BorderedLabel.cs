using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class BorderedLabel : Label
{
    // Esconder do Designer (útil quando você trabalha no VS Code)
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int BorderRadius { get; set; } = 10;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int BorderThickness { get; set; } = 2;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color BorderColor { get; set; } = Color.Black;

    public BorderedLabel()
    {
        // importante para usar BackColor como esperado
        this.AutoSize = false;
        // força double buffering (reduz flicker)
        this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        UpdateRegion(); // atualiza a Region quando muda tamanho
        Invalidate();
    }

    private void UpdateRegion()
    {
        Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
        using (GraphicsPath path = RoundedRect(rect, BorderRadius))
        {
            // define a região real do controle: isso faz o BackColor "recortar" as bordas
            this.Region?.Dispose();
            this.Region = new Region(path);
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // desenha o fundo (já recortado pela Region)
        using (Brush b = new SolidBrush(this.BackColor))
        {
            e.Graphics.FillRectangle(b, 0, 0, Width, Height); // opcional: Label já pinta o BackColor, mas deixamos explícito
        }

        // desenha o texto usando o comportamento padrão do Label (chamamos base depois de desenhar a borda)
        // desenha a borda por cima
        Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
        using (GraphicsPath path = RoundedRect(rect, BorderRadius))
        using (Pen pen = new Pen(BorderColor, BorderThickness))
        {
            e.Graphics.DrawPath(pen, path);
        }

        // agora deixa o Label desenhar texto, etc.
        base.OnPaint(e);
    }

    private GraphicsPath RoundedRect(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();

        if (radius <= 0)
        {
            path.AddRectangle(rect);
            return path;
        }

        int diameter = radius * 2;
        Rectangle arc = new Rectangle(rect.Location, new Size(diameter, diameter));

        // canto superior esquerdo
        arc.X = rect.X;
        arc.Y = rect.Y;
        path.AddArc(arc, 180, 90);

        // canto superior direito
        arc.X = rect.Right - diameter;
        arc.Y = rect.Y;
        path.AddArc(arc, 270, 90);

        // canto inferior direito
        arc.X = rect.Right - diameter;
        arc.Y = rect.Bottom - diameter;
        path.AddArc(arc, 0, 90);

        // canto inferior esquerdo
        arc.X = rect.X;
        arc.Y = rect.Bottom - diameter;
        path.AddArc(arc, 90, 90);

        path.CloseFigure();
        return path;
    }
}
