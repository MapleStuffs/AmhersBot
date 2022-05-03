using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace Amherst
{
    internal class BotFunctions
    {
        const uint WM_KEYDOWN = 0x0100;
        const uint WM_KEYUP = 0x0101;


        //function to send a key press to window, inputs are window handle, virtual key int for the key, and the delay in ms
        public void PressVirtualKey(HandleRef hwnd, int key, int delay)
        {
            //create new class instance
            win32api win32class = new win32api();
            //do whatever the fuck this is to change the key to lparam some left shift or some shit
            int lparam = (key << 16) + 1;

            //call the keyup
            win32class.PostMessageSafe(hwnd, WM_KEYDOWN, (IntPtr)key, IntPtr.Zero);

            //sleep for delay specified
            Thread.Sleep(delay);
        }


        //function to send a key press to window, inputs are window handle, virtual key int for the key, and the delay in ms
        public void PressKey(HandleRef hwnd, int key, int delay)
        {
            //define all params for lparam that need to be filled out
            int repeatCount = 0; //no repeat
            int extended = 0; //not extended key
            int context = 0; //not too sure about this
            int previousState = 0; //previous state up
            int transition = 0; //not in transition

            //create new class instance
            win32api win32class = new win32api();
            //this is old shit way that just held key
            int lparam = (key << 16) + 1;

            //lparam for keydown
            int lparamdown = repeatCount
                | (key << 16)
                | (extended << 24)
                | (context << 29)
                | (previousState << 30)
                | (transition << 31);
            //change needed states and create the param for up
            previousState = 1; //previous state was down
            transition = 1; //we are putting in transition now
            int lparamup = repeatCount
                | (key << 16)
                | (extended << 24)
                | (context << 29)
                | (previousState << 30)
                | (transition << 31);

            //call the keydown 
            win32class.PostMessageSafe(hwnd, WM_KEYDOWN, (IntPtr)key, (IntPtr)lparamdown);

            //call the keyup
            win32class.PostMessageSafe(hwnd, WM_KEYUP, (IntPtr)key, /*IntPtr.Zero*/(IntPtr)lparamup);

            //sleep for delay specified
            Thread.Sleep(delay);
        }

        public void KeyDown(HandleRef hwnd, int key, int delay)
        {
            //define all params for lparam that need to be filled out
            int repeatCount = 0; //no repeat
            int extended = 0; //not extended key
            int context = 0; //not too sure about this
            int previousState = 0; //previous state up
            int transition = 0; //not in transition

            //create new class instance
            win32api win32class = new win32api();
            //this is old shit way that just held key
            //int lparam = (key << 16) + 1;

            //lparam for keydown
            int lparamdown = repeatCount
                | (key << 16)
                | (extended << 24)
                | (context << 29)
                | (previousState << 30)
                | (transition << 31);

            //call the keydown 
            win32class.PostMessageSafe(hwnd, WM_KEYDOWN, (IntPtr)key, (IntPtr)lparamdown);

            //sleep for delay specified
            Thread.Sleep(delay);
        }

        public void KeyUp(HandleRef hwnd, int key)
        {
            //define all params for lparam that need to be filled out
            int repeatCount = 0; //no repeat
            int extended = 0; //not extended key
            int context = 0; //not too sure about this
            int previousState = 1; //previous state down
            int transition = 1; //transitioning to up

            int lparamup = repeatCount
                | (key << 16)
                | (extended << 24)
                | (context << 29)
                | (previousState << 30)
                | (transition << 31);
            //create new class instance
            win32api win32class = new win32api();
            //call the keyup
            win32class.PostMessageSafe(hwnd, WM_KEYUP, (IntPtr)key, (IntPtr)lparamup);
        }

        public V FindFirstValueByKeyWrapper<K,V>(Dictionary<K,V> dict, K key)
        {
            foreach (KeyValuePair<K, V> pair in dict)
            {
                if (EqualityComparer<K>.Default.Equals(pair.Key, key))
                {
                    return pair.Value;
                }
            }
            return default;
        }

        public byte[] ToByteArray(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }

        public int keyCodeLookupFromString(string key)
        {
            //create dictionary for key scan codes
            Dictionary<string, int> virtualKeyCodes = new Dictionary<string, int>
            {
                { "1", 0x31 },
                { "2", 0x32 },
                { "3", 0x33 },
                { "4", 0x34 },
                { "5", 0x35 },
                { "6", 0x36 },
                { "7", 0x37 },
                { "8", 0x38 },
                { "9", 0x39 },
                { "0", 0x30 },
                {"A", 0x41 },
                {"B", 0x42 },
                {"C", 0x43 },
                {"D", 0x44 },
                {"E", 0x45 },
                {"F", 0x46 },
                {"G", 0x47 },
                {"H", 0x48 },
                {"I", 0x49 },
                {"J", 0x4A },
                {"K", 0x4B },
                {"L", 0x4C },
                {"M", 0x4D },
                {"N", 0x4E },
                {"O", 0x4F },
                {"P", 0x50 },
                {"Q", 0x51 },
                {"R", 0x52 },
                {"S", 0x53 },
                {"T", 0x54 },
                {"U", 0x55 },
                {"V", 0x56 },
                {"W", 0x57 },
                {"X", 0x58 },
                {"Y", 0x59 },
                {"Z", 0x5A },
                {"Enter", 0x0D },
                {"Backspace", 0x08 }
            };

            //call wrapper
            int keyCode = FindFirstValueByKeyWrapper(virtualKeyCodes,key);

            return keyCode;
        }
    }
}
