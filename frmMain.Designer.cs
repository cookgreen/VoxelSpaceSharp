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
            this.groupFile = new System.Windows.Forms.GroupBox();
            this.mapList = new System.Windows.Forms.ComboBox();
            this.groupRender = new System.Windows.Forms.GroupBox();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.grid = new System.Windows.Forms.TableLayoutPanel();
            this.groupFile.SuspendLayout();
            this.groupRender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.grid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDiffuseMap
            // 
            this.lbDiffuseMap.AutoSize = true;
            this.lbDiffuseMap.Location = new System.Drawing.Point(9, 23);
            this.lbDiffuseMap.Name = "lbDiffuseMap";
            this.lbDiffuseMap.Size = new System.Drawing.Size(29, 12);
            this.lbDiffuseMap.TabIndex = 0;
            this.lbDiffuseMap.Text = "Map:";
            // 
            // groupFile
            // 
            this.groupFile.Controls.Add(this.mapList);
            this.groupFile.Controls.Add(this.lbDiffuseMap);
            this.groupFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupFile.Location = new System.Drawing.Point(3, 3);
            this.groupFile.Name = "groupFile";
            this.groupFile.Size = new System.Drawing.Size(778, 54);
            this.groupFile.TabIndex = 6;
            this.groupFile.TabStop = false;
            this.groupFile.Text = "File";
            // 
            // mapList
            // 
            this.mapList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapList.FormattingEnabled = true;
            this.mapList.Location = new System.Drawing.Point(44, 20);
            this.mapList.Name = "mapList";
            this.mapList.Size = new System.Drawing.Size(157, 20);
            this.mapList.TabIndex = 1;
            this.mapList.SelectedIndexChanged += new System.EventHandler(this.mapList_SelectedIndexChanged);
            // 
            // groupRender
            // 
            this.groupRender.Controls.Add(this.canvas);
            this.groupRender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupRender.Location = new System.Drawing.Point(3, 63);
            this.groupRender.Name = "groupRender";
            this.groupRender.Size = new System.Drawing.Size(778, 496);
            this.groupRender.TabIndex = 7;
            this.groupRender.TabStop = false;
            this.groupRender.Text = "Viewport";
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(3, 17);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(772, 476);
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
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowCount = 2;
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.grid.Size = new System.Drawing.Size(784, 562);
            this.grid.TabIndex = 8;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbDiffuseMap;
        private System.Windows.Forms.GroupBox groupFile;
        private System.Windows.Forms.GroupBox groupRender;
        private System.Windows.Forms.TableLayoutPanel grid;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.ComboBox mapList;
    }
}

