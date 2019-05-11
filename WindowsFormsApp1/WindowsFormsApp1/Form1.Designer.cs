namespace WindowsFormsApp1
{
    partial class Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.ControlBar = new System.Windows.Forms.Panel();
            this.close_button = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ControlBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close_button)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlBar
            // 
            this.ControlBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ControlBar.BackColor = System.Drawing.Color.Goldenrod;
            this.ControlBar.Controls.Add(this.close_button);
            this.ControlBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ControlBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlBar.Location = new System.Drawing.Point(0, 0);
            this.ControlBar.Name = "ControlBar";
            this.ControlBar.Size = new System.Drawing.Size(268, 23);
            this.ControlBar.TabIndex = 0;
            this.ControlBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Window_MouseDown);
            this.ControlBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Window_MouseMove);
            this.ControlBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Window_MouseUp);
            // 
            // close_button
            // 
            this.close_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.close_button.Image = ((System.Drawing.Image)(resources.GetObject("close_button.Image")));
            this.close_button.Location = new System.Drawing.Point(248, 0);
            this.close_button.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(20, 23);
            this.close_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.close_button.TabIndex = 0;
            this.close_button.TabStop = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(268, 226);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.Khaki;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(262, 220);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(268, 249);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ControlBar);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Window";
            this.ShowIcon = false;
            this.ControlBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.close_button)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ControlBar;
        private System.Windows.Forms.PictureBox close_button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

