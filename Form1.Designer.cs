namespace Amherst
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.attackDelay = new System.Windows.Forms.TextBox();
            this.attackComboBox = new System.Windows.Forms.ComboBox();
            this.toggleBotComboBox = new System.Windows.Forms.ComboBox();
            this.ToggleKeyLabel = new System.Windows.Forms.Label();
            this.AttackLabel = new System.Windows.Forms.Label();
            this.buffComboBox1 = new System.Windows.Forms.ComboBox();
            this.buffDelay1 = new System.Windows.Forms.TextBox();
            this.BuffKeyLabel1 = new System.Windows.Forms.Label();
            this.BuffKeyLabel2 = new System.Windows.Forms.Label();
            this.buffDelay2 = new System.Windows.Forms.TextBox();
            this.buffComboBox2 = new System.Windows.Forms.ComboBox();
            this.BuffKeyLabel3 = new System.Windows.Forms.Label();
            this.buffDelay3 = new System.Windows.Forms.TextBox();
            this.buffComboBox3 = new System.Windows.Forms.ComboBox();
            this.BuffKeyLabel4 = new System.Windows.Forms.Label();
            this.buffDelay4 = new System.Windows.Forms.TextBox();
            this.buffComboBox4 = new System.Windows.Forms.ComboBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.formCloseButton = new System.Windows.Forms.Button();
            this.nxLabel = new System.Windows.Forms.Label();
            this.UserVerifiedLabel = new System.Windows.Forms.Label();
            this.userKeyTextBox = new System.Windows.Forms.TextBox();
            this.botToggleCheckbox = new System.Windows.Forms.CheckBox();
            this.uaCheckBox = new System.Windows.Forms.CheckBox();
            this.screenCap = new Emgu.CV.UI.ImageBox();
            this.uidCopy = new System.Windows.Forms.Button();
            this.LDCaptureLabel = new System.Windows.Forms.Label();
            this.buffAnimationDelay1 = new System.Windows.Forms.TextBox();
            this.buffNumPresses1 = new System.Windows.Forms.TextBox();
            this.buffAnimationDelay2 = new System.Windows.Forms.TextBox();
            this.buffNumPresses2 = new System.Windows.Forms.TextBox();
            this.buffAnimationDelay3 = new System.Windows.Forms.TextBox();
            this.buffNumPresses3 = new System.Windows.Forms.TextBox();
            this.buffAnimationDelay4 = new System.Windows.Forms.TextBox();
            this.buffNumPresses4 = new System.Windows.Forms.TextBox();
            this.AttackDelayLabel = new System.Windows.Forms.Label();
            this.BuffDelayLabel1 = new System.Windows.Forms.Label();
            this.BuffDelayLabel2 = new System.Windows.Forms.Label();
            this.BuffDelayLabel3 = new System.Windows.Forms.Label();
            this.BuffDelayLabel4 = new System.Windows.Forms.Label();
            this.AnimationDelayLabelBuff1 = new System.Windows.Forms.Label();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.BotFunctionsTab = new System.Windows.Forms.TabPage();
            this.attackHoldSpamCheckBox = new System.Windows.Forms.CheckBox();
            this.KeyPressesBuffLabel4 = new System.Windows.Forms.Label();
            this.KeyPressesBuffLabel3 = new System.Windows.Forms.Label();
            this.KeyPressesBuffLabel2 = new System.Windows.Forms.Label();
            this.KeyPressesBuffLabel1 = new System.Windows.Forms.Label();
            this.AnimationDelayLabelBuff4 = new System.Windows.Forms.Label();
            this.AnimationDelayLabelBuff3 = new System.Windows.Forms.Label();
            this.AnimationDelayLabelBuff2 = new System.Windows.Forms.Label();
            this.MiscTab = new System.Windows.Forms.TabPage();
            this.nxTrackerCheckBox = new System.Windows.Forms.CheckBox();
            this.mapLockCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mapLockLabel = new System.Windows.Forms.Label();
            this.HacksEnabledLabel = new System.Windows.Forms.Label();
            this.LDRunningLabel = new System.Windows.Forms.Label();
            this.BotRunningLabel = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screenCap)).BeginInit();
            this.MainTabControl.SuspendLayout();
            this.BotFunctionsTab.SuspendLayout();
            this.MiscTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.button1.Location = new System.Drawing.Point(126, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "Validate";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // attackDelay
            // 
            this.attackDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.attackDelay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attackDelay.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.attackDelay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.attackDelay.Location = new System.Drawing.Point(132, 74);
            this.attackDelay.MaxLength = 5;
            this.attackDelay.Name = "attackDelay";
            this.attackDelay.ShortcutsEnabled = false;
            this.attackDelay.Size = new System.Drawing.Size(57, 23);
            this.attackDelay.TabIndex = 1;
            this.attackDelay.Text = "50";
            // 
            // attackComboBox
            // 
            this.attackComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.attackComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.attackComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.attackComboBox.FormattingEnabled = true;
            this.attackComboBox.Location = new System.Drawing.Point(5, 74);
            this.attackComboBox.Name = "attackComboBox";
            this.attackComboBox.Size = new System.Drawing.Size(121, 23);
            this.attackComboBox.TabIndex = 2;
            // 
            // toggleBotComboBox
            // 
            this.toggleBotComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.toggleBotComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toggleBotComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.toggleBotComboBox.FormattingEnabled = true;
            this.toggleBotComboBox.Location = new System.Drawing.Point(5, 21);
            this.toggleBotComboBox.Name = "toggleBotComboBox";
            this.toggleBotComboBox.Size = new System.Drawing.Size(121, 23);
            this.toggleBotComboBox.TabIndex = 3;
            // 
            // ToggleKeyLabel
            // 
            this.ToggleKeyLabel.AutoSize = true;
            this.ToggleKeyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.ToggleKeyLabel.Location = new System.Drawing.Point(6, 3);
            this.ToggleKeyLabel.Name = "ToggleKeyLabel";
            this.ToggleKeyLabel.Size = new System.Drawing.Size(64, 15);
            this.ToggleKeyLabel.TabIndex = 4;
            this.ToggleKeyLabel.Text = "Toggle Key";
            // 
            // AttackLabel
            // 
            this.AttackLabel.AutoSize = true;
            this.AttackLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.AttackLabel.Location = new System.Drawing.Point(5, 56);
            this.AttackLabel.Name = "AttackLabel";
            this.AttackLabel.Size = new System.Drawing.Size(63, 15);
            this.AttackLabel.TabIndex = 5;
            this.AttackLabel.Text = "Attack Key";
            // 
            // buffComboBox1
            // 
            this.buffComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buffComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffComboBox1.FormattingEnabled = true;
            this.buffComboBox1.Location = new System.Drawing.Point(5, 152);
            this.buffComboBox1.Name = "buffComboBox1";
            this.buffComboBox1.Size = new System.Drawing.Size(121, 23);
            this.buffComboBox1.TabIndex = 6;
            // 
            // buffDelay1
            // 
            this.buffDelay1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffDelay1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buffDelay1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buffDelay1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffDelay1.Location = new System.Drawing.Point(132, 152);
            this.buffDelay1.MaxLength = 4;
            this.buffDelay1.Name = "buffDelay1";
            this.buffDelay1.ShortcutsEnabled = false;
            this.buffDelay1.Size = new System.Drawing.Size(57, 23);
            this.buffDelay1.TabIndex = 7;
            this.buffDelay1.Text = "180";
            // 
            // BuffKeyLabel1
            // 
            this.BuffKeyLabel1.AutoSize = true;
            this.BuffKeyLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.BuffKeyLabel1.Location = new System.Drawing.Point(5, 134);
            this.BuffKeyLabel1.Name = "BuffKeyLabel1";
            this.BuffKeyLabel1.Size = new System.Drawing.Size(51, 15);
            this.BuffKeyLabel1.TabIndex = 8;
            this.BuffKeyLabel1.Text = "Buff Key";
            // 
            // BuffKeyLabel2
            // 
            this.BuffKeyLabel2.AutoSize = true;
            this.BuffKeyLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.BuffKeyLabel2.Location = new System.Drawing.Point(5, 190);
            this.BuffKeyLabel2.Name = "BuffKeyLabel2";
            this.BuffKeyLabel2.Size = new System.Drawing.Size(51, 15);
            this.BuffKeyLabel2.TabIndex = 11;
            this.BuffKeyLabel2.Text = "Buff Key";
            // 
            // buffDelay2
            // 
            this.buffDelay2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffDelay2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buffDelay2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buffDelay2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffDelay2.Location = new System.Drawing.Point(132, 208);
            this.buffDelay2.MaxLength = 4;
            this.buffDelay2.Name = "buffDelay2";
            this.buffDelay2.ShortcutsEnabled = false;
            this.buffDelay2.Size = new System.Drawing.Size(57, 23);
            this.buffDelay2.TabIndex = 10;
            this.buffDelay2.Text = "180";
            // 
            // buffComboBox2
            // 
            this.buffComboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buffComboBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffComboBox2.FormattingEnabled = true;
            this.buffComboBox2.Location = new System.Drawing.Point(5, 208);
            this.buffComboBox2.Name = "buffComboBox2";
            this.buffComboBox2.Size = new System.Drawing.Size(121, 23);
            this.buffComboBox2.TabIndex = 9;
            // 
            // BuffKeyLabel3
            // 
            this.BuffKeyLabel3.AutoSize = true;
            this.BuffKeyLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.BuffKeyLabel3.Location = new System.Drawing.Point(5, 246);
            this.BuffKeyLabel3.Name = "BuffKeyLabel3";
            this.BuffKeyLabel3.Size = new System.Drawing.Size(51, 15);
            this.BuffKeyLabel3.TabIndex = 14;
            this.BuffKeyLabel3.Text = "Buff Key";
            // 
            // buffDelay3
            // 
            this.buffDelay3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffDelay3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buffDelay3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buffDelay3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffDelay3.Location = new System.Drawing.Point(132, 264);
            this.buffDelay3.MaxLength = 4;
            this.buffDelay3.Name = "buffDelay3";
            this.buffDelay3.ShortcutsEnabled = false;
            this.buffDelay3.Size = new System.Drawing.Size(57, 23);
            this.buffDelay3.TabIndex = 13;
            this.buffDelay3.Text = "180";
            // 
            // buffComboBox3
            // 
            this.buffComboBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buffComboBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffComboBox3.FormattingEnabled = true;
            this.buffComboBox3.Location = new System.Drawing.Point(5, 264);
            this.buffComboBox3.Name = "buffComboBox3";
            this.buffComboBox3.Size = new System.Drawing.Size(121, 23);
            this.buffComboBox3.TabIndex = 12;
            // 
            // BuffKeyLabel4
            // 
            this.BuffKeyLabel4.AutoSize = true;
            this.BuffKeyLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.BuffKeyLabel4.Location = new System.Drawing.Point(5, 302);
            this.BuffKeyLabel4.Name = "BuffKeyLabel4";
            this.BuffKeyLabel4.Size = new System.Drawing.Size(51, 15);
            this.BuffKeyLabel4.TabIndex = 17;
            this.BuffKeyLabel4.Text = "Buff Key";
            // 
            // buffDelay4
            // 
            this.buffDelay4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffDelay4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buffDelay4.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buffDelay4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffDelay4.Location = new System.Drawing.Point(132, 320);
            this.buffDelay4.MaxLength = 4;
            this.buffDelay4.Name = "buffDelay4";
            this.buffDelay4.ShortcutsEnabled = false;
            this.buffDelay4.Size = new System.Drawing.Size(57, 23);
            this.buffDelay4.TabIndex = 16;
            this.buffDelay4.Text = "180";
            // 
            // buffComboBox4
            // 
            this.buffComboBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buffComboBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffComboBox4.FormattingEnabled = true;
            this.buffComboBox4.Location = new System.Drawing.Point(5, 320);
            this.buffComboBox4.Name = "buffComboBox4";
            this.buffComboBox4.Size = new System.Drawing.Size(121, 23);
            this.buffComboBox4.TabIndex = 15;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.topPanel.Controls.Add(this.VersionLabel);
            this.topPanel.Controls.Add(this.minimizeButton);
            this.topPanel.Controls.Add(this.formCloseButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(381, 20);
            this.topPanel.TabIndex = 18;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.VersionLabel.Location = new System.Drawing.Point(2, 3);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(37, 15);
            this.VersionLabel.TabIndex = 20;
            this.VersionLabel.Text = "v1.0.2";
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.minimizeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.minimizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(133)))), ((int)(((byte)(134)))));
            this.minimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(133)))), ((int)(((byte)(134)))));
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.minimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.minimizeButton.Location = new System.Drawing.Point(339, 0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(22, 20);
            this.minimizeButton.TabIndex = 19;
            this.minimizeButton.Text = "-";
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // formCloseButton
            // 
            this.formCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.formCloseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.formCloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(133)))), ((int)(((byte)(134)))));
            this.formCloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(133)))), ((int)(((byte)(134)))));
            this.formCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formCloseButton.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.formCloseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.formCloseButton.Location = new System.Drawing.Point(361, 0);
            this.formCloseButton.Name = "formCloseButton";
            this.formCloseButton.Size = new System.Drawing.Size(22, 20);
            this.formCloseButton.TabIndex = 0;
            this.formCloseButton.Text = "X";
            this.formCloseButton.UseVisualStyleBackColor = false;
            this.formCloseButton.Click += new System.EventHandler(this.formCloseButton_Click);
            // 
            // nxLabel
            // 
            this.nxLabel.AutoSize = true;
            this.nxLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.nxLabel.Location = new System.Drawing.Point(3, 67);
            this.nxLabel.Name = "nxLabel";
            this.nxLabel.Size = new System.Drawing.Size(140, 15);
            this.nxLabel.TabIndex = 21;
            this.nxLabel.Text = "NX/HR tracking disabled.";
            // 
            // UserVerifiedLabel
            // 
            this.UserVerifiedLabel.AutoSize = true;
            this.UserVerifiedLabel.ForeColor = System.Drawing.Color.Black;
            this.UserVerifiedLabel.Location = new System.Drawing.Point(10, 502);
            this.UserVerifiedLabel.Name = "UserVerifiedLabel";
            this.UserVerifiedLabel.Size = new System.Drawing.Size(75, 15);
            this.UserVerifiedLabel.TabIndex = 20;
            this.UserVerifiedLabel.Text = "User verified.";
            this.UserVerifiedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userKeyTextBox
            // 
            this.userKeyTextBox.Enabled = false;
            this.userKeyTextBox.Location = new System.Drawing.Point(8, 65);
            this.userKeyTextBox.MaxLength = 19;
            this.userKeyTextBox.Name = "userKeyTextBox";
            this.userKeyTextBox.Size = new System.Drawing.Size(227, 23);
            this.userKeyTextBox.TabIndex = 19;
            // 
            // botToggleCheckbox
            // 
            this.botToggleCheckbox.AutoSize = true;
            this.botToggleCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.botToggleCheckbox.Location = new System.Drawing.Point(133, 23);
            this.botToggleCheckbox.Name = "botToggleCheckbox";
            this.botToggleCheckbox.Size = new System.Drawing.Size(61, 19);
            this.botToggleCheckbox.TabIndex = 21;
            this.botToggleCheckbox.Text = "Toggle";
            this.botToggleCheckbox.UseVisualStyleBackColor = true;
            this.botToggleCheckbox.CheckedChanged += new System.EventHandler(this.botToggleCheckbox_CheckedChanged);
            // 
            // uaCheckBox
            // 
            this.uaCheckBox.AutoSize = true;
            this.uaCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.uaCheckBox.Location = new System.Drawing.Point(8, 6);
            this.uaCheckBox.Name = "uaCheckBox";
            this.uaCheckBox.Size = new System.Drawing.Size(153, 19);
            this.uaCheckBox.TabIndex = 22;
            this.uaCheckBox.Text = "Toggle Unlimited Attack";
            this.uaCheckBox.UseVisualStyleBackColor = true;
            this.uaCheckBox.CheckedChanged += new System.EventHandler(this.uaCheckBox_CheckedChanged);
            // 
            // screenCap
            // 
            this.screenCap.BackColor = System.Drawing.Color.Black;
            this.screenCap.Location = new System.Drawing.Point(195, 21);
            this.screenCap.Name = "screenCap";
            this.screenCap.Size = new System.Drawing.Size(158, 110);
            this.screenCap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.screenCap.TabIndex = 2;
            this.screenCap.TabStop = false;
            // 
            // uidCopy
            // 
            this.uidCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.uidCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.uidCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uidCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.uidCopy.Location = new System.Drawing.Point(8, 93);
            this.uidCopy.Name = "uidCopy";
            this.uidCopy.Size = new System.Drawing.Size(109, 24);
            this.uidCopy.TabIndex = 23;
            this.uidCopy.Text = "Copy Key";
            this.uidCopy.UseVisualStyleBackColor = false;
            this.uidCopy.Click += new System.EventHandler(this.uidCopy_Click);
            // 
            // LDCaptureLabel
            // 
            this.LDCaptureLabel.AutoSize = true;
            this.LDCaptureLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.LDCaptureLabel.Location = new System.Drawing.Point(195, 3);
            this.LDCaptureLabel.Name = "LDCaptureLabel";
            this.LDCaptureLabel.Size = new System.Drawing.Size(69, 15);
            this.LDCaptureLabel.TabIndex = 24;
            this.LDCaptureLabel.Text = "LD Capture:";
            // 
            // buffAnimationDelay1
            // 
            this.buffAnimationDelay1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffAnimationDelay1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buffAnimationDelay1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buffAnimationDelay1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffAnimationDelay1.Location = new System.Drawing.Point(195, 152);
            this.buffAnimationDelay1.MaxLength = 4;
            this.buffAnimationDelay1.Name = "buffAnimationDelay1";
            this.buffAnimationDelay1.ShortcutsEnabled = false;
            this.buffAnimationDelay1.Size = new System.Drawing.Size(87, 23);
            this.buffAnimationDelay1.TabIndex = 27;
            this.buffAnimationDelay1.Text = "1500";
            // 
            // buffNumPresses1
            // 
            this.buffNumPresses1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffNumPresses1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buffNumPresses1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buffNumPresses1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffNumPresses1.Location = new System.Drawing.Point(288, 152);
            this.buffNumPresses1.MaxLength = 2;
            this.buffNumPresses1.Name = "buffNumPresses1";
            this.buffNumPresses1.ShortcutsEnabled = false;
            this.buffNumPresses1.Size = new System.Drawing.Size(65, 23);
            this.buffNumPresses1.TabIndex = 28;
            this.buffNumPresses1.Text = "5";
            // 
            // buffAnimationDelay2
            // 
            this.buffAnimationDelay2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffAnimationDelay2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buffAnimationDelay2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buffAnimationDelay2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffAnimationDelay2.Location = new System.Drawing.Point(195, 208);
            this.buffAnimationDelay2.MaxLength = 4;
            this.buffAnimationDelay2.Name = "buffAnimationDelay2";
            this.buffAnimationDelay2.ShortcutsEnabled = false;
            this.buffAnimationDelay2.Size = new System.Drawing.Size(87, 23);
            this.buffAnimationDelay2.TabIndex = 29;
            this.buffAnimationDelay2.Text = "1500";
            // 
            // buffNumPresses2
            // 
            this.buffNumPresses2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffNumPresses2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buffNumPresses2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buffNumPresses2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffNumPresses2.Location = new System.Drawing.Point(288, 208);
            this.buffNumPresses2.MaxLength = 2;
            this.buffNumPresses2.Name = "buffNumPresses2";
            this.buffNumPresses2.ShortcutsEnabled = false;
            this.buffNumPresses2.Size = new System.Drawing.Size(65, 23);
            this.buffNumPresses2.TabIndex = 30;
            this.buffNumPresses2.Text = "5";
            // 
            // buffAnimationDelay3
            // 
            this.buffAnimationDelay3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffAnimationDelay3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buffAnimationDelay3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buffAnimationDelay3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffAnimationDelay3.Location = new System.Drawing.Point(195, 264);
            this.buffAnimationDelay3.MaxLength = 4;
            this.buffAnimationDelay3.Name = "buffAnimationDelay3";
            this.buffAnimationDelay3.ShortcutsEnabled = false;
            this.buffAnimationDelay3.Size = new System.Drawing.Size(87, 23);
            this.buffAnimationDelay3.TabIndex = 31;
            this.buffAnimationDelay3.Text = "1500";
            // 
            // buffNumPresses3
            // 
            this.buffNumPresses3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffNumPresses3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buffNumPresses3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buffNumPresses3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffNumPresses3.Location = new System.Drawing.Point(288, 264);
            this.buffNumPresses3.MaxLength = 2;
            this.buffNumPresses3.Name = "buffNumPresses3";
            this.buffNumPresses3.ShortcutsEnabled = false;
            this.buffNumPresses3.Size = new System.Drawing.Size(65, 23);
            this.buffNumPresses3.TabIndex = 32;
            this.buffNumPresses3.Text = "5";
            // 
            // buffAnimationDelay4
            // 
            this.buffAnimationDelay4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffAnimationDelay4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buffAnimationDelay4.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buffAnimationDelay4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffAnimationDelay4.Location = new System.Drawing.Point(195, 320);
            this.buffAnimationDelay4.MaxLength = 4;
            this.buffAnimationDelay4.Name = "buffAnimationDelay4";
            this.buffAnimationDelay4.ShortcutsEnabled = false;
            this.buffAnimationDelay4.Size = new System.Drawing.Size(87, 23);
            this.buffAnimationDelay4.TabIndex = 33;
            this.buffAnimationDelay4.Text = "1500";
            // 
            // buffNumPresses4
            // 
            this.buffNumPresses4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.buffNumPresses4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buffNumPresses4.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buffNumPresses4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(132)))), ((int)(((byte)(122)))));
            this.buffNumPresses4.Location = new System.Drawing.Point(288, 320);
            this.buffNumPresses4.MaxLength = 2;
            this.buffNumPresses4.Name = "buffNumPresses4";
            this.buffNumPresses4.ShortcutsEnabled = false;
            this.buffNumPresses4.Size = new System.Drawing.Size(65, 23);
            this.buffNumPresses4.TabIndex = 34;
            this.buffNumPresses4.Text = "5";
            // 
            // AttackDelayLabel
            // 
            this.AttackDelayLabel.AutoSize = true;
            this.AttackDelayLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.AttackDelayLabel.Location = new System.Drawing.Point(130, 56);
            this.AttackDelayLabel.Name = "AttackDelayLabel";
            this.AttackDelayLabel.Size = new System.Drawing.Size(64, 15);
            this.AttackDelayLabel.TabIndex = 35;
            this.AttackDelayLabel.Text = "Delay (MS)";
            // 
            // BuffDelayLabel1
            // 
            this.BuffDelayLabel1.AutoSize = true;
            this.BuffDelayLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.BuffDelayLabel1.Location = new System.Drawing.Point(130, 134);
            this.BuffDelayLabel1.Name = "BuffDelayLabel1";
            this.BuffDelayLabel1.Size = new System.Drawing.Size(53, 15);
            this.BuffDelayLabel1.TabIndex = 36;
            this.BuffDelayLabel1.Text = "Delay (S)";
            // 
            // BuffDelayLabel2
            // 
            this.BuffDelayLabel2.AutoSize = true;
            this.BuffDelayLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.BuffDelayLabel2.Location = new System.Drawing.Point(130, 190);
            this.BuffDelayLabel2.Name = "BuffDelayLabel2";
            this.BuffDelayLabel2.Size = new System.Drawing.Size(53, 15);
            this.BuffDelayLabel2.TabIndex = 37;
            this.BuffDelayLabel2.Text = "Delay (S)";
            // 
            // BuffDelayLabel3
            // 
            this.BuffDelayLabel3.AutoSize = true;
            this.BuffDelayLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.BuffDelayLabel3.Location = new System.Drawing.Point(132, 246);
            this.BuffDelayLabel3.Name = "BuffDelayLabel3";
            this.BuffDelayLabel3.Size = new System.Drawing.Size(53, 15);
            this.BuffDelayLabel3.TabIndex = 38;
            this.BuffDelayLabel3.Text = "Delay (S)";
            // 
            // BuffDelayLabel4
            // 
            this.BuffDelayLabel4.AutoSize = true;
            this.BuffDelayLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.BuffDelayLabel4.Location = new System.Drawing.Point(132, 302);
            this.BuffDelayLabel4.Name = "BuffDelayLabel4";
            this.BuffDelayLabel4.Size = new System.Drawing.Size(53, 15);
            this.BuffDelayLabel4.TabIndex = 39;
            this.BuffDelayLabel4.Text = "Delay (S)";
            // 
            // AnimationDelayLabelBuff1
            // 
            this.AnimationDelayLabelBuff1.AutoSize = true;
            this.AnimationDelayLabelBuff1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.AnimationDelayLabelBuff1.Location = new System.Drawing.Point(193, 134);
            this.AnimationDelayLabelBuff1.Name = "AnimationDelayLabelBuff1";
            this.AnimationDelayLabelBuff1.Size = new System.Drawing.Size(88, 15);
            this.AnimationDelayLabelBuff1.TabIndex = 40;
            this.AnimationDelayLabelBuff1.Text = "Animation(MS)";
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.BotFunctionsTab);
            this.MainTabControl.Controls.Add(this.MiscTab);
            this.MainTabControl.Location = new System.Drawing.Point(7, 26);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(368, 384);
            this.MainTabControl.TabIndex = 41;
            // 
            // BotFunctionsTab
            // 
            this.BotFunctionsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(133)))), ((int)(((byte)(134)))));
            this.BotFunctionsTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BotFunctionsTab.Controls.Add(this.attackHoldSpamCheckBox);
            this.BotFunctionsTab.Controls.Add(this.KeyPressesBuffLabel4);
            this.BotFunctionsTab.Controls.Add(this.LDCaptureLabel);
            this.BotFunctionsTab.Controls.Add(this.KeyPressesBuffLabel3);
            this.BotFunctionsTab.Controls.Add(this.KeyPressesBuffLabel2);
            this.BotFunctionsTab.Controls.Add(this.KeyPressesBuffLabel1);
            this.BotFunctionsTab.Controls.Add(this.AnimationDelayLabelBuff4);
            this.BotFunctionsTab.Controls.Add(this.screenCap);
            this.BotFunctionsTab.Controls.Add(this.AnimationDelayLabelBuff3);
            this.BotFunctionsTab.Controls.Add(this.AnimationDelayLabelBuff2);
            this.BotFunctionsTab.Controls.Add(this.attackDelay);
            this.BotFunctionsTab.Controls.Add(this.AnimationDelayLabelBuff1);
            this.BotFunctionsTab.Controls.Add(this.attackComboBox);
            this.BotFunctionsTab.Controls.Add(this.BuffDelayLabel4);
            this.BotFunctionsTab.Controls.Add(this.toggleBotComboBox);
            this.BotFunctionsTab.Controls.Add(this.BuffDelayLabel3);
            this.BotFunctionsTab.Controls.Add(this.ToggleKeyLabel);
            this.BotFunctionsTab.Controls.Add(this.BuffDelayLabel2);
            this.BotFunctionsTab.Controls.Add(this.AttackLabel);
            this.BotFunctionsTab.Controls.Add(this.BuffDelayLabel1);
            this.BotFunctionsTab.Controls.Add(this.buffComboBox1);
            this.BotFunctionsTab.Controls.Add(this.AttackDelayLabel);
            this.BotFunctionsTab.Controls.Add(this.buffDelay1);
            this.BotFunctionsTab.Controls.Add(this.buffNumPresses4);
            this.BotFunctionsTab.Controls.Add(this.BuffKeyLabel1);
            this.BotFunctionsTab.Controls.Add(this.buffAnimationDelay4);
            this.BotFunctionsTab.Controls.Add(this.buffComboBox2);
            this.BotFunctionsTab.Controls.Add(this.buffNumPresses3);
            this.BotFunctionsTab.Controls.Add(this.buffDelay2);
            this.BotFunctionsTab.Controls.Add(this.buffAnimationDelay3);
            this.BotFunctionsTab.Controls.Add(this.BuffKeyLabel2);
            this.BotFunctionsTab.Controls.Add(this.buffNumPresses2);
            this.BotFunctionsTab.Controls.Add(this.buffComboBox3);
            this.BotFunctionsTab.Controls.Add(this.buffAnimationDelay2);
            this.BotFunctionsTab.Controls.Add(this.buffDelay3);
            this.BotFunctionsTab.Controls.Add(this.buffNumPresses1);
            this.BotFunctionsTab.Controls.Add(this.BuffKeyLabel3);
            this.BotFunctionsTab.Controls.Add(this.buffAnimationDelay1);
            this.BotFunctionsTab.Controls.Add(this.buffComboBox4);
            this.BotFunctionsTab.Controls.Add(this.buffDelay4);
            this.BotFunctionsTab.Controls.Add(this.BuffKeyLabel4);
            this.BotFunctionsTab.Controls.Add(this.botToggleCheckbox);
            this.BotFunctionsTab.Location = new System.Drawing.Point(4, 24);
            this.BotFunctionsTab.Name = "BotFunctionsTab";
            this.BotFunctionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.BotFunctionsTab.Size = new System.Drawing.Size(360, 356);
            this.BotFunctionsTab.TabIndex = 0;
            this.BotFunctionsTab.Text = "Bot Functions";
            // 
            // attackHoldSpamCheckBox
            // 
            this.attackHoldSpamCheckBox.AutoSize = true;
            this.attackHoldSpamCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.attackHoldSpamCheckBox.Location = new System.Drawing.Point(6, 108);
            this.attackHoldSpamCheckBox.Name = "attackHoldSpamCheckBox";
            this.attackHoldSpamCheckBox.Size = new System.Drawing.Size(179, 19);
            this.attackHoldSpamCheckBox.TabIndex = 48;
            this.attackHoldSpamCheckBox.Text = "Attack Hold (On)/Spam (Off)";
            this.attackHoldSpamCheckBox.UseVisualStyleBackColor = true;
            // 
            // KeyPressesBuffLabel4
            // 
            this.KeyPressesBuffLabel4.AutoSize = true;
            this.KeyPressesBuffLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.KeyPressesBuffLabel4.Location = new System.Drawing.Point(286, 302);
            this.KeyPressesBuffLabel4.Name = "KeyPressesBuffLabel4";
            this.KeyPressesBuffLabel4.Size = new System.Drawing.Size(67, 15);
            this.KeyPressesBuffLabel4.TabIndex = 47;
            this.KeyPressesBuffLabel4.Text = "Key Presses";
            // 
            // KeyPressesBuffLabel3
            // 
            this.KeyPressesBuffLabel3.AutoSize = true;
            this.KeyPressesBuffLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.KeyPressesBuffLabel3.Location = new System.Drawing.Point(286, 246);
            this.KeyPressesBuffLabel3.Name = "KeyPressesBuffLabel3";
            this.KeyPressesBuffLabel3.Size = new System.Drawing.Size(67, 15);
            this.KeyPressesBuffLabel3.TabIndex = 46;
            this.KeyPressesBuffLabel3.Text = "Key Presses";
            // 
            // KeyPressesBuffLabel2
            // 
            this.KeyPressesBuffLabel2.AutoSize = true;
            this.KeyPressesBuffLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.KeyPressesBuffLabel2.Location = new System.Drawing.Point(286, 190);
            this.KeyPressesBuffLabel2.Name = "KeyPressesBuffLabel2";
            this.KeyPressesBuffLabel2.Size = new System.Drawing.Size(67, 15);
            this.KeyPressesBuffLabel2.TabIndex = 45;
            this.KeyPressesBuffLabel2.Text = "Key Presses";
            // 
            // KeyPressesBuffLabel1
            // 
            this.KeyPressesBuffLabel1.AutoSize = true;
            this.KeyPressesBuffLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.KeyPressesBuffLabel1.Location = new System.Drawing.Point(286, 134);
            this.KeyPressesBuffLabel1.Name = "KeyPressesBuffLabel1";
            this.KeyPressesBuffLabel1.Size = new System.Drawing.Size(67, 15);
            this.KeyPressesBuffLabel1.TabIndex = 44;
            this.KeyPressesBuffLabel1.Text = "Key Presses";
            // 
            // AnimationDelayLabelBuff4
            // 
            this.AnimationDelayLabelBuff4.AutoSize = true;
            this.AnimationDelayLabelBuff4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.AnimationDelayLabelBuff4.Location = new System.Drawing.Point(195, 302);
            this.AnimationDelayLabelBuff4.Name = "AnimationDelayLabelBuff4";
            this.AnimationDelayLabelBuff4.Size = new System.Drawing.Size(88, 15);
            this.AnimationDelayLabelBuff4.TabIndex = 43;
            this.AnimationDelayLabelBuff4.Text = "Animation(MS)";
            // 
            // AnimationDelayLabelBuff3
            // 
            this.AnimationDelayLabelBuff3.AutoSize = true;
            this.AnimationDelayLabelBuff3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.AnimationDelayLabelBuff3.Location = new System.Drawing.Point(195, 246);
            this.AnimationDelayLabelBuff3.Name = "AnimationDelayLabelBuff3";
            this.AnimationDelayLabelBuff3.Size = new System.Drawing.Size(88, 15);
            this.AnimationDelayLabelBuff3.TabIndex = 42;
            this.AnimationDelayLabelBuff3.Text = "Animation(MS)";
            // 
            // AnimationDelayLabelBuff2
            // 
            this.AnimationDelayLabelBuff2.AutoSize = true;
            this.AnimationDelayLabelBuff2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.AnimationDelayLabelBuff2.Location = new System.Drawing.Point(193, 190);
            this.AnimationDelayLabelBuff2.Name = "AnimationDelayLabelBuff2";
            this.AnimationDelayLabelBuff2.Size = new System.Drawing.Size(88, 15);
            this.AnimationDelayLabelBuff2.TabIndex = 41;
            this.AnimationDelayLabelBuff2.Text = "Animation(MS)";
            // 
            // MiscTab
            // 
            this.MiscTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(133)))), ((int)(((byte)(134)))));
            this.MiscTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MiscTab.Controls.Add(this.nxTrackerCheckBox);
            this.MiscTab.Controls.Add(this.mapLockCheckBox);
            this.MiscTab.Controls.Add(this.uaCheckBox);
            this.MiscTab.Controls.Add(this.button1);
            this.MiscTab.Controls.Add(this.uidCopy);
            this.MiscTab.Controls.Add(this.userKeyTextBox);
            this.MiscTab.Location = new System.Drawing.Point(4, 24);
            this.MiscTab.Name = "MiscTab";
            this.MiscTab.Padding = new System.Windows.Forms.Padding(3);
            this.MiscTab.Size = new System.Drawing.Size(360, 356);
            this.MiscTab.TabIndex = 1;
            this.MiscTab.Text = "Misc";
            // 
            // nxTrackerCheckBox
            // 
            this.nxTrackerCheckBox.AutoSize = true;
            this.nxTrackerCheckBox.Location = new System.Drawing.Point(8, 44);
            this.nxTrackerCheckBox.Name = "nxTrackerCheckBox";
            this.nxTrackerCheckBox.Size = new System.Drawing.Size(93, 19);
            this.nxTrackerCheckBox.TabIndex = 25;
            this.nxTrackerCheckBox.Text = "Track NX/HR";
            this.nxTrackerCheckBox.UseVisualStyleBackColor = true;
            this.nxTrackerCheckBox.CheckedChanged += new System.EventHandler(this.nxTrackerCheckBox_CheckedChanged);
            // 
            // mapLockCheckBox
            // 
            this.mapLockCheckBox.AutoSize = true;
            this.mapLockCheckBox.Location = new System.Drawing.Point(8, 25);
            this.mapLockCheckBox.Name = "mapLockCheckBox";
            this.mapLockCheckBox.Size = new System.Drawing.Size(116, 19);
            this.mapLockCheckBox.TabIndex = 24;
            this.mapLockCheckBox.Text = "Toggle Map Lock";
            this.mapLockCheckBox.UseVisualStyleBackColor = true;
            this.mapLockCheckBox.CheckedChanged += new System.EventHandler(this.mapLockCheckBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nxLabel);
            this.panel1.Controls.Add(this.mapLockLabel);
            this.panel1.Controls.Add(this.HacksEnabledLabel);
            this.panel1.Controls.Add(this.LDRunningLabel);
            this.panel1.Controls.Add(this.BotRunningLabel);
            this.panel1.Location = new System.Drawing.Point(7, 416);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 83);
            this.panel1.TabIndex = 42;
            // 
            // mapLockLabel
            // 
            this.mapLockLabel.AutoSize = true;
            this.mapLockLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.mapLockLabel.Location = new System.Drawing.Point(3, 51);
            this.mapLockLabel.Name = "mapLockLabel";
            this.mapLockLabel.Size = new System.Drawing.Size(93, 15);
            this.mapLockLabel.TabIndex = 3;
            this.mapLockLabel.Text = "Map not locked.";
            // 
            // HacksEnabledLabel
            // 
            this.HacksEnabledLabel.AutoSize = true;
            this.HacksEnabledLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.HacksEnabledLabel.Location = new System.Drawing.Point(3, 35);
            this.HacksEnabledLabel.Name = "HacksEnabledLabel";
            this.HacksEnabledLabel.Size = new System.Drawing.Size(104, 15);
            this.HacksEnabledLabel.TabIndex = 2;
            this.HacksEnabledLabel.Text = "No hacks enabled.";
            // 
            // LDRunningLabel
            // 
            this.LDRunningLabel.AutoSize = true;
            this.LDRunningLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.LDRunningLabel.Location = new System.Drawing.Point(3, 19);
            this.LDRunningLabel.Name = "LDRunningLabel";
            this.LDRunningLabel.Size = new System.Drawing.Size(169, 15);
            this.LDRunningLabel.TabIndex = 1;
            this.LDRunningLabel.Text = "Lie detector solver not running";
            // 
            // BotRunningLabel
            // 
            this.BotRunningLabel.AutoSize = true;
            this.BotRunningLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.BotRunningLabel.Location = new System.Drawing.Point(3, 3);
            this.BotRunningLabel.Name = "BotRunningLabel";
            this.BotRunningLabel.Size = new System.Drawing.Size(142, 15);
            this.BotRunningLabel.TabIndex = 0;
            this.BotRunningLabel.Text = "Botting loop not running.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(133)))), ((int)(((byte)(134)))));
            this.ClientSize = new System.Drawing.Size(381, 525);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.UserVerifiedLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screenCap)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            this.BotFunctionsTab.ResumeLayout(false);
            this.BotFunctionsTab.PerformLayout();
            this.MiscTab.ResumeLayout(false);
            this.MiscTab.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox attackDelay;
        private ComboBox attackComboBox;
        private ComboBox toggleBotComboBox;
        private Label ToggleKeyLabel;
        private Label AttackLabel;
        private ComboBox buffComboBox1;
        private TextBox buffDelay1;
        private Label BuffKeyLabel1;
        private Label BuffKeyLabel2;
        private TextBox buffDelay2;
        private ComboBox buffComboBox2;
        private Label BuffKeyLabel3;
        private TextBox buffDelay3;
        private ComboBox buffComboBox3;
        private Label BuffKeyLabel4;
        private TextBox buffDelay4;
        private ComboBox buffComboBox4;
        private Panel topPanel;
        private Button formCloseButton;
        private Button minimizeButton;
        private TextBox userKeyTextBox;
        private Label UserVerifiedLabel;
        private CheckBox botToggleCheckbox;
        private CheckBox uaCheckBox;
        private Emgu.CV.UI.ImageBox screenCap;
        private Button uidCopy;
        private Label LDCaptureLabel;
        private TextBox buffAnimationDelay1;
        private TextBox buffNumPresses1;
        private TextBox buffAnimationDelay2;
        private TextBox buffNumPresses2;
        private TextBox buffAnimationDelay3;
        private TextBox buffNumPresses3;
        private TextBox buffAnimationDelay4;
        private TextBox buffNumPresses4;
        private Label AttackDelayLabel;
        private Label BuffDelayLabel1;
        private Label BuffDelayLabel2;
        private Label BuffDelayLabel3;
        private Label BuffDelayLabel4;
        private Label AnimationDelayLabelBuff1;
        private TabControl MainTabControl;
        private TabPage BotFunctionsTab;
        private Label KeyPressesBuffLabel4;
        private Label KeyPressesBuffLabel3;
        private Label KeyPressesBuffLabel2;
        private Label KeyPressesBuffLabel1;
        private Label AnimationDelayLabelBuff4;
        private Label AnimationDelayLabelBuff3;
        private Label AnimationDelayLabelBuff2;
        private TabPage MiscTab;
        private Panel panel1;
        private Label HacksEnabledLabel;
        private Label LDRunningLabel;
        private Label BotRunningLabel;
        private CheckBox attackHoldSpamCheckBox;
        private Label VersionLabel;
        private Label mapLockLabel;
        private CheckBox mapLockCheckBox;
        private Label nxLabel;
        private CheckBox nxTrackerCheckBox;
    }
}