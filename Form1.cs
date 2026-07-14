using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListApp
{
    public partial class Form1 : Form
    {
        private void ClearInputFields()
        {
            txtTask.Clear();
            cmbPriority.SelectedIndex = 1;
            dtpDueDate.Value = DateTime.Today;
            chkCompleted.Checked = false;
            txtDetails.Clear();

            txtTask.Focus();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbPriority.Items.Add("Low");
            cmbPriority.Items.Add("Medium");
            cmbPriority.Items.Add("High");

            cmbPriority.SelectedIndex = 1;

            dtpDueDate.Value = DateTime.Today;
            txtTask.Focus();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string task = txtTask.Text.Trim();

            if (task == "")
            {
                MessageBox.Show("Please enter a task.",
                                "Missing Task",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtTask.Focus();
                return;
            }

            if (cmbPriority.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a priority.",
                                "Missing Priority",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                cmbPriority.Focus();
                return;
            }

            string priority = cmbPriority.SelectedItem.ToString();
            string dueDate = dtpDueDate.Value.ToShortDateString();
            string status = chkCompleted.Checked ? "Completed" : "Pending";

            string taskItem = $"[{status}] {task} | Priority: {priority} | Due: {dueDate}";

            lstTasks.Items.Add(taskItem);

            ClearInputFields();

            MessageBox.Show("Task added successfully.",
                            "Task Added",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
                        ClearInputFields();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (lstTasks.Items.Count == 0)
            {
                MessageBox.Show("There are no tasks to clear.",
                                "Empty List",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to clear all tasks?",
                                                  "Confirm Clear All",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                lstTasks.Items.Clear();
                ClearInputFields();

                MessageBox.Show("All tasks have been cleared.",
                                "Tasks Cleared",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }

        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstTasks.SelectedIndex < 0)
            {
                return;
            }

            string selectedTask = lstTasks.SelectedItem.ToString();

            txtDetails.Text = selectedTask;
            txtTask.Text = selectedTask;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a task to update.",
                                "No Task Selected",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                return;
            }

            string task = txtTask.Text.Trim();

            if (task == "")
            {
                MessageBox.Show("Please enter a task.",
                                "Missing Task",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtTask.Focus();
                return;
            }

            string priority = cmbPriority.SelectedItem.ToString();
            string dueDate = dtpDueDate.Value.ToShortDateString();
            string status = chkCompleted.Checked ? "Completed" : "Pending";

            string updatedTask = $"[{status}] {task} | Priority: {priority} | Due: {dueDate}";

            lstTasks.Items[lstTasks.SelectedIndex] = updatedTask;

            txtDetails.Text = updatedTask;

            MessageBox.Show("Task updated successfully.",
                            "Task Updated",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

        }

        

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                                      "Confirm Exit",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a task to delete.",
                                "No Task Selected",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected task?",
                                                  "Confirm Delete",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                lstTasks.Items.RemoveAt(lstTasks.SelectedIndex);
                ClearInputFields();

                MessageBox.Show("Task deleted successfully.",
                                "Task Deleted",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }

        }
    }
}
