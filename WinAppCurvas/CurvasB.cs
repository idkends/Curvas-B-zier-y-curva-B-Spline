using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinAppCurvas
{
    public partial class CurvasB : Form
    {
        // Datos + estado (puntos/drag/animación)
        private List<PointF> puntosControl = new List<PointF>();
        private int indicePuntoArrastrado = -1;
        private bool estaArrastrando = false;
        private const float RADIO_PUNTO = 6f;

        private float t_animacion = 0.0f;
        private bool animando = false;
        private bool animacionFinalizada = false;

        // Estilo (colores)
        private readonly Color colorGuias = Color.FromArgb(150, 120, 120, 120);
        private readonly Color colorBezier = Color.DarkCyan;
        private readonly Color colorSpline = Color.MediumVioletRed;

        private readonly Brush brushPuntoExtremo = Brushes.OrangeRed;
        private readonly Brush brushPuntoControl = Brushes.RoyalBlue;
        private readonly Brush brushTexto = Brushes.Black;

        private readonly Brush brushPuntoAnimacion = Brushes.Gold;

        private readonly Brush brushCasteljauPuntos = Brushes.LimeGreen;
        private readonly Color colorCasteljauLinea = Color.FromArgb(120, 0, 200, 90);
        private readonly Color colorCasteljauTangente = Color.OrangeRed;

        public CurvasB()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTipoCurva.SelectedIndex = 2;
            ConfigurarEscenarioInicial();
            this.DoubleBuffered = true;
        }

        private void ConfigurarEscenarioInicial()
        {
            puntosControl.Clear();
            int cy = pbLienzo.Height / 2;
            int cx = pbLienzo.Width / 2;

            switch (cmbTipoCurva.SelectedIndex)
            {
                case 0:
                    puntosControl.Add(new PointF(100, cy));
                    puntosControl.Add(new PointF(pbLienzo.Width - 100, cy));
                    break;

                case 1:
                    puntosControl.Add(new PointF(100, cy));
                    puntosControl.Add(new PointF(cx, 50));
                    puntosControl.Add(new PointF(pbLienzo.Width - 100, cy));
                    break;

                case 2:
                case 4:
                    puntosControl.Add(new PointF(100, cy));
                    puntosControl.Add(new PointF(cx - 100, 50));
                    puntosControl.Add(new PointF(cx + 100, pbLienzo.Height - 50));
                    puntosControl.Add(new PointF(pbLienzo.Width - 100, cy));
                    break;

                case 3:
                    puntosControl.Add(new PointF(50, cy));
                    puntosControl.Add(new PointF(200, 50));
                    puntosControl.Add(new PointF(400, cy + 100));
                    puntosControl.Add(new PointF(600, 50));
                    puntosControl.Add(new PointF(800, cy));
                    break;
            }

            pbLienzo.Invalidate();
        }

        #region Dibujo

        private void pbLienzo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            // Guías (polilínea)
            if (puntosControl.Count > 1)
            {
                using (Pen penGuias = new Pen(colorGuias, 1))
                {
                    penGuias.DashStyle = DashStyle.Dash;
                    g.DrawLines(penGuias, puntosControl.ToArray());
                }
            }

            // Curva
            float t_limite = animando ? t_animacion : 1.0f;

            if (cmbTipoCurva.SelectedIndex == 4) DibujarBSpline(g, t_limite);
            else DibujarBezier(g, t_limite);

            // Puntos de control
            for (int i = 0; i < puntosControl.Count; i++)
            {
                Brush b;

                if (cmbTipoCurva.SelectedIndex == 4)
                    b = brushPuntoControl;
                else
                    b = (i == 0 || i == puntosControl.Count - 1) ? brushPuntoExtremo : brushPuntoControl;

                float r = RADIO_PUNTO;
                float x = puntosControl[i].X;
                float y = puntosControl[i].Y;

                g.FillEllipse(b, x - r, y - r, r * 2, r * 2);
                g.DrawString("P" + i, this.Font, brushTexto, x + 5, y - 15);
            }

            // Casteljau (solo Bézier)
            if (animando && chkVerLineas.Checked && cmbTipoCurva.SelectedIndex != 4 && puntosControl.Count > 1)
            {
                DibujarDeCasteljauRecursivo(g, puntosControl, t_animacion);
            }
        }

        private void DibujarBezier(Graphics g, float tMax)
        {
            if (puntosControl.Count < 2) return;

            List<PointF> curva = new List<PointF>();
            float paso = 0.005f;

            for (float t = 0; t <= tMax; t += paso)
                curva.Add(CalcularPuntoBezier(puntosControl, t));

            if (tMax >= 1.0f)
                curva.Add(CalcularPuntoBezier(puntosControl, 1.0f));

            if (curva.Count > 1)
            {
                using (Pen penCurva = new Pen(colorBezier, 2))
                {
                    g.DrawLines(penCurva, curva.ToArray());
                }
            }

            if (animando && curva.Count > 0)
            {
                PointF ultimo = curva[curva.Count - 1];
                g.FillEllipse(brushPuntoAnimacion, ultimo.X - 4, ultimo.Y - 4, 8, 8);
            }
        }

        private PointF CalcularPuntoBezier(List<PointF> puntos, float t)
        {
            List<PointF> temp = new List<PointF>(puntos);
            int n = temp.Count - 1;

            for (int r = 1; r <= n; r++)
            {
                for (int i = 0; i <= n - r; i++)
                {
                    float x = (1 - t) * temp[i].X + t * temp[i + 1].X;
                    float y = (1 - t) * temp[i].Y + t * temp[i + 1].Y;
                    temp[i] = new PointF(x, y);
                }
            }
            return temp[0];
        }

        private void DibujarDeCasteljauRecursivo(Graphics g, List<PointF> puntos, float t)
        {
            if (puntos.Count <= 1) return;

            List<PointF> nuevosPuntos = new List<PointF>();
            Color c = (puntos.Count == 2) ? colorCasteljauTangente : colorCasteljauLinea;

            using (Pen p = new Pen(c, 1))
            {
                for (int i = 0; i < puntos.Count - 1; i++)
                {
                    float x = (1 - t) * puntos[i].X + t * puntos[i + 1].X;
                    float y = (1 - t) * puntos[i].Y + t * puntos[i + 1].Y;

                    nuevosPuntos.Add(new PointF(x, y));

                    if (puntos.Count > 2)
                        g.DrawLine(p, puntos[i], puntos[i + 1]);

                    g.FillEllipse(brushCasteljauPuntos, x - 3, y - 3, 6, 6);
                }

                if (nuevosPuntos.Count > 1)
                    g.DrawLines(p, nuevosPuntos.ToArray());
            }

            DibujarDeCasteljauRecursivo(g, nuevosPuntos, t);
        }

        private void DibujarBSpline(Graphics g, float tMax)
        {
            if (puntosControl.Count < 4) return;

            List<PointF> curva = new List<PointF>();
            float paso = 0.01f;

            int numSegmentos = puntosControl.Count - 3;
            float tTotal = numSegmentos * tMax;

            for (int i = 0; i < numSegmentos; i++)
            {
                for (float t = 0; t <= 1; t += paso)
                {
                    if (i + t > tTotal) break;
                    curva.Add(CalcularPuntoBSpline(i, t));
                }
            }

            if (curva.Count > 1)
            {
                using (Pen penSpline = new Pen(colorSpline, 2))
                {
                    g.DrawLines(penSpline, curva.ToArray());
                }
            }
        }

        private PointF CalcularPuntoBSpline(int i, float t)
        {
            PointF p0 = puntosControl[i];
            PointF p1 = puntosControl[i + 1];
            PointF p2 = puntosControl[i + 2];
            PointF p3 = puntosControl[i + 3];

            float t2 = t * t;
            float t3 = t * t * t;

            float b0 = (-t3 + 3 * t2 - 3 * t + 1) / 6.0f;
            float b1 = (3 * t3 - 6 * t2 + 4) / 6.0f;
            float b2 = (-3 * t3 + 3 * t2 + 3 * t + 1) / 6.0f;
            float b3 = t3 / 6.0f;

            float x = b0 * p0.X + b1 * p1.X + b2 * p2.X + b3 * p3.X;
            float y = b0 * p0.Y + b1 * p1.Y + b2 * p2.Y + b3 * p3.Y;

            return new PointF(x, y);
        }

        #endregion

        #region Mouse

        private void pbLienzo_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < puntosControl.Count; i++)
            {
                if (Distancia(e.Location, puntosControl[i]) < RADIO_PUNTO + 5)
                {
                    indicePuntoArrastrado = i;
                    estaArrastrando = true;
                    return;
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                if (puntosControl.Count > 0)
                {
                    puntosControl.RemoveAt(puntosControl.Count - 1);
                    pbLienzo.Invalidate();
                }
                return;
            }

            int limitePuntos = ObtenerLimitePuntos();
            if (limitePuntos == -1 || puntosControl.Count < limitePuntos)
            {
                puntosControl.Add(e.Location);
                pbLienzo.Invalidate();
            }
        }

        private void pbLienzo_MouseMove(object sender, MouseEventArgs e)
        {
            if (estaArrastrando && indicePuntoArrastrado != -1)
            {
                float x = Math.Max(0, Math.Min(pbLienzo.Width, e.X));
                float y = Math.Max(0, Math.Min(pbLienzo.Height, e.Y));

                puntosControl[indicePuntoArrastrado] = new PointF(x, y);

                if (animacionFinalizada) t_animacion = 1.0f;
                else if (!animando) t_animacion = 1.0f;

                pbLienzo.Invalidate();
            }
        }

        private void pbLienzo_MouseUp(object sender, MouseEventArgs e)
        {
            estaArrastrando = false;
            indicePuntoArrastrado = -1;
        }

        private float Distancia(Point p1, PointF p2)
        {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        private int ObtenerLimitePuntos()
        {
            switch (cmbTipoCurva.SelectedIndex)
            {
                case 0: return 2;
                case 1: return 3;
                case 2: return 4;
                default: return -1;
            }
        }

        #endregion

        #region UI / Animación

        private void cmbTipoCurva_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetenerAnimacion();
            ConfigurarEscenarioInicial();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DetenerAnimacion();
            puntosControl.Clear();
            pbLienzo.Invalidate();
        }

        private void btnAnimar_Click(object sender, EventArgs e)
        {
            if (puntosControl.Count < 2) return;

            t_animacion = 0.0f;
            animando = true;
            animacionFinalizada = false;

            tmrAnimacion.Start();
            btnAnimar.Enabled = false;
            cmbTipoCurva.Enabled = false;
        }

        private void tmrAnimacion_Tick(object sender, EventArgs e)
        {
            t_animacion += 0.01f;

            if (t_animacion >= 1.0f)
            {
                t_animacion = 1.0f;
                DetenerAnimacion();
                animacionFinalizada = true;
                pbLienzo.Invalidate();
            }
            else
            {
                lblTValue.Text = "t = " + t_animacion.ToString("0.00");
                pbLienzo.Invalidate();
            }
        }

        private void DetenerAnimacion()
        {
            tmrAnimacion.Stop();
            animando = false;
            btnAnimar.Enabled = true;
            cmbTipoCurva.Enabled = true;
            lblTValue.Text = "t = 1.00";
        }

        private void chkVerLineas_CheckedChanged(object sender, EventArgs e)
        {
            pbLienzo.Invalidate();
        }

        #endregion

        private void pbLienzo_Click(object sender, EventArgs e) { }
    }
}
