namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.tbChatRead = new System.Windows.Forms.TextBox();
            this.sizeOfMap = new System.Windows.Forms.Label();
            this.listOfClients = new System.Windows.Forms.ListBox();
            this.timer = new System.Windows.Forms.Label();
            this.tbIPadress = new System.Windows.Forms.TextBox();
            this.tbPortAdress = new System.Windows.Forms.TextBox();
            this.tbChatWrite = new System.Windows.Forms.TextBox();
            this.SendMessageButton = new System.Windows.Forms.Button();
            this.timerForTimer = new System.Windows.Forms.Timer(this.components);
            this.northButton = new System.Windows.Forms.Button();
            this.eastButton = new System.Windows.Forms.Button();
            this.westButton = new System.Windows.Forms.Button();
            this.southButton = new System.Windows.Forms.Button();
            this.listOfVisiblePlayers = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.controlMap = new Client.CtrlMap();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(751, 86);
            this.tbLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbLogin.Multiline = true;
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(224, 25);
            this.tbLogin.TabIndex = 1;
            this.tbLogin.Text = "Логин";
            this.tbLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLogin.TextChanged += new System.EventHandler(this.tbLogin_TextChanged);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(732, 129);
            this.connectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(124, 32);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(873, 129);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(124, 32);
            this.disconnectButton.TabIndex = 3;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // tbChatRead
            // 
            this.tbChatRead.Location = new System.Drawing.Point(12, 660);
            this.tbChatRead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbChatRead.Multiline = true;
            this.tbChatRead.Name = "tbChatRead";
            this.tbChatRead.ReadOnly = true;
            this.tbChatRead.Size = new System.Drawing.Size(457, 114);
            this.tbChatRead.TabIndex = 4;
            this.tbChatRead.TextChanged += new System.EventHandler(this.tbChatRead_TextChanged);
            // 
            // sizeOfMap
            // 
            this.sizeOfMap.Location = new System.Drawing.Point(731, 177);
            this.sizeOfMap.Name = "sizeOfMap";
            this.sizeOfMap.Size = new System.Drawing.Size(267, 23);
            this.sizeOfMap.TabIndex = 5;
            this.sizeOfMap.Text = "Размер карты";
            this.sizeOfMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listOfClients
            // 
            this.listOfClients.FormattingEnabled = true;
            this.listOfClients.ItemHeight = 16;
            this.listOfClients.Location = new System.Drawing.Point(732, 233);
            this.listOfClients.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listOfClients.Name = "listOfClients";
            this.listOfClients.Size = new System.Drawing.Size(264, 180);
            this.listOfClients.TabIndex = 6;
            this.listOfClients.Tag = "";
            this.listOfClients.SelectedIndexChanged += new System.EventHandler(this.listOfClients_SelectedIndexChanged);
            // 
            // timer
            // 
            this.timer.Location = new System.Drawing.Point(731, 201);
            this.timer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(265, 30);
            this.timer.TabIndex = 8;
            this.timer.Text = "Таймер";
            this.timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbIPadress
            // 
            this.tbIPadress.Location = new System.Drawing.Point(732, 9);
            this.tbIPadress.Margin = new System.Windows.Forms.Padding(4);
            this.tbIPadress.Name = "tbIPadress";
            this.tbIPadress.Size = new System.Drawing.Size(263, 22);
            this.tbIPadress.TabIndex = 11;
            this.tbIPadress.Text = "127.0.0.1";
            this.tbIPadress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbIPadress.TextChanged += new System.EventHandler(this.tbIPadress_TextChanged);
            // 
            // tbPortAdress
            // 
            this.tbPortAdress.Location = new System.Drawing.Point(732, 43);
            this.tbPortAdress.Margin = new System.Windows.Forms.Padding(4);
            this.tbPortAdress.Name = "tbPortAdress";
            this.tbPortAdress.Size = new System.Drawing.Size(263, 22);
            this.tbPortAdress.TabIndex = 12;
            this.tbPortAdress.Text = "7777";
            this.tbPortAdress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPortAdress.TextChanged += new System.EventHandler(this.tbPortAdress_TextChanged);
            // 
            // tbChatWrite
            // 
            this.tbChatWrite.Location = new System.Drawing.Point(475, 660);
            this.tbChatWrite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbChatWrite.Multiline = true;
            this.tbChatWrite.Name = "tbChatWrite";
            this.tbChatWrite.Size = new System.Drawing.Size(201, 114);
            this.tbChatWrite.TabIndex = 13;
            // 
            // SendMessageButton
            // 
            this.SendMessageButton.Location = new System.Drawing.Point(683, 660);
            this.SendMessageButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SendMessageButton.Name = "SendMessageButton";
            this.SendMessageButton.Size = new System.Drawing.Size(44, 114);
            this.SendMessageButton.TabIndex = 14;
            this.SendMessageButton.Text = "se nd";
            this.SendMessageButton.UseVisualStyleBackColor = true;
            this.SendMessageButton.Click += new System.EventHandler(this.SendMessageButton_Click);
            // 
            // timerForTimer
            // 
            this.timerForTimer.Interval = 1000;
            this.timerForTimer.Tick += new System.EventHandler(this.timerForTimer_Tick);
            // 
            // northButton
            // 
            this.northButton.Location = new System.Drawing.Point(860, 660);
            this.northButton.Margin = new System.Windows.Forms.Padding(4);
            this.northButton.Name = "northButton";
            this.northButton.Size = new System.Drawing.Size(44, 43);
            this.northButton.TabIndex = 15;
            this.northButton.Text = "N";
            this.northButton.UseVisualStyleBackColor = true;
            this.northButton.Click += new System.EventHandler(this.northButton_Click);
            // 
            // eastButton
            // 
            this.eastButton.Location = new System.Drawing.Point(912, 695);
            this.eastButton.Margin = new System.Windows.Forms.Padding(4);
            this.eastButton.Name = "eastButton";
            this.eastButton.Size = new System.Drawing.Size(44, 43);
            this.eastButton.TabIndex = 16;
            this.eastButton.Text = "E";
            this.eastButton.UseVisualStyleBackColor = true;
            this.eastButton.Click += new System.EventHandler(this.eastButton_Click);
            // 
            // westButton
            // 
            this.westButton.Location = new System.Drawing.Point(808, 695);
            this.westButton.Margin = new System.Windows.Forms.Padding(4);
            this.westButton.Name = "westButton";
            this.westButton.Size = new System.Drawing.Size(44, 43);
            this.westButton.TabIndex = 17;
            this.westButton.Text = "W";
            this.westButton.UseVisualStyleBackColor = true;
            this.westButton.Click += new System.EventHandler(this.westButton_Click);
            // 
            // southButton
            // 
            this.southButton.Location = new System.Drawing.Point(860, 730);
            this.southButton.Margin = new System.Windows.Forms.Padding(4);
            this.southButton.Name = "southButton";
            this.southButton.Size = new System.Drawing.Size(44, 43);
            this.southButton.TabIndex = 18;
            this.southButton.Text = "S";
            this.southButton.UseVisualStyleBackColor = true;
            this.southButton.Click += new System.EventHandler(this.southButton_Click);
            // 
            // listOfVisiblePlayers
            // 
            this.listOfVisiblePlayers.FormattingEnabled = true;
            this.listOfVisiblePlayers.ItemHeight = 16;
            this.listOfVisiblePlayers.Location = new System.Drawing.Point(735, 420);
            this.listOfVisiblePlayers.Margin = new System.Windows.Forms.Padding(4);
            this.listOfVisiblePlayers.Name = "listOfVisiblePlayers";
            this.listOfVisiblePlayers.Size = new System.Drawing.Size(261, 196);
            this.listOfVisiblePlayers.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.controlMap);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 640);
            this.panel1.TabIndex = 20;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.onPaint);
            // 
            // controlMap
            // 
            this.controlMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlMap.Location = new System.Drawing.Point(0, 0);
            this.controlMap.Margin = new System.Windows.Forms.Padding(4);
            this.controlMap.Name = "controlMap";
            this.controlMap.Size = new System.Drawing.Size(711, 640);
            this.controlMap.TabIndex = 0;
            this.controlMap.Text = "ctrlMap";
            this.controlMap.Paint += new System.Windows.Forms.PaintEventHandler(this.onPaint);
            this.controlMap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 788);
            this.Controls.Add(this.listOfVisiblePlayers);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.southButton);
            this.Controls.Add(this.westButton);
            this.Controls.Add(this.eastButton);
            this.Controls.Add(this.northButton);
            this.Controls.Add(this.SendMessageButton);
            this.Controls.Add(this.tbChatWrite);
            this.Controls.Add(this.tbPortAdress);
            this.Controls.Add(this.tbIPadress);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.listOfClients);
            this.Controls.Add(this.sizeOfMap);
            this.Controls.Add(this.tbChatRead);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.tbLogin);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Крысиные бега";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.onPaint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.TextBox tbChatRead;
        private System.Windows.Forms.Label sizeOfMap;
        private System.Windows.Forms.ListBox listOfClients;
        private System.Windows.Forms.Label timer;
        private System.Windows.Forms.TextBox tbIPadress;
        private System.Windows.Forms.TextBox tbPortAdress;
        private System.Windows.Forms.TextBox tbChatWrite;
        private System.Windows.Forms.Button SendMessageButton;
        private System.Windows.Forms.Timer timerForTimer;
        private System.Windows.Forms.Button northButton;
        private System.Windows.Forms.Button eastButton;
        private System.Windows.Forms.Button westButton;
        private System.Windows.Forms.Button southButton;
        private System.Windows.Forms.ListBox listOfVisiblePlayers;
        private System.Windows.Forms.Panel panel1;
        private CtrlMap controlMap;
    }
}

