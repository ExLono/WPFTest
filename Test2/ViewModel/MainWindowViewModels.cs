using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

using Test2.Command;
using Test2.Models;

namespace Test2.ViewModel
{
    public sealed class MainWindowViewModels : BaseViewModel
    {
        private ObservableCollection<User> _users;

        /// <inheritdoc />
        public MainWindowViewModels()
        {
            _users = new ObservableCollection<User>()
            {
                new User()
                {
                    Id = 1, FirstName = "1111", SecondName = "2222", TreeName = "3333",
                    Telephone = "2222"
                },
                new User()
                {
                    Id = 2, FirstName = "1111", SecondName = "2222", TreeName = "3333",
                    Telephone = "2222"
                },
                new User()
                {
                    Id = 3, FirstName = "1111", SecondName = "2222", TreeName = "3333",
                    Telephone = "2222"
                }
            };
        }

        public ICommand AddUser { get; } = new RelayCommand(new Action<object>(
                                                                (obj) =>
                                                                {
                                                                    IList<User> users =
                                                                        obj as ObservableCollection<User>;
                                                                    users.Add(new User(){Id = uint.MaxValue,FirstName = "dfsdfsdfsdf"});
                                                                }));
        public Collection<User> Users
        {
            get => _users;
        }
    }
}