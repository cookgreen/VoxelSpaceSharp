namespace VoxelSpaceSharp
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbDiffuseMap = new System.Windows.Forms.Label();
            this.txtDiffuseMap = new System.Windows.Forms.TextBox();
            this.btnDiffuseOpen = new System.Windows.Forms.Button();
            this.lbHeightMap = new System.Windows.Forms.Label();
            this.txtHeightMap = new System.Windows.Forms.TextBox();
            this.btnHeightOpen = new System.Windows.Forms.Button();
            this.groupFile = new System.Windows.Forms.GroupBox();
            this.groupRender = new System.Windows.Forms.GroupBox();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.grid = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStartRender = new System.Windows.Forms.Button();
            this.groupFile.SuspendLayout();
            this.groupRender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.grid.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDiffuseMap
            // 
            this.lbDiffuseMap.AutoSize = true;
            this.lbDiffuseMap.Location = new System.Drawing.Point(9, 23);
            this.lbDiffuseMap.Name = "lbDiffuseMap";
            this.lbDiffuseMap.Size = new System.Drawing.Size(77, 12);
            this.lbDiffuseMap.TabIndex = 0;
            this.lbDiffuseMap.Text = "Diffuse Map:";
            // 
            // txtDiffuseMap
            // 
            this.txtDiffuseMap.Location = new System.Drawing.Point(92, 20);
            this.txtDiffuseMap.Name = "txtDiffuseMap";
            this.txtDiffuseMap.ReadOnly = true;
            this.txtDiffuseMap.Size = new System.Drawing.Size(675, 21);
            this.txtDiffuseMap.TabIndex = 1;
            // 
            // btnDiffuseOpen
            // 
            this.btnDiffuseOpen.Location = new System.Drawing.Point(783, 18);
            this.btnDiffuseOpen.Name = "btnDiffuseOpen";
            this.btnDiffuseOpen.Size = new System.Drawing.Size(75, 23);
            this.btnDiffuseOpen.TabIndex = 2;
            this.btnDiffuseOpen.Text = "Open";
            this.btnDiffuseOpen.UseVisualStyleBackColor = true;
            this.btnDiffuseOpen.Click += new System.EventHandler(this.btnDiffuseOpen_Click);
            // 
            // lbHeightMap
            // 
            this.lbHeightMap.AutoSize = true;
            this.lbHeightMap.Location = new System.Drawing.Point(9, 52);
            this.lbHeightMap.Name = "lbHeightMap";
            this.lbHeightMap.Size = new System.Drawing.Size(71, 12);
            this.lbHeightMap.TabIndex = 3;
            this.lbHeightMap.Text = "Height Map:";
            // 
            // txtHeightMap
            // 
            this.txtHeightMap.Location = new System.Drawing.Point(92, 49);
            this.txtHeightMap.Name = "txtHeightMap";
            this.txtHeightMap.ReadOnly = true;
            this.txtHeightMap.Size = new System.Drawing.Size(675, 21);
            this.txtHeightMap.TabIndex = 4;
            // 
            // btnHeightOpen
            // 
            this.btnHeightOpen.Location = new System.Drawing.Point(783, 47);
            this.btnHeightOpen.Name = "btnHeightOpen";
            this.btnHeightOpen.Size = new System.Drawing.Size(75, 23);
            this.btnHeightOpen.TabIndex = 5;
            this.btnHeightOpen.Text = "Open";
            this.btnHeightOpen.UseVisualStyleBackColor = true;
            this.btnHeightOpen.Click += new System.EventHandler(this.btnHeightOpen_Click);
            // 
            // groupFile
            // 
            this.groupFile.Controls.Add(this.btnDiffuseOpen);
            this.groupFile.Controls.Add(this.btnHeightOpen);
            this.groupFile.Controls.Add(this.lbDiffuseMap);
            this.groupFile.Controls.Add(this.txtHeightMap);
            this.groupFile.Controls.Add(this.txtDiffuseMap);
            this.groupFile.Controls.Add(this.lbHeightMap);
            this.groupFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupFile.Location = new System.Drawing.Point(3, 3);
            this.groupFile.Name = "groupFile";
            this.groupFile.Size = new System.Drawing.Size(867, 94);
            this.groupFile.TabIndex = 6;
            this.groupFile.TabStop = false;
            this.groupFile.Text = "File";
            // 
            // groupRender
            // 
            this.groupRender.Controls.Add(this.canvas);
            this.groupRender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupRender.Location = new System.Drawing.Point(3, 103);
            this.groupRender.Name = "groupRender";
            this.groupRender.Size = new System.Drawing.Size(867, 493);
            this.groupRender.TabIndex = 7;
            this.groupRender.TabStop = false;
            this.groupRender.Text = "Viewport";
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(3, 17);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(861, 473);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_paint);
            // 
            // grid
            // 
            this.grid.ColumnCount = 1;
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.grid.Controls.Add(this.groupFile, 0, 0);
            this.grid.Controls.Add(this.groupRender, 0, 1);
            this.grid.Controls.Add(this.panel1, 0, 2);
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowCount = 3;
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.grid.Size = new System.Drawing.Size(873, 699);
            this.grid.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStartRender);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 602);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 94);
            this.panel1.TabIndex = 8;
            // 
            // btnStartRender
            // 
            this.btnStartRender.Location = new System.Drawing.Point(706, 15);
            this.btnStartRender.Name = "btnStartRender";
            this.btnStartRender.Size = new System.Drawing.Size(152, 70);
            this.btnStartRender.TabIndex = 0;
            this.btnStartRender.Text = "Render";
            this.btnStartRender.UseVisualStyleBackColor = true;
            this.btnStartRender.Click += new System.EventHandler(this.btnStartRender_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 699);
            this.Controls.Add(this.grid);
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voxel Space Algorithm Demo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.groupFile.ResumeLayout(false);
            this.groupFile.PerformLayout();
            this.groupRender.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.grid.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbDiffuseMap;
        private System.Windows.Forms.TextBox txtDiffuseMap;
        private System.Windows.Forms.Button btnDiffuseOpen;
        private System.Windows.Forms.Label lbHeightMap;
        private System.Windows.Forms.TextBox txtHeightMap;
        private System.Windows.Forms.Button btnHeightOpen;
        private System.Windows.Forms.GroupBox groupFile;
        private System.Windows.Forms.GroupBox groupRender;
        private System.Windows.Forms.TableLayoutPanel grid;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStartRender;
    }
}

