using System.Windows;

namespace practica_18
{
    public partial class StudentExamWindow : Window
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string SelectedSubject { get; }

        public StudentExamWindow(string firstName, string lastName, string selectedSubject)
        {
          
            FirstName = firstName;
            LastName = lastName;
            SelectedSubject = selectedSubject;

            // Здесь можете инициализировать окно экзамена с переданными данными студента
            InitializeExamWindow();
        }

        private void InitializeExamWindow()
        {
            // Пример инициализации окна экзамена
            // Здесь можете добавить элементы управления и логику для проведения экзамена
            // Например, создание вопросов, выбор ответов и расчет оценки
        }
    }
}
