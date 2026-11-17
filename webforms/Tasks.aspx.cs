using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTasks.Web
{
    public partial class Tasks : Page
    {
        private static readonly TaskService Service = new TaskService(new InMemoryTaskRepository());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTasks();
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                var priority = (TaskPriority)Enum.Parse(typeof(TaskPriority), PriorityList.SelectedValue);
                Service.AddTask(TitleTextBox.Text, priority);
                TitleTextBox.Text = string.Empty;
                ErrorLabel.Text = string.Empty;
            }
            catch (ArgumentException ex)
            {
                ErrorLabel.Text = ex.Message;
            }

            BindTasks();
        }

        protected void TasksGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Complete")
            {
                var rowIndex = Convert.ToInt32(e.CommandArgument);
                var id = (int)TasksGrid.DataKeys[rowIndex].Value;
                Service.CompleteTask(id);
                BindTasks();
            }
        }

        private void BindTasks()
        {
            TasksGrid.DataSource = Service.ListOpenTasks();
            TasksGrid.DataBind();
        }
    }
}
