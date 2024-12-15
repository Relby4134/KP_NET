using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;


namespace KP_NET
{
    public partial class Form1 : Form
    {
        public List<Point> vertices = new List<Point>(); // Координаты вершин
        public Form1()
        {
            InitializeComponent();
            this.tabControl1.ItemSize = new System.Drawing.Size(1, 1);
            button_get_gamgr.Visible = false;
            listBox1.Visible = false;
        }
        void openTab(int tabIndex)
        {
            tabControl1.SelectedIndex = tabIndex;
        }

        int size_m;
        bool count_flag = false;
        private void button_creatematrix_Click(object sender, EventArgs e)
        {
            matrix.Columns.Clear();
            matrix.Rows.Clear();

            if ((!int.TryParse(textBox_numb.Text, out _)) || (textBox_numb.Text == " ") || (int.Parse(textBox_numb.Text) < 2))
            {
                textBox_numb.BackColor = Color.Red;
                count_flag = false;
                label_error.Text = "Ошибка ввода количества вершин! ";
                return;
            }
            else
            {
                size_m = int.Parse(textBox_numb.Text);
                label_error.Text = "";
                textBox_numb.BackColor = Color.Green;
                count_flag = true;
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

            foreach (DataGridViewColumn column in matrix.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }
        

        


        int[,] graph;
        private void button_show_graph_Click(object sender, EventArgs e)
        {
            MatrixChange(matrix, e);

            if (!count_flag)
            {
                MessageBox.Show("Вы не можете создать граф, пока не создадите матрицу смежности!");
                return;
            }
            

            textBox_numb.BackColor = Color.White;
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

                        MessageBox.Show($"Ячейка ({i + 1}, {j + 1}) имеет недопустимое значение!\n Допустимые значение: 0 и 1.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

            }
            button_get_gamgr.Visible = true;
            graphs graphs = new graphs(graf);
            graph = graf;
            GraphMethods.DrawGraph(graphs, Color.Black, pictureBox1);

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
        List<int>? path;
        public void hamCycle(int[,] graph)
        {
            List<int> path = new List<int>();
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
            bool hasEmptyCells = matrix.Rows.Cast<DataGridViewRow>().Any(row => row.Cells.Cast<DataGridViewCell>().Any(cell => cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString())));

            if (hasEmptyCells)
            {
                MessageBox.Show("В таблице есть пустые ячейки.");
            }
            else
            {
                listBox1.Items.Clear();
                listBox1.Visible = true;
                hamCycle(graph);
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            graph = null;
            matrix.Columns.Clear();
            matrix.Rows.Clear();
            textBox_numb.Clear();
            pictureBox1.Image = null;
            textBox_numb.BackColor = Color.White;
            button_get_gamgr.Visible = false;
            listBox1.Visible = false;
            count_flag = false;
            
            size_m=0;

        }

        public static bool ValidateListBoxFormat(ListBox listBox)
        {
            // Регулярное выражение для проверки формата "цифры -> цифры"
            string pattern = @"^\d+(\s*->\s*\d+)+$";

            foreach (var item in listBox.Items)
            {
                // Приводим элемент к строке и проверяем регулярным выражением
                string text = item.ToString();
                if (!Regex.IsMatch(text, pattern))
                {
                    return false;
                }
            }

            return true;
        }

        private void ListBoxCycles_DoubleClick(object sender, EventArgs e)
        {

            if ((listBox1.SelectedItem != null)&&(ValidateListBoxFormat(listBox1)))
            {
                string? select = listBox1.SelectedItem.ToString();
                string[]? indices = select.Split("->");

                List<int> cycle = new List<int>();
                foreach (var index in indices)
                {
                    cycle.Add(int.Parse(index) - 1);
                }

                int[,]? matrix = new int[size_m, size_m];
                string? test = "";
                for (int i = 0; i < size_m; i++)
                {
                    matrix[i, i] = 0;
                    int x = cycle[i];
                    int y = cycle[i + 1];
                    matrix[x, y] = 1;
                    matrix[y, x] = 1;
                    test += matrix[x, y] + " " + matrix[y, x] + '\n';
                }
                matrix[size_m - 1, size_m - 1] = 0;

                graphs graphs = new graphs(matrix);
                GraphMethods.DrawGraph(graphs, Color.Red, pictureBox1);
            } 

        }

        private void button_go_Click(object sender, EventArgs e)
        {
            openTab(1);
        }


        private void MatrixChange(object sender, EventArgs e)
        {
            matrix.ClearSelection();
            for (int i = 0; i < size_m; i++)
            {
                matrix.Rows[i].Cells[i].Value = 0;
            }
        }

        private void matrix_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < size_m; i++)
            {
                for (int j = 0; j < size_m; j++)
                {

                    matrix.Rows[j].Cells[i].Value = matrix.Rows[i].Cells[j].Value;
                }

            }
        }

    }

}
