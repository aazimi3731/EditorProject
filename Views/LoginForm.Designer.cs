namespace EditorProject
{
  partial class LoginForm
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
    private void InitializeComponent(PersonControl personControl_)
    {
      EditorProject.Person person1 = new EditorProject.Person();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
      this.personControl = personControl_;
      this.SuspendLayout();
      // 
      // personControl
      // 
      this.personControl.Location = new System.Drawing.Point(12, 12);
      this.personControl.Name = "personControl";
      person1.Age = 0;
      person1.FirstName = "";
      person1.LastName = "";
      person1.Password = null;
      person1.Username = null;
      this.personControl.Person = person1;
      this.personControl.Size = new System.Drawing.Size(301, 269);
      this.personControl.TabIndex = 0;
      // 
      // LoginForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(327, 218);
      this.Controls.Add(this.personControl);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(345, 265);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(345, 265);
      this.Name = "LoginForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "Login Form";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
      this.ResumeLayout(false);

    }

    #endregion

    private PersonControl personControl;
  }
}
