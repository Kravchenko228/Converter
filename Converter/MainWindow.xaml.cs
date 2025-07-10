using System.Data;
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

namespace Converter;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        BindCurrency();
    }

    private void Convert_Click(object sender, RoutedEventArgs e)
    {
        lblCurrency.Content = "Hello";
        double convertedValue;
        if(!double.TryParse(txtCurrency.Text.ToString(), out convertedValue))
        {
            MessageBox.Show("Enter a valid amount","Information", MessageBoxButton.OK, MessageBoxImage.Information);
            txtCurrency.Focus();
            return;
        }
        else if (cmbFromCurrency.SelectedValue== null || cmbFromCurrency.SelectedIndex==0) {
            MessageBox.Show("Select from currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            cmbFromCurrency.Focus();
            return;
        }
        else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
        {
            MessageBox.Show("Select to currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            cmbFromCurrency.Focus();
            return;
        }

        if (cmbToCurrency.Text == cmbFromCurrency.Text)
        {
            convertedValue=double.Parse(txtCurrency.Text);
            lblCurrency.Content=cmbToCurrency.Text+ " " + convertedValue.ToString("N3") ;
        }

        else
        {
            convertedValue= (double.Parse(cmbFromCurrency.SelectedValue.ToString()) *
                 double.Parse(txtCurrency.Text)) /
                 double.Parse(cmbToCurrency.SelectedValue.ToString());
            lblCurrency.Content = convertedValue.ToString();
        }
    }

    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {

    }
    
    private void BindCurrency()
    {
        DataTable dtCurrency = new DataTable();
        dtCurrency.Columns.Add("Text");
        dtCurrency.Columns.Add("Value");
        dtCurrency.Rows.Add("--SELECT--", 0);
        dtCurrency.Rows.Add("USD", 3.5);
        dtCurrency.Rows.Add("ILS", 1);
        dtCurrency.Rows.Add("HRV", 10);
        dtCurrency.Rows.Add("EUR", 4);

        cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;
        cmbFromCurrency.DisplayMemberPath = "Text";
        cmbFromCurrency.SelectedIndex = 0;
        cmbFromCurrency.SelectedValuePath = "Value";

        cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
        cmbToCurrency.DisplayMemberPath = "Text";
        cmbToCurrency.SelectedIndex = 0;
        cmbToCurrency.SelectedValuePath = "Value";

    }
    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        lblCurrency.Content = "";
        txtCurrency.Text = String.Empty;
        if (cmbFromCurrency.Items.Count > 0) cmbFromCurrency.SelectedIndex = 0;
        if (cmbToCurrency.Items.Count > 0) cmbToCurrency.SelectedIndex = 0;
        txtCurrency.Focus();




    }
}