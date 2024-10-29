using Candidate_BusinessObjects;
using Candidate_DAOs;
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
    /// Interaction logic for CandidateProfileManagement.xaml
    /// </summary>
    public partial class CandidateProfileManagement : Window
    {

        private readonly ICandidateProfileService profileService;
        private readonly IJobPostingService jobService;
        private readonly ICandidateProfileService candidateProfileService;
        private readonly int? roleID;
     //   private readonly  JobPosting;
        public CandidateProfileManagement()
        {
            InitializeComponent();
            this.profileService = new CandidateProfileService();
            this.jobService = new JobPostingService();
            this.candidateProfileService = new CandidateProfileService();

        }
        public CandidateProfileManagement(int? roleID)
        {
            InitializeComponent();
            this.profileService = new CandidateProfileService();
            this.jobService = new JobPostingService();
            this.candidateProfileService = new CandidateProfileService();
            this.roleID=roleID;

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            switch (roleID)
            {
                case 1:
                    break;
                case 2:
                    //Staff
                    this.Add.IsEnabled=false;
                    break;
                case 3:
                    break;
               default:
                    this.Close();
                    break;

            }
          this.LoadCandidateList();
        }

        private void LoadCandidateList()
        {                                                                                          //  muốn cái gì trên gird thì new cái đó 
            this.dtgCandidateProfile.ItemsSource = profileService.GetCandidateProfiles().Select( a => new { a.CandidateId,a.Fullname,
                 a.Birthday,a.ProfileShortDescription,a.ProfileUrl,
                a.Posting.JobPostingTitle
            } );
            this.cmbPosting.ItemsSource = jobService.GetJobPostings();
            this.cmbPosting.DisplayMemberPath = "JobPostingTitle";
            this.cmbPosting.SelectedValuePath = "PostingId";



        }


        public void LoadJobPosting()
        {
          try
            {
                var jobPostingList = jobService.GetJobPostings();
                cmbPosting.ItemsSource = jobPostingList;
                cmbPosting.DisplayMemberPath = "JobPostingTitle";
                cmbPosting.SelectedValuePath = " PostingId";
            }
          catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error  on load  list of Job Posting ");
            }


            }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            CandidateProfile candidateProfile = new CandidateProfile();
            candidateProfile.CandidateId = txtCandidateID.Text;
            candidateProfile.Fullname = txtFullName.Text;
            candidateProfile.ProfileUrl = txtImageURL.Text;
            candidateProfile.Birthday = DateTime.Parse(txtBirthDay.Text);
            candidateProfile.PostingId = cmbPosting.SelectedValue.ToString();
            candidateProfile.ProfileShortDescription = txtDescription.Text;
            if (candidateProfileService.AddCandidateProfile(candidateProfile))
            {
                MessageBox.Show("Add Successful!!!");
                this.LoadCandidateList(); // Load Candidates after message Successful added
            }
            else
            {
                MessageBox.Show("Something is wrong!!!");
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txtCandidateID.Text.Length > 0)
                { 
                CandidateProfile candidateProfile = new CandidateProfile();
                    candidateProfile.CandidateId = txtCandidateID.Text;
                    candidateProfile.Fullname =txtFullName.Text;
                    candidateProfile.ProfileUrl =txtImageURL.Text;
                    candidateProfile.Birthday = txtBirthDay.SelectedDate;
                    candidateProfile.PostingId =cmbPosting.SelectedValue.ToString();
                    candidateProfile.ProfileShortDescription = txtDescription.Text;
                    candidateProfileService.UpdateCandidateProfile(candidateProfile);   

                }

                else
                {
                    MessageBox.Show("You must select a Candidate!!!! ");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                this.LoadCandidateList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (profileService.DeleteCandidateProfile(txtCandidateID.Text.ToString()))
            {
                MessageBox.Show("Delete Successful !");
                this.LoadCandidateList();
            }
            else
            {
                MessageBox.Show("Something went wrong !");
            }
        }

       

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dataGrid = sender as DataGrid;

                // Check if there's any row selected
                if (dataGrid.SelectedIndex >= 0 && dataGrid.SelectedItem != null)
                {
                    DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);

                    // Ensure the row is valid
                    if (row != null)
                    {
                        DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;

                        // Ensure the cell is valid
                        if (RowColumn != null)
                        {
                            String id = ((TextBlock)RowColumn.Content).Text;
                            CandidateProfile candidate = profileService.GetCandidateProfile(id);
                            if (candidate != null)
                            {
                                txtCandidateID.Text = candidate.CandidateId.ToString();
                                txtFullName.Text = candidate.Fullname;
                                txtBirthDay.Text = candidate.Birthday.ToString();
                                txtDescription.Text = candidate.ProfileShortDescription;
                                txtImageURL.Text = candidate.ProfileUrl;
                                cmbPosting.SelectedValue = candidate.PostingId;
                            }
                            else
                            {
                                MessageBox.Show("Candidate profile not found!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while selecting candidate: " + ex.Message);
            }

        }

        private void btnJobPosting_Click(object sender, RoutedEventArgs e)
        {
            JobPostingWindow jobPostingWindow = new JobPostingWindow();
            jobPostingWindow.ShowDialog();
            this.LoadCandidateList();
        }
    }
}
