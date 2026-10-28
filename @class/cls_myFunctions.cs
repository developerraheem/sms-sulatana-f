using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace School._class
{
    
  public   class cls_myFunctions
    {
        string sMessageBox = "[TSI School Management System]";
        

        public void setMessageBox(string sMessage, int iWhich)
        {
            switch (iWhich)
            {
                case 1:
                    MessageBox.Show(sMessage, sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show(sMessage, sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 3:
                    MessageBox.Show(sMessage, sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        public void setCreateError(string sErrorMessage)
        {
            try
            {
                MessageBox.Show(sErrorMessage, sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

    }
}
