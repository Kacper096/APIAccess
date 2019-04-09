using APIAccess.Api;
using APIAccess.Model.Exception;
using Helpers;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace APIAccess.ViewModel
{
    public class SummonerViewModel : ObservableObject
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

        /// <summary>
        /// This property helps to manipulate about validation.
        /// </summary>
        private bool IsOk
        {
            get => ok;
            set
            {
                SetProperty<bool>(ref ok, value);
            }
        }

        /// <summary>
        /// Checks the validation. If some gone wrong Welcome sends Data to View.
        /// </summary>
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
        
        /// <summary>
        /// Sets the color in the View. If some gone wrong label gets the red background until label gets the 
        /// green foreground label.
        /// </summary>
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
        public SummonerViewModel()
        {
            SignUp = new RelayCommand(s =>
            {  IsOk = this.SearchSummoner(out string _tempname);
                Welcome = _tempname;
            });

            Cancel = new RelayCommand(c => this.ResetSummoner());
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Searchs Summoner By Name
        /// </summary>
        /// <returns></returns>
        private  bool SearchSummoner(out string name)
        {
            
            try
            {
               
               var summ = new SummonerV4(region);
               SummonerDTO dtoo =  summ.GetSummonerByName(summoner);
               name = dtoo.Name;
               
               return true;
               
            }
            catch(HttpException e)
            {

                name = e.Message;
                return false;
            }
            catch(RegionException e)
            {
                name = e.Message;
                return false;

            }
            catch(SummonerException e)
            {

                name = e.Message;
                return false;
            }
            catch(Exception e)
            {

                name = e.Message;
                return false;
                
            }
            

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
