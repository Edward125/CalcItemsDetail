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

        private void txtExcelFile_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {

                FileInfo fi = new FileInfo(open.FileName);
                if ((fi.Extension == ".xls") | (fi.Extension == ".xlsx"))
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


        static DataSet DataSetParse(string fileName)
        {
            // string connectionString = string.Format("provider=Microsoft.Jet.OLEDB.4.0; data source={0};Extended Properties=Excel 8.0;", fileName);


            ////2003（Microsoft.Jet.Oledb.4.0）
            //string strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", excelFilePath);
            ////2010（Microsoft.ACE.OLEDB.12.0）
            //string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", excelFilePath);

            string connectionString = string.Empty;
            System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
            //MessageBox.Show(fi.Extension);

            if (fi.Extension == ".xls")
                connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", fileName);
            if (fi.Extension == ".xlsx")
                connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", fileName);


            DataSet data = new DataSet();

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

            return data;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            lstItem.Items.Clear();
            lstItemDetail.Items.Clear();
            lstDepItem.Items.Clear();
            DataSet ds = DataSetParse(txtExcelFile.Text.Trim ());
            dataGridView1.DataSource = ds.Tables[3];
            loadDepItem(ds);
            loadItem(ds);

            for (int k = 0; k < lstDepItem.Items.Count; k++)
            {
                

                string depitem = lstDepItem.Items[k].ToString();
                lstItemDetail.Items.Add(depitem);

                int i_space = 0;
                for (int i = 0; i < lstItem.Items.Count; i++)
                {
                    
                    decimal v_time = 0;
                    int i_itemcount = 0;
                    string itemname = lstItem.Items[i].ToString();
                    if (itemname == " ")
                        i_space++;

                    

                       for (int j = 0; j < ds.Tables[3].Rows.Count; j++)
                        {
                            string itemdetail = string.Empty;//工作細目
                            string depitemdetail = string.Empty;

                            depitemdetail = ds.Tables[3].Rows[j]["DepItem"].ToString();
                            itemdetail = ds.Tables[3].Rows[j]["工作細目"].ToString();

                            if (depitemdetail == depitem)
                            {

                                if (!string.IsNullOrEmpty(itemname))
                                {
                                    if (itemdetail == itemname)
                                    {
                                        i_itemcount++;

                                        //MessageBox.Show((ds.Tables[3].Rows[j]["周工時(分)"].ToString()));

                                        v_time = v_time + Convert.ToDecimal(ds.Tables[3].Rows[j]["周工時(分)"].ToString());
                                    }

                                }


                            }

                        }

                       //if (k != i_space)
                       //    break;
                      

                   // MessageBox.Show(  "k:" + k +",i:" +i_space.ToString());
                       if (k == i_space  && !string.IsNullOrEmpty (itemname.Trim ()))
                       {
                           lstItemDetail.Items.Add(itemname + ",項目個數:" + i_itemcount + ",周工時:" + v_time);
                     }
                   
                    //MessageBox.Show("k:" + k + ",i:" + i_space.ToString());
                   // MessageBox.Show(i_space.ToString());

                }
            }





            this.Enabled = true;
        }





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

                for (int i = 0; i < lstItemDetail.Items.Count; i++)
                {
                    saveLog(lstItemDetail.Items[i].ToString());
                }
                MessageBox.Show("Save OK...");
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
        public static void saveLog( string logcontents)
        {
            //根据logtype获取对应的文件路徑以及文件名
            string logpath = Application.StartupPath +@"\Save360Item" + DateTime.Now.ToString ("yyyyMMddhhmmss") +".txt";
                       

            //判斷文件是否存在，不存在就创建文件，存在就写入文件
            if (!File.Exists(@logpath))
            {
                FileStream fs = File.Create(@logpath);
                fs.Close();
            }
            try
            {

             File.AppendAllText(@logpath, @logcontents + "\r\n");
                    
            
                   
            }
            catch (Exception)
            {
                //wait

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtExcelFile.SetWatermark("DbClick here to select the excel file...");
        }

    }
}
