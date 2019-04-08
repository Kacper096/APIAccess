using APIAccess.Api;
using Helpers;
using System.Windows.Input;


namespace APIAccess.ViewModel
{
    public class ViewModelMain : ObservableObject
    {
        #region Private Fields
        string region = string.Empty;
        string summoner = string.Empty;
        bool ok = false;
        #endregion

        #region Properties
        public string Region
        {
            get => region;
            set
            {
                var newregion = value;
                SetProperty<string>(ref region, newregion,this.Region.ToString());
            }
        }

        public string Summoner
        {
            get => summoner;
            set
            {
                var newsummoner = value;
                SetProperty<string>(ref summoner, newsummoner, this.Summoner.ToString());
            }
        }
        public bool IsOk
        {
            get => ok;
            set
            {
                var _ok = value;
                SetProperty<bool>(ref ok, _ok, this.IsOk.ToString());
            }
        }
        #endregion

        #region Commands
        public ICommand SignUp { get; set; }
        #endregion

        #region Constructors
        public ViewModelMain()
        {
            SignUp = new RelayCommand(s => ok = this.SearchSummoner());
        }
        #endregion

        #region Private Methods
        private bool SearchSummoner()
        {
            var summ = new SummonerV4(region);
            SummonerDTO dtoo = summ.GetSummonerByName(summoner);

            return dtoo != null;
        }
        #endregion

    }
}
