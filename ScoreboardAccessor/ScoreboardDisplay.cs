using System;
using System.ComponentModel;

namespace ScoreboardAccessor
{
    public class ScoreBoardDisplay : INotifyPropertyChanged
    {
        private string _HomeTeam;
        private string _VisitorTeam;
        private int _HomeScore;
        private int _VisitorScore;

        public string HomeTeam {
            get
            {
               return _HomeTeam;
            }
            set
            {
                _HomeTeam = value;
                RaisePropertyChanged("HomeTeam");
            }
        }

        public string VisitorTeam {
            get
            {
                return _VisitorTeam;
            }
            set
            {
                _VisitorTeam = value;
                RaisePropertyChanged("VisitorTeam");
            }
        }

        public int HomeScore
        {
            get
            {
                return _HomeScore;
            }
            set
            {
                _HomeScore = value;
                RaisePropertyChanged("HomeScore");
            }
        }


        public int VisitorScore
        {
            get
            {
                return _VisitorScore;
            }
            set
            {
                _VisitorScore = value;
                RaisePropertyChanged("VisitorScore");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
