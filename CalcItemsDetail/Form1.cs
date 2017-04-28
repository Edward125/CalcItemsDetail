using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Edward;

namespace CalcItemsDetail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public static string appFolder = Application.StartupPath + @"\CalcTemp";


        private void txtExcelFile_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {

                FileInfo fi = new FileInfo(open.FileName);
                if ((fi.Extension == ".xls") || (fi.Extension == ".xlsx"))
                {
                    txtExcelFile.Text = open.FileName;
                }
                else
                {
                    MessageBox.Show("you select file is not excel file...", "File Not Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

            }
        }



        #region DataSet


        static bool  DataSetParse(string fileName , out DataSet ds)
        {
            // string connectionString = string.Format("provider=Microsoft.Jet.OLEDB.4.0; data source={0};Extended Properties=Excel 8.0;", fileName);


            ////2003（Microsoft.Jet.Oledb.4.0）
            //string strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", excelFilePath);
            ////2010（Microsoft.ACE.OLEDB.12.0）
            //string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", excelFilePath);

            string connectionString = string.Empty;
            System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
            //MessageBox.Show(fi.Extension);
            DataSet data = new DataSet();
            try
            {
                if (fi.Extension == ".xls")
                    connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", fileName);
                if (fi.Extension == ".xlsx")
                    connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", fileName);
            }
            catch (Exception  ex)
            {

                MessageBox.Show(ex.Message);
                ds = data;
                return false;
            }

            


          

            foreach (var sheetName in GetExcelSheetNames(connectionString))
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    Console.WriteLine(sheetName);
                    var dataTable = new System.Data.DataTable(sheetName);
                    string query = string.Format("SELECT * FROM [{0}]", sheetName);
                    con.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                    adapter.Fill(dataTable);
                    data.Tables.Add(dataTable);

                }
            }

            ds = data;

            return true;
            
        }



        static string[] GetExcelSheetNames(string connectionString)
        {
            OleDbConnection con = null;
            System.Data.DataTable dt = null;
            con = new OleDbConnection(connectionString);
            con.Open();
            dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (dt == null)
            {
                return null;
            }

            String[] excelSheetNames = new String[dt.Rows.Count];
            int i = 0;

            foreach (DataRow row in dt.Rows)
            {
                excelSheetNames[i] = row["TABLE_NAME"].ToString();
                i++;
            }

            return excelSheetNames;
        }

        #endregion




        #region checkFolder


        private void createTemp()
        {

            

            if (Directory.Exists(appFolder ))
                Directory.Delete(appFolder , true);
            Directory.CreateDirectory(appFolder);

        }

        #endregion



        private void btnOK_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty (txtExcelFile.Text .Trim ()))
                return ;


            createTemp();
            this.Enabled = false;
            lstItem.Items.Clear();
            lstItemDetail.Items.Clear();
            lstDepItem.Items.Clear();
            grbSubItem.Text = "";
            grbDepItem.Text = "";
            DataSet ds = new DataSet();
            if (!DataSetParse(txtExcelFile.Text.Trim(), out ds))
            {
                this.Enabled = true;
                return;
            }
            
            loadItemSubitem(ds);
            dataGridView1.DataSource = ds.Tables[3];
            loadSubitemDetail(ds);


            MessageBox.Show("Calc all item is OK");
            this.Enabled = true;

        }




        #region new method


        private void loadItemSubitem(DataSet ds)
        {
            for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
            {
                string Item = string.Empty;//DepItem
                Item = ds.Tables[3].Rows[i]["DepItem"].ToString().Trim();
                string Subitem = string.Empty;//工作細目
                Subitem = ds.Tables[3].Rows[i]["工作細目"].ToString().Trim();

                if (!string.IsNullOrEmpty(Item))
                {
                    string itemFile = string.Empty;
                    itemFile = Item;

                    itemFile = replaceString(itemFile);
                    if (lstDepItem.Items.IndexOf(itemFile) >= 0)
                    {
                        //exits
                    }
                    else
                        lstDepItem.Items.Add(itemFile);
                        
                    itemFile = appFolder + @"\" + @itemFile;

                    Subitem = replaceString(Subitem);

                    if (!checkContentsExits(Subitem, itemFile))
                    {
                        StreamWriter sw = new StreamWriter(itemFile, true);
                        if (!string.IsNullOrEmpty(Subitem))
                            sw.WriteLine(Subitem);
                        sw.Close();
                    }
                }

            }

            grbDepItem.Text = "Total Items:" + lstDepItem.Items.Count;


        }


        private string replaceString(string str)
        {
            if (str.Contains(@"/"))
                str = str.Replace(@"/", "_");
            if (str.Contains("\r\n"))
                str = str.Replace("\r\n", " ");
            if (str.Contains("\r"))
                str = str.Replace("\r", " ");
            if (str.Contains("\n"))
                str = str.Replace("\n", " ");
            return str;
        }


        private bool checkContentsExits(string scontent, string file)
        {

            if (!File.Exists(file))
                return false;
            else
            {
                StreamReader sr = new StreamReader(file);
                string sl = sr.ReadToEnd();
                sr.Close();
                if (sl.Contains(scontent))
                    return true;
                else
                    return false;
            }
        }





        private void loadSubitemDetail(DataSet ds)
        {
         
            DirectoryInfo di = new DirectoryInfo(appFolder);
            foreach (FileInfo  fi in di.GetFiles())
            {
                lstItemDetail.Items.Add("----------");
                lstItemDetail.Items.Add(fi.Name);
                lstItemDetail.Items.Add("----------");
                StreamReader sr = new StreamReader(fi.FullName);

                string sLine = string.Empty;
                while (!sr.EndOfStream )
                {
                    sLine = sr.ReadLine().Trim();
                    int i_itemcount = 0;
                    decimal v_time = 0;
                    for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                    {
                        string itemdetail = string.Empty;//工作細目
                        itemdetail = ds.Tables[3].Rows[i]["工作細目"].ToString().Trim ();

                        itemdetail = replaceString(itemdetail);

                        if (itemdetail == sLine)
                        {
                            i_itemcount++;
                            v_time = v_time + Convert.ToDecimal(ds.Tables[3].Rows[i]["周工時(分)"].ToString());
                        }
                    }
                    lstItemDetail.Items.Add(sLine  + ",項目個數:" + i_itemcount + ",周工時:" + v_time);
                }

                sr.Close();

            }
        }



        #endregion








        private void loadDepItem(DataSet ds)
        {
            for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
            {
                string itemdetail = string.Empty;//工作細目
                itemdetail = ds.Tables[3].Rows[i]["DepItem"].ToString();

                if (!string.IsNullOrEmpty(itemdetail))
                {
                    if (lstDepItem.Items.IndexOf(itemdetail) >= 0)
                    {
                    }

                    else
                        lstDepItem.Items.Add(itemdetail);
                }

            }
        }

        private void loadItem(DataSet ds)
        {

            for (int j = 0; j < lstDepItem.Items.Count; j++)
            {
                string depitem = lstDepItem.Items[j].ToString();
                for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                {
                    string itemdetail = string.Empty;//工作細目
                    itemdetail = ds.Tables[3].Rows[i]["工作細目"].ToString();

                    string depitemdetail = string.Empty;
                    depitemdetail = ds.Tables[3].Rows[i]["DepItem"].ToString();

                    if (!string.IsNullOrEmpty(itemdetail))
                    {
                        if (depitemdetail == depitem)
                        {
                            if (lstItem.Items.IndexOf(itemdetail) >= 0)
                            {
                            }
                            else
                            {
                                lstItem.Items.Add(itemdetail);
                                

                            }
                        }
                        else
                        {
                            if (i == ds.Tables[3].Rows.Count -1)
                            {
                                lstItem.Items.Add(" ");
                            }
                        }
                   
                       
                    }

                }
            }


               
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstItemDetail.Items.Count >= 0)
            {

                this.Enabled = false;
                string logpath = Application.StartupPath + @"\Save360Item" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                if (File.Exists(@logpath))
                {
                    File.Delete(@logpath);
                }

                StreamWriter sw = new StreamWriter(logpath, true);
                for (int i = 0; i < lstItemDetail.Items.Count; i++)
                {
                    sw.WriteLine(lstItemDetail.Items[i]);
                }

                sw.Close();
                MessageBox.Show("Save ok.file path is :" + logpath);
                this.Enabled = true;
            }
            else
                return;
        }

        public static void updateMessage(ListBox listbox, string message)
        {
            if (listbox.Items.Count > 1000)
                listbox.Items.RemoveAt(0);

            string item = string.Empty;
            item = DateTime.Now.ToString("HH:mm:ss") + " " + @message;
            listbox.Items.Add(item);
            if (listbox.Items.Count > 1)
            {
                listbox.TopIndex = listbox.Items.Count - 1;
                listbox.SetSelected(listbox.Items.Count - 1, true);
            }


            // Display a horizontal scroll bar.
            listbox.HorizontalScrollbar = true;

            // Create a Graphics object to use when determining the size of the largest item in the ListBox.
            Graphics g = listbox.CreateGraphics();

            // Determine the size for HorizontalExtent using the MeasureString method using the last item in the list.
            int hzSize = (int)g.MeasureString(listbox.Items[listbox.Items.Count - 1].ToString(), listbox.Font).Width;
            // Set the HorizontalExtent property.
            listbox.HorizontalExtent = hzSize;


        }
    



  

        /// <summary>
        /// 保存log
        /// </summary>
        /// <param name="logtype">log類型</param>
        /// <param name="logcontents">log內容</param>
        public static void saveLog( string logcontents,string logpath)
        {
            //根据logtype获取对应的文件路徑以及文件名
            
                       

            //判斷文件是否存在，不存在就创建文件，存在就写入文件
            if (File.Exists(@logpath))
            {
                File.Delete(@logpath);
            }

            StreamWriter sw = new StreamWriter(logpath, true);
            sw.WriteLine(logcontents);
            sw.Close();

           
     

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Calculate Items Details info...,Ver:" + Application.ProductVersion;
            txtExcelFile.SetWatermark("DbClick here to select the excel file...");
        }

        private void lstDepItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstItem.Items.Clear();

            decimal i_time = 0;

            string item = lstDepItem.SelectedItem.ToString();
            string fileItem = appFolder + @"\" + item;
            StreamReader sr = new StreamReader(fileItem);
            string sline = string.Empty;
            while (!sr.EndOfStream)
            {
                sline = sr.ReadLine().Trim();

                for (int i = 0; i < lstItemDetail.Items.Count; i++)
                {
                    if (lstItemDetail.Items[i].ToString().Trim().StartsWith(sline))
                    {
                        if (lstItem.Items.IndexOf(lstItemDetail.Items[i]) >= 0)
                        {
                        }
                        else
                        {
                            lstItem.Items.Add(lstItemDetail.Items[i]);

                            string it = lstItemDetail.Items[i].ToString();

                            i_time = i_time + Convert.ToDecimal(it.Substring(it.LastIndexOf(':') + 1, it.Length - it.LastIndexOf(':') - 1));

                        }
                    }
                }

            }

            sr.Close ();


            grbSubItem.Text = lstDepItem.SelectedItem.ToString() + ",Subitem:" + lstItem.Items.Count + ",Time:" + i_time;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Directory.Delete(appFolder, true);
            }
            catch (Exception)
            {
                
                //throw;
            }
        }

    }
}
