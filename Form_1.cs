using Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private const double anInch = 14.4;

        private string ip = File.ReadLines("C:\\adeies\\settings.txt").Skip(0).Take(1).First<string>();

     

        private string entrance = File.ReadLines("C:\\adeies\\settings.txt").Skip(6).Take(1).First<string>();

        private string table_name = File.ReadLines("C:\\adeies\\settings.txt").Skip(5).Take(1).First<string>();

        private string database = File.ReadLines("C:\\adeies\\settings.txt").Skip(2).Take(1).First<string>();

        private string uid = File.ReadLines("C:\\adeies\\settings.txt").Skip(3).Take(1).First<string>();

        private string password = File.ReadLines("C:\\adeies\\settings.txt").Skip(4).Take(1).First<string>();

        private string port = File.ReadLines("C:\\adeies\\settings.txt").Skip(1).Take(1).First<string>();

        //private StringReader myReader;
        MySqlDataAdapter mySqlDataAdapter;
        private PrintDocument mDoc = new PrintDocument();
       
      

        private PrintDocument document = new PrintDocument();

        private PrintDialog dialog = new PrintDialog();

        private MySqlConnection syndesi;

        //private MySqlConnection connection;

     

        //private MySqlCommandBuilder Upd;

        private System.Data.DataTable data = new System.Data.DataTable();

        //private DataSet dataset;

        private string connectionString;
        DataSet DS = new DataSet();
    

        //private IContainer components;

        

        public Form1()
        {
            InitializeComponent();
           
            //this.document.PrintPage += new PrintPageEventHandler(this.document_PrintPage);
            base.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
            this.comboBox_fill();
           
            //this.printDocument1.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);Form1_Load
            Form1_Load();
           
            
        }
       public void update()
        {
            DS.Clear();
            load_table();
       }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι οτι θέλετε να κλείσετε την εφαρμογη", "ΤΕΡΜΑΤΙΣΜΟΣ ΕΦΑΡΜΟΓΗΣ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                System.Windows.Forms.Application.ExitThread();
                return;
            }
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load()//object sender, EventArgs e)
        {
          
            this.button5.Visible = false;
            this.button9.Visible = false;
            this.panel1.Visible = false;
            
            this.button7.Visible = false;
            this.tabControl1.Visible= false;
            label23.Visible = false;
            comboBox5.Visible = false;
          
            
        }

        public void test()
        {
        }

        private void MySQL_ToDatagridview()
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application application = (Microsoft.Office.Interop.Word.Application)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\print.rtf"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\print11111.rtf");
                }
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\print.rtf"))
                {
                    this.richTextBox1.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\print.rtf");
                }
                else
                {
                    this.richTextBox1.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\print.rtf");
                }
            }
            catch { }
        }

        public void load_table()
        {
            
            this.connectionString = string.Concat(new string[]
			{
				"SERVER=",
				this.ip,
				";PORT=",
				this.port,
				";DATABASE=",
				this.database,
				";UID=",
				this.uid,
				";PASSWORD=",
				this.password,
				";charset=utf8"
			});
            
            this.syndesi = new MySqlConnection(this.connectionString);
             mySqlDataAdapter = new MySqlDataAdapter("SELECT * FROM new_table", syndesi); 
            syndesi.Open();
            
        
        try{

                
               // this.syndesi.Open();
                
            
                mySqlDataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            ////dataTable = new DataTable();

                //syndesi.Close();

                this.column_names();

                button5.Visible = true;
                this.button4.Visible = false;
                this.button3.Visible = true;
                this.label11.Visible = true;
                this.button9.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
         
            DialogResult dialogResult = MessageBox.Show("ΘΑ ΓΙΝΟΥΝ ΑΛΛΑΓΕΣ ΣΤΗ ΒΑΣΗ ΔΕΔΟΜΕΝΩΝ,ΘΕΛΕΤΕ ΝΑ ΣΥΝΕΧΙΣΕΤΕ?", "ΠΡΟΣΟΧΗ!!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    // MySqlCommandBuilder gg= new MySqlCommandBuilder(adapter);

                    //DataSet DS = new DataSet();
                    //this.adapter.Update(dataset, this.table_name);
                    ////new MySqlCommandBuilder(adapter);
     
                   //// adapter.Update(dataset);
                 

                    // add rows to dataset
                ///INSERT INTO `new_table` (`name`, `kanoniki_ypol`) VALUES ('444', 'gfgf')

                    // add rows to dataset
                    DS.GetChanges();

                    // Just for test.... Try this with or without the EndEdit....

                    MySqlDataAdapter adapt = new MySqlDataAdapter();
                    MySqlCommandBuilder commbuilder = new MySqlCommandBuilder(adapt);
                    adapt.SelectCommand = new MySqlCommand("SELECT * FROM new_table", syndesi);
                    adapt.Update(DS.Tables[0]);

                    update();

                    // this.dataset.AcceptChanges();
                   // this.adapter.Update(this.dataset, this.table_name);
                   // dataGridView1.DataSource = DS.Tables[0];
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                
                }
           
                MessageBox.Show("ΑΛΛΑΓΗ ΠΛΗΡΟΦΟΡΙΩΝ", "ΑΝΑΒΑΘΜΙΣΗ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox21.Text != this.entrance)
                {
                    MessageBox.Show("ΛΑΘΟΣ ΚΩΔΙΚΟΣ ΠΡΟΣΒΑΣΗΣ!!!ΠΡΟΣΠΑΘΕΙΣΤΕ ΞΑΝΑ", "ΑΝΕΠΙΤΥΧΗΣ ΕΙΣΟΔΟΣ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    this.label20.Text = File.ReadLines("C:\\adeies\\index.txt").Skip(0).Take(1).First<string>();


                    tabPage1.Text = "ΠΕΡΙΟΧΗ ΑΛΛΑΓΩΝ";
                    tabPage2.Text = "ΕΚΤΥΠΩΣΗ ΑΔΕΙΑΣ";
                 
                    this.button7.Visible = true;
                    this.panel1.Visible = true;
                    this.tabControl1.Visible = true;
                    this.button4.Visible = false;
                    this.textBox21.Visible = false;
                    
                   

                    load_table();
                    Fillcombo();

                }
            }
            catch (Exception) 
            {
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                label23.Visible = false;
                comboBox5.Visible = false;
                this.richTextBox1.Clear();
                if (this.comboBox1.Text == "ΚΑΝΟΝΙΚΗ ΑΔΕΙΑ")
                {
                    counter = 0;
                    string text = File.ReadLines("C:\\adeies\\index.txt").Skip(0).Take(1).First<string>();
                    this.label20.Text = text;
                    this.richTextBox1.LoadFile("C:\\adeies\\kanoniki.rtf");
                    this.richTextBox1.Find("date_start");
                    this.richTextBox1.SelectedText = this.dateTimePicker1.Value.ToString();
                }
                if (this.comboBox1.Text == "ΚΑΝΟΝΙΚΗ ΑΔΕΙΑ ΜΕ ΑΝΑΠΛΗΡΩΣΗ")
                {

                    counter = 0;
                    string text = File.ReadLines("C:\\adeies\\index.txt").Skip(0).Take(1).First<string>();
                    this.label20.Text = text;
                    this.richTextBox1.LoadFile("C:\\adeies\\kanoniki_anap.rtf");
                    this.richTextBox1.Find("date_start");
                    this.richTextBox1.SelectedText = this.dateTimePicker1.Value.ToString();
                    label23.Visible = true;
                    comboBox5.Visible = true;
                }
                if (this.comboBox1.Text == "ΑΝΑΡΡΩΤΙΚΗ ΑΔΕΙΑ ΜΕ Υ.Δ.")
                {
                    counter = 0;
                    string text2 = File.ReadLines("C:\\adeies\\index.txt").Skip(0).Take(1).First<string>();
                    this.label20.Text = text2;
                    this.richTextBox1.LoadFile("C:\\adeies\\anarotiki_yd.rtf");
                }
                if (this.comboBox1.Text == "ΑΝΑΡΡΩΤΙΚΗ ΑΔΕΙΑ ΓΙΑΤΡΟΥ")
                {
                    counter = 0;
                    string text3 = File.ReadLines("C:\\adeies\\index.txt").Skip(0).Take(1).First<string>();
                    this.label20.Text = text3;
                    this.richTextBox1.LoadFile("C:\\adeies\\anarotiki_ig.rtf");
                }
                if (this.comboBox1.Text == "ΑΔΕΙΑ ΕΚΤΑΚΤΗΣ ΑΝΑΓΚΗΣ")
                {
                    counter = 0;
                    string text4 = File.ReadLines("C:\\adeies\\index.txt").Skip(0).Take(1).First<string>();
                    this.label20.Text = text4;
                    this.richTextBox1.LoadFile("C:\\adeies\\ektaktis_anagkis.rtf");
                }
                if (this.comboBox1.Text == "ΣΥΝΔΙΚΑΛΙΣΤΙΚΗ ΑΔΕΙΑ")
                {
                    counter = 0;
                    string text5 = File.ReadLines("C:\\adeies\\index.txt").Skip(0).Take(1).First<string>();
                    this.label20.Text = text5;
                    this.richTextBox1.LoadFile("C:\\adeies\\syndikalistiki.rtf");
                }
            }
            catch
            {
            }
        }
        private void Fillcombo()
        {

            try
            {
                int indexOfYourColumn = 1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    comboBox2.Items.Add(row.Cells[indexOfYourColumn].Value);
                }
            }
            catch (Exception)
            {
            }

           // comboBox2.Items.Add(dataGridView1.Columns[1]);
        }
        private int counter;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                counter++;
                if(counter>1 )
                {
                    DialogResult dialogResult = MessageBox.Show("ΕΧΕΤΕ  ΗΔΗ ΧΡΗΣΙΜΟΠΟΙΗΣΕΙ ΤΗ ΛΕΙΤΟΥΡΓΙΑ 1 ΦΟΡΑ ΓΙ ΑΥΤΗ ΤΗΝ ΑΔΕΙΑ.ΘΕΛΕΤΕ ΝΑ ΠΡΟΧΩΡΗΣΕΤΕ?", "ΠΡΟΣΟΧΗ!!!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        apply();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                       
                    }
                }
                else
                {
                    apply();

                }
                
               
        }
            catch(Exception)
            {}
        }
          private void apply()
          {
              try
              {
                  {
                      this.richTextBox1.Clear();
                      if (this.comboBox1.Text == "ΚΑΝΟΝΙΚΗ ΑΔΕΙΑ")
                      {
                          this.richTextBox1.LoadFile("C:\\adeies\\kanoniki.rtf");
                          string text = this.richTextBox1.Text.ToString();
                          int num = Form1.Emfaniseis(text, "onoma");
                          int num2 = Form1.Emfaniseis(text, "date_start");
                          int num3 = Form1.Emfaniseis(text, "date_end");
                          int num4 = Form1.Emfaniseis(text, "date_back");
                          int num5 = Form1.Emfaniseis(text, "date_end");
                          int num6 = Form1.Emfaniseis(text, "pro_num");
                          int num7 = Form1.Emfaniseis(text, "duration");
                          int num8 = Form1.Emfaniseis(text, "sign_persons");
                          int num9 = Form1.Emfaniseis(text, "ypol1");
                          int num10 = Form1.Emfaniseis(text, "selections");
                          int num11 = Form1.Emfaniseis(text, "date_apo");
                          int num12 = Form1.Emfaniseis(text, "tmima");
                          int num13 = Form1.Emfaniseis(text, "adress");
                          int num14 = Form1.Emfaniseis(text, "sec");
                          for (int i = 0; i < num14; i++)
                          {
                              this.richTextBox1.Find("sec");
                              this.richTextBox1.SelectedText = this.CalculateChecksum(WindowsIdentity.GetCurrent().Name.ToString());
                          }
                          for (int j = 0; j < num2; j++)
                          {
                              this.richTextBox1.Find("date_start");
                              this.richTextBox1.SelectedText = this.dateTimePicker1.Value.ToShortDateString();
                          }
                          for (int k = 0; k < num3; k++)
                          {
                              this.richTextBox1.Find("date_end");
                              this.richTextBox1.SelectedText = this.dateTimePicker3.Value.ToShortDateString();
                          }
                          for (int l = 0; l < num4; l++)
                          {
                              this.richTextBox1.Find("date_back");
                              this.richTextBox1.SelectedText = this.dateTimePicker4.Value.ToShortDateString();
                          }
                          for (int m = 0; m < num5; m++)
                          {
                              this.richTextBox1.Find("date_ait");
                              this.richTextBox1.SelectedText = this.dateTimePicker5.Value.ToShortDateString();
                          }
                          for (int n = 0; n < num; n++)
                          {
                              this.richTextBox1.Find("onoma");
                              this.richTextBox1.SelectedText = this.comboBox2.SelectedItem.ToString();
                          }
                          for (int num15 = 0; num15 < num6; num15++)
                          {
                              this.richTextBox1.Find("pro_num");
                              this.richTextBox1.SelectedText = this.textBox2.Text;
                          }
                          for (int num16 = 0; num16 < num7; num16++)
                          {
                              this.richTextBox1.Find("duration");
                              this.richTextBox1.SelectedText = this.numericUpDown2.Value.ToString();
                          }
                          for (int num17 = 0; num17 < num8; num17++)
                          {
                              this.richTextBox1.Find("sign_persons");
                              this.richTextBox1.SelectedText = this.comboBox3.SelectedItem.ToString();
                          }
                          for (int num18 = 0; num18 < num9; num18++)
                          {
                              this.richTextBox1.Find("ypol1");
                              int num19 = Convert.ToInt32(this.dataGridView1[5, this.comboBox2.SelectedIndex].Value);
                              int value = Math.Abs(num19 - decimal.ToInt32(this.numericUpDown2.Value));
                              this.richTextBox1.SelectedText = Convert.ToString(value);
                          }
                          for (int num20 = 0; num20 < num10; num20++)
                          {
                              this.richTextBox1.Find("selections");
                              this.richTextBox1.SelectedText = this.comboBox4.SelectedItem.ToString();
                          }
                          for (int num21 = 0; num21 < num11; num21++)
                          {
                              this.richTextBox1.Find("date_apo");
                              this.richTextBox1.SelectedText = this.dateTimePicker6.Value.ToShortDateString();
                          }
                          for (int num22 = 0; num22 < num12; num22++)
                          {
                              this.richTextBox1.Find("tmima");
                              this.richTextBox1.SelectedText = this.dataGridView1[17, this.comboBox2.SelectedIndex].Value.ToString();
                          }
                          for (int num23 = 0; num23 < num13; num23++)
                          {
                              this.richTextBox1.Find("adress");
                              this.richTextBox1.SelectedText = this.dataGridView1[16, this.comboBox2.SelectedIndex].Value.ToString();
                          }
                          string s = this.dataGridView1[0, this.comboBox2.SelectedIndex].Value.ToString();
                          int num24 = int.Parse(s);
                          int num25 = Convert.ToInt32(this.dataGridView1[5, this.comboBox2.SelectedIndex].Value) - decimal.ToInt32(this.numericUpDown2.Value);
                          string cmdText = "UPDATE `new_table` SET  `anarotiki_yd1`=@anarotiki_yd1   WHERE `name`= @name;";
                          MySqlCommand mySqlCommand = new MySqlCommand(cmdText, this.syndesi);
                          mySqlCommand.Parameters.AddWithValue("@name", num24);
                          mySqlCommand.Parameters.AddWithValue("@anarotiki_yd1", num25);
                          mySqlCommand.CommandTimeout = 120;
                          try
                          {
                              mySqlCommand.ExecuteNonQuery();
                              update();
                          }
                          catch (Exception ex)
                          {
                              MessageBox.Show(ex.Message);
                          }
                      }
                      if (this.comboBox1.Text == "ΚΑΝΟΝΙΚΗ ΑΔΕΙΑ ΜΕ ΑΝΑΠΛΗΡΩΣΗ")
                      {
                          this.richTextBox1.LoadFile("C:\\adeies\\kanoniki_anap.rtf");
                          string text = this.richTextBox1.Text.ToString();
                          int num = Form1.Emfaniseis(text, "onoma");
                          int num2 = Form1.Emfaniseis(text, "date_start");
                          int num3 = Form1.Emfaniseis(text, "date_end");
                          int num4 = Form1.Emfaniseis(text, "date_back");
                          int num5 = Form1.Emfaniseis(text, "date_end");
                          int num6 = Form1.Emfaniseis(text, "pro_num");
                          int num7 = Form1.Emfaniseis(text, "duration");
                          int num8 = Form1.Emfaniseis(text, "sign_persons");
                          int num9 = Form1.Emfaniseis(text, "ypol1");
                          int num10 = Form1.Emfaniseis(text, "selections");
                          int num11 = Form1.Emfaniseis(text, "date_apo");
                          int num12 = Form1.Emfaniseis(text, "tmima");
                          int num13 = Form1.Emfaniseis(text, "adress");
                          int num14 = Form1.Emfaniseis(text, "sec");
                          int anap = Form1.Emfaniseis(text, "anap_name");
                          for (int i = 0; i < num14; i++)
                          {
                              this.richTextBox1.Find("sec");
                              this.richTextBox1.SelectedText = this.CalculateChecksum(WindowsIdentity.GetCurrent().Name.ToString());
                          }
                          for (int j = 0; j < num2; j++)
                          {
                              this.richTextBox1.Find("date_start");
                              this.richTextBox1.SelectedText = this.dateTimePicker1.Value.ToShortDateString();
                          }
                          for (int k = 0; k < num3; k++)
                          {
                              this.richTextBox1.Find("date_end");
                              this.richTextBox1.SelectedText = this.dateTimePicker3.Value.ToShortDateString();
                          }
                          for (int l = 0; l < num4; l++)
                          {
                              this.richTextBox1.Find("date_back");
                              this.richTextBox1.SelectedText = this.dateTimePicker4.Value.ToShortDateString();
                          }
                          for (int m = 0; m < num5; m++)
                          {
                              this.richTextBox1.Find("date_ait");
                              this.richTextBox1.SelectedText = this.dateTimePicker5.Value.ToShortDateString();
                          }
                          for (int n = 0; n < num; n++)
                          {
                              this.richTextBox1.Find("onoma");
                              this.richTextBox1.SelectedText = this.comboBox2.SelectedItem.ToString();
                          }
                          for (int num15 = 0; num15 < num6; num15++)
                          {
                              this.richTextBox1.Find("pro_num");
                              this.richTextBox1.SelectedText = this.textBox2.Text;
                          }
                          for (int num16 = 0; num16 < num7; num16++)
                          {
                              this.richTextBox1.Find("duration");
                              this.richTextBox1.SelectedText = this.numericUpDown2.Value.ToString();
                          }
                          for (int num17 = 0; num17 < num8; num17++)
                          {
                              this.richTextBox1.Find("sign_persons");
                              this.richTextBox1.SelectedText = this.comboBox3.SelectedItem.ToString();
                          }
                          for (int num18 = 0; num18 < num9; num18++)
                          {
                              this.richTextBox1.Find("ypol1");
                              int num19 = Convert.ToInt32(this.dataGridView1[5, this.comboBox2.SelectedIndex].Value);
                              int value = Math.Abs(num19 - decimal.ToInt32(this.numericUpDown2.Value));
                              this.richTextBox1.SelectedText = Convert.ToString(value);
                          }
                          for (int num20 = 0; num20 < num10; num20++)
                          {
                              this.richTextBox1.Find("selections");
                              this.richTextBox1.SelectedText = this.comboBox4.SelectedItem.ToString();
                          }
                          for (int num21 = 0; num21 < num11; num21++)
                          {
                              this.richTextBox1.Find("date_apo");
                              this.richTextBox1.SelectedText = this.dateTimePicker6.Value.ToShortDateString();
                          }
                          for (int num22 = 0; num22 < num12; num22++)
                          {
                              this.richTextBox1.Find("tmima");
                              this.richTextBox1.SelectedText = this.dataGridView1[17, this.comboBox2.SelectedIndex].Value.ToString();
                          }
                          for (int num23 = 0; num23 < num13; num23++)
                          {
                              this.richTextBox1.Find("adress");
                              this.richTextBox1.SelectedText = this.dataGridView1[16, this.comboBox2.SelectedIndex].Value.ToString();
                          }
                          for (int i = 0; i < anap; i++)
                          {
                              this.richTextBox1.Find("anap_name");
                              this.richTextBox1.SelectedText = this.comboBox5.SelectedItem.ToString();
                          }
                          string s = this.dataGridView1[0, this.comboBox2.SelectedIndex].Value.ToString();
                          int num24 = int.Parse(s);
                          int num25 = Convert.ToInt32(this.dataGridView1[5, this.comboBox2.SelectedIndex].Value) - decimal.ToInt32(this.numericUpDown2.Value);
                          string cmdText = "UPDATE `new_table` SET  `anarotiki_yd1`=@anarotiki_yd1   WHERE `name`= @name;";
                          MySqlCommand mySqlCommand = new MySqlCommand(cmdText, this.syndesi);
                          mySqlCommand.Parameters.AddWithValue("@name", num24);
                          mySqlCommand.Parameters.AddWithValue("@anarotiki_yd1", num25);
                          mySqlCommand.CommandTimeout = 120;
                          try
                          {
                              mySqlCommand.ExecuteNonQuery();
                              update();
                          }
                          catch (Exception ex)
                          {
                              MessageBox.Show(ex.Message);
                          }
                      }
                      if (this.comboBox1.Text == "ΑΝΑΡΡΩΤΙΚΗ ΑΔΕΙΑ ΜΕ Υ.Δ.")
                      {
                          this.richTextBox1.LoadFile("C:\\adeies\\anarotiki_yd.rtf");
                          string text2 = this.richTextBox1.Text.ToString();
                          int num26 = Form1.Emfaniseis(text2, "onoma");
                          int num27 = Form1.Emfaniseis(text2, "date_start");
                          int num28 = Form1.Emfaniseis(text2, "date_end");
                          int num29 = Form1.Emfaniseis(text2, "date_back");
                          int num30 = Form1.Emfaniseis(text2, "date_end");
                          int num31 = Form1.Emfaniseis(text2, "pro_num");
                          int num32 = Form1.Emfaniseis(text2, "duration");
                          int num33 = Form1.Emfaniseis(text2, "sign_persons");
                          int num34 = Form1.Emfaniseis(text2, "ypol1");
                          int num35 = Form1.Emfaniseis(text2, "selections");
                          int num36 = Form1.Emfaniseis(text2, "date_apo");
                          int num37 = Form1.Emfaniseis(text2, "tmima");
                          int num38 = Form1.Emfaniseis(text2, "adress");
                          int num39 = Form1.Emfaniseis(text2, "sec");
                          for (int num40 = 0; num40 < num39; num40++)
                          {
                              this.richTextBox1.Find("sec");
                              this.richTextBox1.SelectedText = this.CalculateChecksum(WindowsIdentity.GetCurrent().Name.ToString());
                          }
                          for (int num41 = 0; num41 < num27; num41++)
                          {
                              this.richTextBox1.Find("date_start");
                              this.richTextBox1.SelectedText = this.dateTimePicker1.Value.ToShortDateString();
                          }
                          for (int num42 = 0; num42 < num29; num42++)
                          {
                              this.richTextBox1.Find("date_back");
                              this.richTextBox1.SelectedText = this.dateTimePicker4.Value.ToShortDateString();
                          }
                          for (int num43 = 0; num43 < num30; num43++)
                          {
                              this.richTextBox1.Find("date_ait");
                              this.richTextBox1.SelectedText = this.dateTimePicker5.Value.ToShortDateString();
                          }
                          for (int num44 = 0; num44 < num26; num44++)
                          {
                              this.richTextBox1.Find("onoma");
                              this.richTextBox1.SelectedText = this.comboBox2.SelectedItem.ToString();
                          }
                          for (int num45 = 0; num45 < num31; num45++)
                          {
                              this.richTextBox1.Find("pro_num");
                              this.richTextBox1.SelectedText = this.textBox2.Text;
                          }
                          for (int num46 = 0; num46 < num32; num46++)
                          {
                              this.richTextBox1.Find("duration");
                              this.richTextBox1.SelectedText = this.numericUpDown2.Value.ToString();
                          }
                          for (int num47 = 0; num47 < num33; num47++)
                          {
                              this.richTextBox1.Find("sign_persons");
                              this.richTextBox1.SelectedText = this.comboBox3.SelectedItem.ToString();
                          }
                          for (int num48 = 0; num48 < num35; num48++)
                          {
                              this.richTextBox1.Find("selections");
                              this.richTextBox1.SelectedText = this.comboBox4.SelectedItem.ToString();
                          }
                          for (int num49 = 0; num49 < num36; num49++)
                          {
                              this.richTextBox1.Find("date_apo");
                              this.richTextBox1.SelectedText = this.dateTimePicker6.Value.ToShortDateString();
                          }
                          for (int num50 = 0; num50 < num37; num50++)
                          {
                              this.richTextBox1.Find("tmima");
                              this.richTextBox1.SelectedText = this.dataGridView1[17, this.comboBox2.SelectedIndex].Value.ToString();
                          }
                          for (int num51 = 0; num51 < num38; num51++)
                          {
                              this.richTextBox1.Find("adress");
                              this.richTextBox1.SelectedText = this.dataGridView1[16, this.comboBox2.SelectedIndex].Value.ToString();
                          }
                          for (int num52 = 0; num52 < num34; num52++)
                          {
                              this.richTextBox1.Find("ypol1");
                              int num53 = Convert.ToInt32(this.dataGridView1[5, this.comboBox2.SelectedIndex].Value);
                              int value2 = Math.Abs(num53 - decimal.ToInt32(this.numericUpDown2.Value));
                              this.richTextBox1.SelectedText = Convert.ToString(value2);
                          }
                          for (int num54 = 0; num54 < num28; num54++)
                          {
                              this.richTextBox1.Find("date_end");
                              this.richTextBox1.SelectedText = this.dateTimePicker3.Value.ToShortDateString();
                          }
                          string s2 = this.dataGridView1[0, this.comboBox2.SelectedIndex].Value.ToString();
                          int num55 = int.Parse(s2);
                          int num56 = Convert.ToInt32(this.dataGridView1[6, this.comboBox2.SelectedIndex].Value) + decimal.ToInt32(this.numericUpDown2.Value);
                          string cmdText2 = "UPDATE `new_table` SET  `anarotki_ig1`=@anarotiki_ig1   WHERE `name`= @name;";
                          MySqlCommand mySqlCommand2 = new MySqlCommand(cmdText2, this.syndesi);
                          mySqlCommand2.Parameters.AddWithValue("@name", num55);
                          mySqlCommand2.Parameters.AddWithValue("@anarotiki_ig1", num56);
                          mySqlCommand2.CommandTimeout = 120;
                          try
                          {
                              mySqlCommand2.ExecuteNonQuery();
                              update();
                          }
                          catch (Exception ex2)
                          {
                              MessageBox.Show(ex2.Message);
                          }
                      }
                      if (this.comboBox1.Text == "ΑΝΑΡΡΩΤΙΚΗ ΑΔΕΙΑ ΓΙΑΤΡΟΥ")
                      {
                          this.richTextBox1.LoadFile("C:\\adeies\\anarotiki_ig.rtf");
                          string text3 = this.richTextBox1.Text.ToString();
                          int num57 = Form1.Emfaniseis(text3, "onoma");
                          int num58 = Form1.Emfaniseis(text3, "date_start");
                          int num59 = Form1.Emfaniseis(text3, "date_end");
                          int num60 = Form1.Emfaniseis(text3, "date_back");
                          int num61 = Form1.Emfaniseis(text3, "date_end");
                          int num62 = Form1.Emfaniseis(text3, "pro_num");
                          int num63 = Form1.Emfaniseis(text3, "duration");
                          int num64 = Form1.Emfaniseis(text3, "sign_persons");
                          int num65 = Form1.Emfaniseis(text3, "ypol1");
                          int num66 = Form1.Emfaniseis(text3, "date_apo");
                          int num67 = Form1.Emfaniseis(text3, "tmima");
                          int num68 = Form1.Emfaniseis(text3, "adress");
                          int num69 = Form1.Emfaniseis(text3, "selections");
                          int num70 = Form1.Emfaniseis(text3, "sec");
                          for (int num71 = 0; num71 < num70; num71++)
                          {
                              this.richTextBox1.Find("sec");
                              this.richTextBox1.SelectedText = this.CalculateChecksum(WindowsIdentity.GetCurrent().Name.ToString());
                          }
                          for (int num72 = 0; num72 < num58; num72++)
                          {
                              this.richTextBox1.Find("date_start");
                              this.richTextBox1.SelectedText = this.dateTimePicker1.Value.ToShortDateString();
                          }
                          for (int num73 = 0; num73 < num59; num73++)
                          {
                              this.richTextBox1.Find("date_end");
                              this.richTextBox1.SelectedText = this.dateTimePicker3.Value.ToShortDateString();
                          }
                          for (int num74 = 0; num74 < num60; num74++)
                          {
                              this.richTextBox1.Find("date_back");
                              this.richTextBox1.SelectedText = this.dateTimePicker4.Value.ToShortDateString();
                          }
                          for (int num75 = 0; num75 < num61; num75++)
                          {
                              this.richTextBox1.Find("date_ait");
                              this.richTextBox1.SelectedText = this.dateTimePicker5.Value.ToShortDateString();
                          }
                          for (int num76 = 0; num76 < num57; num76++)
                          {
                              this.richTextBox1.Find("onoma");
                              this.richTextBox1.SelectedText = this.comboBox2.SelectedItem.ToString();
                          }
                          for (int num77 = 0; num77 < num62; num77++)
                          {
                              this.richTextBox1.Find("pro_num");
                              this.richTextBox1.SelectedText = this.textBox2.Text;
                          }
                          for (int num78 = 0; num78 < num63; num78++)
                          {
                              this.richTextBox1.Find("duration");
                              this.richTextBox1.SelectedText = this.numericUpDown2.Value.ToString();
                          }
                          for (int num79 = 0; num79 < num64; num79++)
                          {
                              this.richTextBox1.Find("sign_persons");
                              this.richTextBox1.SelectedText = this.comboBox3.SelectedItem.ToString();
                          }
                          for (int num80 = 0; num80 < num69; num80++)
                          {
                              this.richTextBox1.Find("selections");
                              this.richTextBox1.SelectedText = this.comboBox4.SelectedItem.ToString();
                          }
                          for (int num81 = 0; num81 < num66; num81++)
                          {
                              this.richTextBox1.Find("date_apo");
                              this.richTextBox1.SelectedText = this.dateTimePicker6.Value.ToShortDateString();
                          }
                          for (int num82 = 0; num82 < num67; num82++)
                          {
                              this.richTextBox1.Find("tmima");
                              this.richTextBox1.SelectedText = this.dataGridView1[17, this.comboBox2.SelectedIndex].Value.ToString();
                          }
                          for (int num83 = 0; num83 < num68; num83++)
                          {
                              this.richTextBox1.Find("adress");
                              this.richTextBox1.SelectedText = this.dataGridView1[16, this.comboBox2.SelectedIndex].Value.ToString();
                          }
                          for (int num84 = 0; num84 < num65; num84++)
                          {
                              this.richTextBox1.Find("ypol1");
                              int num85 = Convert.ToInt32(this.dataGridView1[5, this.comboBox2.SelectedIndex].Value);
                              int value3 = Math.Abs(num85 - decimal.ToInt32(this.numericUpDown2.Value));
                              this.richTextBox1.SelectedText = Convert.ToString(value3);
                          }
                          string s3 = this.dataGridView1[0, this.comboBox2.SelectedIndex].Value.ToString();
                          int num86 = int.Parse(s3);
                          int num87 = Convert.ToInt32(this.dataGridView1[7, this.comboBox2.SelectedIndex].Value) - decimal.ToInt32(this.numericUpDown2.Value);
                          string cmdText3 = "UPDATE `new_table` SET  `personID1`=@personID1   WHERE `name`= @name;";
                          MySqlCommand mySqlCommand3 = new MySqlCommand(cmdText3, this.syndesi);
                          mySqlCommand3.Parameters.AddWithValue("@name", num86);
                          mySqlCommand3.Parameters.AddWithValue("@personID1", num87);
                          mySqlCommand3.CommandTimeout = 120;
                          try
                          {
                              mySqlCommand3.ExecuteNonQuery();
                              update();
                          }
                          catch (Exception ex3)
                          {
                              MessageBox.Show(ex3.Message);
                          }
                      }
                      if (this.comboBox1.Text == "ΑΔΕΙΑ ΕΚΤΑΚΤΗΣ ΑΝΑΓΚΗΣ")
                      {
                          this.richTextBox1.LoadFile("C:\\adeies\\ektaktis_anagkis.rtf");
                          string text4 = this.richTextBox1.Text.ToString();
                          int num88 = Form1.Emfaniseis(text4, "onoma");
                          int num89 = Form1.Emfaniseis(text4, "date_start");
                          int num90 = Form1.Emfaniseis(text4, "date_end");
                          int num91 = Form1.Emfaniseis(text4, "date_back");
                          int num92 = Form1.Emfaniseis(text4, "date_end");
                          int num93 = Form1.Emfaniseis(text4, "pro_num");
                          int num94 = Form1.Emfaniseis(text4, "duration");
                          int num95 = Form1.Emfaniseis(text4, "sign_persons");
                          int num96 = Form1.Emfaniseis(text4, "ypol1");
                          int num97 = Form1.Emfaniseis(text4, "date_apo");
                          int num98 = Form1.Emfaniseis(text4, "tmima");
                          int num99 = Form1.Emfaniseis(text4, "adress");
                          int num100 = Form1.Emfaniseis(text4, "selections");
                          int num101 = Form1.Emfaniseis(text4, "sec");
                          for (int num102 = 0; num102 < num101; num102++)
                          {
                              this.richTextBox1.Find("sec");
                              this.richTextBox1.SelectedText = this.CalculateChecksum(WindowsIdentity.GetCurrent().Name.ToString());
                          }
                          for (int num103 = 0; num103 < num89; num103++)
                          {
                              this.richTextBox1.Find("date_start");
                              this.richTextBox1.SelectedText = this.dateTimePicker1.Value.ToShortDateString();
                          }
                          for (int num104 = 0; num104 < num90; num104++)
                          {
                              this.richTextBox1.Find("date_end");
                              this.richTextBox1.SelectedText = this.dateTimePicker3.Value.ToShortDateString();
                          }
                          for (int num105 = 0; num105 < num91; num105++)
                          {
                              this.richTextBox1.Find("date_back");
                              this.richTextBox1.SelectedText = this.dateTimePicker4.Value.ToShortDateString();
                          }
                          for (int num106 = 0; num106 < num92; num106++)
                          {
                              this.richTextBox1.Find("date_ait");
                              this.richTextBox1.SelectedText = this.dateTimePicker5.Value.ToShortDateString();
                          }
                          for (int num107 = 0; num107 < num88; num107++)
                          {
                              this.richTextBox1.Find("onoma");
                              this.richTextBox1.SelectedText = this.comboBox2.SelectedItem.ToString();
                          }
                          for (int num108 = 0; num108 < num93; num108++)
                          {
                              this.richTextBox1.Find("pro_num");
                              this.richTextBox1.SelectedText = this.textBox2.Text;
                          }
                          for (int num109 = 0; num109 < num94; num109++)
                          {
                              this.richTextBox1.Find("duration");
                              this.richTextBox1.SelectedText = this.numericUpDown2.Value.ToString();
                          }
                          for (int num110 = 0; num110 < num95; num110++)
                          {
                              this.richTextBox1.Find("sign_persons");
                              this.richTextBox1.SelectedText = this.comboBox3.SelectedItem.ToString();
                          }
                          for (int num111 = 0; num111 < num100; num111++)
                          {
                              this.richTextBox1.Find("selections");
                              this.richTextBox1.SelectedText = this.comboBox4.SelectedItem.ToString();
                          }
                          for (int num112 = 0; num112 < num97; num112++)
                          {
                              this.richTextBox1.Find("date_apo");
                              this.richTextBox1.SelectedText = this.dateTimePicker6.Value.ToShortDateString();
                          }
                          for (int num113 = 0; num113 < num98; num113++)
                          {
                              this.richTextBox1.Find("tmima");
                              this.richTextBox1.SelectedText = this.dataGridView1[17, this.comboBox2.SelectedIndex].Value.ToString();
                          }
                          for (int num114 = 0; num114 < num99; num114++)
                          {
                              this.richTextBox1.Find("adress");
                              this.richTextBox1.SelectedText = this.dataGridView1[16, this.comboBox2.SelectedIndex].Value.ToString();
                          }
                          for (int num115 = 0; num115 < num96; num115++)
                          {
                              this.richTextBox1.Find("ypol1");
                              int num116 = Convert.ToInt32(this.dataGridView1[5, this.comboBox2.SelectedIndex].Value);
                              int value4 = Math.Abs(num116 - decimal.ToInt32(this.numericUpDown2.Value));
                              this.richTextBox1.SelectedText = Convert.ToString(value4);
                          }
                          string s4 = this.dataGridView1[0, this.comboBox2.SelectedIndex].Value.ToString();
                          int num117 = int.Parse(s4);
                          int num118 = Convert.ToInt32(this.dataGridView1[8, this.comboBox2.SelectedIndex].Value) + decimal.ToInt32(this.numericUpDown2.Value);
                          string cmdText4 = "UPDATE `new_table` SET  `ektaktis_anagkis_ypol1`=@ektaktis_anagkis_ypol1   WHERE `name`= @name;";
                          MySqlCommand mySqlCommand4 = new MySqlCommand(cmdText4, this.syndesi);
                          mySqlCommand4.Parameters.AddWithValue("@name", num117);
                          mySqlCommand4.Parameters.AddWithValue("@ektaktis_anagkis_ypol1", num118);
                          mySqlCommand4.CommandTimeout = 120;
                          try
                          {
                              mySqlCommand4.ExecuteNonQuery();
                              update();
                          }
                          catch (Exception ex4)
                          {
                              MessageBox.Show(ex4.Message);
                          }
                      }
                  }
              }
              catch (Exception )
              { }

           
          
          
          
          
          
          
          }
        private void comboBox_fill()
        {
            try
            {
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                this.comboBox3.Items.AddRange(File.ReadAllLines("C:\\adeies\\signs.txt", Encoding.Default));
                this.comboBox1.Items.AddRange(File.ReadAllLines("C:\\adeies\\aitiseis.txt", Encoding.Default));
                this.comboBox4.Items.AddRange(File.ReadAllLines("C:\\adeies\\select.txt", Encoding.Default));
            }
            catch (Exception)
            {
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
             string text1 = string.Concat(new string[]
				{
					"C:\\adeies\\arxeio\\",
					this.comboBox1.Text.ToString(),
					"_",
					this.comboBox2.Text.ToString(),
					"_",
					this.dateTimePicker6.Text.ToString(),
					"_",
					this.label20.Text.ToString(),
					".rtf"
        

        });
            try
            {
                this.CreateIfMissing("C:\\adeies\\arxeio");
            string text = string.Concat(new string[]
				{
					"C:\\adeies\\arxeio\\",
					this.comboBox1.Text.ToString(),
					"_",
					this.comboBox2.Text.ToString(),
					"_",
					this.dateTimePicker6.Text.ToString(),
					"_",
					this.label20.Text.ToString(),
					".rtf"
				});
                if (File.Exists(text))
                {
                    MessageBox.Show("ΤΟ ΑΡΧΕΙΟ ΥΠΑΡΧΕΙ ΗΔΗ", "ΠΡΟΣΟΧΗ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    this.richTextBox1.SaveFile(text);
                }
                string text2 = File.ReadLines("C:\\adeies\\index.txt").Skip(0).Take(1).First<string>();
                int num = Convert.ToInt32(text2);
                num++;
                File.WriteAllText(text2, string.Empty);
                File.WriteAllText(text2, Convert.ToString(num));
                this.label20.Text = "";
                this.label20.Text = File.ReadLines(text2).Skip(0).Take(1).First<string>();
                if (!File.Exists(File.ReadLines("C:\\adeies\\settings.txt").Skip(7).Take(1).First<string>() + "\\" + text))
                {
                    File.Copy(text, File.ReadLines("C:\\adeies\\settings.txt").Skip(7).Take(1).First<string>() + "\\" + text);
                }
               
            }
            catch
            {
            }
            if (File.Exists(text1))
            {
                MessageBox.Show("Επιτυχης αποθήκευση!!!");
            }
     
          
        }
        private void Document_Print(object sender, PrintPageEventArgs e)
        {
            new StringReader(this.richTextBox1.Text);
        }
        private void mDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float num = (float)e.MarginBounds.Left;
            float num2 = (float)e.MarginBounds.Top;
           // float height = this.mFont.GetHeight(e.Graphics);
           // e.Graphics.DrawString("This is a test", this.mFont, Brushes.Black, num, num2);
            //num2 += height;
           // e.Graphics.DrawString("This is another test", this.mFont, Brushes.Black, num, num2);
           // num += e.Graphics.MeasureString("This is another test", this.mFont).Width;
           // e.Graphics.DrawString("Here's some more text", this.mFont, Brushes.Black, num, num2);
            num = (float)e.MarginBounds.Left;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("ΠΡΟΓΡΑΜΜΑ ΚΑΤΑΧΩΡΗΣΗΣ ΑΔΕΙΩΝ ΤΟΥ ΔΗΜΟΥ ΛΑΜΙΕΩΝ\nΑΝΑΠΤΥΞΗ:ΓΑΛΑΝΗΣ ΙΩΑΝΝΗΣ\nEmail:giannaras13@gmail.com");
            }
            catch
            {
            }
        }

        private static int Emfaniseis(string text, string pattern)
        {
            int num = 0;
            int num2 = 0;
            while ((num2 = text.IndexOf(pattern, num2)) != -1)
            {
                num2 += pattern.Length;
                num++;
            }
            return num;
        }
        private void CreateIfMissing(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        private void save1()
        {
            string text = File.ReadLines("C:\\adeies\\index_loc.txt").Skip(0).Take(1).First<string>();
            string path = text;
            string value = File.ReadLines(text).Skip(0).Take(1).First<string>();
            int num = Convert.ToInt32(value);
            num++;
            File.WriteAllText(path, string.Empty);
            File.WriteAllText(path, Convert.ToString(num));
            this.label20.Text = "";
            this.label20.Text = File.ReadLines(path).Skip(0).Take(1).First<string>();
        }
        private string CalculateChecksum(string dataToCalculate)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(dataToCalculate);
            int num = 0;
            byte[] array = bytes;
            for (int i = 0; i < array.Length; i++)
            {
                byte b = array[i];
                num += (int)b;
            }
            return (num & 255).ToString("X2");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try{
            string cmdText = "UPDATE `new_table` SET   `kanoniki_ypo`=@kanoniki_ypo, `kanoniki_yr1`=@kanoniki_yr1, `kanoniki_ypol1`=@kanoniki_ypol1, `anarotiki_yd1`=@anarotiki_yd1, `anarotki_ig1`=@anarotiki_ig1, `ektaktis_anagkis_yr1`=@ektaktis_anagkis_yr1, `ektaktis_anagkis_ypol1`=@ektaktis_anagkis_ypol1, `syndikalistiki_yr1`=@syndikalistiki_yr1, `syndikalistiki_ypol1`=@syndikalistiki_ypol1, `ygeias_yr1`=@ygeias_yr1, `ygeias_ypol1`=@ygeias_ypol1, `eidikou_skopou1`=@eidikou_skopou1, `personID1`=@personID1, `adress1`=@adress1    WHERE `name`= @name;";
            MySqlCommand mySqlCommand = new MySqlCommand(cmdText, this.syndesi);
             

                string text = this.textBox4.Text;
                int num = int.Parse(text);
               string text2 = this.textBox16.Text;//10
            int num2 = int.Parse(text2);
            string text3 = this.textBox6.Text;
            int num3 = int.Parse(text3);
            string text4 = this.textBox13.Text;
            int num4 = int.Parse(text4);
            string text5 = this.textBox3.Text;
            int num5 = int.Parse(text5);
            string text6 = this.textBox17.Text;
            int num6 = int.Parse(text6);
            string text7 = this.textBox9.Text;
            int num7 = int.Parse(text7);
            string text8 = this.textBox19.Text;
            int num8 = int.Parse(text8);
            string text9 = this.textBox18.Text;
            int num9 = int.Parse(text9);
            string text10 = this.textBox8.Text;
            int num10 = int.Parse(text10);
            string text11 = this.textBox7.Text;
            int num11 = int.Parse(text11);
            string text12 = this.textBox14.Text;
            int num12 = int.Parse(text12);
            string text13 = this.textBox11.Text;
            int num13 = int.Parse(text13);
            string text14 = this.textBox1.Text;
            int num14 = int.Parse(text14);
            mySqlCommand.Parameters.AddWithValue("@anarotiki_yd1", num);
            mySqlCommand.Parameters.AddWithValue("@anarotiki_ig1", num14);
            mySqlCommand.Parameters.AddWithValue("@kanoniki_yr1", num2);
            mySqlCommand.Parameters.AddWithValue("@kanoniki_ypol1", num3);
            mySqlCommand.Parameters.AddWithValue("@adress1", num7);
            mySqlCommand.Parameters.AddWithValue("@eidikou_skopou1", num9);
            mySqlCommand.Parameters.AddWithValue("@kanoniki_ypo", num8);
            mySqlCommand.Parameters.AddWithValue("@ektaktis_anagkis_yr1", num11);
            mySqlCommand.Parameters.AddWithValue("@ektaktis_anagkis_ypol1", num10);
            mySqlCommand.Parameters.AddWithValue("@syndikalistiki_ypol1", num12);
            mySqlCommand.Parameters.AddWithValue("@ygeias_ypol1", num13);
            mySqlCommand.Parameters.AddWithValue("@syndikalistiki_yr1", num4);
            mySqlCommand.Parameters.AddWithValue("@ygeias_yr1", num5);
            mySqlCommand.Parameters.AddWithValue("@personID1", num6);
            mySqlCommand.Parameters.AddWithValue("@name", int.Parse(this.textBox5.Text));
            mySqlCommand.CommandTimeout = 120;
         
                mySqlCommand.ExecuteNonQuery();
                update();
                MessageBox.Show("Η ΑΛΛΑΓΕΣ ΟΛΟΚΛΗΡΩΘΗΚΑΝ ΜΕ ΕΠΙΤΥΧΙΑ!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ΒΕΒΑΙΩΘΕΙΤΕ ΟΤΙ ΔΕΝ ΥΠΑΡΧΟΥΝ ΚΕΝΑ ΠΕΔΙΑ!!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cmdText = "DELETE FROM `new_table` WHERE  `name`= @name;";
            
			MySqlCommand mySqlCommand = new MySqlCommand(cmdText, this.syndesi);
            mySqlCommand.Parameters.AddWithValue("@name", int.Parse(this.textBox5.Text));
			//mySqlCommand.Parameters.AddWithValue("@name", int.Parse(this.textBox13.Text));
			try
			{
				mySqlCommand.ExecuteNonQuery();
                update();
				MessageBox.Show("Η ΔΙΑΓΡΑΦΗ ΟΛΟΚΛΗΡΩΘΗΚΕ ΜΕ ΕΠΙΤΥΧΙΑ!!!");

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		
        }
        private void column_names()
        {
           dataGridView1.Columns[0].HeaderText = "ΑΡ.ΦΑΚΕΛΟΥ";
            dataGridView1.Columns[1].HeaderText = "ΟΝΟΜΑΤΕΠΩΝΥΜΟ";
            dataGridView1.Columns[2].HeaderText = "ΚΑΝΟΝΙΚΗ υπόλοιπο προηγούμενων ετών";
           dataGridView1.Columns[3].HeaderText = "ΚΑΝΟΝΙΚΗ δικαιούμενη τρέχοντος έτους";
            dataGridView1.Columns[4].HeaderText = "ΚΑΝΟΝΙΚΗ σύνολο τρέχοντος έτους";
            dataGridView1.Columns[5].HeaderText = "ΚΑΝΟΝΙΚΗ υπόλοιπο αδείας";
            this.dataGridView1.Columns[6].HeaderText = "ΑΝΑΡΡΩΤΙΚΗ ΜΕ Υ.Δ.";
            this.dataGridView1.Columns[7].HeaderText = "ΑΝΑΡΡΩΤΙΚΗ ΑΠΌ ΙΑΤΡΟ";
            this.dataGridView1.Columns[8].HeaderText = "ΕΚΤΑΚΤΗΣ ΑΝΑΓΚΗΣ σύνολο τρέχοντος έτους";
            this.dataGridView1.Columns[9].HeaderText = "ΕΚΤΑΚΤΗΣ ΑΝΑΓΚΗΣ υπόλοιπο αδείας";
            this.dataGridView1.Columns[10].HeaderText = "ΣΥΝΔΙΚΑΛΙΣΤΙΚΗ σύνολο τρέχοντος έτους";
            this.dataGridView1.Columns[11].HeaderText = "ΣΥΝΔΙΚΑΛΙΣΤΙΚΗ υπόλοιπο αδείας";
            this.dataGridView1.Columns[12].HeaderText = "ΕΙΔΙΚΗ ΓΙΑ ΛΟΓΟΥΣ ΥΓΕΙΑΣ σύνολο τρέχοντος έτους";
            this.dataGridView1.Columns[13].HeaderText = "ΕΙΔΙΚΗ ΓΙΑ ΛΟΓΟΥΣ ΥΓΕΙΑΣ υπόλοιπο αδείας";
            this.dataGridView1.Columns[14].HeaderText = "ΕΙΔΙΚΟΥ ΣΚΟΠΟΥ";
            this.dataGridView1.Columns[15].HeaderText = "ΑΑ";
            this.dataGridView1.Columns[16].HeaderText = "ΔΙΕΥΘΥΝΣΗ";
            this.dataGridView1.Columns[17].HeaderText = "ΤΜΗΜΑ";
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow;
            this.dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            textBox21.PasswordChar = '●';
            
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //richTextBox1.Font = new System.Drawing.Font("Calibri", 14);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //MessageBox.Show(dataGridView1.Rows[e.RowIndex]
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox12.Text=dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox19.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox16.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox13.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBox14.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            textBox18.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            textBox17.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
            textBox20.Text = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
          
            
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            //Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            //Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
      
           // mailItem.Subject = "ΣΦΑΛΜΑ ΕΦΑΡΜΟΓΗ ΑΔΕΙΩΝ ΔΗΜΟΥ ΛΑΜΙΑΣ";
            //mailItem.To = "giannaras13@gmail.com";
            System.Diagnostics.Process.Start("mailto:giannaras13@gmail.com");
        
        }

    }
}
