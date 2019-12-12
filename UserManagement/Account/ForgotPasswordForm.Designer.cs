namespace UserManagement.Account
{
    partial class ForgotPasswordForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.securityAnswerTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.securityQuestionComboBox = new System.Windows.Forms.ComboBox();
            this.validator1 = new Itboy.Components.Validator(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Security Question";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Security Answer";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(103, 16);
            this.userNameTextBox.Name = "userNameTextBox";
            this.validator1.SetRequiredMessage(this.userNameTextBox, "Username is Required!");
            this.userNameTextBox.Size = new System.Drawing.Size(156, 20);
            this.userNameTextBox.TabIndex = 0;
            this.validator1.SetType(this.userNameTextBox, Itboy.Components.ValidationType.Required);
            // 
            // securityAnswerTextBox
            // 
            this.securityAnswerTextBox.Location = new System.Drawing.Point(103, 69);
            this.securityAnswerTextBox.Name = "securityAnswerTextBox";
            this.validator1.SetRequiredMessage(this.securityAnswerTextBox, "Security Answer is Required!");
            this.securityAnswerTextBox.Size = new System.Drawing.Size(156, 20);
            this.securityAnswerTextBox.TabIndex = 2;
            this.validator1.SetType(this.securityAnswerTextBox, Itboy.Components.ValidationType.Required);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(103, 95);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(184, 95);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // securityQuestionComboBox
            // 
            this.securityQuestionComboBox.DropDownHeight = 200;
            this.securityQuestionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.securityQuestionComboBox.DropDownWidth = 300;
            this.securityQuestionComboBox.FormattingEnabled = true;
            this.securityQuestionComboBox.IntegralHeight = false;
            this.securityQuestionComboBox.Items.AddRange(new object[] {
            "What is the name of  Grand Father (Father\'s Father)?",
            "Where were you born?",
            "What is your Date of Birth?",
            "What is the name of your School/College?"});
            this.securityQuestionComboBox.Location = new System.Drawing.Point(103, 42);
            this.securityQuestionComboBox.Name = "securityQuestionComboBox";
            this.validator1.SetRequiredMessage(this.securityQuestionComboBox, "Security Question is Required");
            this.securityQuestionComboBox.Size = new System.Drawing.Size(156, 21);
            this.securityQuestionComboBox.TabIndex = 1;
            this.validator1.SetType(this.securityQuestionComboBox, Itboy.Components.ValidationType.Required);
            // 
            // validator1
            // 
            this.validator1.Form = this;
            // 
            // ForgotPasswordForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(295, 129);
            this.Controls.Add(this.securityQuestionComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.securityAnswerTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ForgotPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forgot Password Form";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox securityAnswerTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox securityQuestionComboBox;
        private Itboy.Components.Validator validator1;
    }
}