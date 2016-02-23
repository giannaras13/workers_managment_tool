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
    public class Form1 : Form
    {
        private const double anInch = 14.4;

        private string ip = File.ReadLines("C:\\adeies\\settings.txt").Skip(0).Take(1).First<string>();

        private string server;

        private string entrance = File.ReadLines("C:\\adeies\\settings.txt").Skip(6).Take(1).First<string>();

        private string table_name = File.ReadLines("C:\\adeies\\settings.txt").Skip(5).Take(1).First<string>();

        private string database = File.ReadLines("C:\\adeies\\settings.txt").Skip(2).Take(1).First<string>();

        private string uid = File.ReadLines("C:\\adeies\\settings.txt").Skip(3).Take(1).First<string>();

        private string password = File.ReadLines("C:\\adeies\\settings.txt").Skip(4).Take(1).First<string>();

        private string port = File.ReadLines("C:\\adeies\\settings.txt").Skip(1).Take(1).First<string>();

        private StringReader myReader;

        private PrintDocument mDoc = new PrintDocument();

        //private Font mFont = new Font("Courier New", 12f);

        private PrintDocument document = new PrintDocument();

        private PrintDialog dialog = new PrintDialog();

        private BindingSource bsource;

        private MySqlConnection syndesi;

        private MySqlConnection connection;

        private MySqlDataAdapter adapter;

        private MySqlCommandBuilder Upd;

        //private DataTable data = new DataTable();

        private DataSet dataset;

        private string connectionString;

      

        private IContainer components;

        private Button button4;

        private TextBox textBox4;

        private Label label11;

        private Button button3;

        private PrintDocument printDocument1;

        private PrintDialog printDialog1;

        private PageSetupDialog pageSetupDialog1;

        private ComboBox comboBox3;

        private Label label18;

        private Button button5;

        private ComboBox comboBox2;

        private RichTextBox richTextBox1;

        private TextBox textBox2;

        private Button button2;

        private DateTimePicker dateTimePicker6;

        private Label label10;

        private DateTimePicker dateTimePicker5;

        private NumericUpDown numericUpDown1;

        private DateTimePicker dateTimePicker4;

        private DateTimePicker dateTimePicker3;

        private DateTimePicker dateTimePicker2;

        private Label label9;

        private Label label8;

        private Label label7;

        private Label label5;

        private Label label4;

        private Label label3;

        private Label label2;

        private Button button1;

        private Label label1;

        private ComboBox comboBox1;

        private TabPage tabPage2;

        private DataGridView dataGridView2;

        private TabControl tabControl1;

        private Button settings_but;

        private Button button7;

        private Label label6;

        private ComboBox comboBox4;

        private Label label12;

        private TextBox textBox1;

        private Panel panel1;

        private Button button6;

        private Label label19;

        private Label label13;

        private TextBox textBox7;

        private TextBox textBox6;

        private TextBox textBox5;

        private TextBox textBox3;

        private TextBox textBox10;

        private TextBox textBox9;

        private TextBox textBox8;

        private Label label24;

        private Label label23;

        private Label label22;

        private Label label21;

        private Label label20;

        private Label label17;

        private Label label16;

        private Label label15;

        private Label label14;

        private TextBox textBox12;

        private TextBox textBox11;

        private TextBox textBox13;

        private TextBox textBox14;

        private Label label25;

        private TextBox textBox21;

        private TextBox textBox20;

        private TextBox textBox19;

        private TextBox textBox18;

        private TextBox textBox17;

        private TextBox textBox16;

        private TextBox textBox15;

        private Label label32;

        private Label label31;

        private Label label30;

        private Label label29;

        private Label label28;

        private Label label27;

        private Label label26;

        private Button button8;

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
            this.textBox4.PasswordChar = '●';
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.link();
            this.button3.Visible = false;
            this.label11.Visible = false;
            this.panel1.Visible = false;
            this.tabControl1.Size = new Size(1250, 630);
            this.dataGridView2.Size = new Size(1250, 400);
            this.Fillcombo();
        }

        public void test()
        {
        }

        private void MySQL_ToDatagridview()
        {
        }

        public Form1()
        {
            this.InitializeComponent();
    
            base.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
            this.comboBox_fill();
            this.Fillcombo();
            this.printDocument1.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
        }

        private void label1_Click(object sender, EventArgs e)
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
                application.Visible = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    Documents arg_E2_0 = application.Documents;
                    object obj = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\print.rtf";
                    object value = Missing.Value;
                    object value2 = Missing.Value;
                    object value3 = Missing.Value;
                    Document document = arg_E2_0.Add(ref obj, ref value, ref value2, ref value3);
                    application.ActivePrinter = printDialog.PrinterSettings.PrinterName;
                    _Document arg_1A1_0 = application.ActiveDocument;
                    object value4 = Missing.Value;
                    object value5 = Missing.Value;
                    object value6 = Missing.Value;
                    object value7 = Missing.Value;
                    object value8 = Missing.Value;
                    object value9 = Missing.Value;
                    object value10 = Missing.Value;
                    object value11 = Missing.Value;
                    object value12 = Missing.Value;
                    object value13 = Missing.Value;
                    object value14 = Missing.Value;
                    object value15 = Missing.Value;
                    object value16 = Missing.Value;
                    object value17 = Missing.Value;
                    object value18 = Missing.Value;
                    object value19 = Missing.Value;
                    object value20 = Missing.Value;
                    object value21 = Missing.Value;
                    arg_1A1_0.PrintOut(ref value4, ref value5, ref value6, ref value7, ref value8, ref value9, ref value10, ref value11, ref value12, ref value13, ref value14, ref value15, ref value16, ref value17, ref value18, ref value19, ref value20, ref value21);
                    _Document arg_1C3_0 = document;
                    object obj2 = false;
                    object value22 = Missing.Value;
                    object value23 = Missing.Value;
                    arg_1C3_0.Close(ref obj2, ref value22, ref value23);
                }
            }
            catch
            {
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }

        public void load_table()
        {
            string selectCommandText = string.Format("SELECT * FROM {0}", this.table_name);
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
            try
            {
                this.syndesi.Open();
                this.adapter = new MySqlDataAdapter(selectCommandText, this.syndesi);
                this.dataset = new DataSet();
                this.adapter.Fill(this.dataset, this.table_name);
                this.dataGridView2.DataSource = this.dataset.Tables[0];
                this.column_names();
                this.textBox4.Visible = false;
                this.button4.Visible = false;
                this.button3.Visible = true;
                this.label11.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ΘΑ ΓΙΝΟΥΝ ΑΛΛΑΓΕΣ ΣΤΗ ΒΑΣΗ ΔΕΔΟΜΕΝΩΝ,ΘΕΛΕΤΕ ΝΑ ΣΥΝΕΧΙΣΕΤΕ?", "ΠΡΟΣΟΧΗ!!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                new MySqlCommandBuilder(this.adapter);
                this.adapter.Update(this.dataset, this.table_name);
                MessageBox.Show("ΑΛΛΑΓΗ ΠΛΗΡΟΦΟΡΙΩΝ", "ΑΝΑΒΑΘΜΙΣΗ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox4.Text != this.entrance)
                {
                    MessageBox.Show("ΛΑΘΟΣ ΚΩΔΙΚΟΣ ΠΡΟΣΒΑΣΗΣ!!!ΠΡΟΣΠΑΘΕΙΣΤΕ ΞΑΝΑ", "ΑΝΕΠΙΤΥΧΗΣ ΕΙΣΟΔΟΣ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    this.label18.Text = File.ReadLines("C:\\adeies\\index.txt").Skip(0).Take(1).First<string>();
                    this.settings_but.Visible = true;
                    this.panel1.Visible = true;
                    this.load_table();
                }
            }
            catch (Exception)
            {
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void link()
        {
        }

        private void richTextBox1_TextChanged_2(object sender, EventArgs e)
        {
        }

        private void dataGridView3_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.richTextBox1.Clear();
                if (this.comboBox1.Text == "ΚΑΝΟΝΙΚΗ ΑΔΕΙΑ")
                {
                    string text = File.ReadLines("C:\\adeies\\index.txt").Skip(0).Take(1).First<string>();
                    this.label18.Text = text;
                    this.richTextBox1.LoadFile("C:\\adeies\\kanoniki.rtf");
                    this.richTextBox1.Find("date_start");
                    this.richTextBox1.SelectedText = this.dateTimePicker2.Value.ToString();
                }
                if (this.comboBox1.Text == "ΑΝΑΡΡΩΤΙΚΗ ΑΔΕΙΑ ΜΕ Υ.Δ.")
                {
                    string text2 = File.ReadLines("C:\\adeies\\index.txt").Skip(0).Take(1).First<string>();
                    this.label18.Text = text2;
                    this.richTextBox1.LoadFile("C:\\adeies\\anarotiki_yd.rtf");
                }
                if (this.comboBox1.Text == "ΑΝΑΡΡΩΤΙΚΗ ΑΔΕΙΑ ΓΙΑΤΡΟΥ")
                {
                    string text3 = File.ReadLines("C:\\adeies\\index.txt").Skip(0).Take(1).First<string>();
                    this.label18.Text = text3;
                    this.richTextBox1.LoadFile("C:\\adeies\\anarotiki_ig.rtf");
                }
                if (this.comboBox1.Text == "ΑΔΕΙΑ ΕΚΤΑΚΤΗΣ ΑΝΑΓΚΗΣ")
                {
                    string text4 = File.ReadLines("C:\\adeies\\index.txt").Skip(0).Take(1).First<string>();
                    this.label18.Text = text4;
                    this.richTextBox1.LoadFile("C:\\adeies\\ektaktis_anagkis.rtf");
                }
                if (this.comboBox1.Text == "ΣΥΝΔΙΚΑΛΙΣΤΙΚΗ ΑΔΕΙΑ")
                {
                    string text5 = File.ReadLines("C:\\adeies\\index.txt").Skip(0).Take(1).First<string>();
                    this.label18.Text = text5;
                    this.richTextBox1.LoadFile("C:\\adeies\\syndikalistiki.rtf");
                }
            }
            catch
            {
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Fillcombo()
        {
            string cmdText = string.Format("SELECT * FROM {0}", "new_table");
            this.server = "127.0.0.1";
            this.database = "adeies";
            this.uid = "giannis";
            this.password = "";
            this.port = "3306";
            string text = string.Concat(new string[]
			{
				"SERVER=",
				this.server,
				";PORT=",
				this.port,
				";DATABASE=",
				this.database,
				";UID=",
				this.uid,
				";PASSWORD=",
				this.password,
				";"
			});
            MySqlConnection mySqlConnection = new MySqlConnection(text);
            MySqlCommand mySqlCommand = new MySqlCommand(cmdText, mySqlConnection);
            try
            {
                mySqlConnection.Open();
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    string @string = mySqlDataReader.GetString("kanoniki_ypol");
                    this.comboBox2.Items.Add(@string);
                }
            }
            catch (Exception)
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
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
                        this.richTextBox1.SelectedText = this.dateTimePicker2.Value.ToShortDateString();
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
                        this.richTextBox1.SelectedText = this.numericUpDown1.Value.ToString();
                    }
                    for (int num17 = 0; num17 < num8; num17++)
                    {
                        this.richTextBox1.Find("sign_persons");
                        this.richTextBox1.SelectedText = this.comboBox3.SelectedItem.ToString();
                    }
                    for (int num18 = 0; num18 < num9; num18++)
                    {
                        this.richTextBox1.Find("ypol1");
                        int num19 = Convert.ToInt32(this.dataGridView2[5, this.comboBox2.SelectedIndex].Value);
                        int value = Math.Abs(num19 - decimal.ToInt32(this.numericUpDown1.Value));
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
                        this.richTextBox1.SelectedText = this.dataGridView2[17, this.comboBox2.SelectedIndex].Value.ToString();
                    }
                    for (int num23 = 0; num23 < num13; num23++)
                    {
                        this.richTextBox1.Find("adress");
                        this.richTextBox1.SelectedText = this.dataGridView2[16, this.comboBox2.SelectedIndex].Value.ToString();
                    }
                    string s = this.dataGridView2[0, this.comboBox2.SelectedIndex].Value.ToString();
                    int num24 = int.Parse(s);
                    int num25 = Convert.ToInt32(this.dataGridView2[5, this.comboBox2.SelectedIndex].Value) - decimal.ToInt32(this.numericUpDown1.Value);
                    string cmdText = "UPDATE `new_table` SET  `anarotiki_yd1`=@anarotiki_yd1   WHERE `name`= @name;";
                    MySqlCommand mySqlCommand = new MySqlCommand(cmdText, this.syndesi);
                    mySqlCommand.Parameters.AddWithValue("@name", num24);
                    mySqlCommand.Parameters.AddWithValue("@anarotiki_yd1", num25);
                    mySqlCommand.CommandTimeout = 120;
                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        this.load_table();
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
                        this.richTextBox1.SelectedText = this.dateTimePicker2.Value.ToShortDateString();
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
                        this.richTextBox1.SelectedText = this.numericUpDown1.Value.ToString();
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
                        this.richTextBox1.SelectedText = this.dataGridView2[17, this.comboBox2.SelectedIndex].Value.ToString();
                    }
                    for (int num51 = 0; num51 < num38; num51++)
                    {
                        this.richTextBox1.Find("adress");
                        this.richTextBox1.SelectedText = this.dataGridView2[16, this.comboBox2.SelectedIndex].Value.ToString();
                    }
                    for (int num52 = 0; num52 < num34; num52++)
                    {
                        this.richTextBox1.Find("ypol1");
                        int num53 = Convert.ToInt32(this.dataGridView2[5, this.comboBox2.SelectedIndex].Value);
                        int value2 = Math.Abs(num53 - decimal.ToInt32(this.numericUpDown1.Value));
                        this.richTextBox1.SelectedText = Convert.ToString(value2);
                    }
                    for (int num54 = 0; num54 < num28; num54++)
                    {
                        this.richTextBox1.Find("date_end");
                        this.richTextBox1.SelectedText = this.dateTimePicker3.Value.ToShortDateString();
                    }
                    string s2 = this.dataGridView2[0, this.comboBox2.SelectedIndex].Value.ToString();
                    int num55 = int.Parse(s2);
                    int num56 = Convert.ToInt32(this.dataGridView2[6, this.comboBox2.SelectedIndex].Value) + decimal.ToInt32(this.numericUpDown1.Value);
                    string cmdText2 = "UPDATE `new_table` SET  `anarotki_ig1`=@anarotiki_ig1   WHERE `name`= @name;";
                    MySqlCommand mySqlCommand2 = new MySqlCommand(cmdText2, this.syndesi);
                    mySqlCommand2.Parameters.AddWithValue("@name", num55);
                    mySqlCommand2.Parameters.AddWithValue("@anarotiki_ig1", num56);
                    mySqlCommand2.CommandTimeout = 120;
                    try
                    {
                        mySqlCommand2.ExecuteNonQuery();
                        this.load_table();
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
                        this.richTextBox1.SelectedText = this.dateTimePicker2.Value.ToShortDateString();
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
                        this.richTextBox1.SelectedText = this.numericUpDown1.Value.ToString();
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
                        this.richTextBox1.SelectedText = this.dataGridView2[17, this.comboBox2.SelectedIndex].Value.ToString();
                    }
                    for (int num83 = 0; num83 < num68; num83++)
                    {
                        this.richTextBox1.Find("adress");
                        this.richTextBox1.SelectedText = this.dataGridView2[16, this.comboBox2.SelectedIndex].Value.ToString();
                    }
                    for (int num84 = 0; num84 < num65; num84++)
                    {
                        this.richTextBox1.Find("ypol1");
                        int num85 = Convert.ToInt32(this.dataGridView2[5, this.comboBox2.SelectedIndex].Value);
                        int value3 = Math.Abs(num85 - decimal.ToInt32(this.numericUpDown1.Value));
                        this.richTextBox1.SelectedText = Convert.ToString(value3);
                    }
                    string s3 = this.dataGridView2[0, this.comboBox2.SelectedIndex].Value.ToString();
                    int num86 = int.Parse(s3);
                    int num87 = Convert.ToInt32(this.dataGridView2[7, this.comboBox2.SelectedIndex].Value) - decimal.ToInt32(this.numericUpDown1.Value);
                    string cmdText3 = "UPDATE `new_table` SET  `personID1`=@personID1   WHERE `name`= @name;";
                    MySqlCommand mySqlCommand3 = new MySqlCommand(cmdText3, this.syndesi);
                    mySqlCommand3.Parameters.AddWithValue("@name", num86);
                    mySqlCommand3.Parameters.AddWithValue("@personID1", num87);
                    mySqlCommand3.CommandTimeout = 120;
                    try
                    {
                        mySqlCommand3.ExecuteNonQuery();
                        this.load_table();
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
                        this.richTextBox1.SelectedText = this.dateTimePicker2.Value.ToShortDateString();
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
                        this.richTextBox1.SelectedText = this.numericUpDown1.Value.ToString();
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
                        this.richTextBox1.SelectedText = this.dataGridView2[17, this.comboBox2.SelectedIndex].Value.ToString();
                    }
                    for (int num114 = 0; num114 < num99; num114++)
                    {
                        this.richTextBox1.Find("adress");
                        this.richTextBox1.SelectedText = this.dataGridView2[16, this.comboBox2.SelectedIndex].Value.ToString();
                    }
                    for (int num115 = 0; num115 < num96; num115++)
                    {
                        this.richTextBox1.Find("ypol1");
                        int num116 = Convert.ToInt32(this.dataGridView2[5, this.comboBox2.SelectedIndex].Value);
                        int value4 = Math.Abs(num116 - decimal.ToInt32(this.numericUpDown1.Value));
                        this.richTextBox1.SelectedText = Convert.ToString(value4);
                    }
                    string s4 = this.dataGridView2[0, this.comboBox2.SelectedIndex].Value.ToString();
                    int num117 = int.Parse(s4);
                    int num118 = Convert.ToInt32(this.dataGridView2[8, this.comboBox2.SelectedIndex].Value) + decimal.ToInt32(this.numericUpDown1.Value);
                    string cmdText4 = "UPDATE `new_table` SET  `ektaktis_anagkis_ypol1`=@ektaktis_anagkis_ypol1   WHERE `name`= @name;";
                    MySqlCommand mySqlCommand4 = new MySqlCommand(cmdText4, this.syndesi);
                    mySqlCommand4.Parameters.AddWithValue("@name", num117);
                    mySqlCommand4.Parameters.AddWithValue("@ektaktis_anagkis_ypol1", num118);
                    mySqlCommand4.CommandTimeout = 120;
                    try
                    {
                        mySqlCommand4.ExecuteNonQuery();
                        this.load_table();
                    }
                    catch (Exception ex4)
                    {
                        MessageBox.Show(ex4.Message);
                    }
                }
            }
            catch
            {
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
        }

        private void column_names()
        {
            this.dataGridView2.Columns[0].HeaderText = "ΑΡ.ΦΑΚΕΛΟΥ";
            this.dataGridView2.Columns[1].HeaderText = "ΟΝΟΜΑΤΕΠΩΝΥΜΟ";
            this.dataGridView2.Columns[2].HeaderText = "ΚΑΝΟΝΙΚΗ υπόλοιπο προηγούμενων ετών";
            this.dataGridView2.Columns[3].HeaderText = "ΚΑΝΟΝΙΚΗ δικαιούμενη τρέχοντος έτους";
            this.dataGridView2.Columns[4].HeaderText = "ΚΑΝΟΝΙΚΗ σύνολο τρέχοντος έτους";
            this.dataGridView2.Columns[5].HeaderText = "ΚΑΝΟΝΙΚΗ υπόλοιπο αδείας";
            this.dataGridView2.Columns[6].HeaderText = "ΑΝΑΡΡΩΤΙΚΗ ΜΕ Υ.Δ.";
            this.dataGridView2.Columns[7].HeaderText = "ΑΝΑΡΡΩΤΙΚΗ ΑΠΌ ΙΑΤΡΟ";
            this.dataGridView2.Columns[8].HeaderText = "ΕΚΤΑΚΤΗΣ ΑΝΑΓΚΗΣ σύνολο τρέχοντος έτους";
            this.dataGridView2.Columns[9].HeaderText = "ΕΚΤΑΚΤΗΣ ΑΝΑΓΚΗΣ υπόλοιπο αδείας";
            this.dataGridView2.Columns[10].HeaderText = "ΣΥΝΔΙΚΑΛΙΣΤΙΚΗ σύνολο τρέχοντος έτους";
            this.dataGridView2.Columns[11].HeaderText = "ΣΥΝΔΙΚΑΛΙΣΤΙΚΗ υπόλοιπο αδείας";
            this.dataGridView2.Columns[12].HeaderText = "ΕΙΔΙΚΗ ΓΙΑ ΛΟΓΟΥΣ ΥΓΕΙΑΣ σύνολο τρέχοντος έτους";
            this.dataGridView2.Columns[13].HeaderText = "ΕΙΔΙΚΗ ΓΙΑ ΛΟΓΟΥΣ ΥΓΕΙΑΣ υπόλοιπο αδείας";
            this.dataGridView2.Columns[14].HeaderText = "ΕΙΔΙΚΟΥ ΣΚΟΠΟΥ";
            this.dataGridView2.Columns[15].HeaderText = "ΑΑ";
            this.dataGridView2.Columns[16].HeaderText = "ΔΙΕΥΘΥΝΣΗ";
            this.dataGridView2.Columns[17].HeaderText = "ΤΜΗΜΑ";
            this.dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow;
            this.dataGridView2.EnableHeadersVisualStyles = false;
        }

       

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
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
					this.label18.Text.ToString(),
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
                this.label18.Text = "";
                this.label18.Text = File.ReadLines(text2).Skip(0).Take(1).First<string>();
                if (!File.Exists(File.ReadLines("C:\\adeies\\settings.txt").Skip(7).Take(1).First<string>() + "\\" + text))
                {
                    File.Copy(text, File.ReadLines("C:\\adeies\\settings.txt").Skip(7).Take(1).First<string>() + "\\" + text);
                }
            }
            catch
            {
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
        }

        private void cell_change()
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void Document_Print(object sender, PrintPageEventArgs e)
        {
            new StringReader(this.richTextBox1.Text);
        }

       

        private void Button1_Click_1(object sender, EventArgs e)
        {
        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
        }



        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("ΠΡΟΓΡΑΜΜΑ ΚΑΤΑΧΩΡΗΣΗΣ ΑΔΕΙΩΝ ΤΟΥ ΔΗΜΟΥ ΛΑΜΙΕΩΝ\n");
            }
            catch
            {
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
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
            this.label18.Text = "";
            this.label18.Text = File.ReadLines(path).Skip(0).Take(1).First<string>();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            string cmdText = "UPDATE `new_table` SET   `kanoniki_ypo`=@kanoniki_ypo, `kanoniki_yr1`=@kanoniki_yr1, `kanoniki_ypol1`=@kanoniki_ypol1, `anarotiki_yd1`=@anarotiki_yd1, `anarotki_ig1`=@anarotiki_ig1, `ektaktis_anagkis_yr1`=@ektaktis_anagkis_yr1, `ektaktis_anagkis_ypol1`=@ektaktis_anagkis_ypol1, `syndikalistiki_yr1`=@syndikalistiki_yr1, `syndikalistiki_ypol1`=@syndikalistiki_ypol1, `ygeias_yr1`=@ygeias_yr1, `ygeias_ypol1`=@ygeias_ypol1, `eidikou_skopou1`=@eidikou_skopou1, `personID1`=@personID1, `adress1`=@adress1    WHERE `name`= @name;";
            MySqlCommand mySqlCommand = new MySqlCommand(cmdText, this.syndesi);
            string text = this.textBox8.Text;
            int num = int.Parse(text);
            string text2 = this.textBox10.Text;
            int num2 = int.Parse(text2);
            string text3 = this.textBox9.Text;
            int num3 = int.Parse(text3);
            string text4 = this.textBox3.Text;
            int num4 = int.Parse(text4);
            string text5 = this.textBox6.Text;
            int num5 = int.Parse(text5);
            string text6 = this.textBox7.Text;
            int num6 = int.Parse(text6);
            string text7 = this.textBox16.Text;
            int num7 = int.Parse(text7);
            string text8 = this.textBox17.Text;
            int num8 = int.Parse(text8);
            string text9 = this.textBox18.Text;
            int num9 = int.Parse(text9);
            string text10 = this.textBox19.Text;
            int num10 = int.Parse(text10);
            string text11 = this.textBox20.Text;
            int num11 = int.Parse(text11);
            string text12 = this.textBox21.Text;
            int num12 = int.Parse(text12);
            string text13 = this.textBox15.Text;
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
            mySqlCommand.Parameters.AddWithValue("@name", int.Parse(this.textBox13.Text));
            mySqlCommand.CommandTimeout = 120;
            try
            {
                mySqlCommand.ExecuteNonQuery();
                this.load_table();
                MessageBox.Show("Η ΑΛΛΑΓΕΣ ΟΛΟΚΛΗΡΩΘΗΚΑΝ ΜΕ ΕΠΙΤΥΧΙΑ!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.textBox13.Text = this.dataGridView2.Rows[e.RowIndex].Cells["name"].Value.ToString();
            this.textBox5.Text = this.dataGridView2.Rows[e.RowIndex].Cells["kanoniki_ypol"].Value.ToString();
            this.textBox10.Text = this.dataGridView2.Rows[e.RowIndex].Cells["kanoniki_yr1"].Value.ToString();
            this.textBox9.Text = this.dataGridView2.Rows[e.RowIndex].Cells["kanoniki_ypol1"].Value.ToString();
            this.textBox8.Text = this.dataGridView2.Rows[e.RowIndex].Cells["anarotiki_yd1"].Value.ToString();
            this.textBox1.Text = this.dataGridView2.Rows[e.RowIndex].Cells["anarotki_ig1"].Value.ToString();
            this.textBox3.Text = this.dataGridView2.Rows[e.RowIndex].Cells["syndikalistiki_yr1"].Value.ToString();
            this.textBox6.Text = this.dataGridView2.Rows[e.RowIndex].Cells["ygeias_yr1"].Value.ToString();
            this.textBox7.Text = this.dataGridView2.Rows[e.RowIndex].Cells["eidikou_skopou1"].Value.ToString();
            this.textBox11.Text = this.dataGridView2.Rows[e.RowIndex].Cells["tmima1"].Value.ToString();
            this.textBox12.Text = this.dataGridView2.Rows[e.RowIndex].Cells["folder_id1"].Value.ToString();
            this.textBox17.Text = this.dataGridView2.Rows[e.RowIndex].Cells["kanoniki_ypo"].Value.ToString();
            this.textBox20.Text = this.dataGridView2.Rows[e.RowIndex].Cells["ektaktis_anagkis_yr1"].Value.ToString();
            this.textBox19.Text = this.dataGridView2.Rows[e.RowIndex].Cells["ektaktis_anagkis_ypol1"].Value.ToString();
            this.textBox21.Text = this.dataGridView2.Rows[e.RowIndex].Cells["syndikalistiki_ypol1"].Value.ToString();
            this.textBox15.Text = this.dataGridView2.Rows[e.RowIndex].Cells["ygeias_ypol1"].Value.ToString();
            this.textBox18.Text = this.dataGridView2.Rows[e.RowIndex].Cells["eidikou_skopou1"].Value.ToString();
            this.textBox16.Text = this.dataGridView2.Rows[e.RowIndex].Cells["adress1"].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string cmdText = "DELETE FROM `new_table` WHERE  `name`= @name;";
            MySqlCommand mySqlCommand = new MySqlCommand(cmdText, this.syndesi);
            mySqlCommand.Parameters.AddWithValue("@name", int.Parse(this.textBox13.Text));
            try
            {
                mySqlCommand.ExecuteNonQuery();
                this.load_table();
                MessageBox.Show("Η ΔΙΑΓΡΑΦΗ ΟΛΟΚΛΗΡΩΘΗΚΕ ΜΕ ΕΠΙΤΥΧΙΑ!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {

        }
    }
}
