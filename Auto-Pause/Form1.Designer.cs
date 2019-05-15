namespace Auto_Pause
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.processBox = new System.Windows.Forms.ComboBox();
            this.processLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.filterLabel = new System.Windows.Forms.Label();
            this.filterField = new System.Windows.Forms.TextBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.setForegroundButton = new System.Windows.Forms.Button();
            this.playerBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.shortcutBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.getForegroundButton = new System.Windows.Forms.Button();
            this.doMinimizeBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // processBox
            // 
            this.processBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.processBox.FormattingEnabled = true;
            this.processBox.Location = new System.Drawing.Point(12, 28);
            this.processBox.Name = "processBox";
            this.processBox.Size = new System.Drawing.Size(521, 21);
            this.processBox.TabIndex = 0;
            this.processBox.SelectedValueChanged += new System.EventHandler(this.processBox_SelectedValueChanged);
            // 
            // processLabel
            // 
            this.processLabel.AutoSize = true;
            this.processLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processLabel.Location = new System.Drawing.Point(12, 5);
            this.processLabel.Name = "processLabel";
            this.processLabel.Size = new System.Drawing.Size(83, 20);
            this.processLabel.TabIndex = 1;
            this.processLabel.Text = "Processes";
            this.processLabel.Click += new System.EventHandler(this.processLabel_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(539, 28);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(57, 21);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterLabel.Location = new System.Drawing.Point(12, 52);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(44, 20);
            this.filterLabel.TabIndex = 3;
            this.filterLabel.Text = "Filter";
            // 
            // filterField
            // 
            this.filterField.Location = new System.Drawing.Point(12, 75);
            this.filterField.Name = "filterField";
            this.filterField.Size = new System.Drawing.Size(521, 20);
            this.filterField.TabIndex = 4;
            this.filterField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filterField_KeyDown);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(540, 75);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(55, 19);
            this.filterButton.TabIndex = 5;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Auto-Pause";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // setForegroundButton
            // 
            this.setForegroundButton.Location = new System.Drawing.Point(12, 101);
            this.setForegroundButton.Name = "setForegroundButton";
            this.setForegroundButton.Size = new System.Drawing.Size(97, 34);
            this.setForegroundButton.TabIndex = 6;
            this.setForegroundButton.Text = "Set Foreground";
            this.setForegroundButton.UseVisualStyleBackColor = true;
            this.setForegroundButton.Click += new System.EventHandler(this.setForegroundButton_Click);
            // 
            // playerBox
            // 
            this.playerBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playerBox.FormattingEnabled = true;
            this.playerBox.Location = new System.Drawing.Point(12, 169);
            this.playerBox.Name = "playerBox";
            this.playerBox.Size = new System.Drawing.Size(202, 21);
            this.playerBox.TabIndex = 7;
            this.playerBox.SelectedValueChanged += new System.EventHandler(this.playerBox_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Player";
            // 
            // shortcutBox
            // 
            this.shortcutBox.Enabled = false;
            this.shortcutBox.Location = new System.Drawing.Point(227, 169);
            this.shortcutBox.Name = "shortcutBox";
            this.shortcutBox.ReadOnly = true;
            this.shortcutBox.Size = new System.Drawing.Size(306, 20);
            this.shortcutBox.TabIndex = 9;
            this.shortcutBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.shortcutBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(223, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Pause Shortcut";
            // 
            // getForegroundButton
            // 
            this.getForegroundButton.Location = new System.Drawing.Point(117, 101);
            this.getForegroundButton.Name = "getForegroundButton";
            this.getForegroundButton.Size = new System.Drawing.Size(97, 34);
            this.getForegroundButton.TabIndex = 11;
            this.getForegroundButton.Text = "Get Foreground";
            this.getForegroundButton.UseVisualStyleBackColor = true;
            this.getForegroundButton.Click += new System.EventHandler(this.getForegroundButton_Click);
            // 
            // doMinimizeBox
            // 
            this.doMinimizeBox.AutoSize = true;
            this.doMinimizeBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doMinimizeBox.Location = new System.Drawing.Point(14, 208);
            this.doMinimizeBox.Name = "doMinimizeBox";
            this.doMinimizeBox.Size = new System.Drawing.Size(164, 17);
            this.doMinimizeBox.TabIndex = 12;
            this.doMinimizeBox.Text = "Minimize Window after toggle";
            this.doMinimizeBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(608, 254);
            this.Controls.Add(this.doMinimizeBox);
            this.Controls.Add(this.getForegroundButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shortcutBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playerBox);
            this.Controls.Add(this.setForegroundButton);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.filterField);
            this.Controls.Add(this.filterLabel);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.processLabel);
            this.Controls.Add(this.processBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Auto-Pause";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox processBox;
        private System.Windows.Forms.Label processLabel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.TextBox filterField;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button setForegroundButton;
        private System.Windows.Forms.ComboBox playerBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox shortcutBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button getForegroundButton;
        private System.Windows.Forms.CheckBox doMinimizeBox;
    }
}

