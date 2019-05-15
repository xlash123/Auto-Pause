using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Auto_Pause
{
    public partial class Form1 : Form
    {
        const int VK_K = 0x4B;
        new const int KeyUp = 0x02;
        new const int KeyDown = 0;

        public List<Keys> customKeys;
        public Dictionary<string, Keys[]> keyPairs;

        public MMDevice audioDevice;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        const int MAXTITLE = 255;

        private static Dictionary<IntPtr, String> mTitlesList;
        private PropertiesConfig props;

        private delegate bool EnumDelegate(IntPtr hWnd, int lParam);

        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool _EnumDesktopWindows(IntPtr hDesktop, EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "GetWindowText",
         ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int _GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxCount);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        private static bool EnumWindowsProc(IntPtr hWnd, int lParam)
        {
            string title = GetWindowText(hWnd);
            mTitlesList.Add(hWnd, title);
            return true;
        }

        /// <summary>
        /// Returns the caption of a windows by given HWND identifier.
        /// </summary>
        public static string GetWindowText(IntPtr hWnd)
        {
            StringBuilder title = new StringBuilder(MAXTITLE);
            int titleLength = _GetWindowText(hWnd, title, title.Capacity + 1);
            title.Length = titleLength;

            return title.ToString();
        }

        /// <summary>
        /// Returns the caption of all desktop windows.
        /// </summary>
        public static void GetDesktopWindows()
        {
            mTitlesList = new Dictionary<IntPtr, String>();
            EnumDelegate enumfunc = new EnumDelegate(EnumWindowsProc);
            IntPtr hDesktop = IntPtr.Zero; // current desktop
            bool success = _EnumDesktopWindows(hDesktop, enumfunc, IntPtr.Zero);
            if (!success)
            {
                // Get the last Win32 error code
                int errorCode = Marshal.GetLastWin32Error();

                string errorMessage = String.Format("EnumDesktopWindows failed with code {0}.", errorCode);
                throw new Exception(errorMessage);
            }
        }

        public Form1()
        {
            mTitlesList = new Dictionary<IntPtr, String>();
            customKeys = new List<Keys>();

            keyPairs = new Dictionary<string, Keys[]>
            {
                { "YouTube", new Keys[] { Keys.K } },
                { "Windows Media Player", new Keys[] { Keys.ControlKey, Keys.P } },
                { "iTunes", new Keys[] { Keys.Space } },
                { "QuickTime", new Keys[] { Keys.Space } },
                { "VLC Media Player", new Keys[] { Keys.Space } },
                { "Netflix", new Keys[] { Keys.Space } },
                { "Groove Music", new Keys[] { Keys.Space } }
            };

            InitializeComponent();

            var dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString(), "AutoPause/");
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
            props = new PropertiesConfig(Path.Combine(dirPath, "config.properties"));
            this.doMinimizeBox.Checked = props.get("doMinimize", "false").Equals("True");

            playerBox.Items.AddRange(keyPairs.Keys.ToArray());
            playerBox.Items.Add("Custom");

            notifyIcon.ContextMenu = new ContextMenu();
            var menuItem = new MenuItem("E&xit", Close);
            notifyIcon.ContextMenu.MenuItems.Add(menuItem);
            audioDevice = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            audioDevice.AudioEndpointVolume.OnVolumeNotification += OnMute;

            Hide();
            notifyIcon.Visible = true;

            GetDesktopWindows();
            filter();
        }

        protected override void OnClosed(EventArgs e)
        {
            Close(null, e);
        }

        private void Close(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Console.WriteLine("Kill");

            props.set("doMinimize", this.doMinimizeBox.Checked);
            props.Save();

            Application.Exit();
        }

        private void processLabel_Click(object sender, EventArgs e)
        {

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            GetDesktopWindows();
            filter();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            filter();
        }

        public void filter()
        {
            processBox.Items.Clear();
            var filter = filterField.Text.ToLower();
            var enumerator = mTitlesList.GetEnumerator();
            foreach (var current in mTitlesList)
            {
                var title = current.Value.Trim();
                var entry = current.Key + ": ";
                if (title.Length > 0)
                {
                    entry += title;
                }
                else entry += "[No Title]";
                if (entry.ToLower().Contains(filter))
                {
                    processBox.Items.Add(entry);
                }
            }
            if(processBox.Items.Count > 0) processBox.SelectedIndex = 0;
        }

        private delegate string GetTextDel();

        private string GetText()
        {
            if (processBox.InvokeRequired)
            {
                GetTextDel d = new GetTextDel(GetText);
                return (string) this.Invoke(d);
            }
            else
            {
                return processBox.Text;
            }
        }

        private void OnMute(AudioVolumeNotificationData data)
        {
            Console.WriteLine("On Mute");
            string text = GetText();
            if (text.Length == 0) return;
            IntPtr hWnd;
            try
            {
                hWnd = new IntPtr(int.Parse(text.Substring(0, text.IndexOf(":"))));
            }catch (FormatException)
            {
                hWnd = new IntPtr(0);
            }

            IntPtr currentWindow = GetForegroundWindow();

            if (Control.ModifierKeys != Keys.Control)
            {
                ShowWindow(hWnd, 9);
                SetForegroundWindow(hWnd);
                TogglePause();
                if (this.doMinimizeBox.Checked) ShowWindow(hWnd, 6);
                SetForegroundWindow(currentWindow);
            }
        }

        private void TogglePause()
        {
            Thread.Sleep(30);

            foreach (Keys k in customKeys)
            {
                keybd_event((byte) k, 0, KeyDown, 0);
            }
            foreach (Keys k in customKeys)
            {
                keybd_event((byte)k, 0, KeyUp, 0);
            }

            Thread.Sleep(30);
        }
        
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void filterField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filter();
            }
        }

        private void playerBox_SelectedValueChanged(object sender, EventArgs e)
        {
            shortcutBox.Enabled = playerBox.Text == "Custom";
            if (playerBox.Text != "Custom")
            {
                customKeys.Clear();
                customKeys.AddRange(keyPairs[playerBox.Text]);
            }
            shortcutBox.Text = "";
            foreach (var k in customKeys)
            {
                shortcutBox.Text += k.ToString() + " + ";
            }
            if(shortcutBox.Text.Length > 0) shortcutBox.Text = shortcutBox.Text.Substring(0, shortcutBox.Text.Length - 3);
        }

        private void shortcutBox_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keyPressed = e.KeyCode;
            customKeys = customKeys.Where(k => System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.KeyInterop.KeyFromVirtualKey((int)k))).ToList();
            if (!customKeys.Contains(keyPressed))
            {
                if (keyPressed == Keys.ControlKey)
                {
                    customKeys.Insert(0, keyPressed);
                }
                else if (keyPressed == Keys.ShiftKey && customKeys.Count > 0)
                {
                    customKeys.Insert(1, keyPressed);
                }
                else customKeys.Add(keyPressed);
            }
            shortcutBox.Text = "";
            foreach (var k in customKeys)
            {
                shortcutBox.Text += k.ToString() + " + ";
            }
            shortcutBox.Text = shortcutBox.Text.Substring(0, shortcutBox.Text.Length - 3);
        }

        private void getForegroundButton_Click(object sender, EventArgs e)
        {
            Thread.Sleep(1500);
            IntPtr hWnd = GetForegroundWindow();
            filterField.Text = hWnd.ToString();
            filter();
        }

        private void processBox_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (var player in keyPairs.Keys)
            {
                if (processBox.Text.Contains(player))
                {
                    playerBox.Text = player;
                    break;
                }
            }
        }

        private void setForegroundButton_Click(object sender, EventArgs e)
        {
            var text = processBox.Text;
            var hWnd = new IntPtr(int.Parse(text.Substring(0, text.IndexOf(":"))));
            ShowWindow(hWnd, 9);
            SetForegroundWindow(hWnd);
        }
    }
}
