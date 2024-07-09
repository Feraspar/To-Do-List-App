﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using To_Do_List_WPF.Data;
using To_Do_List_WPF.Models;

namespace To_Do_List_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ToDoContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new ToDoContext();
            LoadTodoItems();
        }

        private void LoadTodoItems()
        {
            var Todos = _context.ToDoItems.ToList();
            ToDoListBox.ItemsSource = Todos;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ToDoItemTextBox.Text))
            {
                var newTodoItem = new ToDoItem { Title = ToDoItemTextBox.Text, IsCompleted = false };
                _context.ToDoItems.Add(newTodoItem);
                _context.SaveChanges();

                LoadTodoItems();
                ToDoItemTextBox.Clear();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}