namespace SoftwareLocker
{
    partial class RegisterDialog
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
            this.sebBaseString = new SoftwareLocker.SerialBox();
            this.sebPassword = new SoftwareLocker.SerialBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnTrial = new System.Windows.Forms.Button();
            this.grbRegister = new System.Windows.Forms.GroupBox();
            this.lblText = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblCallPhone = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblDaysToEnd = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblRunTimesLeft = new System.Windows.Forms.Label();
            this.lblTimes = new System.Windows.Forms.Label();
            this.grbTrialRunning = new System.Windows.Forms.GroupBox();
            this.btnDemo = new System.Windows.Forms.Button();
            this.grbRegister.SuspendLayout();
            this.grbTrialRunning.SuspendLayout();
            this.SuspendLayout();
            // 
            // sebBaseString
            // 
            this.sebBaseString.CaptleLettersOnly = true;
            this.sebBaseString.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.sebBaseString.Location = new System.Drawing.Point(12, 74);
            this.sebBaseString.Name = "sebBaseString";
            this.sebBaseString.ReadOnly = true;
            this.sebBaseString.Size = new System.Drawing.Size(293, 18);
            this.sebBaseString.TabIndex = 2;
            // 
            // sebPassword
            // 
            this.sebPassword.CaptleLettersOnly = true;
            this.sebPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.sebPassword.Location = new System.Drawing.Point(12, 117);
            this.sebPassword.Name = "sebPassword";
            this.sebPassword.Size = new System.Drawing.Size(293, 18);
            this.sebPassword.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(121, 154);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnTrial
            // 
            this.btnTrial.Location = new System.Drawing.Point(206, 17);
            this.btnTrial.Name = "btnTrial";
            this.btnTrial.Size = new System.Drawing.Size(99, 23);
            this.btnTrial.TabIndex = 2;
            this.btnTrial.Text = "Trial Run";
            this.btnTrial.UseVisualStyleBackColor = true;
            this.btnTrial.Click += new System.EventHandler(this.btnTrial_Click);
            // 
            // grbRegister
            // 
            this.grbRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbRegister.Controls.Add(this.lblText);
            this.grbRegister.Controls.Add(this.lblSerial);
            this.grbRegister.Controls.Add(this.lblID);
            this.grbRegister.Controls.Add(this.lblCallPhone);
            this.grbRegister.Controls.Add(this.sebBaseString);
            this.grbRegister.Controls.Add(this.btnOK);
            this.grbRegister.Controls.Add(this.sebPassword);
            this.grbRegister.Location = new System.Drawing.Point(12, 57);
            this.grbRegister.Name = "grbRegister";
            this.grbRegister.Size = new System.Drawing.Size(317, 232);
            this.grbRegister.TabIndex = 1;
            this.grbRegister.TabStop = false;
            this.grbRegister.Text = "Registration Info";
            // 
            // lblText
            // 
            this.lblText.Location = new System.Drawing.Point(9, 184);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(296, 35);
            this.lblText.TabIndex = 6;
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(9, 101);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(36, 13);
            this.lblSerial.TabIndex = 3;
            this.lblSerial.Text = "Serial:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(9, 58);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID:";
            // 
            // lblCallPhone
            // 
            this.lblCallPhone.AutoSize = true;
            this.lblCallPhone.Location = new System.Drawing.Point(6, 21);
            this.lblCallPhone.Name = "lblCallPhone";
            this.lblCallPhone.Size = new System.Drawing.Size(210, 26);
            this.lblCallPhone.TabIndex = 0;
            this.lblCallPhone.Text = "Call shoping part and read you ID.\r\nThey will give you serial for your applicatio" +
    "n";
            // 
            // lblComment
            // 
            this.lblComment.Location = new System.Drawing.Point(12, 9);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(317, 43);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "To use this application, you must buy it.\r\nBefore buying, you can run application" +
    " as trial. in trial mode some parts may be inactive and after buying they will b" +
    "e active";
            // 
            // lblDaysToEnd
            // 
            this.lblDaysToEnd.AutoSize = true;
            this.lblDaysToEnd.Location = new System.Drawing.Point(9, 22);
            this.lblDaysToEnd.Name = "lblDaysToEnd";
            this.lblDaysToEnd.Size = new System.Drawing.Size(118, 13);
            this.lblDaysToEnd.TabIndex = 3;
            this.lblDaysToEnd.Text = "Days to end trial period:";
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.ForeColor = System.Drawing.Color.Red;
            this.lblDays.Location = new System.Drawing.Point(132, 22);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(37, 13);
            this.lblDays.TabIndex = 4;
            this.lblDays.Text = "[Days]";
            // 
            // lblRunTimesLeft
            // 
            this.lblRunTimesLeft.AutoSize = true;
            this.lblRunTimesLeft.Location = new System.Drawing.Point(9, 48);
            this.lblRunTimesLeft.Name = "lblRunTimesLeft";
            this.lblRunTimesLeft.Size = new System.Drawing.Size(74, 13);
            this.lblRunTimesLeft.TabIndex = 5;
            this.lblRunTimesLeft.Text = "Run times left:";
            // 
            // lblTimes
            // 
            this.lblTimes.AutoSize = true;
            this.lblTimes.ForeColor = System.Drawing.Color.Red;
            this.lblTimes.Location = new System.Drawing.Point(132, 48);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new System.Drawing.Size(41, 13);
            this.lblTimes.TabIndex = 6;
            this.lblTimes.Text = "[Times]";
            // 
            // grbTrialRunning
            // 
            this.grbTrialRunning.Controls.Add(this.btnDemo);
            this.grbTrialRunning.Controls.Add(this.lblDaysToEnd);
            this.grbTrialRunning.Controls.Add(this.lblRunTimesLeft);
            this.grbTrialRunning.Controls.Add(this.lblDays);
            this.grbTrialRunning.Controls.Add(this.lblTimes);
            this.grbTrialRunning.Controls.Add(this.btnTrial);
            this.grbTrialRunning.Location = new System.Drawing.Point(12, 295);
            this.grbTrialRunning.Name = "grbTrialRunning";
            this.grbTrialRunning.Size = new System.Drawing.Size(317, 74);
            this.grbTrialRunning.TabIndex = 8;
            this.grbTrialRunning.TabStop = false;
            this.grbTrialRunning.Text = "Trial Running";
            // 
            // btnDemo
            // 
            this.btnDemo.Location = new System.Drawing.Point(206, 43);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(99, 23);
            this.btnDemo.TabIndex = 7;
            this.btnDemo.Text = "Demo Version";
            this.btnDemo.UseVisualStyleBackColor = true;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
            // 
            // RegisterDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 379);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.grbTrialRunning);
            this.Controls.Add(this.grbRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Regitration Dialog";
            this.grbRegister.ResumeLayout(false);
            this.grbRegister.PerformLayout();
            this.grbTrialRunning.ResumeLayout(false);
            this.grbTrialRunning.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SoftwareLocker.SerialBox sebBaseString;
        private SoftwareLocker.SerialBox sebPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnTrial;
        private System.Windows.Forms.GroupBox grbRegister;
        private System.Windows.Forms.Label lblCallPhone;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblDaysToEnd;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lblRunTimesLeft;
        private System.Windows.Forms.Label lblTimes;
        private System.Windows.Forms.GroupBox grbTrialRunning;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Button btnDemo;
    }
}