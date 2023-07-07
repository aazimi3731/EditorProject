using EditorProject.Interfaces;
using System;
using System.Windows.Forms;

namespace EditorProject
{
  public partial class PersonControl : UserControl
  {
    private readonly IPersonService _personService;
    public Person Person { get; set; }

    private Form parentForm;

    public PersonControl(IPersonService personService_)
    {
      InitializeComponent();

      _personService = personService_;

      Person = new Person
      {
        Username = string.Empty,
        Password = string.Empty,
      };
    }

    private void PersonControl_Load(object sender, EventArgs e)
    {
      parentForm = (Form)this.Parent;
      errorProvider1.ContainerControl = this;

      usernameTextBox.Text = Person.Username;
      passwordTextBox.Text = Person.Password;
    }

    private void LoginButton_Click(object sender, EventArgs e)
    {
      bool bValidUsername = ValidateUsername();
      bool bValidPassword = ValidatePassword();

      var username = usernameTextBox.Text;
      var password = passwordTextBox.Text;

      var person = _personService.GetPersonByUsername(username);

      if (person != null && string.Equals(person.Password, password))
      {
        MessageBox.Show("You are logined successfully");
        parentForm.Visible = false;
        parentForm.Close();
      }
      else
      {
        MessageBox.Show("Please enter valid username or password");
      }
    }

    private void usernameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      ValidateUsername();
    }

    private void passwordTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      ValidatePassword();
    }

    private bool ValidateUsername()
    {
      bool bStatus = true;
      if (usernameTextBox.Text == "")
      {
        errorProvider1.SetError(usernameTextBox, "Please enter your Username");
        bStatus = false;
      }
      else
        errorProvider1.SetError(usernameTextBox, "");
      return bStatus;
    }

    private bool ValidatePassword()
    {
      bool bStatus = true;
      if (passwordTextBox.Text == "")
      {
        errorProvider1.SetError(passwordTextBox, "Please enter your Password");
        bStatus = false;
      }
      else
        errorProvider1.SetError(passwordTextBox, "");
      return bStatus;
    }
  }
}
