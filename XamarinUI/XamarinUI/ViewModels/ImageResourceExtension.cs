﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinUI.ViewModels
{
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }
            ImageSource imageSource = ImageSource.FromResource(Source);

            return imageSource;
        }
    }
}