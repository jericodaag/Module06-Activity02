﻿using App8.Model;
using App8.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App8.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowEmployeePage : ContentPage
    {
        EmployeeViewModel viewModel;

        public ShowEmployeePage()
        {
            InitializeComponent();
            viewModel = new EmployeeViewModel();
        }

        private void showEmployeePage()
        {
            var res = viewModel.GetAllEmployee().Result;
            lstData.ItemsSource = res;
        }

        protected override void OnAppearing()
        {
                base.OnAppearing();
                showEmployeePage();
        }

        private void btnAddRecord(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new EmployeeView());
        }
        private async void lsdata_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                EmployeeModel obj = (EmployeeModel)e.SelectedItem;
                string res = await DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

                switch (res)
                {
                    case "Update":
                        await this.Navigation.PushAsync(new EmployeeView(obj));
                        break;

                    case "Delete":
                        viewModel.DeleteEmployee(obj);
                        showEmployeePage();
                        break;
                }

                lstData.SelectedItem = null;
            }
        }
    }
}