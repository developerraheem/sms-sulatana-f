using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class frmtest : Form
    {
        public frmtest()
        {
            InitializeComponent();
        }

        private void frmtest_Load(object sender, EventArgs e)
        {
                        
        }

        private void fee_ClassBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
this.Validate();
this.fee_ClassBindingSource.EndEdit();
this.tableAdapterManager.UpdateAll(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet);
        
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
try {
    this.fee_ClassTableAdapter.Fill(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Fee_Class, new System.Nullable<int>(((int)(System.Convert.ChangeType(c_IDToolStripTextBox.Text, typeof(int))))));
}
catch (System.Exception ex) {
    System.Windows.Forms.MessageBox.Show(ex.Message);
}
        
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
        
        }

        

       

        

       
       
       

       

        

        
    }
}
