using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ShopProject
{
	public partial class App : Application
	{
        public App()
        {
            InitializeComponent();

            MainPage = new ShopProject.ShopPage();
            //MainPage = new TabbedPage
            //{
            //    Children =
            //              {
            //                  new Shoes(),
            //                  new Bags(),
            //                  new Accessoreis()
            //              }
            //};



        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
