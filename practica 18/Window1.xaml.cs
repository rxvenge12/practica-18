using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace practica_18
{
    public partial class Window1 : Window
    {
        public partial class StudentExamWindow : Window
        {
            public StudentExamWindow(string firstName, string lastName, string selectedSubject, List<Question> questions)
            {
               
            }
        }
        public class Question
        {
            public string Text { get; set; }
            public string Option1 { get; set; }
            public string Option2 { get; set; }
            public string Option3 { get; set; }
            public string Option4 { get; set; }
            public string CorrectAnswer { get; set; }

            // Конструктор для удобства создания экземпляров вопросов
            public Question(string text, string option1, string option2, string option3, string option4, string correctAnswer)
            {
                Text = text;
                Option1 = option1;
                Option2 = option2;
                Option3 = option3;
                Option4 = option4;
                CorrectAnswer = correctAnswer;
            }
        }
        private List<Question> questions = new List<Question>();
        public Window1()
        {
            InitializeComponent();
        }
        public class Reflector
        {
            public void OutputClassInfoToFile(string className, string outputPath)
            {
                Type type = Type.GetType(className);
                if (type == null)
                {
                    Console.WriteLine($"Class '{className}' not found.");
                    return;
                }

                // Проверяем, существует ли файл
                if (!File.Exists(outputPath))
                {
                    // Если файл не существует, создаем новый
                    using (StreamWriter createWriter = File.CreateText(outputPath))
                    {
                        // Ничего не записываем, так как файл только что создан
                    }
                }

                // Теперь открываем файл для добавления информации в конец
                using (StreamWriter writer = new StreamWriter(outputPath, true))
                {
                    writer.WriteLine($"Class: {type.FullName}");

                    // Write fields
                    writer.WriteLine("Fields:");
                    foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                    {
                        writer.WriteLine($"{field.Name}: {field.FieldType}");
                    }

                    // Write properties
                    writer.WriteLine("Properties:");
                    foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                    {
                        writer.WriteLine($"{property.Name}: {property.PropertyType}");
                    }

                    writer.WriteLine();
                    Console.WriteLine($"Class information appended to {outputPath}");
                }
            }
        }
            private void StartExamButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика для начала экзамена студента
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string selectedSubject = (SubjectComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            // Проверяем, что список вопросов содержит 5 элементов
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(selectedSubject) || questions.Count != 5)
            {
                MessageBox.Show("Please fill in all fields and add 5 questions.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Передача данных студента и вопросов в новое окно экзамена
            Window2 window2 = new Window2(firstName, lastName, selectedSubject, questions);
            window2.Show();
            Close();
        }



        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика для добавления вопроса преподавателем
            string questionText = QuestionTextBox.Text;
            string option1 = Option1TextBox.Text;
            string option2 = Option2TextBox.Text;
            string option3 = Option3TextBox.Text;
            string option4 = Option4TextBox.Text;
            string correctAnswer = (CorrectAnswerComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(questionText) || string.IsNullOrEmpty(option1) || string.IsNullOrEmpty(option2) ||
                string.IsNullOrEmpty(option3) || string.IsNullOrEmpty(option4) || string.IsNullOrEmpty(correctAnswer))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Создание экземпляра вопроса и добавление его в список
            Question question = new Question(questionText, option1, option2, option3, option4, correctAnswer);
            questions.Add(question);

            // Очистка полей ввода после добавления вопроса
            QuestionTextBox.Text = "";
            Option1TextBox.Text = "";
            Option2TextBox.Text = "";
            Option3TextBox.Text = "";
            Option4TextBox.Text = "";
            CorrectAnswerComboBox.SelectedIndex = -1; // Сброс выбранного варианта ответа
        }

        private void SaveToFileButton_Click(object sender, RoutedEventArgs e)
        {
            // Путь к файлу, куда будут сохранены информация о классах
            string outputPath = "C:\\Users\\Miyagifn\\Downloads\\122\\out.txt";

            // Создаем экземпляр класса Reflector
            Reflector reflector = new Reflector();

            try
            {
                // Сохраняем информацию о каждом классе
                reflector.OutputClassInfoToFile(typeof(Window1).FullName, outputPath);
                reflector.OutputClassInfoToFile(typeof(StudentExamWindow).FullName, outputPath);
                reflector.OutputClassInfoToFile(typeof(Question).FullName, outputPath);

                // Сообщаем пользователю о завершении сохранения
                MessageBox.Show($"Информация о классах сохранена в файл {outputPath}", "Сохранение завершено", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Если произошла ошибка при сохранении, выводим сообщение об ошибке
                MessageBox.Show($"При сохранении произошла ошибка: {ex.Message}", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }





        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика для обновления данных преподавателя
            // Например, обновление списка вопросов и вариантов ответов

            // В данном примере просто обновим текстовые поля и комбо-боксы для ввода вопроса и ответов
            QuestionTextBox.Text = "";
            Option1TextBox.Text = "";
            Option2TextBox.Text = "";
            Option3TextBox.Text = "";
            Option4TextBox.Text = "";
            CorrectAnswerComboBox.SelectedIndex = -1; // Сброс выбранного варианта ответа
        }
    }
}
