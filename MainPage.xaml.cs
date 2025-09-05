﻿using SimpleCalc.ViewModel;

namespace SimpleCalc
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }

}
