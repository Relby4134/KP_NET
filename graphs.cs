using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KP_NET
{
    public interface IGraph
    {
        // Метод для установки матрицы смежности
        void SetMatrix(int[,] matrix);

        // Метод для получения копии матрицы смежности
        int[,]? GetMatrix();
    }


    public class graphs : IGraph
    {
        private int[,]? adjacency_matrix_;

        public graphs() 
        {
            adjacency_matrix_ = new int[0, 0];
        }
        public graphs(int[,] adjacency_matrix)
        {
            if (adjacency_matrix != null)
            {
                int rows = adjacency_matrix.GetLength(0);
                int cols = adjacency_matrix.GetLength(1);
                adjacency_matrix_ = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        adjacency_matrix_[i, j] = adjacency_matrix[i, j];
                    }
                }
            }
            else
            {
                adjacency_matrix_ = new int[0, 0];
            }
        }


        public int[,] GetMatrix()
        {
            if(adjacency_matrix_ == null)
            {
                return null;
            }
            int rows = adjacency_matrix_.GetLength(0);
            int cols = adjacency_matrix_.GetLength(1);

            int[,] copyMatrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    copyMatrix[i, j] = adjacency_matrix_[i, j];
                }
            }

            return copyMatrix;
        }

        public void SetMatrix(int[,] matrix)
        {
            if (matrix == null)
            {
                return;
            }
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            adjacency_matrix_ = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    adjacency_matrix_[i, j] = matrix[i, j];
                }
            }
        }
    }

    public static class GraphMethods
    {
        public static void DrawGraph(graphs graphs, Color color, PictureBox picture)
        {
            int[,] matrix = graphs.GetMatrix();
            int vertexCount = matrix.GetLength(0);
            int radius = 100;
            int centerX = picture.Width / 2;
            int centerY = picture.Height / 2;

            Bitmap bitmap = new Bitmap(picture.Width, picture.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                Pen pen = new Pen(color);
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

            picture.Image = bitmap;
        }
    }
}
