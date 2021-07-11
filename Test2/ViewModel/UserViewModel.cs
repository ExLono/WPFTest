using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

using Test2.Command;
using Test2.Models;

namespace Test2.ViewModel
{
	public sealed class UserViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> _users;
        private uint _currentId;

        public UserViewModel()
        {
            _users = new ObservableCollection<User>()
            {
                new User() { Id = 1, FirstName = "1111", SecondName = "2222", Phone = "2222" },
                new User() { Id = 2, FirstName = "1111", SecondName = "2222",  Phone = "2222" },
                new User() { Id = 3, FirstName = "1111", SecondName = "2222",  Phone = "2222" }
            };
			_executeDeleteUserCurrentId = Execute;
			DeleteUserCurrentId = new RelayCommand(_executeDeleteUserCurrentId);
		}




        public ICommand AddUser { get; set; } = new RelayCommand(new Action<object>(                                                                
            (obj) =>            
            {
            IList<User> users = obj as ObservableCollection<User>;
            users.Add(new User() { Id = 4, FirstName = "dfsdfsdfsdf"});
            }));



        public ICommand DeleteUser { get;} = new RelayCommand((obj) =>
		{
			IList<User> users = obj as ObservableCollection<User>;
			users.RemoveAt(users.Count-1);
		});

		public ICommand DeleteUserCurrentId { get; }

        public ObservableCollection<User> Users
        {
            get => _users;
        }
        public uint CurrentId
        {
            get => _currentId;
			set
			{
				_currentId = value;
                OnPropertyChanged(nameof(CurrentId));
			}
        }

		public event PropertyChangedEventHandler PropertyChanged;

		private static Action<object> _executeDeleteUserCurrentId;

		private void Execute(object parameter)
		{
			try
			{
				int index = checked((int) CurrentId);
				Users.RemoveAt(index - 1);
			}
			catch (OverflowException)
			{
				MessageBox.Show("Ошибка переполнения -> вводимый id значительно больше ожидаемого параметра");
				Users.RemoveAt(Users.Count - 1);
			}
			catch (ArgumentOutOfRangeException)
			{
				MessageBox.Show("Значение ID либо меньше нуля, либо больше макмимального значения");
			}
		}

		
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
