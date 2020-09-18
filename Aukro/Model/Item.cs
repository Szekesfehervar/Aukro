using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Aukro.Model
{
    class Item : INotifyPropertyChanged
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; NotifyPropertyChanged("Name"); } }

        private double _price;
        public double Price { get { return _price; } set { _price = value; NotifyPropertyChanged("Price"); } }

        private string _description;
        public string Description { get { return _description; } set { _description = value; NotifyPropertyChanged("Description"); } }

        //private DateTime _dateTime;
        //public DateTime DateTime { get { return _dateTime; } set { _dateTime = value; NotifyPropertyChanged(); } }

        private double _lastbid;
        public double LastBid { get { return _lastbid; } set { _lastbid = value; NotifyPropertyChanged("Lastbid"); } }

        private string _lastname;
        public string LastName { get { return _lastname; } set { _lastname = value; NotifyPropertyChanged("LastName"); } }
        private int _lasted;
        public int Lasted { get { return _lasted; } set { _lasted = value; NotifyPropertyChanged("Lasted"); } }

        private string _password;
        public string Password { get { return _password; } set { _password = value; NotifyPropertyChanged("Password"); } }

        private string _nickname;
        public string Nickname { get { return _nickname; } set { _nickname = value; NotifyPropertyChanged("Nickname"); } }

        private bool _buttonenable;
        public bool Buttonenable { get { return _buttonenable; } set { _buttonenable = value; NotifyPropertyChanged("Buttonenable"); } }

        private bool _loged;
        public bool Loged { get { return _loged; } set { _loged = value; NotifyPropertyChanged("Loged"); } }

        private string _table;
        public string Table { get { return _table; } set { _table = value; NotifyPropertyChanged("Table"); } }

        private bool _textboxenable;
        public bool TextBoxEnable { get { return _textboxenable; } set { _textboxenable = value; NotifyPropertyChanged("Textboxenable"); } }



        Dictionary<string, List<string>> Advertisments = new Dictionary<string, List<string>>();
        Dictionary<string, string> Users = new Dictionary<string, string>();

        public async void Login()
        {
            if (Users.ContainsKey(Nickname) == true)
            {
                if (Password == (Users[Nickname]).ToString())
                {
                    var dialog = new MessageDialog("Jste přihlášený", "Login");
                    await dialog.ShowAsync();
                    Loged = true;
                    Buttonenable = true;
                    Password = null;
                    TextBoxEnable = false;
                }
                else
                {
                    var dialog = new MessageDialog("Nesprávné jméno nebo heslo", "Přihlašování");
                    await dialog.ShowAsync();
                }
            }
            else
            {
                var dialog = new MessageDialog("Nesprávné jméno nebo heslo", "Přihlašování");
                await dialog.ShowAsync();
            }
        }

        public async void Buy()
        {
            if (Advertisments.ContainsKey(Name) == true)
            {
                if (Convert.ToInt32(Advertisments[Name][2]) < Price)
                {
                    Advertisments.Remove(Name);
                    LastBid = Price;
                    LastName = Name;
                    var Dialog = new MessageDialog("Úspěšně jste zakoupil", "Inzeráty");
                    await Dialog.ShowAsync();
                }
                else
                {
                    var Dialog = new MessageDialog("Částka je příliš nízká pro koupení", "Inzeráty");
                    await Dialog.ShowAsync();
                }
            }
            else
            {
                var Dialog = new MessageDialog("Nesprávné jméno nebo heslo", "Přihlašování");
                await Dialog.ShowAsync();
            }
        }
        public void LogOut()
        {
            Loged = false;
            Buttonenable = false;
            TextBoxEnable = true;
        }

        public async void Registration()
        {
            if (Users.ContainsKey(Nickname) == false)
            {
                Users.Add(Nickname, Password);
                var dialog = new MessageDialog("Jste úspěšně zaregistrován", "Registrace");
                await dialog.ShowAsync();
            }
            else
            {
                var Dialog = new MessageDialog("Uživatelské jméno je již obsazeno", "Registrace");
                await Dialog.ShowAsync();
            }
        }

        public async void AddAdvertisment()
        {
            if (Advertisments.ContainsKey(Name) == false)
            {
                Advertisments.Add(Name, new List<string>(new string[] { Description, Lasted.ToString(), Price.ToString() }));              
                var Dialog = new MessageDialog("Váš inzerát byl přidán", "Inzeráty");
                await Dialog.ShowAsync();

            }
            else
            {
                var Dialog = new MessageDialog("Název je již obsazen, zkuste jiný", "Inzeráty");
                await Dialog.ShowAsync();
            }
        }

        public async void Bid()
        {
            if (Advertisments.ContainsKey(Name) == true)
            {
                if (Convert.ToInt32(Advertisments[Name][2]) < Price)
                {
                    Advertisments[Name][2] = Price.ToString();
                    var Dialog = new MessageDialog("Úspěšně jste přihodil", "Inzeráty");
                    await Dialog.ShowAsync();
                }
                else
                {
                    var Dialog = new MessageDialog("Částka je příliš nízká pro přihození", "Inzeráty");
                    await Dialog.ShowAsync();
                }
            }
            else
            {
                var Dialog = new MessageDialog("Název se neshoduje s žádným inzerátem", "Inzeráty");
                await Dialog.ShowAsync();
            }
        }

        public void Refresh()
        {
            var lines = Advertisments.Select(kv => "Název: " + kv.Key + "Popisek: " + kv.Value[0].ToString() + "Hodnota: " + kv.Value[2].ToString());
            Table = string.Join(Environment.NewLine, lines);
        }



        public override string ToString()
        {
            return Name + " " + Price;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
