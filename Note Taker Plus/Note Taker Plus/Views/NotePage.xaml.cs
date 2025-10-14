using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Storage;
using System.Threading.Tasks;

using Note_Taker_Plus.Models;

namespace Note_Taker_Plus.Views;

public sealed partial class NotePage : Page
{
    private Note? noteModel;
    
    public NotePage()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        if (e.Parameter is Note note)
        {
            noteModel = note;
        }
        else
        {
            noteModel = new Note();
        }
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (noteModel is not null)
        {
            await noteModel.SaveAsync();
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (noteModel is not null)
        {
            await noteModel.DeleteAsync();
        }

        if (Frame.CanGoBack == true)
        {
            Frame.GoBack();
        }
    }
}
