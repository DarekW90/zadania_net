using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_3_binding_do_klas_C_
{
    public enum FilmFormat { VHS, DVD, BlueRay }
    public enum MusicFormat { Kaseta, CD, Pendrive }

    public class MediaItem : INotifyPropertyChanged
    {
        private string _title;
        private string _creator;
        private string _publisher;
        private DateTime _releaseDate;
        private string _mediaType;
        private TimeSpan _length;

        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(nameof(Title)); }
        }

        public string Creator
        {
            get => _creator;
            set { _creator = value; OnPropertyChanged(nameof(Creator)); }
        }

        public string Publisher
        {
            get => _publisher;
            set { _publisher = value; OnPropertyChanged(nameof(Publisher)); }
        }

        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set { _releaseDate = value; OnPropertyChanged(nameof(ReleaseDate)); }
        }

        public string MediaType
        {
            get => _mediaType;
            set { _mediaType = value; OnPropertyChanged(nameof(MediaType)); }
        }

        public string Length
        {
            get => _length.ToString(@"hh\:mm\:ss");
            set { _length = TimeSpan.Parse(value); OnPropertyChanged(nameof(Length)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}