using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ihbiproject.ViewModels;
using ihbiproject.Models;

namespace ihbiproject.Views
{
    public partial class Login : ContentPage
    {
        //every view must have a reference to its viewmodel
        public LoginViewModel vm { get { return (LoginViewModel)BindingContext; } }
        public Login()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        async void OnLogin_Clicked(object sender, EventArgs args)
        {
            string title = CONST.SUCCESS;
            string message = CONST.LOGIN_SUCCESS_MSG;
            string button = CONST.OK_BUTTON;
            var user = vm.Login();
            if (user != null)
            {
                title = CONST.FAIL;
                message = CONST.LOGIN_FAILED_MSG;
            }
            await DisplayAlert(title, message, button);
            //todo: move to new page
        }
        async void OnSignup_Clicked(object sender, EventArgs args)
        {
            throw new NotImplementedException("onsignup not implemented");
        }
    }
}
