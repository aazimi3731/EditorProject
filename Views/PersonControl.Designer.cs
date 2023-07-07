namespace EditorProject
{
  partial class PersonControl
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
      this.components = new System.ComponentModel.Container();
      this.usernameTextBox = new System.Windows.Forms.TextBox();
      this.passwordTextBox = new System.Windows.Forms.TextBox();
      this.usernameLabel = new System.Windows.Forms.Label();
      this.passwordLabel = new System.Windows.Forms.Label();
      this.loginButton = new System.Windows.Forms.Button();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // usernameTextBox
      // 
      this.usernameTextBox.Location = new System.Drawing.Point(160, 40);
      this.usernameTextBox.Name = "usernameTextBox";
      this.usernameTextBox.Size = new System.Drawing.Size(100, 22);
      this.usernameTextBox.TabIndex = 0;
      this.usernameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.usernameTextBox_Validating);
      // 
      // passwordTextBox
      // 
      this.passwordTextBox.Location = new System.Drawing.Point(160, 100);
      this.passwordTextBox.Name = "passwordTextBox";
      this.passwordTextBox.Size = new System.Drawing.Size(100, 22);
      this.passwordTextBox.TabIndex = 2;
      this.passwordTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.passwordTextBox_Validating);
      // 
      // usernameLabel
      // 
      this.usernameLabel.AutoSize = true;
      this.usernameLabel.Location = new System.Drawing.Point(45, 43);
      this.usernameLabel.Name = "usernameLabel";
      this.usernameLabel.Size = new System.Drawing.Size(70, 16);
      this.usernameLabel.TabIndex = 3;
      this.usernameLabel.Text = "Username";
      // 
      // passwordLabel
      // 
      this.passwordLabel.AutoSize = true;
      this.passwordLabel.Location = new System.Drawing.Point(45, 103);
      this.passwordLabel.Name = "passwordLabel";
      this.passwordLabel.Size = new System.Drawing.Size(67, 16);
      this.passwordLabel.TabIndex = 4;
      this.passwordLabel.Text = "Password";
      // 
      // loginButton
      // 
      this.loginButton.Location = new System.Drawing.Point(109, 149);
      this.loginButton.Name = "loginButton";
      this.loginButton.Size = new System.Drawing.Size(75, 31);
      this.loginButton.TabIndex = 6;
      this.loginButton.Text = "Login";
      this.loginButton.UseVisualStyleBackColor = true;
      this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // PersonControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.loginButton);
      this.Controls.Add(this.passwordLabel);
      this.Controls.Add(this.usernameLabel);
      this.Controls.Add(this.passwordTextBox);
      this.Controls.Add(this.usernameTextBox);
      this.Name = "PersonControl";
      this.Size = new System.Drawing.Size(301, 202);
      this.Load += new System.EventHandler(this.PersonControl_Load);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox usernameTextBox;
    private System.Windows.Forms.TextBox passwordTextBox;
    private System.Windows.Forms.Label usernameLabel;
    private System.Windows.Forms.Label passwordLabel;
    private System.Windows.Forms.Button loginButton;
    private System.Windows.Forms.ErrorProvider errorProvider1;
  }
}
