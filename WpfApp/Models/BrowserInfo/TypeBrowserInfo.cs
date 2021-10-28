using System.Collections.Generic;
using System.ComponentModel;

namespace WpfApp.Models.BrowserInfo
{
    public class TypeBrowserInfo : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private List<string> _signatures;

        public List<string> Signatures
        {
            get => _signatures;
            set
            {
                _signatures = value;
                OnPropertyChanged(nameof(Signatures));
            }
        }

        public TypeBrowserInfo()
        {
            _signatures = new List<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}