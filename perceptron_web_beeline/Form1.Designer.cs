namespace perceptron_web_beeline
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_open = new System.Windows.Forms.Button();
            this.button_train = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button_NeyroActivate = new System.Windows.Forms.Button();
            this.button_AutoTrain = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button_CreateTestBMP = new System.Windows.Forms.Button();
            this.button_answer = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.backgroundWorker_Autotrain = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_Answer = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(16, 134);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(487, 292);
            this.listBox1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 85);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(271, 15);
            this.button_open.Margin = new System.Windows.Forms.Padding(4);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(100, 28);
            this.button_open.TabIndex = 3;
            this.button_open.Text = "Open";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // button_train
            // 
            this.button_train.Location = new System.Drawing.Point(403, 14);
            this.button_train.Margin = new System.Windows.Forms.Padding(4);
            this.button_train.Name = "button_train";
            this.button_train.Size = new System.Drawing.Size(100, 28);
            this.button_train.TabIndex = 4;
            this.button_train.Text = "Не верно";
            this.button_train.UseVisualStyleBackColor = true;
            this.button_train.Click += new System.EventHandler(this.button_train_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 50);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "CreateDict";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_CreateDict_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(271, 50);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = "CreateBitmap";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_BitmapCreater_Click);
            // 
            // button_NeyroActivate
            // 
            this.button_NeyroActivate.Location = new System.Drawing.Point(143, 15);
            this.button_NeyroActivate.Margin = new System.Windows.Forms.Padding(4);
            this.button_NeyroActivate.Name = "button_NeyroActivate";
            this.button_NeyroActivate.Size = new System.Drawing.Size(100, 28);
            this.button_NeyroActivate.TabIndex = 7;
            this.button_NeyroActivate.Text = "button_NeyroActivate";
            this.button_NeyroActivate.UseVisualStyleBackColor = true;
            this.button_NeyroActivate.Click += new System.EventHandler(this.button_NeyroActivate_Click);
            // 
            // button_AutoTrain
            // 
            this.button_AutoTrain.Location = new System.Drawing.Point(403, 49);
            this.button_AutoTrain.Margin = new System.Windows.Forms.Padding(4);
            this.button_AutoTrain.Name = "button_AutoTrain";
            this.button_AutoTrain.Size = new System.Drawing.Size(100, 28);
            this.button_AutoTrain.TabIndex = 8;
            this.button_AutoTrain.Text = "AutoTrain";
            this.button_AutoTrain.UseVisualStyleBackColor = true;
            this.button_AutoTrain.Click += new System.EventHandler(this.button_AutoTrain_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "w0",
            "w1",
            "w2",
            "w3",
            "w4",
            "w5",
            "w6",
            "w7"});
            this.checkedListBox1.Location = new System.Drawing.Point(511, 15);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(61, 140);
            this.checkedListBox1.TabIndex = 9;
            // 
            // button_CreateTestBMP
            // 
            this.button_CreateTestBMP.Location = new System.Drawing.Point(143, 87);
            this.button_CreateTestBMP.Margin = new System.Windows.Forms.Padding(4);
            this.button_CreateTestBMP.Name = "button_CreateTestBMP";
            this.button_CreateTestBMP.Size = new System.Drawing.Size(100, 28);
            this.button_CreateTestBMP.TabIndex = 10;
            this.button_CreateTestBMP.Text = "CreateTestBMP";
            this.button_CreateTestBMP.UseVisualStyleBackColor = true;
            this.button_CreateTestBMP.Click += new System.EventHandler(this.button_CreateTestBMP_Click);
            // 
            // button_answer
            // 
            this.button_answer.Location = new System.Drawing.Point(271, 87);
            this.button_answer.Margin = new System.Windows.Forms.Padding(4);
            this.button_answer.Name = "button_answer";
            this.button_answer.Size = new System.Drawing.Size(100, 28);
            this.button_answer.TabIndex = 11;
            this.button_answer.Text = "Answer";
            this.button_answer.UseVisualStyleBackColor = true;
            this.button_answer.Click += new System.EventHandler(this.button_answer_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth4Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(85, 104);
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            // 
            // backgroundWorker_Autotrain
            // 
            this.backgroundWorker_Autotrain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Autotrain_DoWork);
            this.backgroundWorker_Autotrain.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Autotrain_RunWorkerCompleted);
            // 
            // backgroundWorker_Answer
            // 
            this.backgroundWorker_Answer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Answer_DoWork);
            this.backgroundWorker_Answer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Answer_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 462);
            this.Controls.Add(this.button_answer);
            this.Controls.Add(this.button_CreateTestBMP);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.button_AutoTrain);
            this.Controls.Add(this.button_NeyroActivate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_train);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button_train;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_NeyroActivate;
        private System.Windows.Forms.Button button_AutoTrain;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button_CreateTestBMP;
        private System.Windows.Forms.Button button_answer;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Autotrain;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Answer;
    }
}

