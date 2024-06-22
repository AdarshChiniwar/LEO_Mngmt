using leomanagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leomanagement.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        #region Properties
        private string urlSource;
        public string UrlSource
        {
            get { return urlSource; }
            set { urlSource = value; OnPropertyChanged(nameof(UrlSource)); }
        }

        private bool isRunning;
        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; OnPropertyChanged(nameof(IsRunning)); }
        }

        #endregion

        #region Constructor
        public HomePageViewModel()
        {
            InitUI();
        }
        #endregion

        #region Functions
        public void InitUI()
        {
            IsRunning =true;
            var data = Preferences.Get("mode", string.Empty);
            if (!string.IsNullOrEmpty(data))
            {
                ApplicationModel applicationModel = JsonConvert.DeserializeObject<ApplicationModel>(data);
                if (applicationModel != null)
                {
                    UrlSource = applicationModel.Link;
                }
            }
        }
        #endregion
    }
}
