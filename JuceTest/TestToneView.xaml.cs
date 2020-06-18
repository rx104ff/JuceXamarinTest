using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JuceTest
{
    public partial class TestToneView : ContentPage
    {
        protected TestToneViewModel ViewModel => BindingContext as TestToneViewModel;
        public TestToneView()
        {
            InitializeComponent();
            this.BindingContext = ViewModel;
        }

        void Switch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
        }
    }
}
