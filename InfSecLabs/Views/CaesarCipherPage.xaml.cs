namespace InfSecLabs.Views;

public partial class CaesarCipherPage : ContentPage
{
	public CaesarCipherPage()
	{
		InitializeComponent();
	}

    private void ShiftEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
        {
            if (int.TryParse(entry.Text, out int value))
            {
                if (value < 1 || value > 50)
                {
                    entry.Text = e.OldTextValue;
                }
            }
            else if (!string.IsNullOrWhiteSpace(entry.Text))
            {
                entry.Text = e.OldTextValue;
            }
        }
    }
}