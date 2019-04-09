using APIAccess.Api;
using Helpers;
using System;
using System.Windows.Input;


namespace APIAccess.ViewModel
{
    public class ViewModelMain : ObservableObject
    {
        #region Private Fields
        string region = string.Empty;
        string summoner = string.Empty;
        string _welcome = string.Empty;
        bool ok = false;
        #endregion
        #region Validation Helper
        private Tuple<string, string> _validation = new Tuple<string, string>(ValidationModel.InValid.Item1, ValidationModel.Valid.Item2);
        #endregion

        #region Properties
        public string Region
        {
            get => region;
            set
            {
                SetProperty<string>(ref region, value);
            }
        }
        public string Summoner
        {
            get => summoner;
            set
            {
                SetProperty<string>(ref summoner, value);
            }
        }
        private bool IsOk
        {
            get => ok;
            set
            {
                SetProperty<bool>(ref ok, value);
            }
        }
        public string Welcome
        {
            get => _welcome;
            set
            {
                if(IsOk)
                {
                    this.Validation = new Tuple<string, string>(ValidationModel.Valid.Item1, ValidationModel.Valid.Item2);
                    var newWelcome = "Witaj " + value;
                    SetProperty<string>(ref _welcome, newWelcome);
                }
                else
                {
                    this.Validation = new Tuple<string, string>(ValidationModel.InValid.Item1, ValidationModel.InValid.Item2);
                    var newWelcome =  value;
                    SetProperty<string>(ref _welcome, newWelcome);
                }
            }
        }
        #endregion

        #region Validation Colors Properties
        
        public Tuple<string,string> Validation
        {
            get => _validation;
            set
            {
                SetProperty<Tuple<string, string>>(ref _validation, value);
            }
        }
  
        #endregion

        #region Commands
        public ICommand SignUp { get; set; }
        public ICommand Cancel { get; set; }
        #endregion

        #region Constructors
        public ViewModelMain()
        {
            SignUp = new RelayCommand(s => { IsOk = this.SearchSummoner().Item2; Welcome = this.SearchSummoner().Item1;});
            Cancel = new RelayCommand(c => this.ResetSummoner());
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Searchs Summoner By Name
        /// </summary>
        /// <returns></returns>
        private Tuple<String, bool> SearchSummoner()
        {
            try
            {
                var summ = new SummonerV4(region);
                SummonerDTO dtoo = summ.GetSummonerByName(summoner);

                return CheckSummoner(dtoo.Name);
            }
            catch(Exception)
            {
                return CheckSummoner();
                
            }
            

        }

        /// <summary>
        /// Checks the name of summoer
        /// </summary>
        /// <param name="summoner">Summoner Name</param>
        /// <returns></returns>
        private Tuple<string,bool> CheckSummoner(string summoner = null)
        {
            Tuple<string, bool> result = string.IsNullOrEmpty(summoner) ? new Tuple<string, bool>("Summoner hasn't been found.", false) : new Tuple<string, bool>(summoner, true);

            return result;
        }

        /// <summary>
        /// Resets summoner name and region in the textbox.
        /// </summary>
        private void ResetSummoner()
        {
            this.Summoner = string.Empty;
            this.Region = string.Empty;
        }
        #endregion

    }
}
