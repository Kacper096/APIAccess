using APIAccess.Api.Model.Search;
using APIAccess.Model;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAccess.ViewModel
{
    public class ProfileViewModel
    {
        private Profile _profile { get; }

        public Profile Profile
        {
            get => _profile;
            set { }
        }

        public ProfileViewModel()
        {
            _profile = new Profile();
        }
    }
}
