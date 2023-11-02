using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SmartScreenMessagePopupDialog
{
    public class SmartScreenMessageDialog
    {
        private Form customForm;
        private string mTitle;
        private string mMessage;
        private Boolean mShowOkayButton;

        public SmartScreenMessageDialog(string title, string message, Boolean showOkayButton = true)
        {
            Screen primaryScreen = Screen.PrimaryScreen;
            int screenWidth = primaryScreen.Bounds.Width;
            int screenHeight = primaryScreen.Bounds.Height;
            this.mTitle = title;
            this.mMessage = message;
            this.mShowOkayButton = showOkayButton;
            customForm = new Form();
            customForm.BackColor = Color.FromArgb(0x01, 0x67, 0xB2);
            customForm.FormBorderStyle = FormBorderStyle.None;
            customForm.Text = this.mTitle;
            customForm.Size = new System.Drawing.Size(800, 360);
            int centerX = ((screenWidth / 2) - (customForm.Size.Width / 2));
            int centerY = ((screenHeight / 2) - (customForm.Size.Height / 2));
            customForm.Location = new System.Drawing.Point(centerX, centerY);

            Label myTitle = new Label();
            myTitle.Text = this.mTitle;
            myTitle.Location = new Point(32, 32);
            myTitle.ForeColor = Color.White;
            myTitle.Size = new Size(customForm.Size.Width - 32, 64);
            myTitle.Font = new Font(myTitle.Font.FontFamily, 22, FontStyle.Bold);
            customForm.Controls.Add(myTitle);

            Label myMessage = new Label();
            myMessage.Text = this.mMessage;
            myMessage.Location = new Point(32, myTitle.Size.Height + 32);
            myMessage.ForeColor = Color.White;
            myMessage.Size = new Size(customForm.Size.Width - 32, 200);
            myMessage.Font = new Font(myMessage.Font.FontFamily, 12, FontStyle.Regular);
            customForm.Controls.Add(myMessage);

            if (showOkayButton)
            {
                Button closeButton = new Button();
                closeButton.Text = "Okay";
                closeButton.Size = new System.Drawing.Size(100, 32);
                int xFactor = 32;
                int yFactor = 32;
                closeButton.FlatStyle = FlatStyle.Flat;
                closeButton.FlatAppearance.BorderSize = 1;
                closeButton.FlatAppearance.BorderColor = Color.White;
                closeButton.ForeColor = Color.White;
                closeButton.Location = new System.Drawing.Point(customForm.Size.Width - (closeButton.Size.Width + xFactor), customForm.Size.Height - (closeButton.Size.Height + yFactor));
                closeButton.Click += (sender, e) =>
                {
                    customForm.Close();
                };
                customForm.Controls.Add(closeButton);
            }
        }

        public void Show()
        {
            this.customForm.ShowDialog();
        }
    }
}