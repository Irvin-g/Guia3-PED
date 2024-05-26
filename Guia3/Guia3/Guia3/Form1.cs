using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Guia3
{
    public partial class Form1 : Form
    {
        private List<Nodo> nodos = new List<Nodo>();
        private List<Arco> arcos = new List<Arco>();
        private int nodoId = 0;
        private Nodo nodoSeleccionado = null;

        public Form1()
        {
            InitializeComponent();
            // Conectar eventos manualmente
            this.btnAgregarNodo.Click += new EventHandler(this.btnAgregarNodo_Click);
            this.btnAgregarArco.Click += new EventHandler(this.btnAgregarArco_Click);
            this.btnEjecutarDijkstra.Click += new EventHandler(this.btnEjecutarDijkstra_Click);
            this.btnLimpiar.Click += new EventHandler(this.btnLimpiar_Click);
            this.panelDibujo.Paint += new PaintEventHandler(this.panelDibujo_Paint);
            this.btnCalcularRuta.Click += new EventHandler(this.btnCalcularRuta_Click); // Conectar el evento del botón de calcular ruta
        }

        private void btnAgregarNodo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Haz clic en el panel para agregar un nodo");
            panelDibujo.MouseClick += PanelDibujo_MouseClick;
        }

        private void PanelDibujo_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show($"Se agregó un nodo en ({e.Location.X}, {e.Location.Y})");
            nodos.Add(new Nodo(nodoId++, e.Location));
            panelDibujo.Invalidate();
            panelDibujo.MouseClick -= PanelDibujo_MouseClick;
        }

        private void btnAgregarArco_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecciona dos nodos para agregar un arco");
            panelDibujo.MouseClick += SeleccionarNodoParaArco;
        }

        private void SeleccionarNodoParaArco(object sender, MouseEventArgs e)
        {
            var nodo = nodos.FirstOrDefault(n => EsNodoSeleccionado(n, e.Location));
            if (nodo != null)
            {
                if (nodoSeleccionado == null)
                {
                    nodoSeleccionado = nodo;
                    MessageBox.Show($"Nodo {nodo.Id} seleccionado. Ahora selecciona el nodo de destino.");
                }
                else
                {
                    int peso = PromptForPeso();
                    if (peso > 0)
                    {
                        arcos.Add(new Arco(nodoSeleccionado, nodo, peso));
                        MessageBox.Show($"Arco agregado desde {nodoSeleccionado.Id} hasta {nodo.Id} con peso {peso}");
                        nodoSeleccionado = null;
                        panelDibujo.Invalidate();
                        panelDibujo.MouseClick -= SeleccionarNodoParaArco;
                    }
                }
            }
        }

        private bool EsNodoSeleccionado(Nodo nodo, Point punto)
        {
            int radio = 10;
            return Math.Sqrt(Math.Pow(nodo.Posicion.X - punto.X, 2) + Math.Pow(nodo.Posicion.Y - punto.Y, 2)) <= radio;
        }

        private void btnEjecutarDijkstra_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNodoInicial.Text, out int nodoInicial) && nodoInicial >= 0 && nodoInicial < nodos.Count)
            {
                MessageBox.Show($"Ejecutando Dijkstra desde el nodo {nodoInicial}");
                var algoritmo = new AlgoritmoDijkstra(nodos, arcos);
                algoritmo.Ejecutar(nodoInicial);

                var distancias = algoritmo.ObtenerDistancias();
                MostrarDistancias(distancias);
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un nodo inicial válido.");
            }
        }

        private void MostrarDistancias(int[] distancias)
        {
            lstResultados.Items.Clear();
            for (int i = 0; i < distancias.Length; i++)
            {
                lstResultados.Items.Add($"Distancia al nodo {i}: {distancias[i]}");
            }
            MessageBox.Show("Distancias calculadas y mostradas.");
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (var nodo in nodos)
            {
                g.FillEllipse(Brushes.Blue, nodo.Posicion.X - 5, nodo.Posicion.Y - 5, 10, 10);
                g.DrawString(nodo.Id.ToString(), DefaultFont, Brushes.White, nodo.Posicion);
            }

            foreach (var arco in arcos)
            {
                g.DrawLine(Pens.Black, arco.Origen.Posicion, arco.Destino.Posicion);
                var puntoMedio = new Point((arco.Origen.Posicion.X + arco.Destino.Posicion.X) / 2, (arco.Origen.Posicion.Y + arco.Destino.Posicion.Y) / 2);
                g.DrawString(arco.Peso.ToString(), DefaultFont, Brushes.Red, puntoMedio);
            }
        }

        private int PromptForPeso()
        {
            using (var form = new Form())
            {
                var lbl = new Label() { Left = 50, Top = 20, Text = "Peso del arco:" };
                var txt = new TextBox() { Left = 50, Top = 50, Width = 200 };
                var btnOk = new Button() { Text = "OK", Left = 150, Width = 100, Top = 80, DialogResult = DialogResult.OK };

                form.Controls.Add(lbl);
                form.Controls.Add(txt);
                form.Controls.Add(btnOk);
                form.AcceptButton = btnOk;

                if (form.ShowDialog() == DialogResult.OK && int.TryParse(txt.Text, out int peso))
                {
                    return peso;
                }
                else
                {
                    MessageBox.Show("Por favor, ingresa un peso válido.");
                    return 0;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar nodos y arcos
            nodos.Clear();
            arcos.Clear();
            nodoId = 0;
            nodoSeleccionado = null;

            // Limpiar cuadro de texto
            txtNodoInicial.Text = string.Empty;

            // Limpiar ListBox
            lstResultados.Items.Clear();

            // Limpiar el panel de dibujo
            panelDibujo.Invalidate();
        }

        private void btnCalcularRuta_Click(object sender, EventArgs e)
        {
            if (lstResultados.Items.Count == 0)
            {
                MessageBox.Show("No hay distancias calculadas.");
                return;
            }

            int menorDistancia = int.MaxValue;

            foreach (var item in lstResultados.Items)
            {
                string[] partes = item.ToString().Split(':');
                if (partes.Length == 2 && int.TryParse(partes[1].Trim(), out int distancia) && distancia > 0)
                {
                    if (distancia < menorDistancia)
                    {
                        menorDistancia = distancia;
                    }
                }
            }

            if (menorDistancia == int.MaxValue)
            {
                MessageBox.Show("No se encontraron distancias ");
            }
            else
            {
                MessageBox.Show($"La menor distancia mas corta es: {menorDistancia}");
            }
        }
    }

    public class Nodo
    {
        public int Id { get; set; }
        public Point Posicion { get; set; }

        public Nodo(int id, Point posicion)
        {
            Id = id;
            Posicion = posicion;
        }
    }

    public class Arco
    {
        public Nodo Origen { get; set; }
        public Nodo Destino { get; set; }
        public int Peso { get; set; }

        public Arco(Nodo origen, Nodo destino, int peso)
        {
            Origen = origen;
            Destino = destino;
            Peso = peso;
        }
    }

    public class AlgoritmoDijkstra
    {
        private List<Nodo> nodos;
        private List<Arco> arcos;
        private int[] distancias;
        private int[] predecesores;

        public AlgoritmoDijkstra(List<Nodo> nodos, List<Arco> arcos)
        {
            this.nodos = nodos;
            this.arcos = arcos;
            distancias = new int[nodos.Count];
            predecesores = new int[nodos.Count];
        }

        public void Ejecutar(int nodoInicial)
        {
            for (int i = 0; i < nodos.Count; i++)
            {
                distancias[i] = int.MaxValue;
                predecesores[i] = -1;
            }
            distancias[nodoInicial] = 0;

            var colaPrioridad = new SortedSet<Tuple<int, int>>(Comparer<Tuple<int, int>>.Create((x, y) => x.Item2 == y.Item2 ? x.Item1.CompareTo(y.Item1) : x.Item2.CompareTo(y.Item2)));
            colaPrioridad.Add(Tuple.Create(nodoInicial, 0));

            while (colaPrioridad.Any())
            {
                var (nodoActual, distanciaActual) = colaPrioridad.Min;
                colaPrioridad.Remove(colaPrioridad.Min);

                foreach (var arco in arcos.Where(a => a.Origen.Id == nodoActual))
                {
                    int nuevoCosto = distanciaActual + arco.Peso;
                    if (nuevoCosto < distancias[arco.Destino.Id])
                    {
                        colaPrioridad.Remove(Tuple.Create(arco.Destino.Id, distancias[arco.Destino.Id]));
                        distancias[arco.Destino.Id] = nuevoCosto;
                        predecesores[arco.Destino.Id] = nodoActual;
                        colaPrioridad.Add(Tuple.Create(arco.Destino.Id, nuevoCosto));
                    }
                }
            }
        }

        public int[] ObtenerDistancias() => distancias;
    }
}
