using System.Collections.Generic;
using System.ComponentModel;


namespace WpfApp.Models.BrowserInfo
{
    public class NamespaceBrowserInfo : INotifyPropertyChanged
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
        
        private List<TypeBrowserInfo> _types;

        public List<TypeBrowserInfo> Types
        {
            get => _types;
            set
            {
                _types = value;
                OnPropertyChanged(nameof(Types));
            }
        }

        public NamespaceBrowserInfo()
        {
            _types = new List<TypeBrowserInfo>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}