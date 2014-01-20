using System.Windows;
using System.Windows.Input;

namespace MedievalInterface
{
    /// <summary>
    /// Interaction logic for GameControler.xaml
    /// </summary>
    public partial class GameControler
    {
        public GameControler()
        {
            InitializeComponent();
        }

        private void TextboxInput_OnPreviewInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPause_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
