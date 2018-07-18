﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSeminarioCic.Views.ViewGeneral
{
    public partial class DetalleFeed : ContentPage
    {
        public DetalleFeed(Publicacion p, bool NaviBar)
        {
            if (p == null)
                throw new ArgumentNullException();
            InitializeComponent();
            if (NaviBar)
            {
                listComments1.IsVisible = true;
                stack1.IsVisible = true;
            }
               
            else
            {
                listComments.IsVisible = true;
                stack.IsVisible = true;
            }

            this.BindingContext = p;
        }

        private void KaipNum_Clicked(object sender, EventArgs e)
        {

        }

        private void CommentNum_Clicked(object sender, EventArgs e)
        {

        }
    }
}