using EditorProject.Interfaces;
using EditorProject.Properties;
using System.Windows.Forms;

namespace EditorProject
{
  public partial class LoginForm : Form, ILoginForm
  {
    public LoginForm(PersonControl personControl_)
    {
      InitializeComponent(personControl_);
    }

    private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.Visible)
      {
        Application.Exit();
      }
      this.Visible = true;
    }

    public void ShowLoginForm()
    {
      this.StartPosition = FormStartPosition.CenterParent;
      this.Icon = Resources.LoginUser;

      this.AutoScaleDimensions = new System.Drawing.Size();
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ResumeLayout(false);
      this.PerformLayout();

      this.ShowDialog();
    }
  }
}
