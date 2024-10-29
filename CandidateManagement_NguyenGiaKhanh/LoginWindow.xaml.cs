using Candidate_BusinessObjects;
using Candidate_Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CandidateManagement_NguyenGiaKhanh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private IHRAccountServices isAccountService;
        public LoginWindow()
        {
            InitializeComponent();
            isAccountService = new HRAccountService();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = isAccountService.GetHraccountByEmail(txtEmail.Text.Trim());
            // Phân Quyền

            if (hraccount != null && txtPassword.Password.Equals(hraccount.Password) )
            {
                int? roleID = hraccount.MemberRole; // dấu chấm hỏi có thể null
                switch (roleID)
                {
                    case 1:
                        this.Hide();
                        CandidateProfileManagement candForm = new CandidateProfileManagement(roleID);
                        candForm.Show();
                        break;
                    case 2:
                        this.Hide();
                        CandidateProfileManagement staffCandidate = new CandidateProfileManagement(roleID);
                        staffCandidate.Show();

                        break;
                    case 3:
                        break;
                    default:
                        break;
                }



            }
            else
            {
                MessageBox.Show("Bye beNghiCuTe !!!");
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}