using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GL_SCHOOL
{
    public partial class FrmVouchers : Form
    {
        public FrmVouchers()
        {
            InitializeComponent();
        }
        Cls_db db = new Cls_db();
        private void FrmVouchers_Load(object sender, EventArgs e)
        {
            //db.View_Vouchers(dataGridView1);
            this.db.list_DataView("SELECT [VOUCHER_NO],[VCH_TYPE],[VCH_DATE] FROM [SchoolSQL].[dbo].[ACT_VOUCHER_MASTER]", this.lstv_coa);
        }

        private void btnshow_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmVoucherEntry frm = new FrmVoucherEntry();
            frm.Show();
        }

        private void lstv_coa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
