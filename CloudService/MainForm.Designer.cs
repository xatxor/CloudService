
namespace CloudService
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.zipButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.loadPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.filesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.archiveNameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.archivePathOnDiskTextbox = new System.Windows.Forms.TextBox();
            this.loginControl = new CloudService.LoginControl();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Multiselect = true;
            // 
            // openButton
            // 
            this.openButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.openButton.Location = new System.Drawing.Point(15, 80);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(145, 42);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Выбрать файлы";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sendButton.Location = new System.Drawing.Point(15, 296);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(145, 42);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Отправить архив";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // zipButton
            // 
            this.zipButton.Enabled = false;
            this.zipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.zipButton.Location = new System.Drawing.Point(15, 248);
            this.zipButton.Name = "zipButton";
            this.zipButton.Size = new System.Drawing.Size(145, 42);
            this.zipButton.TabIndex = 2;
            this.zipButton.Text = "Сжать";
            this.zipButton.UseVisualStyleBackColor = true;
            this.zipButton.Click += new System.EventHandler(this.zipButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(171, 21);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(336, 317);
            this.tabControl.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.loadPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(328, 291);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Выбранные файлы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // loadPanel
            // 
            this.loadPanel.AutoScroll = true;
            this.loadPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.loadPanel.Location = new System.Drawing.Point(6, 6);
            this.loadPanel.Name = "loadPanel";
            this.loadPanel.Size = new System.Drawing.Size(316, 279);
            this.loadPanel.TabIndex = 0;
            this.loadPanel.WrapContents = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.filesPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(328, 291);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Корневая папка диска";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // filesPanel
            // 
            this.filesPanel.AutoScroll = true;
            this.filesPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.filesPanel.Location = new System.Drawing.Point(6, 6);
            this.filesPanel.Name = "filesPanel";
            this.filesPanel.Size = new System.Drawing.Size(316, 279);
            this.filesPanel.TabIndex = 1;
            this.filesPanel.WrapContents = false;
            // 
            // archiveNameTextbox
            // 
            this.archiveNameTextbox.Location = new System.Drawing.Point(15, 222);
            this.archiveNameTextbox.Name = "archiveNameTextbox";
            this.archiveNameTextbox.Size = new System.Drawing.Size(145, 20);
            this.archiveNameTextbox.TabIndex = 7;
            this.archiveNameTextbox.TextChanged += new System.EventHandler(this.archiveNameTextbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(12, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Имя архива";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 51);
            this.progressBar.Maximum = 2147483647;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(145, 23);
            this.progressBar.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(12, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Пароль от архива";
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(15, 182);
            this.passwordTextbox.MaxLength = 14;
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.PasswordChar = '*';
            this.passwordTextbox.Size = new System.Drawing.Size(145, 20);
            this.passwordTextbox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(12, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Путь к папке на диске";
            // 
            // archivePathOnDiskTextbox
            // 
            this.archivePathOnDiskTextbox.Location = new System.Drawing.Point(15, 142);
            this.archivePathOnDiskTextbox.MaxLength = 100;
            this.archivePathOnDiskTextbox.Name = "archivePathOnDiskTextbox";
            this.archivePathOnDiskTextbox.Size = new System.Drawing.Size(145, 20);
            this.archivePathOnDiskTextbox.TabIndex = 12;
            this.archivePathOnDiskTextbox.TextChanged += new System.EventHandler(this.archivePathOnDiskTextbox_TextChanged);
            // 
            // loginControl
            // 
            this.loginControl.Location = new System.Drawing.Point(0, -1);
            this.loginControl.Name = "loginControl";
            this.loginControl.Size = new System.Drawing.Size(529, 364);
            this.loginControl.TabIndex = 5;
            this.loginControl.token = "AgAAAABPGUwfAAbUEJddsmI91Ehzkvfyq1YTTgE";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 361);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.archivePathOnDiskTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.archiveNameTextbox);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.loginControl);
            this.Controls.Add(this.zipButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.openButton);
            this.MaximumSize = new System.Drawing.Size(544, 400);
            this.MinimumSize = new System.Drawing.Size(544, 400);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button zipButton;
        private LoginControl loginControl;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel loadPanel;
        private System.Windows.Forms.TextBox archiveNameTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel filesPanel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox archivePathOnDiskTextbox;
    }
}

