using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System;
using System.IO;
using System.Reflection;


namespace KP_NET
{
    public partial class Form1 : Form
    {
        public List<Point> vertices = new List<Point>(); // Координаты вершин
        public Form1()
        {
            InitializeComponent();
            
        }


        int size_m;
        private void button_creatematrix_Click(object sender, EventArgs e)
        {
            matrix.Columns.Clear();
            matrix.Rows.Clear();

            if ((!int.TryParse(textBox_numb.Text, out _)) || (textBox_numb.Text == " ") || (int.Parse(textBox_numb.Text) < 2))
            {
                textBox_numb.BackColor = Color.Red;
                label_error.Text = "Ошибка ввода количества вершин! ";
            }
            else
            {
                size_m = int.Parse(textBox_numb.Text);
                label_error.Text = "";
                textBox_numb.BackColor = Color.Green;
            }
            matrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int i = 0; i < size_m; i++)
            {
                matrix.Columns.Add("Col" + i, (i + 1).ToString());
            }
            matrix.Rows.Add(size_m);
            for (int i = 0; i < size_m; i++)
            {

                matrix.Rows[i].HeaderCell.Value = (i + 1).ToString();

            }


            for (int i = 0; i < size_m; i++)
            {
                for (int j = 0; j < size_m; j++)
                {
                    if (i == j)
                    {
                        matrix.Rows[i].Cells[j].Value = 0;
                    }
                }
            }




        }
        bool flag= false;
        private void DrawGraph(int[,] matrix)
        {
            int vertexCount = matrix.GetLength(0);
            int radius = 100;
            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;

            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                Pen pen = new Pen(Color.Black);
                Brush brush = new SolidBrush(Color.Blue);

                Point[] points = new Point[vertexCount];
                double angleStep = 2 * Math.PI / vertexCount;

                for (int i = 0; i < vertexCount; i++)
                {
                    double angle = angleStep * i;
                    int x = (int)(centerX + radius * Math.Cos(angle));
                    int y = (int)(centerY + radius * Math.Sin(angle));
                    points[i] = new Point(x, y);
                }

                for (int i = 0; i < vertexCount; i++)
                {
                    for (int j = i + 1; j < vertexCount; j++)
                    {
                        if (matrix[i, j] == 1)
                        {
                            g.DrawLine(pen, points[i], points[j]);
                        }

                    }
                }


                for (int i = 0; i < vertexCount; i++)
                {
                    g.FillEllipse(brush, points[i].X - 10, points[i].Y - 10, 20, 20);

                    g.DrawString((i + 1).ToString(), new Font("Arial", 10), Brushes.White, points[i].X - 5, points[i].Y - 5);
                }
            }

            pictureBox1.Image = bitmap;
        }


        int[,] graph;
        private void button_show_graph_Click(object sender, EventArgs e)
        {

            int rows = matrix.Rows.Count;
            int cols = matrix.Columns.Count;
            int[,] graf = new int[rows, cols];


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {

                    var cellValue = matrix.Rows[i].Cells[j].Value;

                    if (cellValue != null && (cellValue.ToString() == "0" || cellValue.ToString() == "1"))
                    {

                        graf[i, j] = Convert.ToInt32(cellValue);
                    }
                    else
                    {

                        MessageBox.Show($"Ячейка ({i}, {j}) имеет недопустимое значение: {cellValue}.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

            }

            graph = graf;
            DrawGraph(graf);

        }


        static bool isSafe(int v, int[,] graph, List<int> path, int pos)
        {
            if (graph[path[pos - 1], v] == 0)
                return false;

            for (int i = 0; i < pos; i++)
                if (path[i] == v)
                    return false;

            return true;
        }
        string inp = "";
        public void FindHamCycle(int[,] graph, int pos, List<int> path, bool[] visited)
        {
            string item = "";
            if (pos == graph.GetLength(0))
            {


                if (graph[path[path.Count - 1], path[0]] != 0)
                {


                    path.Add(0);
                    for (int i = 0; i < path.Count; i++)
                    {
                        item += (path[i] + 1).ToString() + "->";

                    }
                    inp = item.Substring(0, item.Length - 2);
                    listBox1.Items.Add(inp);

                    path.RemoveAt(path.Count - 1);

                    hasCycle = true;
                }
                return;
            }


            for (int v = 0; v < graph.GetLength(0); v++)
            {

                if (isSafe(v, graph, path, pos) && !visited[v])
                {

                    path.Add(v);
                    visited[v] = true;

                    FindHamCycle(graph, pos + 1, path, visited);

                    visited[v] = false;
                    path.RemoveAt(path.Count - 1);
                }
            }
        }

        static bool hasCycle;
        List<int> path = new List<int>();
        public void hamCycle(int[,] graph)
        {
            hasCycle = false;
            path.Add(0);
            bool[] visited = new bool[graph.GetLength(0)];

            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;

            visited[0] = true;

            FindHamCycle(graph, 1, path, visited);

            if (!hasCycle)
            {
                listBox1.Items.Add("В данном графе НЕТ гамельтоновых циклов!");
                return;
            }
        }

        private void button_get_gamgr_Click(object sender, EventArgs e)
        {
            hamCycle(graph);
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            path.Clear();
            graph = null;
            matrix.Columns.Clear();
            matrix.Rows.Clear();
            textBox_numb.Clear();

        }
        public void DrawCycle(List<int> cycle)
        {
            int vertexCount = cycle.Count;
            int radius = 100;
            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;

            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                Pen pen = new Pen(Color.Black);
                Brush brush = new SolidBrush(Color.Blue);

                Point[] points = new Point[vertexCount];
                double angleStep = 2 * Math.PI / vertexCount;

                for (int i = 0; i < vertexCount; i++)
                {
                    double angle = angleStep * i;
                    int x = (int)(centerX + radius * Math.Cos(angle));
                    int y = (int)(centerY + radius * Math.Sin(angle));
                    points[i] = new Point(x, y);
                }


                // Рисуем рёбра
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    for (int j = i + 1; j < graph.GetLength(0); j++)
                    {
                        if (graph[i, j] == 1)
                        {
                            // Проверяем, является ли это ребро частью выбранного цикла
                            if (cycle.Contains(i) && cycle.Contains(j))
                            {
                                // Выделяем рёбра красным цветом, если они входят в цикл
                                g.DrawLine(new Pen(Color.Red, 2), points[i], points[j]);
                            }
                            //else
                            //{
                            //    g.DrawLine(pen, points[i], points[j]);
                            //}
                        }
                    }
                }

                // Рисуем вершины
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    g.FillEllipse(brush, points[i].X - 10, points[i].Y - 10, 20, 20);
                    g.DrawString((i+1).ToString(), new Font("Arial", 10), Brushes.White, points[i].X - 5, points[i].Y - 5);
                }
            }

            pictureBox1.Image = bitmap;
        }

        private void ListBoxCycles_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                // Получаем выбранный элемент
                string select = listBox1.SelectedItem.ToString();
                //string selectedCycle = select.Substring(0, select.Length - 3);
                //label6.Text=selectedCycle;
                string[] indices = select.Split("->");
                
                List<int> cycle = new List<int>();
                foreach (var index in indices)
                {
                    cycle.Add(int.Parse(index)-1);
                    // Преобразуем строки в числа (уменьшаем на 1 для нулевой индексации)
                }
                for (int i = 0; i < cycle.Count; i++) {
                    label6.Text += cycle[i] + "\n";
                }

                // Вызываем метод для рисования выбранного цикла
                DrawCycle(cycle);
            }
        }




    }

}
