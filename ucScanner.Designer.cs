namespace VTools
{
    partial class ucScanner
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucScanner));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.baudsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baudbox = new System.Windows.Forms.ToolStripTextBox();
            this.dataBitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBitsBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.delayTimeMsg = new System.Windows.Forms.ToolStripMenuItem();
            this.delayTimeMsgBox = new System.Windows.Forms.ToolStripTextBox();
            this.maxLengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxlengthBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.delayTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delayTimeFileBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.open = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.close = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.flushBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.comBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.status = new System.Windows.Forms.ToolStripLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripSeparator4,
            this.open,
            this.toolStripSeparator2,
            this.close,
            this.toolStripSeparator1,
            this.flushBtn,
            this.toolStripSeparator6,
            this.toolStripLabel1,
            this.comBox,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.toolStripSeparator8,
            this.status});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1010, 57);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baudsToolStripMenuItem,
            this.dataBitsToolStripMenuItem,
            this.toolStripSeparator7,
            this.delayTimeMsg,
            this.maxLengthToolStripMenuItem,
            this.toolStripSeparator5,
            this.delayTimeToolStripMenuItem});
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(69, 54);
            this.toolStripLabel2.Text = "MENU";
            // 
            // baudsToolStripMenuItem
            // 
            this.baudsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baudbox});
            this.baudsToolStripMenuItem.Name = "baudsToolStripMenuItem";
            this.baudsToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.baudsToolStripMenuItem.Text = "Bauds";
            // 
            // baudbox
            // 
            this.baudbox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baudbox.Name = "baudbox";
            this.baudbox.Size = new System.Drawing.Size(152, 33);
            this.baudbox.Text = "9600";
            this.baudbox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.baudbox.TextChanged += new System.EventHandler(this.parameterBoxTextChanged);
            // 
            // dataBitsToolStripMenuItem
            // 
            this.dataBitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataBitsBox});
            this.dataBitsToolStripMenuItem.Name = "dataBitsToolStripMenuItem";
            this.dataBitsToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.dataBitsToolStripMenuItem.Text = "Data Bits";
            // 
            // dataBitsBox
            // 
            this.dataBitsBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.dataBitsBox.Name = "dataBitsBox";
            this.dataBitsBox.Size = new System.Drawing.Size(152, 33);
            this.dataBitsBox.Text = "8";
            this.dataBitsBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataBitsBox.Click += new System.EventHandler(this.parameterBoxTextChanged);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(261, 6);
            // 
            // delayTimeMsg
            // 
            this.delayTimeMsg.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delayTimeMsgBox});
            this.delayTimeMsg.Name = "delayTimeMsg";
            this.delayTimeMsg.Size = new System.Drawing.Size(264, 26);
            this.delayTimeMsg.Text = "Message Delay Time (ms)";
            this.delayTimeMsg.ToolTipText = "Delay time when transfering messages (in ms)";
            // 
            // delayTimeMsgBox
            // 
            this.delayTimeMsgBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.delayTimeMsgBox.Name = "delayTimeMsgBox";
            this.delayTimeMsgBox.Size = new System.Drawing.Size(152, 33);
            this.delayTimeMsgBox.Text = "50";
            this.delayTimeMsgBox.ToolTipText = "Delay time when transfering messages (in ms)";
            // 
            // maxLengthToolStripMenuItem
            // 
            this.maxLengthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maxlengthBox});
            this.maxLengthToolStripMenuItem.Name = "maxLengthToolStripMenuItem";
            this.maxLengthToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.maxLengthToolStripMenuItem.Text = "Max char length";
            this.maxLengthToolStripMenuItem.ToolTipText = "Maximum char length per transfer";
            // 
            // maxlengthBox
            // 
            this.maxlengthBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.maxlengthBox.Name = "maxlengthBox";
            this.maxlengthBox.Size = new System.Drawing.Size(152, 33);
            this.maxlengthBox.Text = "8";
            this.maxlengthBox.ToolTipText = "Maximum char length per transfer";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(261, 6);
            // 
            // delayTimeToolStripMenuItem
            // 
            this.delayTimeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delayTimeFileBox});
            this.delayTimeToolStripMenuItem.Name = "delayTimeToolStripMenuItem";
            this.delayTimeToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.delayTimeToolStripMenuItem.Text = "File Delay Time (ms)";
            this.delayTimeToolStripMenuItem.ToolTipText = "Delay time when transfering files (in ms)";
            // 
            // delayTimeFileBox
            // 
            this.delayTimeFileBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.delayTimeFileBox.Name = "delayTimeFileBox";
            this.delayTimeFileBox.Size = new System.Drawing.Size(152, 33);
            this.delayTimeFileBox.Text = "500";
            this.delayTimeFileBox.ToolTipText = "Delay time when transfering files (in ms)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 57);
            // 
            // open
            // 
            this.open.BackColor = System.Drawing.Color.Honeydew;
            this.open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.open.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.open.Image = ((System.Drawing.Image)(resources.GetObject("open.Image")));
            this.open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(55, 54);
            this.open.Text = "OPEN";
            this.open.Click += new System.EventHandler(this.close_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 57);
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.Linen;
            this.close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.close.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Image = ((System.Drawing.Image)(resources.GetObject("close.Image")));
            this.close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(61, 54);
            this.close.Text = "CLOSE";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 57);
            // 
            // flushBtn
            // 
            this.flushBtn.BackColor = System.Drawing.Color.White;
            this.flushBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.flushBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flushBtn.Image = ((System.Drawing.Image)(resources.GetObject("flushBtn.Image")));
            this.flushBtn.ImageTransparentColor = System.Drawing.Color.MediumAquamarine;
            this.flushBtn.Name = "flushBtn";
            this.flushBtn.Size = new System.Drawing.Size(62, 54);
            this.flushBtn.Text = "FLUSH";
            this.flushBtn.Click += new System.EventHandler(this.flushBtn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 57);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(50, 54);
            this.toolStripLabel1.Text = "PORT";
            // 
            // comBox
            // 
            this.comBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comBox.Name = "comBox";
            this.comBox.Size = new System.Drawing.Size(100, 57);
            this.comBox.Text = "6";
            this.comBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.comBox.TextChanged += new System.EventHandler(this.parameterBoxTextChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 57);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.Lavender;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.MediumAquamarine;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(96, 54);
            this.toolStripButton1.Text = "SEND FILES";
            this.toolStripButton1.Click += new System.EventHandler(this.sendFiles_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 57);
            // 
            // status
            // 
            this.status.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(66, 54);
            this.status.Text = "STATUS";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // ucScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Name = "ucScanner";
            this.Size = new System.Drawing.Size(1010, 57);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton open;
        private System.Windows.Forms.ToolStripButton close;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox comBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel status;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripLabel2;
        private System.Windows.Forms.ToolStripMenuItem baudsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox baudbox;
        private System.Windows.Forms.ToolStripMenuItem dataBitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox dataBitsBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem maxLengthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delayTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton flushBtn;
        private System.Windows.Forms.ToolStripTextBox maxlengthBox;
        private System.Windows.Forms.ToolStripTextBox delayTimeFileBox;
        private System.Windows.Forms.ToolStripMenuItem delayTimeMsg;
        private System.Windows.Forms.ToolStripTextBox delayTimeMsgBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    }
}
