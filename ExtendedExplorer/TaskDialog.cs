//----------------------------------------------------
// Downloaded From
// Visual C# Kicks - http://www.vcskicks.com/
//----------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExtendedExplorer
{
    public partial class TaskDialog : Form
    {
        public enum IconType
        {
            Application,
            Error,
            Information,
            Question,
            Shield,
            Warning
        }

        #region CONSTRUCTORS ----------------------------------------
        public TaskDialog(string Message)
        {
            InitializeComponent();

            lMsg.Text = Message;
            AdjustSize();
        }

        public TaskDialog(string Message, IconType Icon) : this(Message) //call base constructor
        {
            Image iconImg = null;

            switch (Icon)
            {
                case IconType.Application:
                    iconImg = (Image)SystemIcons.Application.ToBitmap();
                    break;
                case IconType.Error:
                    iconImg = (Image)SystemIcons.Error.ToBitmap();
                    break;
                case IconType.Information:
                    iconImg = (Image)SystemIcons.Information.ToBitmap();
                    break;
                case IconType.Question:
                    iconImg = (Image)SystemIcons.Question.ToBitmap();
                    break;
                case IconType.Shield:
                    iconImg = (Image)SystemIcons.Shield.ToBitmap();
                    break;
                case IconType.Warning:
                    iconImg = (Image)SystemIcons.Warning.ToBitmap();
                    break;
                default:
                    break;
            }

            picSystemIcon.Image = iconImg;
        } 

        public TaskDialog(string Message, string Caption, IconType Icon) : this(Message, Icon)
        {
            this.Text = Caption;
        }

        #endregion

        #region METHODS ------------------------------------------
        private void AdjustSize()
        {
            //Width
            if (lMsg.Left + lMsg.Width + 32 >= this.Width)
            {
                //Label goes outside the Form, resize the Form
                this.Width += (lMsg.Left + lMsg.Width + 32) - this.Width;
            }

            //Height
            if (lMsg.Top + lMsg.Height + 25 >= btnYes.Top)
            {
                //Label goes on top of the Yes button, resize the Form
                this.Height += (lMsg.Top + lMsg.Height + 25) - btnYes.Top;
            }
        } 
        #endregion

        #region PROPERTY METHODS --------------------------------------------
        public void SetButtonYesText(string Header, string Description)
        {
            btnYes.HeaderText = Header;
            btnYes.DescriptionText = Description;
        }

        public void SetButtonNoText(string Header, string Description)
        {
            btnNo.HeaderText = Header;
            btnNo.DescriptionText = Description;
        } 
        #endregion
    }
}