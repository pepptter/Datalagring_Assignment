using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using LibraryApp.Business;
using LibraryApp.Infrastructure;

namespace YourWpfApp
{
    public partial class App : Application
    {
        private IServiceProvider serviceProvider;

    }
}
