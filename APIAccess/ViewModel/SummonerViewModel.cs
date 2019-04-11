using APIAccess.Api;
using APIAccess.Model.Exception;
using Helpers;
using System;
using System.Windows.Input;
using APIAccess.Api.Model;
using APIAccess.View;
using APIAccess.Api.Model.Search;
using System.Threading.Tasks;

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
                if(ok)
                {
                    var lig = new League();
                    lig.Show();
                }
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
        public ICommand Search { get; set; }
        public ICommand Cancel { get; set; }
        #endregion

        #region Constructors
        public SummonerViewModel()
        {
            Search = new RelayCommand(s =>
            {   IsOk = this.SearchSummoner(out string _tempname);
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
        private bool SearchSummoner( string name)
        {
            try
            {
               
               var summ = new SummonerV4(region);
               SummonerDTO dtoo =  summ.GetSummonerByName(summoner);
               name = dtoo.Name;
                ArchiveSummoner(dtoo);
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
        /// <summary>
        /// Archive names to the static class. So we can delivery data to profile.
        /// </summary>
        /// <param name="summoner"></param>
        private void ArchiveSummoner(SummonerDTO summoner)
        {
            Access.Clear();
            Access.Summoner = summoner;
            Access.Region = region;
        }
        #endregion

        
    }
}
