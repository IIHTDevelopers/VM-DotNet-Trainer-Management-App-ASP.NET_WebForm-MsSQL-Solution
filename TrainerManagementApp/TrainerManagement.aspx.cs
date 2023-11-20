using TrainerManagementApp.DAL;
using TrainerManagementApp.Model;
using System;
using System.Web.UI;

namespace TrainerManagementApp
{
    public partial class TrainerManagement : Page
    {
        private readonly datalayer _dataLayer;
        private readonly TrainerManagementApp.DAL.Interfaces.ITrainerService _trainerService;

        public TrainerManagement()
        {
            _dataLayer = new datalayer();
            _trainerService = new DAL.Services.TrainerService(new DAL.Services.TrainerRepository(new TrainerManagementApp.DAL.TrainerDbContext()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            var trainers = _trainerService.GetAll();
            _dataLayer.fillgridView(trainers, gv);
        }

        protected void gv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = gv.SelectedRow.Cells[1].Text;
            // Retrieve the trainer details and populate the form
            var trainer = _trainerService.GetById(id);
            if (trainer != null)
            {
                txtFirstName.Text = trainer.FirstName;
                txtLastName.Text = trainer.LastName;
                txtDateOfBirth.Text = trainer.DateOfBirth.ToString("yyyy-MM-dd");
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            var newTrainer = new TrainerModel
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                DateOfBirth = DateTime.Parse(txtDateOfBirth.Text)
            };

            _trainerService.Add();
            BindGridView();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string id = gv.SelectedRow.Cells[1].Text.ToString();
            var existingTrainer = _trainerService.GetById(id);

            if (existingTrainer != null)
            {
                existingTrainer.LastName = txtLastName.Text;
                existingTrainer.FirstName = txtFirstName.Text;
                existingTrainer.DateOfBirth = DateTime.Parse(txtDateOfBirth.Text);

                _trainerService.Update();
                BindGridView();
            }
        }

        protected void btndlt_Click(object sender, EventArgs e)
        {
            string id = gv.SelectedRow.Cells[1].Text.ToString();
            _trainerService.Delete();
            BindGridView();
        }
    }
}
