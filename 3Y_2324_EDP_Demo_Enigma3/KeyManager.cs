using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3Y_2324_EDP_Demo_Enigma3
{
    internal static class KeyManager
    {
        private static Dictionary<Key, Char?> KeyCharPairs = new Dictionary<Key, Char?>()
        {
            [Key.Space] = ' ',
            [Key.CapsLock] = null,
            [Key.LeftShift] = null,
            [Key.Oem1] = ';',
            [Key.Oem2]= '/',
            [Key.Oem3]= '`',
            [Key.Oem4]= '[',
            [Key.Oem5]= '\\',
            [Key.Oem6]= ']',
            [Key.Oem7]= '\'',
            [Key.OemComma]= ',',
            [Key.OemMinus]= '-',
            [Key.OemPeriod]= '.',
            [Key.OemPlus]= '=',
            [Key.OemOpenBrackets]= '[',
            [Key.Oem6]= ']',
            [Key.Oem7]= '\''
        };
        public static bool ShiftPressed { get; set; } = false;
        public static bool CapsLockPressed { get; set;} = false;

        public static char? MapKey(Key key)
        {
            if (KeyCharPairs.ContainsKey(key))
            {
                return KeyCharPairs[key];
            }
            if (int.TryParse(key.ToString()[1].ToString(), out int a))
            {
                return a.ToString()[0];
            }
            else if (CapsLockPressed)
            {
                if (ShiftPressed)
                {
                    return key.ToString().ToLower()[0];
                }
                return key.ToString().ToUpper()[0];
            }
            else if (ShiftPressed)
            {
                return key.ToString().ToUpper()[0];
            }


            return key.ToString().ToLower()[0];
        }
    }
}
