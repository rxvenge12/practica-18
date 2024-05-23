using System.Collections.Generic;
using System.Windows;
using static practica_18.Window1;

namespace practica_18
{
    public partial class Window2 : Window
    {
        private readonly string firstName;
        private readonly string lastName;
        private readonly string selectedSubject;
        private readonly List<Question> questions;

        public List<Question> Questions
        {
            get { return questions; }
          
        }

        public Window2(string firstName, string lastName, string selectedSubject, List<Question> questions)
        {
            InitializeComponent();
            this.firstName = firstName;
            this.lastName = lastName;
            this.selectedSubject = selectedSubject;
            this.questions = questions;

            DataContext = this;

            InitializeExam();
        }

        private void InitializeExam()
        {
            // Здесь можно использовать список вопросов для проведения экзамена
            // Например, отобразить текст вопросов в элементах управления на форме
        }

        private void FinishExamButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика для завершения экзамена и вывода результатов
            // Например, подсчет правильных ответов и выставление оценки
            // Вывод результата экзамена с использованием MessageBox
            MessageBox.Show($"Экзамен завершен!\n\nИмя: {firstName}\nФамилия: {lastName}\n\nОценка: 5", "Результаты", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
