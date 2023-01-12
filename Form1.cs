using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Scanning_Tool
{
    public partial class Form1 : Form
    {

       string connectionString = @"*******************************************************************************";
        public Form1()
        {
            InitializeComponent();
            textBox2.Enabled = false;
            textBox2.BackColor = Color.Gray;
            textBox3.Enabled = false;
            textBox3.BackColor = Color.Gray;
            textBox1.Enabled = false;
            textBox1.BackColor = Color.Gray;
            textBox4.Enabled = false;
            textBox4.BackColor = Color.Gray;
            button2.Enabled = false;
            button2.BackColor = Color.Gray;
            pictureBox3.Hide();
            pictureBox10.Hide();
            pictureBox4.Hide();
            pictureBox9.Hide();
            pictureBox5.Hide();
            pictureBox8.Hide();
            pictureBox7.Hide();
            pictureBox6.Hide();
            pictureBox12.Hide();
            pictureBox13.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label15.Hide();
            label18.Hide();
            TimeUpdater();
            textBox2.Focus();

            // temporal

            // Obtener una hora anterior
            label24.Text = "HxH pasado: "+ Globals.hxhLast.ToString("t") +"";
            label26.Text = "HxH actual " + Globals.hxh.ToString("t") + "";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                
                if (Globals.horaMinuto.Hour >= 18)
                {
                    sqlCon.Open();
                    SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.primerHoraRev + "' AND Linea = 'Linea 1'", sqlCon);
                    Int32 count = (Int32)cmd2.ExecuteScalar();
                    string NumReg = count.ToString();
                    SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.primerHoraRev + "' AND Linea = 'Linea 2'", sqlCon);
                    Int32 count2 = (Int32)cmd3.ExecuteScalar();
                    string NumReg2 = count2.ToString();
                    SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + Globals.hxhLast + "' AND date <= '" + Globals.hxh + "' AND Linea = 'Linea 1'", sqlCon);
                    Int32 count4 = (Int32)cmd4.ExecuteScalar();
                    string NumReg3 = count4.ToString();
                    SqlCommand cmd5 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + Globals.hxh + "' AND Linea = 'Linea 1'", sqlCon);
                    Int32 count5 = (Int32)cmd5.ExecuteScalar();
                    string NumReg4 = count5.ToString();
                    label25.Text = NumReg4;
                    label23.Text = NumReg3;
                    label10.Text = NumReg;
                    label21.Text = NumReg2;

                    sqlCon.Close();

                } else if (Globals.horaMinuto.Hour < 6)
                {
                    sqlCon.Open();
                    SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date BETWEEN '" + Globals.dia + " " + Globals.primerHoraRev + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.segundaHoraRev + "' AND Linea = 'Linea 1'", sqlCon);
                    Int32 count = (Int32)cmd2.ExecuteScalar();
                    string NumReg = count.ToString();
                    SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date BETWEEN '" + Globals.dia + " " + Globals.primerHoraRev + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.segundaHoraRev + "' AND Linea = 'Linea 2'", sqlCon);
                    Int32 count2 = (Int32)cmd3.ExecuteScalar();
                    string NumReg2 = count2.ToString();
                    SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date BETWEEN '" + Globals.hxhLast + "' AND '" + Globals.hxh + "' AND Linea = 'Linea 1'", sqlCon);
                    Int32 count4 = (Int32)cmd4.ExecuteScalar();
                    string NumReg3 = count4.ToString();
                    SqlCommand cmd5 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + Globals.hxh + "' AND Linea = 'Linea 1'", sqlCon);
                    Int32 count5 = (Int32)cmd5.ExecuteScalar();
                    string NumReg4 = count5.ToString();
                    label25.Text = NumReg4;
                    label23.Text = NumReg3;
                    label10.Text = NumReg;
                    label21.Text = NumReg2;

                    sqlCon.Close();

                } else
                {
                    sqlCon.Open();
                    SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.primerHoraRev + "' and date <= '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.segundaHoraRev + "' AND Linea = 'Linea 1'", sqlCon);
                    Int32 count = (Int32)cmd2.ExecuteScalar();
                    string NumReg = count.ToString();
                    SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.primerHoraRev + "' and date <= '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.segundaHoraRev + "' AND Linea = 'Linea 2'", sqlCon);
                    Int32 count2 = (Int32)cmd3.ExecuteScalar();
                    string NumReg2 = count2.ToString();
                    SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + Globals.hxhLast + "' AND date <= '"+ Globals.hxh +"' AND Linea = 'Linea 1'", sqlCon);
                    Int32 count4 = (Int32)cmd4.ExecuteScalar();
                    string NumReg3 = count4.ToString();
                    SqlCommand cmd5 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + Globals.hxh + "' AND Linea = 'Linea 1'", sqlCon);
                    Int32 count5 = (Int32)cmd5.ExecuteScalar();
                    string NumReg4 = count5.ToString();
                    label25.Text = NumReg4;
                    label23.Text = NumReg3;
                    label10.Text = NumReg;
                    label21.Text = NumReg2;

                    sqlCon.Close();
                }
                
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Radio Button Linea 1
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox2.BackColor = Color.White;
            textBox2.Focus();
            if (radioButton1.Checked)
            {
                radioButton1.ForeColor = Color.FromArgb(32, 191, 85);
            }
            else if (radioButton1.Checked == false)
            {
                radioButton1.ForeColor = Color.White;
            }

        }

        // Radio Button Linea 2
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox2.BackColor = Color.White;
            textBox2.Focus();
            if (radioButton2.Checked)
            {
                radioButton2.ForeColor = Color.FromArgb(32, 191, 85);

            } else if (radioButton2.Checked == false)
            {
                radioButton2.ForeColor = Color.White;
            }
            
        }

        // Bearing Housing
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pictureBox3.Hide();
            pictureBox10.Hide();
            label12.Hide();
            if (textBox2.Text.Length == 32)
            {
                bool found = textBox2.Text.ToLower().IndexOf("16001500036") >= 0;
                if (found)
                {
                    try
                    {
                        using (SqlConnection sqlCon = new SqlConnection(connectionString))
                        {
                            sqlCon.Open();
                            SqlCommand sqlDa = new SqlCommand("SELECT date FROM GM_12L WHERE BearingHousing = '" + textBox2.Text + "' ", sqlCon);
                            var existe = sqlDa.ExecuteScalar();
                            var result = (existe == null ? "FirstTime" : "Repetido");

                            if (result == "FirstTime")
                            {
                                pictureBox3.Show();
                                textBox3.Enabled = true;
                                textBox3.BackColor = Color.White;
                                textBox3.Focus();
                            }
                            else if (result == "Repetido")
                            {
                                pictureBox10.Show();
                                textBox2.SelectionStart = textBox2.Text.Length;
                                textBox2.SelectionLength = textBox2.Text.Length;
                                textBox2.Focus();
                                label12.Show();
                                label12.Text = "Este Bearing Housing ya fue registrado en la base de datos el " + existe.ToString() + "";
                                return;
                            }

                        }



                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                        MessageBox.Show(error, "Error registrando datos BearingHousing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    pictureBox10.Show();
                    textBox2.SelectionStart = 0;
                    textBox2.SelectionLength = textBox2.Text.Length;
                    label12.Show();
                    label12.Text = "Pieza escaneada NO es un Bearing Housing";
                    textBox3.Enabled = false;
                    textBox3.BackColor = Color.Gray;
                    
                }
            }
            else
            {
                textBox3.Enabled = false;
                textBox3.BackColor = Color.Gray;
            }

        }

        // Shaft & Wheel
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            pictureBox4.Hide();
            pictureBox9.Hide();
            label13.Hide();

            if (textBox3.Text != "")
            {
                
                    

                try
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlDa = new SqlCommand("SELECT date FROM GM_12L WHERE SW = '" + textBox3.Text + "' ", sqlCon);
                        var existe = sqlDa.ExecuteScalar();
                        var result = (existe == null ? "FirstTime" : "Repetido");

                        if (result == "FirstTime")
                        {
                            pictureBox4.Show();
                            textBox1.Enabled = true;
                            textBox1.BackColor = Color.White;

                        }
                        else if (result == "Repetido")
                        {
                            pictureBox9.Show();
                            label13.Show();
                            textBox1.Enabled = false;
                            textBox1.BackColor = Color.Gray;
                            label13.Text = "Este Shaft & Wheel ya fue registrado en la base de datos el " + existe.ToString() + "";
                            return;
                        }

                    }



                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    MessageBox.Show(error, "Error registrando datos Shaft & Wheel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                textBox1.Enabled = false;
                textBox1.BackColor = Color.Gray;
           
            }
        }

        // Bearing Cover
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pictureBox5.Hide();
            pictureBox8.Hide();
            label14.Hide();

            if (textBox1.Text.Length == 32)
            {
                bool found = textBox1.Text.ToLower().IndexOf("16001500031") >= 0;
                if (found)
                {
                    

                    try
                    {
                        using (SqlConnection sqlCon = new SqlConnection(connectionString))
                        {
                            sqlCon.Open();
                            SqlCommand sqlDa = new SqlCommand("SELECT date FROM GM_12L WHERE BearingCover = '" + textBox1.Text + "' ", sqlCon);
                            var existe = sqlDa.ExecuteScalar();
                            var result = (existe == null ? "FirstTime" : "Repetido");

                            if (result == "FirstTime")
                            {
                                pictureBox5.Show();
                                textBox4.Enabled = true;
                                textBox4.BackColor = Color.White;
                                textBox4.Focus();
                            }
                            else if (result == "Repetido")
                            {
                                pictureBox8.Show();
                                textBox1.SelectionStart = 0;
                                textBox1.SelectionLength = textBox1.Text.Length;
                                label14.Show();
                                label14.Text = "Este BearingCover ya fue registrado en la base de datos el " + existe.ToString() + "";
                                return;
                            }

                        }



                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                        MessageBox.Show(error, "Error registrando datos BearingCover", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    pictureBox8.Show();
                    textBox1.SelectionStart = 0;
                    textBox1.SelectionLength = textBox1.Text.Length;
                    label14.Show();
                    label14.Text = "Pieza escaneada NO es un Bearing Cover";
                    textBox4.Enabled = false;
                    textBox4.BackColor = Color.Gray;
                }
            }
            else
            {

                textBox4.Enabled = false;
                textBox4.BackColor = Color.Gray;
               

            }
        }

        // Compressor Wheel
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            pictureBox6.Hide();
            pictureBox7.Hide();
            label15.Hide();

            if (textBox4.Text.Length == 32)
            {
                bool found = textBox4.Text.ToLower().IndexOf("16391232024") >= 0;
                if (found)
                {

                    try
                    {
                        using (SqlConnection sqlCon = new SqlConnection(connectionString))
                        {
                            sqlCon.Open();
                            SqlCommand sqlDa = new SqlCommand("SELECT date FROM GM_12L WHERE CompressorWheel = '" + textBox4.Text + "' ", sqlCon);
                            var existe = sqlDa.ExecuteScalar();
                            var result = (existe == null ? "FirstTime" : "Repetido");

                            if (result == "FirstTime")
                            {
                                pictureBox6.Show();
                                if (label22.Text == "Conectado a internet")
                                {
                                    button2.Enabled = true;
                                    button2.BackColor = Color.FromArgb(17, 133, 61);
                                    button2.Focus();
                                } else if (label22.Text == "Desconectado de internet")
                                {
                                    MessageBox.Show("NO HAY CONEXIÓN A INTERNET", "Error en conexión ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                
                            }
                            else if (result == "Repetido")
                            {
                                pictureBox7.Show();
                                textBox4.SelectionStart = 0;
                                textBox4.SelectionLength = textBox4.Text.Length;
                                label15.Show();
                                label15.Text = "Este Compressor Wheel ya fue registrado en la base de datos el " + existe.ToString() + "";
                                return;
                            }

                            sqlCon.Close();
                        }



                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                        MessageBox.Show(error, "Error registrando datos Compressor Wheel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    pictureBox7.Show();
                    textBox4.SelectionStart = 0;
                    textBox4.SelectionLength = textBox4.Text.Length;
                    label15.Show();
                    label15.Text = "Pieza escaneada NO es un Compressor Wheel";
                    
                }
            }
        }

        // Boton Borrar
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            button2.Enabled = false;
            button2.BackColor = Color.Gray;
        }

        // Boton enviar
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Register", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@BearingHousing", textBox2.Text.ToString());
                    cmd.Parameters.AddWithValue("@SW", textBox3.Text.ToString());
                    cmd.Parameters.AddWithValue("@BearingCover", textBox1.Text.ToString());
                    cmd.Parameters.AddWithValue("@CompressorWheel", textBox4.Text.ToString());
                    if (radioButton1.Checked)
                    {
                        cmd.Parameters.AddWithValue("@Linea", "Linea 1");
                        label18.Text = "Linea 1";
                    }else if (radioButton2.Checked)
                    {
                        cmd.Parameters.AddWithValue("@Linea", "Linea 2");
                        label18.Text = "Linea 2";
                    }
                    cmd.ExecuteNonQuery();
                    if (Globals.horaMinuto.Hour >= 18)
                    {
                        
                        SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.primerHoraRev + "' AND Linea = 'Linea 1'", sqlCon);
                        Int32 count = (Int32)cmd2.ExecuteScalar();
                        string NumReg = count.ToString();
                        SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.primerHoraRev + "' AND Linea = 'Linea 2'", sqlCon);
                        Int32 count2 = (Int32)cmd3.ExecuteScalar();
                        string NumReg2 = count2.ToString();
                        SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + Globals.hxhLast + "' AND date <= '" + Globals.hxh + "' AND Linea = 'Linea 1'", sqlCon);
                        Int32 count4 = (Int32)cmd4.ExecuteScalar();
                        string NumReg3 = count4.ToString();
                        SqlCommand cmd5 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + Globals.hxh + "' AND Linea = 'Linea 1'", sqlCon);
                        Int32 count5 = (Int32)cmd5.ExecuteScalar();
                        string NumReg4 = count5.ToString();
                        label25.Text = NumReg4;
                        label23.Text = NumReg3;
                        label10.Text = NumReg;
                        label21.Text = NumReg2;

                        sqlCon.Close();

                    }
                    else if (Globals.horaMinuto.Hour < 6)
                    {
                        
                        SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date BETWEEN '" + Globals.dia + " " + Globals.primerHoraRev + "' AND '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.segundaHoraRev + "' AND Linea = 'Linea 1'", sqlCon);
                        Int32 count = (Int32)cmd2.ExecuteScalar();
                        string NumReg = count.ToString();
                        SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + Globals.dia + " " + Globals.primerHoraRev + "' and date <= '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.segundaHoraRev + "' AND Linea = 'Linea 2'", sqlCon);
                        Int32 count2 = (Int32)cmd3.ExecuteScalar();
                        string NumReg2 = count2.ToString();
                        SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + Globals.hxhLast + "' AND date <= '" + Globals.hxh + "' AND Linea = 'Linea 1'", sqlCon);
                        Int32 count4 = (Int32)cmd4.ExecuteScalar();
                        string NumReg3 = count4.ToString();
                        SqlCommand cmd5 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + Globals.hxh + "' AND Linea = 'Linea 1'", sqlCon);
                        Int32 count5 = (Int32)cmd5.ExecuteScalar();
                        string NumReg4 = count5.ToString();
                        label25.Text = NumReg4;
                        label23.Text = NumReg3;
                        label10.Text = NumReg;
                        label21.Text = NumReg2;

                        sqlCon.Close();

                    }
                    else
                    {
                        
                        SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.primerHoraRev + "' and date <= '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.segundaHoraRev + "' AND Linea = 'Linea 1'", sqlCon);
                        Int32 count = (Int32)cmd2.ExecuteScalar();
                        string NumReg = count.ToString();
                        SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.primerHoraRev + "' and date <= '" + DateTime.Now.ToString("yyyy-MM-dd") + " " + Globals.segundaHoraRev + "' AND Linea = 'Linea 2'", sqlCon);
                        Int32 count2 = (Int32)cmd3.ExecuteScalar();
                        string NumReg2 = count2.ToString();
                        SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + Globals.hxhLast + "' AND date <= '" + Globals.hxh + "' AND Linea = 'Linea 1'", sqlCon);
                        Int32 count4 = (Int32)cmd4.ExecuteScalar();
                        string NumReg3 = count4.ToString();
                        SqlCommand cmd5 = new SqlCommand("SELECT COUNT(*) FROM GM_12L WHERE date >= '" + Globals.hxh + "' AND Linea = 'Linea 1'", sqlCon);
                        Int32 count5 = (Int32)cmd5.ExecuteScalar();
                        string NumReg4 = count5.ToString();
                        label25.Text = NumReg4;
                        label23.Text = NumReg3;
                        label10.Text = NumReg;
                        label21.Text = NumReg2;

                        sqlCon.Close();
                    }

                    
                }

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                label11.Visible = true;
                System.Threading.Tasks.Task.Delay(2500).ContinueWith(_ =>
                {
                    Invoke(new MethodInvoker(() => { label11.Visible = false; }));
                });

                label18.Visible = true;
                System.Threading.Tasks.Task.Delay(2500).ContinueWith(_ =>
                {
                    Invoke(new MethodInvoker(() => { label18.Visible = false; }));
                });

                pictureBox12.Visible = true;
                System.Threading.Tasks.Task.Delay(2500).ContinueWith(_ =>
                {
                    Invoke(new MethodInvoker(() => { pictureBox12.Visible = false; }));
                });

                pictureBox13.Visible = true;
                System.Threading.Tasks.Task.Delay(2500).ContinueWith(_ =>
                {
                    Invoke(new MethodInvoker(() => { pictureBox13.Visible = false; }));
                });

                button2.Enabled = false;
                button2.BackColor = Color.Gray;
                if (radioButton1.Checked || radioButton2.Checked)
                {
                    textBox2.Enabled = true;
                    textBox2.BackColor = Color.White;
                    textBox2.Focus();
                }
                
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(error, "Error registrando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Para tener el timer que se actualiza en la pantalla principal
        async void TimeUpdater()
        {
            while (true)
            {
                bool con = NetworkInterface.GetIsNetworkAvailable();
                if (con == true)
                {
                    label22.Text = "Conectado a internet";
                    label22.BackColor = Color.FromArgb(0, 56, 108);
                } else
                {
                    label22.Text = "Desconectado de internet";
                    label22.BackColor = Color.Red;
                }
                label24.Text = "HxH pasado: " + Globals.hxhLast.ToString("t") + "";
                label26.Text = "HxH actual " + Globals.hxh.ToString("t") + "";
                label8.Text = DateTime.Now.ToString();
                if ((Globals.horaMinuto.Hour >= 6) && (Globals.horaMinuto.Hour <= 17 && Globals.horaMinuto.Minute <= 59))
                {
                    label16.Text = Globals.primerTurno;
                    Globals.primerHoraRev = "06:00:00";
                    Globals.segundaHoraRev = "17:59:59";
                    Globals.dia = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    label16.Text = Globals.segundoTurno;
                    Globals.primerHoraRev = "18:00:00";
                    Globals.segundaHoraRev = " 05:59:59";
                    Globals.dia = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
                }
                await Task.Delay(1000);
            }
        }

        // Para evitar las acciones del enter automatico de los scanners
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                e.Handled = true;

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void radioButton2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void radioButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                e.SuppressKeyPress = true;
            }
        }


    }

    // MARK: - Globales de hora
    static class Globals
    {
        public static DateTime horaMinuto = DateTime.Now;
        public static string dia;
        public static string primerTurno = "1er turno";
        public static string segundoTurno = "2do turno";
        public static string primerHoraRev;
        public static string segundaHoraRev;
        public static DateTime src = DateTime.Now.AddHours(-1);
        public static DateTime hxhLast = new DateTime(src.Year, src.Month, src.Day, src.Hour, 00, 00);
        public static DateTime hxh = new DateTime(horaMinuto.Year, horaMinuto.Month, horaMinuto.Day, horaMinuto.Hour, 00, 00);
    }

}
