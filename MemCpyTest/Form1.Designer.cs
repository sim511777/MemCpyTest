namespace MemCpyTest {
    partial class Form1 {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            this.lbxLog = new System.Windows.Forms.ListBox();
            this.numMegabyte = new System.Windows.Forms.NumericUpDown();
            this.btnAlloc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.lbxMemcpyType = new System.Windows.Forms.ListBox();
            this.btnMemetRandom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMegabyte)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxLog
            // 
            this.lbxLog.FormattingEnabled = true;
            this.lbxLog.ItemHeight = 12;
            this.lbxLog.Location = new System.Drawing.Point(214, 41);
            this.lbxLog.Name = "lbxLog";
            this.lbxLog.Size = new System.Drawing.Size(574, 544);
            this.lbxLog.TabIndex = 0;
            // 
            // numMegabyte
            // 
            this.numMegabyte.Location = new System.Drawing.Point(12, 12);
            this.numMegabyte.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMegabyte.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMegabyte.Name = "numMegabyte";
            this.numMegabyte.Size = new System.Drawing.Size(104, 21);
            this.numMegabyte.TabIndex = 4;
            this.numMegabyte.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // btnAlloc
            // 
            this.btnAlloc.Location = new System.Drawing.Point(152, 12);
            this.btnAlloc.Name = "btnAlloc";
            this.btnAlloc.Size = new System.Drawing.Size(74, 23);
            this.btnAlloc.TabIndex = 5;
            this.btnAlloc.Text = "Alloc";
            this.btnAlloc.UseVisualStyleBackColor = true;
            this.btnAlloc.Click += new System.EventHandler(this.btnAlloc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "MB";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(713, 6);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 7;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // lbxMemcpyType
            // 
            this.lbxMemcpyType.DisplayMember = "Item1";
            this.lbxMemcpyType.FormattingEnabled = true;
            this.lbxMemcpyType.ItemHeight = 12;
            this.lbxMemcpyType.Location = new System.Drawing.Point(12, 41);
            this.lbxMemcpyType.Name = "lbxMemcpyType";
            this.lbxMemcpyType.Size = new System.Drawing.Size(196, 544);
            this.lbxMemcpyType.TabIndex = 8;
            this.lbxMemcpyType.ValueMember = "Item2";
            this.lbxMemcpyType.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxMemcpyType_MouseDoubleClick);
            // 
            // btnMemetRandom
            // 
            this.btnMemetRandom.Location = new System.Drawing.Point(232, 12);
            this.btnMemetRandom.Name = "btnMemetRandom";
            this.btnMemetRandom.Size = new System.Drawing.Size(115, 23);
            this.btnMemetRandom.TabIndex = 9;
            this.btnMemetRandom.Text = "memset random";
            this.btnMemetRandom.UseVisualStyleBackColor = true;
            this.btnMemetRandom.Click += new System.EventHandler(this.btnMemetRandom_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 599);
            this.Controls.Add(this.btnMemetRandom);
            this.Controls.Add(this.lbxMemcpyType);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAlloc);
            this.Controls.Add(this.numMegabyte);
            this.Controls.Add(this.lbxLog);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numMegabyte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxLog;
        private System.Windows.Forms.NumericUpDown numMegabyte;
        private System.Windows.Forms.Button btnAlloc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.ListBox lbxMemcpyType;
        private System.Windows.Forms.Button btnMemetRandom;
    }
}

