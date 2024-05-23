using System.Windows;

namespace practica_18
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (login == "123" && password == "123")
            {
                // Создаем экземпляр окна Window1
                Window1 window1 = new Window1();

                // Показываем окно, вызывая метод Show() для созданного экземпляра
                window1.Show();

                // Закрываем текущее окно авторизации
                Close();
            }

            else if (login == "1111" && password == "1111")
            {
                StudentRegistrationWindow studentRegistrationWindow = new StudentRegistrationWindow();
                studentRegistrationWindow.Show();
                Close();
            }
            else
            {
                ErrorMessageTextBlock.Text = "Invalid login or password.";
            }
        }

    }

    // Класс для формы преподавателя
    public partial class TeacherWindow : Window
    {
        public TeacherWindow()
        {

        }
    }

    // Класс для формы регистрации студента
    public partial class StudentRegistrationWindow : Window
    {
        public StudentRegistrationWindow()
        {

        }
    }
}
