namespace CV_Creator
{
    partial class Import
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.close = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.image_path = new System.Windows.Forms.TextBox();
            this.pick_picture = new System.Windows.Forms.Button();
            this.document_path = new System.Windows.Forms.TextBox();
            this.pick_file = new System.Windows.Forms.Button();
            this.imports = new System.Windows.Forms.Button();
            this.list_ico = new System.Windows.Forms.TextBox();
            this.pick_ico = new System.Windows.Forms.Button();
            this.imagesDialog = new System.Windows.Forms.OpenFileDialog();
            this.documentDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.0937F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.9063F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(619, 329);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.close);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(106, 323);
            this.panel1.TabIndex = 0;
            // 
            // close
            // 
            this.close.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.close.BackColor = System.Drawing.Color.Maroon;
            this.close.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.close.Location = new System.Drawing.Point(19, 9);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(69, 28);
            this.close.TabIndex = 9;
            this.close.Text = "Cancel";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Developer: Sunesis";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(115, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(501, 323);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.185629F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.image_path, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.pick_picture, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.document_path, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.pick_file, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.imports, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.list_ico, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.pick_ico, 2, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.23077F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.76923F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(501, 323);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 81);
            this.label1.TabIndex = 3;
            this.label1.Text = "Import Your Custom Format";
            // 
            // image_path
            // 
            this.image_path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.image_path.Location = new System.Drawing.Point(12, 84);
            this.image_path.Name = "image_path";
            this.image_path.Size = new System.Drawing.Size(328, 20);
            this.image_path.TabIndex = 4;
            // 
            // pick_picture
            // 
            this.pick_picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pick_picture.Location = new System.Drawing.Point(346, 84);
            this.pick_picture.Name = "pick_picture";
            this.pick_picture.Size = new System.Drawing.Size(152, 30);
            this.pick_picture.TabIndex = 5;
            this.pick_picture.Text = "Pick Picture";
            this.pick_picture.UseVisualStyleBackColor = true;
            this.pick_picture.Click += new System.EventHandler(this.pick_picture_Click);
            // 
            // document_path
            // 
            this.document_path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.document_path.Location = new System.Drawing.Point(12, 120);
            this.document_path.Name = "document_path";
            this.document_path.Size = new System.Drawing.Size(328, 20);
            this.document_path.TabIndex = 6;
            // 
            // pick_file
            // 
            this.pick_file.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pick_file.Location = new System.Drawing.Point(346, 120);
            this.pick_file.Name = "pick_file";
            this.pick_file.Size = new System.Drawing.Size(152, 25);
            this.pick_file.TabIndex = 7;
            this.pick_file.Text = "Pick File";
            this.pick_file.UseVisualStyleBackColor = true;
            this.pick_file.Click += new System.EventHandler(this.pick_file_Click);
            // 
            // imports
            // 
            this.imports.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imports.Location = new System.Drawing.Point(88, 238);
            this.imports.Name = "imports";
            this.imports.Size = new System.Drawing.Size(176, 28);
            this.imports.TabIndex = 8;
            this.imports.Text = "Import Template";
            this.imports.UseVisualStyleBackColor = true;
            this.imports.Click += new System.EventHandler(this.imports_Click);
            // 
            // list_ico
            // 
            this.list_ico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_ico.Location = new System.Drawing.Point(12, 151);
            this.list_ico.Name = "list_ico";
            this.list_ico.Size = new System.Drawing.Size(328, 20);
            this.list_ico.TabIndex = 9;
            // 
            // pick_ico
            // 
            this.pick_ico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pick_ico.Location = new System.Drawing.Point(346, 151);
            this.pick_ico.Name = "pick_ico";
            this.pick_ico.Size = new System.Drawing.Size(152, 27);
            this.pick_ico.TabIndex = 10;
            this.pick_ico.Text = "Pick List Preview";
            this.pick_ico.UseVisualStyleBackColor = true;
            this.pick_ico.Click += new System.EventHandler(this.pick_ico_Click);
            // 
            // imagesDialog
            // 
            this.imagesDialog.FileName = "openFileDialog1";
            // 
            // documentDialog
            // 
            this.documentDialog.FileName = "openFileDialog1";
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 329);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Import";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox image_path;
        private System.Windows.Forms.Button pick_picture;
        private System.Windows.Forms.TextBox document_path;
        private System.Windows.Forms.Button pick_file;
        private System.Windows.Forms.Button imports;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.OpenFileDialog imagesDialog;
        private System.Windows.Forms.TextBox list_ico;
        private System.Windows.Forms.Button pick_ico;
        private System.Windows.Forms.OpenFileDialog documentDialog;
    }
}