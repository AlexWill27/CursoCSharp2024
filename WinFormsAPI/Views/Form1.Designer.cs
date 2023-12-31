namespace WinFormsAPI
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
            button1 = new Button();
            dataGridView1 = new DataGridView();
            ResultCount = new DataGridViewTextBoxColumn();
            PageCount = new DataGridViewTextBoxColumn();
            PageNbr = new DataGridViewTextBoxColumn();
            NextPage = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(461, 355);
            button1.Name = "button1";
            button1.Size = new Size(183, 50);
            button1.TabIndex = 0;
            button1.Text = "Obtener";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ResultCount, PageCount, PageNbr, NextPage });
            dataGridView1.Location = new Point(67, 40);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(526, 254);
            dataGridView1.TabIndex = 1;
            // 
            // ResultCount
            // 
            ResultCount.HeaderText = "ResultCount";
            ResultCount.MinimumWidth = 6;
            ResultCount.Name = "ResultCount";
            ResultCount.ReadOnly = true;
            ResultCount.Width = 125;
            // 
            // PageCount
            // 
            PageCount.HeaderText = "PageCount";
            PageCount.MinimumWidth = 6;
            PageCount.Name = "PageCount";
            PageCount.ReadOnly = true;
            PageCount.Width = 125;
            // 
            // PageNbr
            // 
            PageNbr.HeaderText = "PageNbr";
            PageNbr.MinimumWidth = 6;
            PageNbr.Name = "PageNbr";
            PageNbr.ReadOnly = true;
            PageNbr.Width = 125;
            // 
            // NextPage
            // 
            NextPage.HeaderText = "NextPage";
            NextPage.MinimumWidth = 6;
            NextPage.Name = "NextPage";
            NextPage.ReadOnly = true;
            NextPage.Width = 125;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ResultCount;
        private DataGridViewTextBoxColumn PageCount;
        private DataGridViewTextBoxColumn PageNbr;
        private DataGridViewTextBoxColumn NextPage;
    }
}