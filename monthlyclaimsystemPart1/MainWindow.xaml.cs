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

namespace monthlyclaimsystemPart1
{
    public partial class MainWindow : Window
    {
        private List<string> pendingClaims = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            LoadPendingClaims();
        }

        private void SubmitClaim(object sender, RoutedEventArgs e)
        {
            string name = LecturerName.Text;
            double hoursWorked = Convert.ToDouble(HoursWorked.Text);
            double hourlyRate = Convert.ToDouble(HourlyRate.Text);
            double totalAmount = hoursWorked * hourlyRate;

            TotalAmount.Text = totalAmount.ToString("C");

            // Simulate claim submission
            MessageBox.Show("Claim Submitted Successfully!");
            ClaimStatus.Text = "Pending";

            pendingClaims.Add(name + " - " + totalAmount.ToString("C"));
            LoadPendingClaims();
        }

        private void UploadDocument(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Document Uploaded Successfully!");
        }

        private void ApproveClaim(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Claim Approved!");
            ClaimStatus.Text = "Approved";
            RemoveSelectedClaim();
        }

        private void RejectClaim(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Claim Rejected!");
            ClaimStatus.Text = "Rejected";
            RemoveSelectedClaim();
        }

        private void LoadPendingClaims()
        {
            PendingClaims.ItemsSource = null;
            PendingClaims.ItemsSource = pendingClaims;
        }

        private void RemoveSelectedClaim()
        {
            if (PendingClaims.SelectedItem != null)
            {
                pendingClaims.Remove(PendingClaims.SelectedItem.ToString());
                LoadPendingClaims();
            }
        }

        private void OnClaimSelected(object sender, RoutedEventArgs e)
        {
           
            if (PendingClaims.SelectedItem != null)
            {
                
                LecturerNameDetails.Text = "";
                HoursWorkedDetails.Text = "";
                HourlyRateDetails.Text = "";
                TotalAmountDetails.Text = "";
                DateSubmittedDetails.Text = "";
                DocumentPathDetails.Text = "";
            }
        }
    }
}