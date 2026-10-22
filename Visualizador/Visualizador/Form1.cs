namespace Visualizador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CalcularImprimirGris(55, 188, 125);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen (*.jpg; *.jpeg; *.png; *.bmp)| *.jpg; *.jpeg; *.png; *.bmp";
                openFileDialog.Title = "Selecciona una imagen";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string rutaImagen = openFileDialog.FileName;
                        pictureBox1.Image = Image.FromFile(rutaImagen);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al cargar la imagen: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap imagenOriginal = new Bitmap(pictureBox1.Image);

            Bitmap imagenGris = new Bitmap(imagenOriginal.Width, imagenOriginal.Height);

            for (int x = 0; x < imagenOriginal.Width; x++)
            {
                for (int y = 0; y < imagenOriginal.Height; y++)
                {
                    Color pixel = imagenOriginal.GetPixel(x, y);

                    int rojo = pixel.R;
                    int verde = pixel.G;
                    int azul = pixel.B;

                    int gris = (int)(0.299 * rojo + 0.587 * verde + 0.114 * azul);

                    Color nuevoPixel = Color.FromArgb(gris, gris, gris);

                    imagenGris.SetPixel(x, y, nuevoPixel);
                }
            }
            pictureBox1.Image = imagenGris;
        }

        public static void CalcularImprimirGris(int r, int g, int b)
        {
            double rL = Math.Pow(r / 255.0, 2.4);
            double gL = Math.Pow(g / 255.0, 2.4);
            double bL = Math.Pow(b / 255.0, 2.4);

            double yL = (0.2126 * rL) + (0.7172 * gL) + (0.0722 * bL);

            int gray = (int)Math.Round(Math.Pow(yL, 1.0 / 2.4) * 255.0);

            gray = Math.Clamp(gray, 0, 255);

            System.Diagnostics.Debug.WriteLine($"RGB Original: ({r}, {g}, {b})");
            System.Diagnostics.Debug.WriteLine($"Valor en escala de grises: {gray}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Por favor, carga una imagen primero (Botón 1).", "Sin imagen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap imagenOriginal = new Bitmap(pictureBox1.Image);
            Bitmap imagenGris = new Bitmap(imagenOriginal.Width, imagenOriginal.Height);

            for (int x = 0; x < imagenOriginal.Width; x++)
            {
                for (int y = 0; y < imagenOriginal.Height; y++)
                {
                    Color pixel = imagenOriginal.GetPixel(x, y);

                    int valorGris = CalcularValorGris(pixel.R, pixel.G, pixel.B);

                    Color nuevoPixel = Color.FromArgb(valorGris, valorGris, valorGris);

                    imagenGris.SetPixel(x, y, nuevoPixel);
                }
            }

            pictureBox1.Image = imagenGris;
        }

        public int CalcularValorGris(int r, int g, int b)
        {
            double rL = Math.Pow(r / 255.0, 2.4);
            double gL = Math.Pow(g / 255.0, 2.4);
            double bL = Math.Pow(b / 255.0, 2.4);

            double yL = (0.2126 * rL) + (0.7172 * gL) + (0.0722 * bL);

            int gray = (int)Math.Round(Math.Pow(yL, 1.0 / 2.4) * 255.0);
            return Math.Clamp(gray, 0, 255);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Validamos que haya una imagen cargada
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Por favor, carga una imagen primero.", "Sin imagen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtenemos la imagen actual 
            Bitmap imagenActual = new Bitmap(pictureBox1.Image);

            // Calculamos los datos
            int[] datosHistograma = CalcularHistograma(imagenActual);

            // Dibujamos y mostramos la ventana
            MostrarHistogramaGrafico(datosHistograma);
        }

        public int[] CalcularHistograma(Bitmap imagen)
        {
            int[] histograma = new int[256];

            for (int x = 0; x < imagen.Width; x++)
            {
                for (int y = 0; y < imagen.Height; y++)
                {
                    Color pixel = imagen.GetPixel(x, y);

                    // Calculamos la intensidad del píxel
                    int intensidad = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);

                    // Aseguramos que esté en el rango 0-255
                    intensidad = Math.Clamp(intensidad, 0, 255);

                    // Aumentamos el contador para ese nivel de intensidad
                    histograma[intensidad]++;
                }
            }

            return histograma;
        }

        // Y aquí está la función que dibuja (con la corrección para ignorar el 0)
        public void MostrarHistogramaGrafico(int[] histograma)
        {
            int maxPixeles = 0;
            // Empezamos en i = 1 para ignorar el 0
            for (int i = 1; i < 256; i++)
            {
                if (histograma[i] > maxPixeles)
                    maxPixeles = histograma[i];
            }

            int ancho = 512;
            int alto = 300;
            Bitmap bmpHistograma = new Bitmap(ancho, alto);

            using (Graphics g = Graphics.FromImage(bmpHistograma))
            {
                g.Clear(Color.White);
                Pen lapizNegro = new Pen(Color.Black, 2);

                // Empezamos en i = 1 para ignorar el 0 en el dibujo
                for (int i = 1; i < 256; i++)
                {
                    if (maxPixeles > 0)
                    {
                        int alturaBarra = (int)(((double)histograma[i] / maxPixeles) * (alto - 20));
                        g.DrawLine(lapizNegro, i * 2, alto, i * 2, alto - alturaBarra);
                    }
                }
            }

            Form ventanaHistograma = new Form();
            ventanaHistograma.Text = "Histograma de Intensidad (Sin Píxeles 0)";
            ventanaHistograma.ClientSize = new Size(ancho, alto);
            ventanaHistograma.FormBorderStyle = FormBorderStyle.FixedDialog;
            ventanaHistograma.StartPosition = FormStartPosition.CenterScreen;

            PictureBox pbGrafico = new PictureBox();
            pbGrafico.Dock = DockStyle.Fill;
            pbGrafico.Image = bmpHistograma;

            ventanaHistograma.Controls.Add(pbGrafico);
            ventanaHistograma.Show();
        }

        // ACTIVIDAD 1: Cargar imagen desde ruta fija, convertir de S a L y mostrar histograma por color

        private Point? puntoA = null;
        private Point? puntoB = null;

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap imagenOriginal;
            try
            {
                imagenOriginal = new Bitmap("C:/Users/kuroh/Pictures/Fondos de pantalla/1.jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la imagen en la ruta especificada: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int[] histR, histG, histB;
            CalcularHistogramaPorColor(imagenOriginal, out histR, out histG, out histB);
            MostrarHistogramaPorColor(histR, histG, histB);


            Bitmap imagenGrisL = ConvertirSaturacionALuminosidad(imagenOriginal);
            pictureBox1.Image = imagenGrisL;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public Bitmap ConvertirSaturacionALuminosidad(Bitmap origen)
        {
            Bitmap destino = new Bitmap(origen.Width, origen.Height);

            for (int x = 0; x < origen.Width; x++)
            {
                for (int y = 0; y < origen.Height; y++)
                {
                    Color pixel = origen.GetPixel(x, y);

                    int max = Math.Max(pixel.R, Math.Max(pixel.G, pixel.B));
                    int min = Math.Min(pixel.R, Math.Min(pixel.G, pixel.B));

                    int l = (max + min) / 2;

                    destino.SetPixel(x, y, Color.FromArgb(l, l, l));
                }
            }

            return destino;
        }

        public void CalcularHistogramaPorColor(Bitmap imagen, out int[] histR, out int[] histG, out int[] histB)
        {
            histR = new int[256];
            histG = new int[256];
            histB = new int[256];

            for (int x = 0; x < imagen.Width; x++)
            {
                for (int y = 0; y < imagen.Height; y++)
                {
                    Color pixel = imagen.GetPixel(x, y);
                    histR[pixel.R]++;
                    histG[pixel.G]++;
                    histB[pixel.B]++;
                }
            }
        }

        public void MostrarHistogramaPorColor(int[] histR, int[] histG, int[] histB)
        {
            int ancho = 512;
            int alto = 300;
            Bitmap bmp = new Bitmap(ancho, alto);

            int maxValor = 0;
            for (int i = 1; i < 256; i++)
                maxValor = Math.Max(maxValor, Math.Max(histR[i], Math.Max(histG[i], histB[i])));

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                Pen lapizRojo = new Pen(Color.Red, 1);
                Pen lapizVerde = new Pen(Color.Green, 1);
                Pen lapizAzul = new Pen(Color.Blue, 1);

                for (int i = 1; i < 256; i++)
                {
                    if (maxValor > 0)
                    {
                        int altR = (int)(((double)histR[i] / maxValor) * (alto - 20));
                        int altG = (int)(((double)histG[i] / maxValor) * (alto - 20));
                        int altB = (int)(((double)histB[i] / maxValor) * (alto - 20));

                        g.DrawLine(lapizRojo, i * 2, alto, i * 2, alto - altR);
                        g.DrawLine(lapizVerde, i * 2, alto, i * 2, alto - altG);
                        g.DrawLine(lapizAzul, i * 2, alto, i * 2, alto - altB);
                    }
                }
            }

            Form ventana = new Form();
            ventana.Text = "Histograma por Canal (Rojo / Verde / Azul)";
            ventana.ClientSize = new Size(ancho, alto);
            ventana.FormBorderStyle = FormBorderStyle.FixedDialog;
            ventana.StartPosition = FormStartPosition.CenterScreen;

            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Fill;
            pb.Image = bmp;

            ventana.Controls.Add(pb);
            ventana.Show();
        }


        // Parte 2: Lienzo con punto A y punto B, cálculo de distancias y movimientos

        private void pictureBoxLienzo_MouseClick(object sender, MouseEventArgs e)
        {
            if (puntoA == null)
            {
                puntoA = e.Location;
            }
            else if (puntoB == null)
            {
                puntoB = e.Location;
            }
            else
            {
                puntoA = e.Location;
                puntoB = null;
            }

            DibujarPuntosEnLienzo();
        }

        private void DibujarPuntosEnLienzo()
        {
            Bitmap lienzo = new Bitmap(pictureBoxLienzo.Width, pictureBoxLienzo.Height);

            using (Graphics g = Graphics.FromImage(lienzo))
            {
                g.Clear(Color.White);

                if (puntoA != null)
                {
                    g.FillEllipse(Brushes.Red, puntoA.Value.X - 4, puntoA.Value.Y - 4, 8, 8);
                    g.DrawString("A", this.Font, Brushes.Black, puntoA.Value.X + 6, puntoA.Value.Y - 6);
                }

                if (puntoB != null)
                {
                    g.FillEllipse(Brushes.Blue, puntoB.Value.X - 4, puntoB.Value.Y - 4, 8, 8);
                    g.DrawString("B", this.Font, Brushes.Black, puntoB.Value.X + 6, puntoB.Value.Y - 6);
                }

                if (puntoA != null && puntoB != null)
                {
                    g.DrawLine(Pens.Gray, puntoA.Value, puntoB.Value);
                }
            }

            pictureBoxLienzo.Image = lienzo;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (puntoA == null || puntoB == null)
            {
                MessageBox.Show("Da clic en el lienzo para marcar primero el punto A y luego el punto B.",
                    "Faltan puntos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int dx = Math.Abs(puntoB.Value.X - puntoA.Value.X);
            int dy = Math.Abs(puntoB.Value.Y - puntoA.Value.Y);

            double distEuclidiana = Math.Sqrt(dx * dx + dy * dy);

            int distManhattan = dx + dy;

            int distChebyshev = Math.Max(dx, dy);

            string mensaje =
                $"Punto A: ({puntoA.Value.X}, {puntoA.Value.Y})\n" +
                $"Punto B: ({puntoB.Value.X}, {puntoB.Value.Y})\n\n" +
                $"Distancia Euclidiana: {distEuclidiana:F2} px\n" +
                $"Distancia Manhattan: {distManhattan} movimientos\n" +
                $"Distancia Chebyshev: {distChebyshev} movimientos";

            MessageBox.Show(mensaje, "Resultado de distancias", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            puntoA = null;
            puntoB = null;
            DibujarPuntosEnLienzo();
        }

        // ACTIVIDAD: Suavizado de imagen usando un Kernel (Filtro de Media 3x3)
        private void button8_Click(object sender, EventArgs e)
        {
            // 1. Validamos que haya una imagen cargada (reutilizando tu pictureBox1)
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Por favor, carga una imagen primero (Botón 1).", "Sin imagen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Avisamos al usuario porque GetPixel/SetPixel puede tardar unos segundos en imágenes grandes
            this.Text = "Aplicando suavizado... Por favor espera.";
            Application.DoEvents(); // Fuerza a la interfaz a actualizar el título

            Bitmap imagenOriginal = new Bitmap(pictureBox1.Image);
            Bitmap imagenSuavizada = new Bitmap(imagenOriginal.Width, imagenOriginal.Height);

            // 2. Recorremos toda la matriz de píxeles de la imagen
            for (int x = 0; x < imagenOriginal.Width; x++)
            {
                for (int y = 0; y < imagenOriginal.Height; y++)
                {
                    int sumaR = 0, sumaG = 0, sumaB = 0;
                    int vecinosContados = 0;

                    // 3. Aplicamos la ventana / Kernel 3x3 alrededor del píxel actual (x, y)
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int nx = x + i;
                            int ny = y + j;

                            // Validación crucial: Proteger los bordes de la imagen
                            if (nx >= 0 && nx < imagenOriginal.Width && ny >= 0 && ny < imagenOriginal.Height)
                            {
                                Color pixelVecino = imagenOriginal.GetPixel(nx, ny);

                                sumaR += pixelVecino.R;
                                sumaG += pixelVecino.G;
                                sumaB += pixelVecino.B;
                                vecinosContados++;
                            }
                        }
                    }

                    // 4. Calculamos el promedio y aplicamos tu regla de redondeo
                    int nuevoR = (int)Math.Round((double)sumaR / vecinosContados, MidpointRounding.AwayFromZero);
                    int nuevoG = (int)Math.Round((double)sumaG / vecinosContados, MidpointRounding.AwayFromZero);
                    int nuevoB = (int)Math.Round((double)sumaB / vecinosContados, MidpointRounding.AwayFromZero);

                    // Nos aseguramos de que los valores no se salgan del límite RGB (0-255)
                    nuevoR = Math.Clamp(nuevoR, 0, 255);
                    nuevoG = Math.Clamp(nuevoG, 0, 255);
                    nuevoB = Math.Clamp(nuevoB, 0, 255);

                    // 5. Asignamos el nuevo valor suavizado
                    Color nuevoPixel = Color.FromArgb(nuevoR, nuevoG, nuevoB);
                    imagenSuavizada.SetPixel(x, y, nuevoPixel);
                }
            }

            // 6. Mostramos el resultado
            pictureBox1.Image = imagenSuavizada;
            this.Text = "Suavizado Terminado"; // Restauramos el título

            // 7. DIÁLOGO DE AVISO AL TERMINAR
            MessageBox.Show("El proceso de suavizado ha terminado correctamente.",
                            "Proceso Completado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
    }
}