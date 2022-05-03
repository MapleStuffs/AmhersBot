using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Emgu.CV;
using Emgu.CV.Structure;
using Tesseract;
using System.Text.RegularExpressions;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Reflection;
using Squirrel;

namespace Amherst
{
    public partial class Form1 : Form
    {
        private readonly BackgroundWorker attackWorker;
        private readonly BackgroundWorker ldWorker;
        private readonly BackgroundWorker mapLockWorker;
        private readonly BackgroundWorker nxTrackerWorker;

        System.Windows.Forms.Timer dbt = new System.Windows.Forms.Timer();

        public DateTime endTime = DateTime.Now;
        object locks = new object();
        //buff global timers
        public DateTime buffglobal1 = DateTime.Now;
        public DateTime buffglobal2 = DateTime.Now;
        public DateTime buffglobal3 = DateTime.Now;
        public DateTime buffglobal4 = DateTime.Now;
        //bools for each skill (these will reset to true if number is edited)
        public bool bufffirst1 = true;
        public bool bufffirst2 = true;
        public bool bufffirst3 = true;
        public bool bufffirst4 = true;

        public Form1()
        {
            InitializeComponent();

            //create a botfunction class instance so we can use get uuid
            HardwareInfo hardwareInfo = new HardwareInfo();
            string mac = hardwareInfo.GetMACAddress();
            string procid = hardwareInfo.GetProcessorId();

            string uid = mac + procid;

            var list = Enumerable
            .Range(0, uid.Length / 4)
            .Select(i => uid.Substring(i * 4, 4));
                    string res = string.Join("-", list);
            //set textbox to uniqueid
            userKeyTextBox.Text = res;

            //assigning the movement mousedown handler
            topPanel.MouseDown += TopPanel_MouseDown;
            VersionLabel.MouseDown += VersionLabel_MouseDown;
            UserVerifiedLabel.MouseDown += UserVerifiedLabel_MouseDown; ;


            //attack and buff worker
            attackWorker = new BackgroundWorker();
            attackWorker.WorkerSupportsCancellation = true;
            attackWorker.DoWork += StartBot;
            attackWorker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            //worker.WorkerSupportsCancellation = true;

            //lie detector worker
            ldWorker = new BackgroundWorker();
            ldWorker.WorkerSupportsCancellation = true;
            ldWorker.DoWork += StartLD;
            ldWorker.RunWorkerCompleted += LdWorker_RunWorkerCompleted;

            //map lock worker
            mapLockWorker = new BackgroundWorker();
            mapLockWorker.WorkerSupportsCancellation = true;
            mapLockWorker.DoWork += MapLockWorker_DoWork;
            mapLockWorker.RunWorkerCompleted += MapLockWorker_RunWorkerCompleted;

            //nx tracker worker
            nxTrackerWorker = new BackgroundWorker();
            nxTrackerWorker.WorkerSupportsCancellation = true;
            nxTrackerWorker.WorkerReportsProgress = true;
            nxTrackerWorker.DoWork += NxTrackerWorker_DoWork;
            nxTrackerWorker.ProgressChanged += NxTrackerWorker_ProgressChanged;
            nxTrackerWorker.RunWorkerCompleted += NxTrackerWorker_RunWorkerCompleted;


            //create dictionary for key scan codes
            Dictionary<string, int> scanCodes = new Dictionary<string, int>
            {
                {"NONE",  -1 },
                {"LCTRL",  0x1D },
                {"LSHIFT", 0x2A },
                {"RSHIFT", 0x36 },
                {"SPACE", 0x39 },
                /*{"INSERT", 0x52 },*/
                {"DELETE", 0x53 },
                {"HOME", 0x47 },
                {"END", 0x4F },
                {"PGUP", 0x49 },
                {"PGDN", 0x51 },
                {"A", 0x1E },
                {"B", 0x30 },
                {"C", 0x2E },
                {"D", 0x20 },
                {"E", 0x12 },
                {"F", 0x21 },
                {"G", 0x22 },
                {"H", 0x23 },
                {"I", 0x17 },
                {"J", 0x24 },
                {"K", 0x25 },
                {"L", 0x26 },
                {"M", 0x32 },
                {"N", 0x31 },
                {"O", 0x18 },
                {"P", 0x19 },
                {"Q", 0x10 },
                {"R", 0x13 },
                {"S", 0x1F },
                {"T", 0x14 },
                {"U", 0x16 },
                {"V", 0x2F },
                {"W", 0x11 },
                {"X", 0x2D },
                {"Y", 0x15 },
                {"Z", 0x2C },
                {"1", 0x02 },
                {"2", 0x03 },
                {"3", 0x04 },
                {"4", 0x05 },
                {"5", 0x06 },
                {"6", 0x07 },
                {"7", 0x08 },
                {"8", 0x09 },
                {"9", 0x0A },
                {"0", 0x0B }
            };

            
        //set toggle button combobox
        toggleBotComboBox.DataSource = new BindingSource(scanCodes, null);
            toggleBotComboBox.DisplayMember = "Key";
            toggleBotComboBox.ValueMember = "Value";

            //set attack combobox
            attackComboBox.DataSource = new BindingSource(scanCodes, null);
            attackComboBox.DisplayMember = "Key";
            attackComboBox.ValueMember = "Value";

            //set buff1-4 combobox
            buffComboBox1.DataSource = new BindingSource(scanCodes, null);
            buffComboBox1.DisplayMember = "Key";
            buffComboBox1.ValueMember = "Value";
            buffComboBox2.DataSource = new BindingSource(scanCodes, null);
            buffComboBox2.DisplayMember = "Key";
            buffComboBox2.ValueMember = "Value";
            buffComboBox3.DataSource = new BindingSource(scanCodes, null);
            buffComboBox3.DisplayMember = "Key";
            buffComboBox3.ValueMember = "Value";
            buffComboBox4.DataSource = new BindingSource(scanCodes, null);
            buffComboBox4.DisplayMember = "Key";
            buffComboBox4.ValueMember = "Value";

            //set the keypress functions for the delay boxes
            attackDelay.KeyPress += AttackDelay_KeyPress;
            buffDelay1.KeyPress += BuffDelay1_KeyPress;
            buffDelay2.KeyPress += BuffDelay2_KeyPress;
            buffDelay3.KeyPress += BuffDelay3_KeyPress;
            buffDelay4.KeyPress += BuffDelay4_KeyPress;
            //set functions for the animation delay boxes
            buffAnimationDelay1.KeyPress += BuffAnimationDelay1_KeyPress;
            buffAnimationDelay2.KeyPress += BuffAnimationDelay2_KeyPress;
            buffAnimationDelay3.KeyPress += BuffAnimationDelay3_KeyPress;
            buffAnimationDelay4.KeyPress += BuffAnimationDelay4_KeyPress;
            //set function for the number of times pressed boxes
            buffNumPresses1.KeyPress += BuffNumPresses1_KeyPress;
            buffNumPresses2.KeyPress += BuffNumPresses2_KeyPress;
            buffNumPresses3.KeyPress += BuffNumPresses3_KeyPress;
            buffNumPresses4.KeyPress += BuffNumPresses4_KeyPress;
            //disable everything until verified
            //botToggleCheckbox.Enabled = false;
            //toggleBotComboBox.Enabled = false;
            //attackComboBox.Enabled = false;
            //attackDelay.Enabled = false;
            //attackHoldSpamCheckBox.Enabled = false;
            //buffComboBox1.Enabled = false;
            //buffDelay1.Enabled = false;
            //buffAnimationDelay1.Enabled = false;
            //buffNumPresses1.Enabled = false;
            //buffComboBox2.Enabled = false;
            //buffDelay2.Enabled = false;
            //buffAnimationDelay2.Enabled = false;
            //buffNumPresses2.Enabled = false;
            //buffComboBox3.Enabled = false;
            //buffDelay3.Enabled = false;
            //buffAnimationDelay3.Enabled = false;
            //buffNumPresses3.Enabled = false;
            //buffComboBox4.Enabled = false;
            //buffDelay4.Enabled = false;
            //buffAnimationDelay4.Enabled = false;
            //buffNumPresses4.Enabled = false;
            //uaCheckBox.Enabled = false;

            //set the users settings into the textboxes
            attackDelay.Text = Discord.Properties.Settings.Default.attackDelay;
            buffDelay1.Text = Discord.Properties.Settings.Default.buffDelay1;
            buffAnimationDelay1.Text = Discord.Properties.Settings.Default.buffAnimation1;
            buffNumPresses1.Text = Discord.Properties.Settings.Default.BuffNumPress1;
            buffDelay2.Text = Discord.Properties.Settings.Default.buffDelay2;
            buffAnimationDelay2.Text = Discord.Properties.Settings.Default.buffAnimation2;
            buffNumPresses2.Text = Discord.Properties.Settings.Default.BuffNumPress2;
            buffDelay3.Text = Discord.Properties.Settings.Default.buffDelay3;
            buffAnimationDelay3.Text = Discord.Properties.Settings.Default.buffAnimation3;
            buffNumPresses3.Text = Discord.Properties.Settings.Default.BuffNumPress3;
            buffDelay4.Text = Discord.Properties.Settings.Default.buffDelay4;
            buffAnimationDelay4.Text = Discord.Properties.Settings.Default.buffAnimation4;
            buffNumPresses4.Text = Discord.Properties.Settings.Default.BuffNumPress4;
            //set the buff keys
            attackComboBox.SelectedIndex = Discord.Properties.Settings.Default.attackKey;
            buffComboBox1.SelectedIndex = Discord.Properties.Settings.Default.buffKey1;
            buffComboBox2.SelectedIndex = Discord.Properties.Settings.Default.buffKey2;
            buffComboBox3.SelectedIndex = Discord.Properties.Settings.Default.buffKey3;
            buffComboBox4.SelectedIndex = Discord.Properties.Settings.Default.buffKey4;
        }

        
        private void UserVerifiedLabel_MouseDown(object? sender, MouseEventArgs e)
        {
            //variables for button down and hcaption
            int WM_NCLBUTTONDOWN = 0xA1;
            int HTCAPTION = 0x2;
            if (e.Button == MouseButtons.Left)
            {
                win32api.ReleaseCapture();
                win32api.SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        //function to allow for movement of the window
        private void TopPanel_MouseDown(object? sender, MouseEventArgs e)
        {
            //variables for button down and hcaption
            int WM_NCLBUTTONDOWN = 0xA1;
            int HTCAPTION = 0x2;
            if (e.Button == MouseButtons.Left)
            {
                win32api.ReleaseCapture();
                win32api.SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void VersionLabel_MouseDown(object? sender, MouseEventArgs e)
        {
            //variables for button down and hcaption
            int WM_NCLBUTTONDOWN = 0xA1;
            int HTCAPTION = 0x2;
            if (e.Button == MouseButtons.Left)
            {
                win32api.ReleaseCapture();
                win32api.SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        //runworker completed for bot worker
        private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                BotRunningLabel.Text = e.Error.ToString();
                BotRunningLabel.ForeColor = Color.DarkRed;
                botToggleCheckbox.Checked = false;
            }
            else if (e.Cancelled)
            {
                BotRunningLabel.Text = "Botting loop not running.";
            }
            else
            {
                BotRunningLabel.Text = e.Result.ToString();
                BotRunningLabel.ForeColor = Color.DarkRed;
                if (!ldWorker.IsBusy)
                {
                    botToggleCheckbox.Checked = false;
                }
            }
            //only re-enable if it's not because of the ld solver calling
            if(!ldWorker.IsBusy)
            {
                //re-enable the key selections
                attackComboBox.Enabled = true;
                attackDelay.Enabled = true;
                buffComboBox1.Enabled = true;
                buffDelay1.Enabled = true;
                buffComboBox2.Enabled = true;
                buffDelay2.Enabled = true;
                buffComboBox3.Enabled = true;
                buffDelay3.Enabled = true;
                buffComboBox4.Enabled = true;
                buffDelay4.Enabled = true;
            }
        }
        //runworker completed for ld worker
        private void LdWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                LDRunningLabel.Text = e.Error.ToString();
                LDRunningLabel.ForeColor = Color.DarkRed;
            }
            else if (e.Cancelled)
            {
                LDRunningLabel.Text = "Lie detector solver not running.";
            }
            else
            {
                LDRunningLabel.Text = e.Result.ToString();
                LDRunningLabel.ForeColor = Color.DarkRed;
                botToggleCheckbox.Checked = false;
            }
        }

        //this is the main botting loop for attacking
        private void StartBot(object? sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            var userInputs = (UserData)e.Argument;

            //class for win32api to get window handle and class for botfunction to send key
            win32api win32Api = new win32api();
            BotFunctions botFunctions = new BotFunctions();

            //intptr for windowhandle
            IntPtr hwnd = IntPtr.Zero;

            //buff temp timers
            DateTime buffend1;
            DateTime buffend2;
            DateTime buffend3;
            DateTime buffend4;

            try
            {
                //grab window handle
                hwnd = win32Api.FindAmherst("Amherst");
            }
            catch (Exception ex)
            {
                e.Result = "Botting loop not able to find Amherst window.";
                return;
            }


            //if window found start bot otherwise exit
            if (hwnd != IntPtr.Zero)
            {
                //set initial buff timers so that they can be used during botting also set first bot run to false so we never do this again
                DateTime attack = DateTime.Now;
                lock(locks)
                {
                    //check if its the first bot run for each buff if so set the buff ends to now so they buff and set bool to false
                    //buff 1
                    if(bufffirst1 == true)
                    {
                        buffend1 = DateTime.Now;
                        bufffirst1 = false;
                    }
                    else
                    {
                        buffend1 = buffglobal1;
                    }
                    //buff 2
                    if (bufffirst2 == true)
                    {
                        buffend2 = DateTime.Now;
                        bufffirst2 = false;
                    }
                    else
                    {
                        buffend2 = buffglobal2;
                    }
                    //buff 3
                    if (bufffirst3 == true)
                    {
                        buffend3 = DateTime.Now;
                        bufffirst3 = false;
                    }
                    else
                    {
                        buffend3 = buffglobal3;
                    }
                    //buff 4
                    if (bufffirst4 == true)
                    {
                        buffend4 = DateTime.Now;
                        bufffirst4 = false;
                    }
                    else
                    {
                        buffend4 = buffglobal4;
                    }
                }

                //loop to run the bot
                while (true)
                {
                    try
                    {
                        //grab window handle
                        hwnd = win32Api.FindAmherst("Amherst");
                    }
                    catch (Exception ex)
                    {
                        e.Result = "Botting loop not able to find Amherst window.";
                        return;
                    }
                    //if there is a pending cancellation then cancel
                    if (worker.CancellationPending)
                    {
                        //set the global buff timers
                        lock (locks)
                        {
                            buffglobal1 = buffend1;
                            buffglobal2 = buffend2;
                            buffglobal3 = buffend3;
                            buffglobal4 = buffend4;
                        }
                        //send all key ups for all bot keys before ending
                        //send attack key up to make sure it's not still being used
                        if (userInputs.attackKey != -1)
                        {
                            botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.attackKey);
                        }
                        if(userInputs.buffKey1 != -1)
                        {
                            botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey1);
                        }
                        if (userInputs.buffKey2 != -1)
                        {
                            botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey2);
                        }
                        if (userInputs.buffKey3 != -1)
                        {
                            botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey3);
                        }
                        if (userInputs.buffKey4 != -1)
                        {
                            botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey4);
                        }
                        e.Cancel = true;
                        break;
                    }
                    //otherwise run bot
                    else
                    {
                        try
                        {
                            //if there is a pending cancellation then cancel
                            if (worker.CancellationPending)
                            {
                                //set the global buff timers
                                lock (locks)
                                {
                                    buffglobal1 = buffend1;
                                    buffglobal2 = buffend2;
                                    buffglobal3 = buffend3;
                                    buffglobal4 = buffend4;
                                }
                                //send all key ups for all bot keys before ending
                                //send attack key up to make sure it's not still being used
                                if (userInputs.attackKey != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.attackKey);
                                }
                                if (userInputs.buffKey1 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey1);
                                }
                                if (userInputs.buffKey2 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey2);
                                }
                                if (userInputs.buffKey3 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey3);
                                }
                                if (userInputs.buffKey4 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey4);
                                }
                                e.Cancel = true;
                                break;
                            }
                            //buff 1, if the buff time + the delay is less than the current time then we need to stop and buff
                            if (userInputs.buffKey1 != -1 && DateTime.Now > buffend1)
                            {
                                //send attack key up to make sure it's not still being used
                                botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.attackKey);
                                //loop through and buff up
                                for (int i = 0; i < userInputs.buffKeyNumPresses1; i++)
                                {
                                    botFunctions.PressKey(new HandleRef(null, hwnd), userInputs.buffKey1, 40);
                                    Thread.Sleep(50);
                                }
                                //sleep for user defined delay to get buff done before moving on
                                Thread.Sleep(userInputs.buffKeyAnimationDelay1);
                                //reset buff timer
                                buffend1 = DateTime.Now.AddSeconds(userInputs.buffKeyDelay1);
                            }
                            //if there is a pending cancellation then cancel
                            if (worker.CancellationPending)
                            {
                                //set the global buff timers
                                lock (locks)
                                {
                                    buffglobal1 = buffend1;
                                    buffglobal2 = buffend2;
                                    buffglobal3 = buffend3;
                                    buffglobal4 = buffend4;
                                }
                                //send all key ups for all bot keys before ending
                                //send attack key up to make sure it's not still being used
                                if (userInputs.attackKey != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.attackKey);
                                }
                                if (userInputs.buffKey1 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey1);
                                }
                                if (userInputs.buffKey2 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey2);
                                }
                                if (userInputs.buffKey3 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey3);
                                }
                                if (userInputs.buffKey4 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey4);
                                }
                                e.Cancel = true;
                                break;
                            }
                            //buff 2, if the buff time + the delay is less than the current time then we need to stop and buff
                            if (userInputs.buffKey2 != -1 && DateTime.Now > buffend2)
                            {
                                //send attack key up to make sure it's not still being used
                                botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.attackKey);
                                //loop through and buff up
                                for (int i = 0; i < userInputs.buffKeyNumPresses2; i++)
                                {
                                    botFunctions.PressKey(new HandleRef(null, hwnd), userInputs.buffKey2, 40);
                                    Thread.Sleep(50);
                                }
                                //sleep for user defined delay to get buff done before moving on
                                Thread.Sleep(userInputs.buffKeyAnimationDelay2);
                                //reset buff timer
                                buffend2 = DateTime.Now.AddSeconds(userInputs.buffKeyDelay2);
                            }
                            //if there is a pending cancellation then cancel
                            if (worker.CancellationPending)
                            {
                                //set the global buff timers
                                lock (locks)
                                {
                                    buffglobal1 = buffend1;
                                    buffglobal2 = buffend2;
                                    buffglobal3 = buffend3;
                                    buffglobal4 = buffend4;
                                }
                                //send all key ups for all bot keys before ending
                                //send attack key up to make sure it's not still being used
                                if (userInputs.attackKey != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.attackKey);
                                }
                                if (userInputs.buffKey1 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey1);
                                }
                                if (userInputs.buffKey2 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey2);
                                }
                                if (userInputs.buffKey3 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey3);
                                }
                                if (userInputs.buffKey4 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey4);
                                }
                                e.Cancel = true;
                                break;
                            }
                            //buff 3, if the buff time + the delay is less than the current time then we need to stop and buff
                            if (userInputs.buffKey3 != -1 && DateTime.Now > buffend3)
                            {
                                //send attack key up to make sure it's not still being used
                                botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.attackKey);
                                //loop through and buff up
                                for (int i = 0; i < userInputs.buffKeyNumPresses3; i++)
                                {
                                    botFunctions.PressKey(new HandleRef(null, hwnd), userInputs.buffKey3, 40);
                                    Thread.Sleep(50);
                                }
                                //sleep for user defined delay to get buff done before moving on
                                Thread.Sleep(userInputs.buffKeyAnimationDelay3);
                                //reset buff timer
                                buffend3 = DateTime.Now.AddSeconds(userInputs.buffKeyDelay3);
                            }
                            //if there is a pending cancellation then cancel
                            if (worker.CancellationPending)
                            {
                                //set the global buff timers
                                lock (locks)
                                {
                                    buffglobal1 = buffend1;
                                    buffglobal2 = buffend2;
                                    buffglobal3 = buffend3;
                                    buffglobal4 = buffend4;
                                }
                                //send all key ups for all bot keys before ending
                                //send attack key up to make sure it's not still being used
                                if (userInputs.attackKey != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.attackKey);
                                }
                                if (userInputs.buffKey1 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey1);
                                }
                                if (userInputs.buffKey2 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey2);
                                }
                                if (userInputs.buffKey3 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey3);
                                }
                                if (userInputs.buffKey4 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey4);
                                }
                                e.Cancel = true;
                                break;
                            }
                            //buff 4, if the buff time + the delay is less than the current time then we need to stop and buff
                            if (userInputs.buffKey4 != -1 && DateTime.Now > buffend4)
                            {
                                //send attack key up to make sure it's not still being used
                                botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.attackKey);
                                //loop through and buff up
                                for (int i = 0; i < userInputs.buffKeyNumPresses4; i++)
                                {
                                    botFunctions.PressKey(new HandleRef(null, hwnd), userInputs.buffKey4, 40);
                                    Thread.Sleep(50);
                                }
                                //sleep for user defined delay to get buff done before moving on
                                Thread.Sleep(userInputs.buffKeyAnimationDelay4);
                                //reset buff timer
                                buffend4 = DateTime.Now.AddSeconds(userInputs.buffKeyDelay4);
                            }
                            //if there is a pending cancellation then cancel
                            if (worker.CancellationPending)
                            {
                                //set the global buff timers
                                lock (locks)
                                {
                                    buffglobal1 = buffend1;
                                    buffglobal2 = buffend2;
                                    buffglobal3 = buffend3;
                                    buffglobal4 = buffend4;
                                }
                                //send all key ups for all bot keys before ending
                                //send attack key up to make sure it's not still being used
                                if (userInputs.attackKey != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.attackKey);
                                }
                                if (userInputs.buffKey1 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey1);
                                }
                                if (userInputs.buffKey2 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey2);
                                }
                                if (userInputs.buffKey3 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey3);
                                }
                                if (userInputs.buffKey4 != -1)
                                {
                                    botFunctions.KeyUp(new HandleRef(null, hwnd), userInputs.buffKey4);
                                }
                                e.Cancel = true;
                                break;
                            }
                            //attack key last, if the buff time + the delay is less than the current time then we need to attack
                            if (userInputs.attackKey != -1 && attack.AddMilliseconds(userInputs.attackDelay) < DateTime.Now)
                            {
                                //if they want to spam then spam
                                if (userInputs.attackHoldSpam == false)
                                {
                                    //basic attacking right here
                                    botFunctions.PressKey(new HandleRef(null, hwnd), userInputs.attackKey, 5);
                                }
                                //if they want to hold then only send key down
                                if (userInputs.attackHoldSpam == true)
                                {
                                    //basic attacking right here
                                    botFunctions.KeyDown(new HandleRef(null, hwnd), userInputs.attackKey, 5);
                                }

                                //reset attack timer
                                attack = DateTime.Now;
                            }
                        }
                        catch (Exception ex)
                        {
                            e.Result = "Botting loop encountered an error, is game still open?";
                            return;
                        }
                    }
                    //small thread sleep
                    Thread.Sleep(1);
                }
                    
            }
            
        }

        //function for doing LD stuff
        private void StartLD(object? sender, DoWorkEventArgs e)
        {
            //bot worker args for cancelling and starting
            var userInputs = (UserData)e.Argument;
            BackgroundWorker worker = sender as BackgroundWorker;
            //user32 for getting window screenshots
            user32 user32 = new user32();
            //class for win32api to get window handle and class for botfunction to send key
            win32api win32Api = new win32api();
            BotFunctions botFunctions = new BotFunctions();
            //intptr for window handle
            IntPtr procLD = IntPtr.Zero;
            //inptr for keypresses
            IntPtr hwnd = IntPtr.Zero;
            //int for key to press
            int keyPress = 0x00;
            //boolean for seeing if we got correct ld input or not
            bool isSolved = false;
            //string for solving
            string ldanswer = "";
            //template to search for
            string templatepath = System.IO.Directory.GetCurrentDirectory() + "\\ld_template2.jpg";
            string tessdir = System.IO.Directory.GetCurrentDirectory() + "\\tessdata";
            Image<Bgr, byte> template = new Image<Bgr, byte>(templatepath); // Image A

            try
            {
                //get mainwindow handle for the opencv stuff
                procLD = Process.GetProcessesByName("Maplestory")[0].MainWindowHandle;
            }
            catch (Exception ex)
            {
                e.Result = "LD loop not able to access Maplestory process.";
                return;
            }

            //loop to run the bot
            while (true)
            {
                //if there is a pending cancellation then cancel
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                //otherwise run bot
                else
                {
                    
                    try
                    {
                        while(isSolved == false)
                        {
                            try
                            {
                                //grab window handle for sending keypresses
                                hwnd = win32Api.FindAmherst("Amherst");
                            }
                            catch (Exception ex)
                            {
                                e.Result = "LD loop not able to find Amherst window.";
                                return;
                            }
                            //if there is a pending cancellation then cancel
                            if (worker.CancellationPending)
                            {
                                e.Cancel = true;
                                break;
                            }
                            //get bitmap of the maplestory window
                            Bitmap bmp = user32.PrintWindow(procLD);
                            //convert to image so we can use opencv and display it
                            Image<Bgr, byte> emguImage = bmp.ToImage<Bgr, byte>();

                            using (Image<Gray, float> result = emguImage.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
                            {
                                double[] minValues, maxValues;
                                Point[] minLocations, maxLocations;
                                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                                if (maxValues[0] > 0.9)
                                {
                                    

                                    //set range of interest which will be just the numbers
                                    emguImage.ROI = new Rectangle(maxLocations[0].X - 110, maxLocations[0].Y - 110, 120, 40);

                                    //set the roi to grey scale
                                    Image<Gray, Byte> grayImage = emguImage.Convert<Gray, Byte>();

                                    //binarize image
                                    grayImage = grayImage.ThresholdBinary(new Gray(170), new Gray(255));
                                    //invert image
                                    CvInvoke.BitwiseNot(grayImage, grayImage);

                                    CvInvoke.Resize(grayImage, grayImage, new Size(120, 40), 2, 2, Emgu.CV.CvEnum.Inter.Cubic);
                                    //convert to bitmap
                                    Bitmap solvebmp = grayImage.ToBitmap();
                                    //set the new res
                                    solvebmp.SetResolution(300, 300);
                                    //set imagebox screencap
                                    screenCap.Image = grayImage;
                                    //convert to pix
                                    Pix img = PixConverter.ToPix(solvebmp);
                                    //create tesseract engine
                                    TesseractEngine engine = new TesseractEngine(tessdir, "eng", EngineMode.TesseractOnly);
                                    //process text
                                    Page page = engine.Process(img, PageSegMode.Auto);
                                    //get answer into string
                                    ldanswer = page.GetText();
                                    //replace newlines
                                    ldanswer = ldanswer.Replace("\n", "");

                                    //save pix image
                                    //img.Save(System.IO.Directory.GetCurrentDirectory() + "\\images\\" +ldanswer+".png", ImageFormat.Png);


                                    //if ldanswer is only numbers then we can solve and restart bot, otherwise it will loop again
                                    if (ldanswer.All(char.IsDigit))
                                    {
                                        isSolved = true;
                                    }
                                    else
                                    {
                                        //MessageBox.Show(ldanswer, "Wrong Solution");
                                    }

                                    //if is solved then solve
                                    if(isSolved == true)
                                    {
                                        //double check to make sure bot worker isn't running
                                        if(attackWorker.IsBusy)
                                        {
                                            attackWorker.CancelAsync();
                                        }
                                        //sleep to wait for attack worker to finish
                                        Thread.Sleep(2000);
                                        //if restarting send a ton of backspace chars to cancel out any attacks that may have got triggered
                                        for (int i = 0; i < 40; i++)
                                        {
                                            //find the keyCode corresponding to the char
                                            keyPress = botFunctions.keyCodeLookupFromString("Backspace");
                                            //press the key in game 
                                            botFunctions.PressVirtualKey(new HandleRef(null, hwnd), keyPress, 20);
                                            //sleep between presses
                                            Thread.Sleep(20);
                                        }
                                        //send keypresses to the window
                                        for (int i = 0; i < ldanswer.Length; i++)
                                        {
                                            //find the keyCode corresponding to the char
                                            keyPress = botFunctions.keyCodeLookupFromString(ldanswer[i].ToString());
                                            //press the key in game 
                                            botFunctions.PressVirtualKey(new HandleRef(null, hwnd), keyPress, 30);
                                            //sleep between presses
                                            Thread.Sleep(100);
                                        }
                                        //when done press enter (commented out for now)
                                        keyPress = botFunctions.keyCodeLookupFromString("Enter");
                                        botFunctions.PressVirtualKey(new HandleRef(null, hwnd), keyPress, 30);
                                        //after processing sleep before testing again to see if solver is still there
                                        Thread.Sleep(2000);

                                        //final test to see if it was solved or not
                                        //get mainwindow handle for the opencv stuff
                                        IntPtr procLDsolve = Process.GetProcessesByName("Maplestory")[0].MainWindowHandle;
                                        //get bitmap of the maplestory window
                                        Bitmap bmpsolved = user32.PrintWindow(procLDsolve);
                                        //convert to image so we can use opencv and display it
                                        Image<Bgr, byte> emguImageSolved = bmpsolved.ToImage<Bgr, byte>();

                                        using (Image<Gray, float> aftersolvecheck = emguImageSolved.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
                                        {
                                            double[] minValuespost, maxValuespost;
                                            Point[] minLocationspost, maxLocationspost;
                                            result.MinMax(out minValuespost, out maxValuespost, out minLocationspost, out maxLocationspost);

                                            //if no match then we can start the background worker otherwise we are chilling and running this whole thing again
                                            if (maxValuespost[0] < 0.98)
                                            {
                                                if (!attackWorker.IsBusy)
                                                {
                                                    attackWorker.RunWorkerAsync(userInputs);
                                                    isSolved = false;
                                                }
                                            }
                                            else
                                            {
                                                //if restarting send a ton of backspace chars to cancel out any bs we already have put in
                                                for (int i = 0; i < 30; i++)
                                                {
                                                    //find the keyCode corresponding to the char
                                                    keyPress = botFunctions.keyCodeLookupFromString("Backspace");
                                                    //press the key in game 
                                                    botFunctions.PressVirtualKey(new HandleRef(null, hwnd), keyPress, 30);
                                                    //sleep between presses
                                                    Thread.Sleep(20);
                                                }
                                            }

                                        }
                                    }
                                }
                            }
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        e.Result = "Lie detector solver encountered an error.";
                        return;
                    }
                }
                //check every .5 second to not be too intense processing wise
                Thread.Sleep(500);
            }
        }

        
        /*
        ******************************************************************************
         Managing inputs to the delay input boxes
        ******************************************************************************
        */
        private void AttackDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void BuffDelay1_KeyPress(object? sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                //lock the object and reset this buff
                lock (locks)
                {
                    bufffirst1 = true;
                }
            }
        }
        private void BuffDelay2_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                //lock the object and reset this buff
                lock (locks)
                {
                    bufffirst2 = true;
                }
            }
        }
        private void BuffDelay3_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                //lock the object and reset this buff
                lock (locks)
                {
                    bufffirst3 = true;
                }
            }
        }
        private void BuffDelay4_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                //lock the object and reset this buff
                lock (locks)
                {
                    bufffirst4 = true;
                }
            }
        }
        private void BuffNumPresses4_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BuffNumPresses3_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BuffNumPresses2_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BuffNumPresses1_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BuffAnimationDelay4_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void BuffAnimationDelay3_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BuffAnimationDelay2_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BuffAnimationDelay1_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /*
        ******************************************************************************
         Handling the form close and minimize buttons
        ******************************************************************************
        */
        private void formCloseButton_Click(object sender, EventArgs e)
        {
            //set all the settings before closing
            Discord.Properties.Settings.Default.attackDelay = attackDelay.Text;
            Discord.Properties.Settings.Default.buffDelay1 = buffDelay1.Text;
            Discord.Properties.Settings.Default.buffAnimation1 = buffAnimationDelay1.Text;
            Discord.Properties.Settings.Default.BuffNumPress1 = buffNumPresses1.Text;
            Discord.Properties.Settings.Default.buffDelay2 = buffDelay2.Text;
            Discord.Properties.Settings.Default.buffAnimation2 = buffAnimationDelay2.Text;
            Discord.Properties.Settings.Default.BuffNumPress2 = buffNumPresses2.Text;
            Discord.Properties.Settings.Default.buffDelay3 = buffDelay3.Text;
            Discord.Properties.Settings.Default.buffAnimation3 = buffAnimationDelay3.Text;
            Discord.Properties.Settings.Default.BuffNumPress3 = buffNumPresses3.Text;
            Discord.Properties.Settings.Default.buffDelay4 = buffDelay4.Text;
            Discord.Properties.Settings.Default.buffAnimation4 = buffAnimationDelay4.Text;
            Discord.Properties.Settings.Default.BuffNumPress4 = buffNumPresses4.Text;
            Discord.Properties.Settings.Default.attackKey = attackComboBox.SelectedIndex;
            Discord.Properties.Settings.Default.buffKey1 = buffComboBox1.SelectedIndex;
            Discord.Properties.Settings.Default.buffKey2 = buffComboBox2.SelectedIndex;
            Discord.Properties.Settings.Default.buffKey3 = buffComboBox3.SelectedIndex;
            Discord.Properties.Settings.Default.buffKey4 = buffComboBox4.SelectedIndex;
            Discord.Properties.Settings.Default.Save();
            Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        /*
        ******************************************************************************
         Handling toggle for bot checkbox to start ld/bot loops
        ******************************************************************************
        */
        private void botToggleCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            //try to read process if fails then exit
            try
            {
                //get mainwindow handle for the opencv stuff
                IntPtr proc = Process.GetProcessesByName("Maplestory")[0].MainWindowHandle;
            }
            catch
            {
                BotRunningLabel.Text = "Amherst window not found.";
                BotRunningLabel.ForeColor = Color.DarkRed;
                LDRunningLabel.Text = "Amherst window not found.";
                LDRunningLabel.ForeColor = Color.DarkRed;
                return;
            }
            //if not checked then start the bot
            if (botToggleCheckbox.Checked)
            {
                //create new temp class to store user input in
                UserData userInputs = new UserData()
                {
                    attackKey = (int)attackComboBox.SelectedValue,
                    attackDelay = int.Parse(attackDelay.Text),
                    attackHoldSpam = attackHoldSpamCheckBox.Checked,
                    buffKey1 = (int)buffComboBox1.SelectedValue,
                    buffKeyDelay1 = int.Parse(buffDelay1.Text),
                    buffKeyAnimationDelay1 = int.Parse(buffAnimationDelay1.Text),
                    buffKeyNumPresses1 = int.Parse(buffNumPresses1.Text),
                    buffKey2 = (int)buffComboBox2.SelectedValue,
                    buffKeyDelay2 = int.Parse(buffDelay2.Text),
                    buffKeyAnimationDelay2 = int.Parse(buffAnimationDelay2.Text),
                    buffKeyNumPresses2 = int.Parse(buffNumPresses2.Text),
                    buffKey3 = (int)buffComboBox3.SelectedValue,
                    buffKeyDelay3 = int.Parse(buffDelay3.Text),
                    buffKeyAnimationDelay3 = int.Parse(buffAnimationDelay3.Text),
                    buffKeyNumPresses3 = int.Parse(buffNumPresses3.Text),
                    buffKey4 = (int)buffComboBox4.SelectedValue,
                    buffKeyDelay4 = int.Parse(buffDelay4.Text),
                    buffKeyAnimationDelay4 = int.Parse(buffAnimationDelay4.Text),
                    buffKeyNumPresses4 = int.Parse(buffNumPresses4.Text)
                };
                //if the worker isn't already running then start
                if (!attackWorker.IsBusy)
                {
                    //set label so we know botting started
                    BotRunningLabel.Text = "Botting loop running.";
                    BotRunningLabel.ForeColor = Color.Green;
                    
                    //disable combo boxes so they can't change keys while running
                    attackComboBox.Enabled = false;
                    attackDelay.Enabled = false;
                    attackHoldSpamCheckBox.Enabled = false;
                    buffComboBox1.Enabled = false;
                    buffDelay1.Enabled = false;
                    buffAnimationDelay1.Enabled = false;
                    buffNumPresses1.Enabled = false;
                    buffComboBox2.Enabled = false;
                    buffDelay2.Enabled = false;
                    buffAnimationDelay2.Enabled = false;
                    buffNumPresses2.Enabled = false;
                    buffComboBox3.Enabled = false;
                    buffDelay3.Enabled = false;
                    buffAnimationDelay3.Enabled = false;
                    buffNumPresses3.Enabled = false;
                    buffComboBox4.Enabled = false;
                    buffDelay4.Enabled = false;
                    buffAnimationDelay4.Enabled = false;
                    buffNumPresses4.Enabled = false;
                    //run worker
                    attackWorker.RunWorkerAsync(userInputs);
                }
                //if the ldworker isn't running start it
                if (!ldWorker.IsBusy)
                {
                    //set label so we know ld stoped
                    LDRunningLabel.Text = "Lie detector solver running.";
                    LDRunningLabel.ForeColor = Color.Green;
                    //run worker
                    ldWorker.RunWorkerAsync(userInputs);
                }
            }
            //otherwise cancel the bot if it is running
            else
            {
                if(attackWorker.IsBusy)
                {
                    //set label so we know botting stoped
                    BotRunningLabel.Text = "Botting loop not running.";
                    BotRunningLabel.ForeColor = Color.DarkRed;
                    attackWorker.CancelAsync();
                }
                if (ldWorker.IsBusy)
                {
                    //set label so we know ld stoped
                    LDRunningLabel.Text = "Lie detector solver not running.";
                    LDRunningLabel.ForeColor = Color.DarkRed;
                    ldWorker.CancelAsync();
                }
                //re-enable all after bots are turned off
                attackComboBox.Enabled = true;
                attackDelay.Enabled = true;
                attackHoldSpamCheckBox.Enabled = true;
                buffComboBox1.Enabled = true;
                buffDelay1.Enabled = true;
                buffAnimationDelay1.Enabled = true;
                buffNumPresses1.Enabled = true;
                buffComboBox2.Enabled = true;
                buffDelay2.Enabled = true;
                buffAnimationDelay2.Enabled = true;
                buffNumPresses2.Enabled = true;
                buffComboBox3.Enabled = true;
                buffDelay3.Enabled = true;
                buffAnimationDelay3.Enabled = true;
                buffNumPresses3.Enabled = true;
                buffComboBox4.Enabled = true;
                buffDelay4.Enabled = true;
                buffAnimationDelay4.Enabled = true;
                buffNumPresses4.Enabled = true;
            }

        }
        /*
        ******************************************************************************
        Function for enabling/disabling UA hack
        ******************************************************************************
        */
        private void uaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //try to read process if fails then exit
            try
            {
                //get mainwindow handle for the opencv stuff
                IntPtr proc = Process.GetProcessesByName("Maplestory")[0].MainWindowHandle;
            }
            catch
            {
                HacksEnabledLabel.Text = "Amherst window not found.";
                HacksEnabledLabel.ForeColor = Color.DarkRed;
                return;
            }
            //create kernel32 class to use methods
            kernel32 kernel32 = new kernel32();

            //memory address
            int uaAddress = 0x01313020;

            //enable and disable writes
            byte[] enable = { 0xEB };
            byte[] disable = { 0x7E };

            //initiate process handle
            IntPtr procOpen = IntPtr.Zero;


            //if checked then enable UA
            if (uaCheckBox.Checked)
            {
                //get process
                procOpen = Process.GetProcessesByName("Maplestory")[0].Handle;

                //if we opened the process
                if (procOpen != IntPtr.Zero)
                {
                    //write memory
                    kernel32.WriteByte(procOpen, uaAddress, enable);

                    //close process
                }
                //change label to show it is enabled
                HacksEnabledLabel.Text = "Unlimited attack enabled.";
                HacksEnabledLabel.ForeColor = Color.Green;
            }
            //otherwise disable UA
            else
            {
                //get process
                procOpen = Process.GetProcessesByName("Maplestory")[0].Handle;

                //if we opened the process
                if (procOpen != IntPtr.Zero)
                {
                    //write memory
                    kernel32.WriteByte(procOpen, uaAddress, disable);

                    //close process
                }
                //change label to show it is disabled
                HacksEnabledLabel.Text = "No hacks enabled.";
                HacksEnabledLabel.ForeColor = Color.DarkRed;
            }
        }

        private void uidCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(userKeyTextBox.Text);
        }

        //debounce timer function
        void dbt_Tick(object? sender, System.EventArgs e)
        {
            button1.Enabled = true;
            dbt.Stop();
        }

        private void mapLockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //initialize kernel32 class for read memory
            kernel32 k32 = new kernel32();
            //initiate process handle
            IntPtr procOpen = IntPtr.Zero;
            //if checked then enable map lock, otherwise cancel map lock worker
            if (mapLockCheckBox.Checked)
            {
                if(!mapLockWorker.IsBusy)
                {
                    try
                    {
                        //get process
                        procOpen = Process.GetProcessesByName("Maplestory")[0].Handle;
                        //get map id to lock on and set text before starting lock loop
                        mapLockLabel.Text = "Map locked on map id: " + k32.ReadMapID(procOpen).ToString();
                        mapLockLabel.ForeColor = Color.Green;
                        //very small sleep
                        Thread.Sleep(5);
                        //run the lock worker
                        mapLockWorker.RunWorkerAsync();
                    }
                    catch (Exception ex)
                    {
                        mapLockLabel.Text = "Map lock loop not able to find Amherst window.";
                        return;
                    }
                    
                }
            }
            else
            {
                if (mapLockWorker.IsBusy)
                {
                    mapLockWorker.CancelAsync();
                }
            }
        }

        private void MapLockWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            
            //initialize kernel32 class for read memory
            kernel32 k32 = new kernel32();

            //initiate process handle
            IntPtr procOpen = IntPtr.Zero;

            //map variables
            int lockedmap = 0;
            int tempmap = 0;

            //do first iteration to get initial map
            try
            {
                //get process
                procOpen = Process.GetProcessesByName("Maplestory")[0].Handle;
                lockedmap = k32.ReadMapID(procOpen);
                Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                e.Result = "Map lock loop not able to find Amherst window.";
                return;
            }

            //loop to run the bot
            while (true)
            {
                try
                {
                    //get process
                    procOpen = Process.GetProcessesByName("Maplestory")[0].Handle;
                }
                catch (Exception ex)
                {
                    e.Result = "Map lock loop not able to find Amherst window.";
                    return;
                }
                //if there is a pending cancellation then cancel
                if (worker.CancellationPending)
                {
                    e.Result = "Map not locked.";
                    return;
                }
                //otherwise read map
                else
                {
                    //read map
                    tempmap = k32.ReadMapID(procOpen);
                    //compare locked map to this map and if different then stop the botting loop
                    if(lockedmap != tempmap && attackWorker.IsBusy)
                    {
                        attackWorker.CancelAsync();
                    }
                }
                //run this every 1 seconds
                Thread.Sleep(1000);
            }
        }
        private void MapLockWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                mapLockLabel.Text = e.Error.ToString();
                mapLockLabel.ForeColor = Color.DarkRed;
                mapLockCheckBox.Checked = false;
            }
            else if (e.Cancelled)
            {
                mapLockLabel.Text = "Map not locked.";
            }
            else
            {
                mapLockLabel.Text = e.Result.ToString();
                mapLockLabel.ForeColor = Color.DarkRed;
            }
            mapLockCheckBox.Checked = false;
        }

        private void nxTrackerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if checked then enable UA
            if (nxTrackerCheckBox.Checked)
            {
                //if nx tracker not running then start and change text color to green
                if(!nxTrackerWorker.IsBusy)
                {
                    nxLabel.ForeColor = Color.Green;
                    nxTrackerWorker.RunWorkerAsync();
                }
            }
            else
            {
                //if nx tracker is running then cancel
                if (nxTrackerWorker.IsBusy)
                {
                    nxTrackerWorker.CancelAsync();
                }
            }
        }
        //functions for nx tracker worker
        private void NxTrackerWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            nxLabel.Text = String.Format("NX/HR: {0:#,##0} NX", e.UserState); ;
        }

        private void NxTrackerWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                nxLabel.Text = e.Error.ToString();
                nxLabel.ForeColor = Color.DarkRed;
                nxTrackerCheckBox.Checked = false;
            }
            else if (e.Cancelled)
            {
                nxLabel.Text = "NX/HR tracking disabled.";
                nxLabel.ForeColor = Color.DarkRed;
            }
            else
            {
                nxLabel.Text = e.Result.ToString();
                nxLabel.ForeColor = Color.DarkRed;

            }
            nxTrackerCheckBox.Checked = false;
        }

        private void NxTrackerWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            //background worker object for cancellation and things
            BackgroundWorker worker = sender as BackgroundWorker;
            //intptr for proccess handle
            IntPtr procOpen;
            int basenx;
            int currentnx;
            int nxdif;
            DateTime starttime = DateTime.Now;
            double secdifference;

            double nxpersec;
            double nxperhour;

            //class isntance of kernel32 for read nx function
            kernel32 readnx = new kernel32();
            //get proc address and get the base nx to compare off of
            try
            {
                procOpen = Process.GetProcessesByName("Maplestory")[0].Handle;
                basenx = readnx.ReadNXAmt(procOpen);
            }
            catch (Exception ex)
            {
                e.Result = "NX/HR loop not able to find Maplestory.";
                return;
            }
            // loop to run the bot
            while (true)
            {
                //if there is a pending cancellation then cancel
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                try
                {
                    //get current nx and calc nxdif
                    currentnx = readnx.ReadNXAmt(procOpen);
                    //if current nx is ever = -1 we know the readnx function errored so we need to exit
                    if(currentnx == -1)
                    {
                        e.Result = "NX/HR tracking not able to read memory, did game close?";
                        break;
                    }
                    nxdif = currentnx - basenx;
                    //if somehow it is negative because they sold nx or something restart calculation
                    if(nxdif < 0)
                    {
                        basenx = currentnx;
                    }
                    //otherwise run calculation and report back
                    else
                    {
                        //calculate per hour value
                        //start with time difference
                        TimeSpan ts = DateTime.Now.Subtract(starttime);
                        //handle divide by 0 issue
                        secdifference = ts.TotalSeconds;
                        
                        //divide total nx made by seconds elapsed to get nx per second
                        nxpersec = nxdif / secdifference;
                        nxperhour = (int)nxpersec * 3600;

                        //report progress back to assign value to text element
                        worker.ReportProgress(0, nxperhour);
                    }
                    
                }
                catch (Exception ex)
                {
                    e.Result = "NX/HR loop encountered an error.";
                    return;
                }
                //sleep every second so we don't continuously run this
                Thread.Sleep(1000);
            }
        }
    }
}