using Aukro.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aukro.ViewModel
{
    class MainViewModel
    {
        public RelayCommand ModelLogin { get; set; }
        public RelayCommand ModelRegistation { get; set; }
        public RelayCommand ModelAdd { get; set; }
        public RelayCommand ModelBid { get; set; }
        public RelayCommand ModelLogout { get; set; }
        public RelayCommand ModelBuy { get; set; }
        public ObservableCollection<Item> ItemList { get; set; }
        //public ObservableCollection<Item> Items { get { return _items; } set { _items = value; NotifyPropertyChanged(); } }
        //public Item SelectedItem { get { return _selectedItem; } set { _selectedItem = value; NotifyPropertyChanged(); } }
        //public int SelectedItemIndex { get { return _selectedItemsIndex + 1; } set { _selectedItemsIndex = value; NotifyPropertyChanged(); Remove.RaiseCanExecuteChanged(); } }


        public MainViewModel()
        {
            Item = new Item
            {
                Lasted = 24,
                Buttonenable = false,
                TextBoxEnable = true,
            };
            ModelLogin = new RelayCommand(Login, canExecuteMethod);
            ModelRegistation = new RelayCommand(Registration, canExecuteMethod);
            ModelAdd = new RelayCommand(AddAdvertisment, canExecuteMethod);
            ModelBid = new RelayCommand(Bid, canExecuteMethod);
            ModelLogout = new RelayCommand(Logout, canExecuteMethod);
            ModelBuy = new RelayCommand(Buy, canExecuteMethod);
            ItemList = new ObservableCollection<Item>();

            //Items.Add(new Item { Name = "Volant na loď", Description = "Je teplejsdfkjsahfdkuazdkjahiuldzakjdhfalisudzakljsdhaliuedzalisjchbalkjhgzdfkluahflkauwzeakjcsakljszdrakludhakjdh", Price = 5 }); ;

            //Add = new RelayCommand(
            //    () => { Items.Add(new Item { Name = "Nový", Description = "Popis itemu", Price = 0 }); },
            //    () => true
            //    );

            //Remove = new RelayCommand(
            //    () => { Items.Remove(SelectedItem); },
            //    () => { return SelectedItem != null; }
            //    );
        }



        private bool canExecuteMethod(object parameter)
        {
            return true;
        }

        private void Buy(object parameter)
        {
            Item.Buy();
            Item.Refresh();
        }
        private void Logout(object parameter)
        {
            Item.LogOut();
        }
        private void Registration(object parameter)
        {
            Item.Registration();
        }

        private void Bid(object parameter)
        {
            Item.Bid();
            Item.Refresh();
        }

        private void AddAdvertisment(object parameter)
        {
            Item.AddAdvertisment();
            Item.Refresh();
        }

        private void Login(object parameter)
        {
            Item.Login();
        }

        public Item Item { get; set; }





    }
}
