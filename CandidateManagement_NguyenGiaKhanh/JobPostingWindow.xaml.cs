using Candidate_BusinessObjects;
using Candidate_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CandidateManagement_NguyenGiaKhanh
{
    /// <summary>
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {

        private IJobPostingService jobPostingService;
        public JobPostingWindow()
        {
            InitializeComponent();
            // Load service
            jobPostingService = new JobPostingService();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPosting = new JobPosting();
            jobPosting.PostingId = txtPostingID.Text;
            jobPosting.JobPostingTitle = txtTitle.Text;
            jobPosting.Description = txtDescription.Text;
            jobPosting.PostedDate = date.SelectedDate;
            if (jobPostingService.AddJobPosting(jobPosting))
            {
                MessageBox.Show("Add Successful !");
            }
            else
            {
                MessageBox.Show("Something went wrong !");
            }
            Loading();
        }

        private void dtgJobPosting_Loaded(object sender, RoutedEventArgs e)
        {
            Loading();
        }

        private void Loading()
        {
            this.dtgJobPosting.ItemsSource = null;
            this.dtgJobPosting.ItemsSource = jobPostingService.GetJobPostings();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPosting = new JobPosting();
            jobPosting.PostingId = txtPostingID.Text;
            jobPosting.JobPostingTitle = txtTitle.Text;
            jobPosting.Description = txtDescription.Text;
            jobPosting.PostedDate = date.SelectedDate;
            if (jobPostingService.UpdateJobPosting(jobPosting))
            {
                MessageBox.Show("Update Successful !");
            }
            else
            {
                MessageBox.Show("Something went wrong !");
            }
            Loading();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (jobPostingService.deleteJobPosting(txtPostingID.Text))
            {
                MessageBox.Show("Delete Successful !");
            }
            else
            {
                MessageBox.Show("Something went wrong !");
            }
            Loading();

        }

       


    }
}
