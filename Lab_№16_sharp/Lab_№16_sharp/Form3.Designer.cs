namespace Lab__16_sharp
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Table1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Table1)).BeginInit();
            this.SuspendLayout();
            // 
            // Table1
            // 
            this.Table1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.Table1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Table1.Location = new System.Drawing.Point(0, 116);
            this.Table1.Name = "Table1";
            this.Table1.RowHeadersWidth = 51;
            this.Table1.RowTemplate.Height = 24;
            this.Table1.Size = new System.Drawing.Size(566, 334);
            this.Table1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(23, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Загрузить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Table1);
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.Text = "Вывод таблицы ";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Table1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Table1;
        private System.Windows.Forms.Button button1;
    }
}