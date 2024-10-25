using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AppTask.Models
{
    public class TaskModel : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public DateTime FinalDate { get; set; }

        private bool _isCompleted;
        public bool IsCompleted { 
            get { return _isCompleted; } 
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }

        public DateTime Create {  get; set; }

        public DateTime Updated { get; set; }

        public ObservableCollection<SubTaskModel> SubTasks { get; set; } = new ObservableCollection<SubTaskModel>();
        public TaskModel() { }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
