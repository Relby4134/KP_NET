﻿namespace KP_NET
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button_go = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            groupBox2 = new GroupBox();
            label8 = new Label();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            label6 = new Label();
            button_get_gamgr = new Button();
            button_clear = new Button();
            listBox1 = new ListBox();
            button_show_graph = new Button();
            label_error = new Label();
            matrix = new DataGridView();
            label4 = new Label();
            label5 = new Label();
            button_creatematrix = new Button();
            textBox_numb = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)matrix).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 35.9999962F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(167, 71);
            label1.Name = "label1";
            label1.Size = new Size(404, 55);
            label1.TabIndex = 0;
            label1.Text = "Курсовой проект";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Console", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(38, 162);
            label2.Name = "label2";
            label2.Size = new Size(614, 38);
            label2.TabIndex = 1;
            label2.Text = "на тему: Программная реализация метода построения \r\n         гамильтоновых циклов в неориентированном графе";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Console", 14.25F);
            label3.Location = new Point(38, 226);
            label3.Name = "label3";
            label3.Size = new Size(295, 38);
            label3.TabIndex = 2;
            label3.Text = "Выполнил: студент бИСТ-233\r\n      Кудинова А. Ю.";
            // 
            // button_go
            // 
            button_go.Location = new Point(332, 299);
            button_go.Name = "button_go";
            button_go.Size = new Size(111, 49);
            button_go.TabIndex = 3;
            button_go.Text = "Начать";
            button_go.UseVisualStyleBackColor = true;
            button_go.Click += button_go_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, -11);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(739, 424);
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(button_go);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label3);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(731, 396);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(731, 396);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Location = new Point(363, 14);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(362, 380);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Граф";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Red;
            label8.Location = new Point(15, 19);
            label8.Name = "label8";
            label8.Size = new Size(0, 15);
            label8.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(4, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(352, 352);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(button_get_gamgr);
            groupBox1.Controls.Add(button_clear);
            groupBox1.Controls.Add(listBox1);
            groupBox1.Controls.Add(button_show_graph);
            groupBox1.Controls.Add(label_error);
            groupBox1.Controls.Add(matrix);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(button_creatematrix);
            groupBox1.Controls.Add(textBox_numb);
            groupBox1.Location = new Point(8, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(344, 380);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Создание графа";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(355, 229);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 13;
            label6.Text = "label6";
            // 
            // button_get_gamgr
            // 
            button_get_gamgr.Location = new Point(6, 246);
            button_get_gamgr.Name = "button_get_gamgr";
            button_get_gamgr.Size = new Size(75, 41);
            button_get_gamgr.TabIndex = 12;
            button_get_gamgr.Text = "Расчитать циклы";
            button_get_gamgr.UseVisualStyleBackColor = true;
            button_get_gamgr.Click += button_get_gamgr_Click;
            // 
            // button_clear
            // 
            button_clear.Location = new Point(6, 331);
            button_clear.Name = "button_clear";
            button_clear.Size = new Size(75, 39);
            button_clear.TabIndex = 11;
            button_clear.Text = "Очистить\r\n все";
            button_clear.UseVisualStyleBackColor = true;
            button_clear.Click += button_clear_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(87, 246);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(257, 124);
            listBox1.TabIndex = 9;
            listBox1.SelectedIndexChanged += ListBoxCycles_DoubleClick;
            // 
            // button_show_graph
            // 
            button_show_graph.Location = new Point(200, 69);
            button_show_graph.Name = "button_show_graph";
            button_show_graph.Size = new Size(121, 23);
            button_show_graph.TabIndex = 7;
            button_show_graph.Text = "Нарисовать граф";
            button_show_graph.UseVisualStyleBackColor = true;
            button_show_graph.Click += button_show_graph_Click;
            // 
            // label_error
            // 
            label_error.AutoSize = true;
            label_error.ForeColor = Color.Red;
            label_error.Location = new Point(15, 19);
            label_error.Name = "label_error";
            label_error.Size = new Size(0, 15);
            label_error.TabIndex = 6;
            // 
            // matrix
            // 
            matrix.AllowUserToAddRows = false;
            matrix.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            matrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            matrix.Location = new Point(15, 98);
            matrix.Name = "matrix";
            matrix.Size = new Size(306, 133);
            matrix.TabIndex = 5;
            matrix.CellValueChanged += matrix_CellValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 69);
            label4.Name = "label4";
            label4.Size = new Size(184, 15);
            label4.TabIndex = 4;
            label4.Text = "Заполните матрицу смежности:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 34);
            label5.Name = "label5";
            label5.Size = new Size(167, 30);
            label5.TabIndex = 1;
            label5.Text = "Введите количество вершин:\r\n(2<=N)";
            // 
            // button_creatematrix
            // 
            button_creatematrix.Location = new Point(228, 20);
            button_creatematrix.Name = "button_creatematrix";
            button_creatematrix.Size = new Size(107, 42);
            button_creatematrix.TabIndex = 3;
            button_creatematrix.Text = "Создать матрицу";
            button_creatematrix.UseVisualStyleBackColor = true;
            button_creatematrix.Click += button_creatematrix_Click;
            // 
            // textBox_numb
            // 
            textBox_numb.Location = new Point(180, 35);
            textBox_numb.Name = "textBox_numb";
            textBox_numb.Size = new Size(42, 23);
            textBox_numb.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 412);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Алгоритм поиска гамельтоновых путей в неориентированном графе";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)matrix).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button button_go;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBox_numb;
        private Label label5;
        private GroupBox groupBox1;
        private DataGridView matrix;
        private Label label4;
        private Button button_creatematrix;
        private Label label_error;
        private Button button_show_graph;
        private ListBox listBox1;
        private PictureBox pictureBox1;
        private Button button_get_gamgr;
        private Button button_clear;
        private Label label6;
        private GroupBox groupBox2;
        private Label label8;
    }
}
