namespace UserManagement.Account
{
    partial class RegisterForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.securityAnswerTextBox = new System.Windows.Forms.TextBox();
            this.securityQuestionComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.validator1 = new Ratnantray.Components.Validator(this.components);
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Confirm Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Security Question";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Security Answer";
            // 
            // confirmPasswordTextBox
            // 
            this.validator1.SetComparedControl(this.confirmPasswordTextBox, this.passwordTextBox);
            this.validator1.SetCompareMessage(this.confirmPasswordTextBox, "Password and Confirm Password should Match");
            this.validator1.SetCompareOperator(this.confirmPasswordTextBox, Ratnantray.Components.ValidationCompareOperator.Equal);
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(117, 71);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.PasswordChar = '*';
            this.validator1.SetRequiredMessage(this.confirmPasswordTextBox, "Confirm Password is required");
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(231, 20);
            this.confirmPasswordTextBox.TabIndex = 2;
            this.validator1.SetType(this.confirmPasswordTextBox, ((Ratnantray.Components.ValidationType)((Ratnantray.Components.ValidationType.Required | Ratnantray.Components.ValidationType.Compare))));
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(117, 45);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.validator1.SetRequiredMessage(this.passwordTextBox, "Password is required.");
            this.passwordTextBox.Size = new System.Drawing.Size(231, 20);
            this.passwordTextBox.TabIndex = 1;
            this.validator1.SetType(this.passwordTextBox, ((Ratnantray.Components.ValidationType)((Ratnantray.Components.ValidationType.Required | Ratnantray.Components.ValidationType.Compare))));
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(117, 18);
            this.userNameTextBox.Name = "userNameTextBox";
            this.validator1.SetRequiredMessage(this.userNameTextBox, "User name is required.");
            this.userNameTextBox.Size = new System.Drawing.Size(231, 20);
            this.userNameTextBox.TabIndex = 0;
            this.validator1.SetType(this.userNameTextBox, Ratnantray.Components.ValidationType.Required);
            // 
            // securityAnswerTextBox
            // 
            this.securityAnswerTextBox.Location = new System.Drawing.Point(117, 150);
            this.securityAnswerTextBox.Name = "securityAnswerTextBox";
            this.validator1.SetRequiredMessage(this.securityAnswerTextBox, "Security Answer is required!");
            this.securityAnswerTextBox.Size = new System.Drawing.Size(231, 20);
            this.securityAnswerTextBox.TabIndex = 5;
            this.validator1.SetType(this.securityAnswerTextBox, Ratnantray.Components.ValidationType.Required);
            // 
            // securityQuestionComboBox
            // 
            this.securityQuestionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.securityQuestionComboBox.DropDownWidth = 500;
            this.securityQuestionComboBox.FormattingEnabled = true;
            this.securityQuestionComboBox.Items.AddRange(new object[] {
            "What is the name of  Grand Father (Father\'s Father)?",
            "Where were you born?",
            "What is your Date of Birth?",
            "What is the name of your School/College?"});
            this.securityQuestionComboBox.Location = new System.Drawing.Point(117, 123);
            this.securityQuestionComboBox.Name = "securityQuestionComboBox";
            this.validator1.SetRequiredMessage(this.securityQuestionComboBox, "Security Question is required.");
            this.securityQuestionComboBox.Size = new System.Drawing.Size(231, 21);
            this.securityQuestionComboBox.TabIndex = 4;
            this.validator1.SetType(this.securityQuestionComboBox, Ratnantray.Components.ValidationType.Required);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(117, 176);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "&Sumit";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(198, 176);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // validator1
            // 
            this.validator1.Form = this;
            // 
            // emailTextBox
            // 
            this.validator1.SetCompareMessage(this.emailTextBox, "");
            this.emailTextBox.Location = new System.Drawing.Point(117, 97);
            this.emailTextBox.Name = "emailTextBox";
            this.validator1.SetRegularExpression(this.emailTextBox, "[a-z0-9!#$%&\'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&\'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-" +
        "z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            this.validator1.SetRegularExpressionMessage(this.emailTextBox, "Please enter a Valid Email address");
            this.validator1.SetRequiredMessage(this.emailTextBox, "Confirm Password is required");
            this.emailTextBox.Size = new System.Drawing.Size(231, 20);
            this.emailTextBox.TabIndex = 3;
            this.validator1.SetType(this.emailTextBox, ((Ratnantray.Components.ValidationType)((Ratnantray.Components.ValidationType.Required | Ratnantray.Components.ValidationType.RegularExpression))));
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Email Address";
            // 
            // RegisterForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(372, 212);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.securityQuestionComboBox);
            this.Controls.Add(this.securityAnswerTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.confirmPasswordTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register Form";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox securityAnswerTextBox;
        private System.Windows.Forms.ComboBox securityQuestionComboBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private Ratnantray.Components.Validator validator1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox emailTextBox;
    }
}