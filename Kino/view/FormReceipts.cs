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
    /// <summary>
    /// This form displays a list of receipts, allows filtering by date, and provides functionality for viewing receipt details
    /// and deleting selected receipts.
    /// </summary>
    public partial class FormReceipts : Form
    {
        User User { get; set; } // current logged-in user
        Form FormNavigation { get; set; } // parent form that navigates to this form

        public DateTime selectedDate; // selected date for filtering receipts

        /// <summary>
        /// Constructor for FormReceipts.
        /// Initializes the form, sets up UI controls, and loads receipt data.
        /// </summary>
        /// <param name="formNavigation">The parent form for navigation.</param>
        /// <param name="user">The current logged-in user.</param>
        public FormReceipts (Form formNavigation, User user)
        {
            InitializeComponent();
            User = user;
            FormNavigation = formNavigation;

            Dock = DockStyle.Fill;
            TopLevel = false;
            TopMost = true;
            DoubleBuffered = true;

            labelStatus.Text = "";

            dateTimePickerDate.CustomFormat = " ";
            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            buttonFilter.Enabled = false;

            FillData();
        }

        /// <summary>
        /// Retrieves and displays all the receipts in the data grid view.
        /// </summary>
        private void FillData()
        {
            dataGridViewReceipts.Rows.Clear();

            ReceiptService receiptService = new ReceiptService(labelStatus);
            List<Receipt> receipts = receiptService.GetReceipts();

            UserService userService = new UserService(labelStatus);

            foreach (Receipt receipt in receipts)
            {
                User user = userService.GetUserById(receipt.IdUser);
                dataGridViewReceipts.Rows.Add(false, receipt.IdReceipt, receipt.Created, user.Username, receipt.Total,"view");
            }
        }

        /// <summary>
        /// Handles changes in the data grid view when a checkbox is toggled in the 'Delete' column.
        /// Enables the delete button when a row's 'Delete' checkbox is checked.
        /// </summary>
        private void dataGridViewReceipts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewReceipts.Columns[e.ColumnIndex].Name == "Delete")
            {
                buttonDelete.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the delete button click event. Deletes selected receipts from the system.
        /// </summary>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Initialize the receipt service to delete receipts
            ReceiptService receiptService = new ReceiptService(labelStatus);

            // Loop through each row in the data grid view
            for (int i = 0; i < dataGridViewReceipts.Rows.Count; i++)
            {
                // Skip new rows that have not been added yet
                if (!dataGridViewReceipts.Rows[i].IsNewRow)
                {
                    // Get the receipt ID and check if the 'Delete' checkbox is checked
                    int receiptID = (int)dataGridViewReceipts.Rows[i].Cells["ReceiptID"].Value;

                    if ((bool)dataGridViewReceipts.Rows[i].Cells["Delete"].Value == true)
                    {
                        // Delete the receipt by its ID
                        receiptService.DeleteReceiptById(receiptID);
                    }
                }
            }

            // Disable the delete button and refresh the data
            buttonDelete.Enabled = false;
            FillData();
        }

        /// <summary>
        /// Handles cell clicks in the data grid view. When the 'Details' column is clicked, it displays the receipt details form.
        /// </summary>
        private void dataGridViewReceipts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If the 'Details' column is clicked, show the receipt details form
            if (e.RowIndex >= 0 && dataGridViewReceipts.Columns[e.ColumnIndex].Name == "Details")
            {
                // Get the selected receipt ID
                int receiptID = (int)dataGridViewReceipts.Rows[e.RowIndex].Cells["ReceiptID"].Value;

                // Retrieve the receipt details by its ID
                ReceiptService receiptService = new ReceiptService(labelStatus);
                Receipt receipt = receiptService.GetReceiptById(receiptID);

                // Find the panel in the parent form to load the receipt details form
                foreach (Control control in FormNavigation.Controls)
                {
                    if (control is Panel panel && panel.Name == "panelFormLoader")
                    {
                        panel.Controls.Clear();

                        // Create and show the receipt details form
                        FormReceiptDetails formReceiptDetails = new FormReceiptDetails(User, receipt);
                        formReceiptDetails.FormBorderStyle = FormBorderStyle.None;
                        panel.Controls.Add(formReceiptDetails);
                        formReceiptDetails.Show();
                    }
                }
            }
        }

        /// <summary>
        /// Filters the receipts based on the selected date in the date picker.
        /// </summary>
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService(labelStatus);
            ReceiptService receiptService = new ReceiptService(labelStatus);
            List<Receipt> receipts = receiptService.GetReceipts();
            dataGridViewReceipts.Rows.Clear();

            foreach (Receipt receipt in receipts)
            {
                if(receipt.Created.Date == selectedDate)
                {
                    User user = userService.GetUserById(receipt.IdUser);
                    dataGridViewReceipts.Rows.Add(false, receipt.IdReceipt, receipt.Created, user.Username, receipt.Total, "view");
                }
            }
        }

        /// <summary>
        /// Clears the selected date in the date picker and disables the filter button.
        /// </summary>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            buttonFilter.Enabled = false;
            dateTimePickerDate.CustomFormat = " ";
            FillData();
        }

        /// <summary>
        /// Updates the selected date when the user picks a new date in the date picker.
        /// Enables the filter button when a date is selected.
        /// </summary>
        private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)
        {
            buttonFilter.Enabled = true;
            selectedDate = dateTimePickerDate.Value.Date;
            dateTimePickerDate.CustomFormat = "dd.MM.yyyy";
        }
    }
}
