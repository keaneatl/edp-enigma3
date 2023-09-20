using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3Y_2324_EDP_Demo_Enigma3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool initialState = true;
        string defaultMessage = "Just type whatever...";

        public MainWindow()
        {
            InitializeComponent();

            if(initialState)
                lblInput.Content = defaultMessage;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            string content = lblInput.Content.ToString();

            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                KeyManager.ShiftPressed = false;
            }

            if (e.Key == Key.CapsLock)
            {
                KeyManager.CapsLockPressed = !KeyManager.CapsLockPressed;
            }



            if (initialState) 
            {
                char? key = KeyManager.MapKey(e.Key);
                
                if (e.Key == Key.Back && content != "")
                {
                    lblInput.Content = content.Remove(content.Length - 1);
                }
                else if (key != null)
                {
                    initialState = false;
                    lblInput.Content = KeyManager.MapKey(e.Key);
                }
            }
            else
            {
                char? key = KeyManager.MapKey(e.Key);

                if (e.Key == Key.Back && content != "")
                {
                    lblInput.Content = content.Remove(content.Length - 1);
                }
                else if (key != null)
                {
                    lblInput.Content += KeyManager.MapKey(e.Key).ToString();
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                KeyManager.ShiftPressed = true;
            }
        }
    }
}
