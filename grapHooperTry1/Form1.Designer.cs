namespace grapHooperTry1
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
            this.GetCorordinatesButton = new System.Windows.Forms.Button();
            this.destBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RouteButton = new System.Windows.Forms.Button();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.srcCoordinatesBox = new System.Windows.Forms.TextBox();
            this.destCoordinatesBox = new System.Windows.Forms.TextBox();
            this.copyButton1 = new System.Windows.Forms.Button();
            this.copyButton2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // GetCorordinatesButton
            // 
            this.GetCorordinatesButton.Location = new System.Drawing.Point(516, 120);
            this.GetCorordinatesButton.Name = "GetCorordinatesButton";
            this.GetCorordinatesButton.Size = new System.Drawing.Size(199, 81);
            this.GetCorordinatesButton.TabIndex = 0;
            this.GetCorordinatesButton.Text = "getCoordinates";
            this.GetCorordinatesButton.UseVisualStyleBackColor = true;
            this.GetCorordinatesButton.Click += new System.EventHandler(this.GetCorordinatesButton_Click);
            // 
            // destBox
            // 
            this.destBox.Location = new System.Drawing.Point(516, 67);
            this.destBox.Name = "destBox";
            this.destBox.Size = new System.Drawing.Size(199, 26);
            this.destBox.TabIndex = 1;
            this.destBox.Text = "Hod Hasharon, israel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(399, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Result:";
            // 
            // RouteButton
            // 
            this.RouteButton.Location = new System.Drawing.Point(484, 345);
            this.RouteButton.Name = "RouteButton";
            this.RouteButton.Size = new System.Drawing.Size(210, 78);
            this.RouteButton.TabIndex = 4;
            this.RouteButton.Text = "Route";
            this.RouteButton.UseVisualStyleBackColor = true;
            this.RouteButton.Click += new System.EventHandler(this.RouteButton_Click);
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(464, 240);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(251, 26);
            this.resultBox.TabIndex = 5;
            // 
            // srcCoordinatesBox
            // 
            this.srcCoordinatesBox.Location = new System.Drawing.Point(277, 317);
            this.srcCoordinatesBox.Name = "srcCoordinatesBox";
            this.srcCoordinatesBox.Size = new System.Drawing.Size(127, 26);
            this.srcCoordinatesBox.TabIndex = 6;
            // 
            // destCoordinatesBox
            // 
            this.destCoordinatesBox.Location = new System.Drawing.Point(279, 428);
            this.destCoordinatesBox.Name = "destCoordinatesBox";
            this.destCoordinatesBox.Size = new System.Drawing.Size(127, 26);
            this.destCoordinatesBox.TabIndex = 7;
            // 
            // copyButton1
            // 
            this.copyButton1.Location = new System.Drawing.Point(112, 310);
            this.copyButton1.Name = "copyButton1";
            this.copyButton1.Size = new System.Drawing.Size(144, 39);
            this.copyButton1.TabIndex = 8;
            this.copyButton1.Text = "copy>>";
            this.copyButton1.UseVisualStyleBackColor = true;
            this.copyButton1.Click += new System.EventHandler(this.copyButton1_Click);
            // 
            // copyButton2
            // 
            this.copyButton2.Location = new System.Drawing.Point(112, 422);
            this.copyButton2.Name = "copyButton2";
            this.copyButton2.Size = new System.Drawing.Size(144, 35);
            this.copyButton2.TabIndex = 9;
            this.copyButton2.Text = "copy>>";
            this.copyButton2.UseVisualStyleBackColor = true;
            this.copyButton2.Click += new System.EventHandler(this.copyButton2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(751, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(730, 619);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1599, 725);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.copyButton2);
            this.Controls.Add(this.copyButton1);
            this.Controls.Add(this.destCoordinatesBox);
            this.Controls.Add(this.srcCoordinatesBox);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.RouteButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.destBox);
            this.Controls.Add(this.GetCorordinatesButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetCorordinatesButton;
        private System.Windows.Forms.TextBox destBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RouteButton;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.TextBox srcCoordinatesBox;
        private System.Windows.Forms.TextBox destCoordinatesBox;
        private System.Windows.Forms.Button copyButton1;
        private System.Windows.Forms.Button copyButton2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

