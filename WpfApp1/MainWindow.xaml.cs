using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TextFormatter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateProgress();
        }


        private void UpdateTextFormatting(object sender, RoutedEventArgs e)
        {
            FontWeight fontWeight = BoldCheckBox.IsChecked == true ? FontWeights.Bold : FontWeights.Normal;
            FontStyle fontStyle = ItalicCheckBox.IsChecked == true ? FontStyles.Italic : FontStyles.Normal;
            TextDecorationCollection textDecorations = UnderlineCheckBox.IsChecked == true ? TextDecorations.Underline : null;

            MainTextBox.FontWeight = fontWeight;
            MainTextBox.FontStyle = fontStyle;
            MainTextBox.TextDecorations = textDecorations;

       
            MainTextBox.FontSize = FontSizeSlider.Value;

            
            string selectedColor = ((ComboBoxItem)FontColorComboBox.SelectedItem)?.Content.ToString();
            MainTextBox.Foreground = selectedColor switch
            {
                "Red" => Brushes.Red,
                "Green" => Brushes.Green,
                "Blue" => Brushes.Blue,
                _ => Brushes.Black,
            };
            UpdateProgress();
        }


        private void UpdateProgress()
        {
            int progress = 0;
            if (BoldCheckBox.IsChecked == true) progress++;
            if (ItalicCheckBox.IsChecked == true) progress++;
            if (UnderlineCheckBox.IsChecked == true) progress++;
            if (FontSizeSlider.Value != 12) progress++;
            if (FontColorComboBox.SelectedIndex > -1) progress++;

            ProgressBar.Value = progress;
        }
    }
}

