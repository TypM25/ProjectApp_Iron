using System;
using System.Data;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Npgsql;

namespace App_Iron
{
    public partial class Test_page : Window
    {
        private SerialPort _serialPort;

        private bool _isStateOn;


        public Test_page()
        {

            InitializeComponent();
            Loaded += Test_page_Loaded;
            Unloaded += Test_page_Unloaded;
            _isStateOn = false;
        }



     
        public static NpgsqlCommand vCmd = new NpgsqlCommand("", Center.vCon);

        public DataTable getData(string sql)
        {
            DataTable dt = new DataTable();
            Center.openConnection();
            using (var vCmd = new NpgsqlCommand(sql, Center.vCon))
            {
                if (Center.vCon.State == ConnectionState.Open) // Verify the connection state
                {
                    using (var dr = vCmd.ExecuteReader())
                    {
                        dt.Load(dr);
                    }
                }
                else
                {
                    throw new InvalidOperationException("Connection is not open.");
                }
            }

            Center.closeConnection();
            return dt;
        }

        private void Test_page_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_Loaded(sender, e);
            Center.openConnection();
        }

        private void Test_page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_serialPort != null)
            {
                _serialPort.Close();
                _serialPort.Dispose();
            }
        }

        //-----------START-----------  code serial port
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            cmbPortNames.Items.Clear();
            foreach (string portName in SerialPort.GetPortNames())
            {
                cmbPortNames.Items.Add(portName);
            }
            if (cmbPortNames.Items.Count > 0)
            {
                cmbPortNames.SelectedIndex = 0;
            }
        }

        private void btnStartqc_Click(object sender, RoutedEventArgs e)
        {

            if (cmbPortNames.SelectedItem != null)
            {

                string portName = cmbPortNames.SelectedItem.ToString();
                // Ensure any previous instance of _serialPort is closed before creating a new one
                if (_serialPort != null)
                {

                    _serialPort.Close();
                    _serialPort.Dispose();
                }
                _serialPort = new SerialPort(portName, 9600);
                _serialPort.DataReceived += SerialPort_DataReceived;
                try
                {
                    _isStateOn = !_isStateOn;
                    MessageBox.Show("State is now " + (_isStateOn ? "On" : "Off"));
                    string stateEvent = _isStateOn ? "State_On" : "State_Off";

                    _serialPort.Open();
                    _serialPort.WriteLine(stateEvent); // Send data to Arduino


                    //MessageBox.Show("Connected to " + portName);

                    // Example of sending data (you can replace this with actual data)
                    string dataToSend = $"Temp 1: {txtTemp1.Text}, Temp 2: {txtTemp2.Text}, Temp 3: {txtTemp3.Text}, Temp Limit: {txtTempLimit.Text}, " +
                                        $"Time: {txtTime.Text}, Time Limit: {txtTimeLimit.Text}, " +
                                        $"Current: {txtCurrent.Text}, Current Limit: {txtCurrentLimit.Text}";
                    _serialPort.WriteLine(dataToSend);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show($"Access to the port '{portName}' is denied.\n{ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open the port '{portName}'.\n{ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select Port!");
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e); // Call the base class method to ensure standard behavior
            if (_serialPort.IsOpen)
            {
                _serialPort.Close(); // Close the serial port if it is open
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = _serialPort?.ReadLine() ?? string.Empty;
            string[] values = data.Split(',');

            if (values.Length >= 8)  // Ensure there are enough values
            {
                Dispatcher.Invoke(() =>
                {
                    txtTemp1.Text = values[0];
                    txtTemp2.Text = values[1];
                    txtTemp3.Text = values[2];
                    txtTempLimit.Text = values[3];
                    txtTime.Text = values[4];
                    txtTimeLimit.Text = values[5];
                    txtCurrent.Text = values[6];
                    txtCurrentLimit.Text = values[7];

                    if (values[8] == "1")
                    {
                        try
                        {
                            Center.openConnection();
                            string query = "INSERT INTO product (voltage, current) VALUES (@voltage, @current)";
                            using (NpgsqlCommand vCmd = new NpgsqlCommand(query, Center.vCon))
                            {
                                vCmd.Parameters.AddWithValue("@voltage", 11);
                                vCmd.Parameters.AddWithValue("@current", 22);
                                vCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        Center.closeConnection();
                    }

                });
            }


        }



        private void btnSarub_Click(object sender, RoutedEventArgs e)
        {
            //Insertvalues();    
            DataTable dtgetdata = new DataTable();
            dtgetdata = getData("SELECT * FROM public.product");
            dtgTable.ItemsSource = dtgetdata.DefaultView;

        }

        


        //-----------END-----------  code serial port
    }


}
