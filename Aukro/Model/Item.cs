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



        Dictionary<string, List<string>> Advertisment = new Dictionary<string, List<string>>();
        Dictionary<string, string> Users = new Dictionary<string, string>();

        public void Login()
        {
            if (Users.ContainsKey(Nickname) == true)
            {
                if (Password == (Users[Nickname]).ToString())
                {
                    var dialog = new MessageDialog("Jste přihlášený", "Login");
                    Loged = true;
                    Buttonenable = true;
                    Password = null;
                    TextBoxEnable = false;
                }
                else
                {
                    var dialog = new MessageDialog("Nesprávné jméno nebo heslo", "Přihlašování");
                }
            }
            else
            {
                var dialog = new MessageDialog("Nesprávné jméno nebo heslo", "Přihlašování");
            }

        }

        public void Buy()
        {
            if (Advertisment.ContainsKey(Name) == true)
            {
                if (Convert.ToInt32(Advertisment[Name][2]) < Price)
                {
                    Advertisment.Remove(Name);
                    LastBid = Price;
                    LastName = Name;
                    var Dialog = new MessageDialog("Úspěšně jste zakoupil", "Inzeráty");
                }
                else
                {
                    var Dialog = new MessageDialog("Částka je příliš nízká pro koupení", "Inzeráty");
                }
            }
            else
            {
                var Dialog = new MessageDialog("Nesprávné jméno nebo heslo", "Přihlašování");
            }
        }
        public void LogOut()
        {
            Loged = false;
            Buttonenable = false;
            TextBoxEnable = true;
        }

        public void Registration()
        {
            if (Users.ContainsKey(Nickname) == false)
            {
                Users.Add(Nickname, Password);
                var Dialog = new MessageDialog("Jste úspěšně zaregistrován", "Registrace");
            }
            else
            {
                var Dialog = new MessageDialog("Uživatelské jméno je již obsazeno", "Registrace");
            }
        }

        public void AddAdvertisment()
        {
            if (Advertisment.ContainsKey(Name) == false)
            {
                Advertisment.Add(Name, new List<string>(new string[] { Description, Lasted.ToString(), Price.ToString() }));
                var Dialog = new MessageDialog("Váš inzerát byl přidán", "Inzeráty");
            }
            else
            {
                var Dialog = new MessageDialog("Název je již obsazen, zkuste jiný", "Inzeráty");
            }
        }

        public void Bid()
        {
            if (Advertisment.ContainsKey(Name) == true)
            {
                if (Convert.ToInt32(Advertisment[Name][2]) < Price)
                {
                    Advertisment[Name][2] = Price.ToString();
                    var Dialog = new MessageDialog("Úspěšně jste přihodil", "Inzeráty");
                }
                else
                {
                    var Dialog = new MessageDialog("Částka je příliš nízká pro přihození", "Inzeráty");
                }
            }
            else
            {
                var Dialog = new MessageDialog("Název se neshoduje s žádným inzerátem", "Inzeráty");
            }
        }

        public void Refresh()
        {
            var lines = Advertisment.Select(kv => "Název: " + kv.Key + "Popisek: " + kv.Value[0].ToString() + "Hodnota: " + kv.Value[2].ToString());
            Table = string.Join(Environment.NewLine, lines);
        }



        public override string ToString()
        {
            return Name + " " + Price;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
