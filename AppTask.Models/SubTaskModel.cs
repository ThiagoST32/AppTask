using System.ComponentModel;

namespace AppTask.Models
{
    public class SubTaskModel : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public bool _isCompleted { get; set; }

        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
