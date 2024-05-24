using App8.ViewModel;
using App8.Model;
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
    public partial class EmployeeView : ContentPage
    {

        EmployeeViewModel _viewModel;
            bool _isUpdate;
            int employeeId;

        public EmployeeView()
        {
            InitializeComponent();
            //BindingContext = new EmployeeViewModel();

            _viewModel = new EmployeeViewModel();
            _isUpdate = false;
        }

        public EmployeeView(EmployeeModel obj)
        {
            InitializeComponent();
            _viewModel = new EmployeeViewModel();
            if (obj != null) 
            {
                employeeId = obj.Id;
                txtName.Text = obj.Name;
                txtEmail.Text = obj.Email;
                txtAddress.Text = obj.Address;
                _isUpdate |= true;
            }
        }

        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            EmployeeModel obj = new EmployeeModel();
            obj.Name = txtName.Text;
            obj.Email = txtEmail.Text;
            obj.Address = txtAddress.Text;

            if(_isUpdate)
            {
                obj.Id = employeeId;
                await _viewModel.UpdateEmployee(obj);
            }
            else
            {
                _viewModel.InsertEmployee(obj);
            }

            await this.Navigation.PopAsync();
        }
    }
}