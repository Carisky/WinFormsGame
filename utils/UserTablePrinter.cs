using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinFormsGame.db.models;

namespace WinFormsGame.utils
{
    public static class UserTablePrinter
    {
        public static void ShowUsersTable(List<User> users)
        {
            // Create a new form to display the DataGridView
            Form tableForm = new Form();
            tableForm.Text = "User Leaderboard";
            tableForm.Size = new Size(321, 400);

            // Prevent the form from being resized
            tableForm.FormBorderStyle = FormBorderStyle.FixedDialog;  // Disable resizing
            tableForm.MaximizeBox = false; // Disable maximize button
            tableForm.MinimizeBox = false; // Disable minimize button

            // Create a new DataGridView
            DataGridView dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill; // Set to fill the form
            dataGridView.AutoGenerateColumns = false; // Prevent auto-generation of columns
            dataGridView.AllowUserToAddRows = false; // Disable row adding

            // Prohibit any selection in the DataGridView
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Full row selection
            dataGridView.MultiSelect = false; // Allow only single row selection
            dataGridView.ReadOnly = true; // Set the grid to read-only (no editing)

            // Hide the row header (button-like column on the left side)
            dataGridView.RowHeadersVisible = false;

            // Disable row resizing
            dataGridView.AllowUserToResizeRows = false;

            // Disable column resizing
            dataGridView.AllowUserToResizeColumns = false;

            // Create columns for the DataGridView
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Username",
                HeaderText = "Username",
                Width = 200
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Highscore",
                HeaderText = "Highscore",
                Width = 100
            });

            // Bind the DataGridView to the list of users
            dataGridView.DataSource = users;

            // Add the DataGridView to the form
            tableForm.Controls.Add(dataGridView);

            // Show the form
            tableForm.ShowDialog();
        }
    }
}
