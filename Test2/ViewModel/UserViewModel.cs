using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Test2.Command;
using Test2.Models;

namespace Test2.ViewModel
{
    public sealed class UserViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;
        private string _currentid;

        public UserViewModel()
        {
            _users = new ObservableCollection<User>()
            {
                new User() { Id = 1, FirstName = "1111", SecondName = "2222", Phone = "2222" },
                new User() { Id = 2, FirstName = "1111", SecondName = "2222",  Phone = "2222" },
                new User() { Id = 3, FirstName = "1111", SecondName = "2222",  Phone = "2222" }
            };
        }




        public ICommand AddUser { get; set; } = new Button1(new Action<object>(                                                                
            (obj) =>            
            {
            IList<User> users = obj as ObservableCollection<User>;
            users.Add(new User() { Id = 4, FirstName = "dfsdfsdfsdf"});
            }));



        public ICommand DeleteUser { get; set; } = new Button2(new Action<object>(
            (obj) =>
            {
                IList<User> users = obj as ObservableCollection<User>;
                users.RemoveAt(users.Count-1);
            }));

        public ICommand DeleteUserCurrentId { get; set; } = new Button2(new Action<object>(
            (obj) =>
            {
                IList<User> users = obj as ObservableCollection<User>;
                users.RemoveAt(_currentid);
            }));

        public Collection<User> Users
        {
            get => (_users);
        }
        public string currentid
        {
            get => _currentid;
        }

    }
}
