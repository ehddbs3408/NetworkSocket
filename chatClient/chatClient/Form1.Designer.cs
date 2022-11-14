
namespace chatClient
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.Btn_cal = new System.Windows.Forms.Button();
            this.Btn_earInHorse = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.Out = new System.Windows.Forms.Button();
            this.CLS = new System.Windows.Forms.Button();
            this.Red = new System.Windows.Forms.Button();
            this.O = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(576, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 25);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(12, 80);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(776, 282);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 368);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(381, 25);
            this.textBox3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(525, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(683, 43);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(105, 23);
            this.btn_connect.TabIndex = 4;
            this.btn_connect.Text = "Go to Server";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(13, 400);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(129, 23);
            this.btn_send.TabIndex = 5;
            this.btn_send.Text = "Send Message";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // Btn_cal
            // 
            this.Btn_cal.Location = new System.Drawing.Point(148, 400);
            this.Btn_cal.Name = "Btn_cal";
            this.Btn_cal.Size = new System.Drawing.Size(134, 23);
            this.Btn_cal.TabIndex = 6;
            this.Btn_cal.Text = "calculator";
            this.Btn_cal.UseVisualStyleBackColor = true;
            this.Btn_cal.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_earInHorse
            // 
            this.Btn_earInHorse.Location = new System.Drawing.Point(289, 399);
            this.Btn_earInHorse.Name = "Btn_earInHorse";
            this.Btn_earInHorse.Size = new System.Drawing.Size(104, 23);
            this.Btn_earInHorse.TabIndex = 7;
            this.Btn_earInHorse.Text = "earInHorse";
            this.Btn_earInHorse.UseVisualStyleBackColor = true;
            this.Btn_earInHorse.Click += new System.EventHandler(this.Btn_earInHorse_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(400, 397);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 25);
            this.textBox4.TabIndex = 8;
            // 
            // Out
            // 
            this.Out.Location = new System.Drawing.Point(576, 43);
            this.Out.Name = "Out";
            this.Out.Size = new System.Drawing.Size(101, 23);
            this.Out.TabIndex = 9;
            this.Out.Text = "Login Out";
            this.Out.UseVisualStyleBackColor = true;
            this.Out.Click += new System.EventHandler(this.Out_Click);
            // 
            // CLS
            // 
            this.CLS.Location = new System.Drawing.Point(683, 366);
            this.CLS.Name = "CLS";
            this.CLS.Size = new System.Drawing.Size(100, 25);
            this.CLS.TabIndex = 10;
            this.CLS.Text = "CLS";
            this.CLS.UseVisualStyleBackColor = true;
            this.CLS.Click += new System.EventHandler(this.CLS_Click);
            // 
            // Red
            // 
            this.Red.BackColor = System.Drawing.Color.Red;
            this.Red.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Red.Location = new System.Drawing.Point(12, 12);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(78, 61);
            this.Red.TabIndex = 11;
            this.Red.Text = "Red";
            this.Red.UseVisualStyleBackColor = false;
            this.Red.Click += new System.EventHandler(this.Red_Click);
            // 
            // O
            // 
            this.O.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.O.Location = new System.Drawing.Point(96, 13);
            this.O.Name = "O";
            this.O.Size = new System.Drawing.Size(78, 61);
            this.O.TabIndex = 12;
            this.O.Text = "O";
            this.O.UseVisualStyleBackColor = false;
            this.O.Click += new System.EventHandler(this.O_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Yellow;
            this.button2.Location = new System.Drawing.Point(180, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 61);
            this.button2.TabIndex = 13;
            this.button2.Text = "O";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lime;
            this.button3.Location = new System.Drawing.Point(264, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 61);
            this.button3.TabIndex = 14;
            this.button3.Text = "O";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Aqua;
            this.button4.Location = new System.Drawing.Point(348, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 61);
            this.button4.TabIndex = 15;
            this.button4.Text = "O";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Blue;
            this.button5.Location = new System.Drawing.Point(432, 15);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(78, 61);
            this.button5.TabIndex = 16;
            this.button5.Text = "O";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::chatClient.Properties.Resources.ww;
            this.pictureBox3.Location = new System.Drawing.Point(585, 399);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(92, 89);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::chatClient.Properties.Resources.bhmhklhgf;
            this.pictureBox2.Location = new System.Drawing.Point(683, 410);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(101, 79);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::chatClient.Properties.Resources._2021_08_31_011746;
            this.pictureBox1.Location = new System.Drawing.Point(509, 430);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 501);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.O);
            this.Controls.Add(this.Red);
            this.Controls.Add(this.CLS);
            this.Controls.Add(this.Out);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.Btn_earInHorse);
            this.Controls.Add(this.Btn_cal);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "ChatServer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button Btn_cal;
        private System.Windows.Forms.Button Btn_earInHorse;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button Out;
        private System.Windows.Forms.Button CLS;
        private System.Windows.Forms.Button Red;
        private System.Windows.Forms.Button O;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

