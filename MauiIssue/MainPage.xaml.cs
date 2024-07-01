using System.Collections.ObjectModel;

namespace MauiIssue;

public partial class MainPage : ContentPage
{
    int count = 0;

    public ObservableCollection<string> Options { get; } = [];
    int _selectedIndex;
    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            _selectedIndex = value;
            OnPropertyChanged(nameof(SelectedIndex));
            if (SelectedIndex == 0)
            {
                // Insert new option at the beginning
                Options.Insert(0, $"Inserted Option {count++}");
                // Increment SelectedIndex to keep what was previously the first option selected
                SelectedIndex++;
            }
        }
    }

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        Options.Add("Option 1");
        Options.Add("Option 2");
        Options.Add("Option 3");
        SelectedIndex = 1;
    }
}

