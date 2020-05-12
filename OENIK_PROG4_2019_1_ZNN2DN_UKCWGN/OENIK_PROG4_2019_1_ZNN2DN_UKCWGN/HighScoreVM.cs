using _2048.Data;
using _2048.Repository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OENIK_PROG4_2019_1_ZNN2DN_UKCWGN
{
    class HighScoreVM : ViewModelBase
    {
        private GameRepository repo;
        private ObservableCollection<PLAYER> players;

        public ObservableCollection<PLAYER> Players
        {
            get
            {
                return this.players;
            }

            set
            {
                this.Set(ref this.players, value);
            }
        }

        public ICommand AddCommand { get; private set; }

        public HighScoreVM()
        {
            this.repo = new GameRepository();
            this.repo.AddPlayer("asd", 16, 16);
            this.repo.AddPlayer("bsd", 250, 128);
            this.repo.AddPlayer("csd", 0, 0);
            this.players = new ObservableCollection<PLAYER>(this.repo.GetPlayerByScore());
            this.AddCommand = new RelayCommand(() => this.repo.AddPlayer(null, 0, 0));
        }
    }
}
