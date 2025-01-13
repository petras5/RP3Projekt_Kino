using Kino.model;
using Kino.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.view
{
    public partial class FormReservations : Form
    {
        User User { get; set; }
        Form FormRegister { get; set; }
        public FormReservations(Form formRegister, User user)
        {
            InitializeComponent();
            User = user;
            FormRegister = formRegister;

            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;

            labelStatus.Text = "";

            FillData();
        }

        
        private void FillData()
        {
            dataGridViewReceipts.Rows.Clear();

            ReceiptService receiptService = new ReceiptService(labelStatus);
            List<Receipt> receipts = receiptService.GetReceipts();

            UserService userService = new UserService(labelStatus);

            foreach (Receipt receipt in receipts)
            {
                User user = userService.GetUserById(receipt.IdUser);
                dataGridViewReceipts.Rows.Add(false, receipt.IdReceipt, receipt.Created, user.Username, "view");
            }
        }

        private void dataGridViewReceipts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewReceipts.Columns[e.ColumnIndex].Name == "Delete")
            {
                buttonDelete.Enabled = true;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ReceiptService receiptService = new ReceiptService(labelStatus);

            for (int i = 0; i < dataGridViewReceipts.Rows.Count; i++)
            {
                if (!dataGridViewReceipts.Rows[i].IsNewRow)
                {
                    int receiptID = (int)dataGridViewReceipts.Rows[i].Cells["ReceiptID"].Value;

                    if ((bool)dataGridViewReceipts.Rows[i].Cells["Delete"].Value == true)
                    {
                        receiptService.DeleteReceiptById(receiptID);
                    }
                }
            }

            buttonDelete.Enabled = false;

            FillData();
        }
    }
}
