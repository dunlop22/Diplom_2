using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

using System.IO;    //получение информации о накопителях
namespace Diplom_2
{
    public partial class AboutSoftwareForm : Form
    {
        public AboutSoftwareForm()
        {
            InitializeComponent();
        }

        private static List<string> GetHardwareInfo(string WIN32_Class, string ClassItemField)
        {
            List<string> result = new List<string>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + WIN32_Class);

            try
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    result.Add(obj[ClassItemField].ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        private static string OutputResult(List<string> result)
        {
            string ret = "";

            if (result.Count > 0)
            {
                for (int i = 0; i < result.Count; ++i)
                    ret = ret + "\n" + result[i];
                    //Console.WriteLine(result[i]);
            }
            return ret;
        }

        private void AboutSoftwareForm_Load(object sender, EventArgs e)
        {
            



            this.label_os.Text = "Операционная система: " + Environment.OSVersion.ToString();
            //this.label_cpu.Text = "Модель процессора: " + Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            //Процессор
            this.label_cpu.Text = "Процессор" + OutputResult(GetHardwareInfo("Win32_Processor", "Name"));
            this.label_num_cpu.Text = "Количество процессоров: " + Environment.ProcessorCount;
            this.label_name_user.Text = "Имя пользователя: " + Environment.UserName;
            this.label_path_sys.Text = "Путь к системному каталогу: " + Environment.SystemDirectory;
            Console.WriteLine("Локальные диски: ");
            foreach (DriveInfo dI in DriveInfo.GetDrives())
            {
                Console.Write(
                      "\t Диск: {0}\n\t" +
                      " Формат диска: {1}\n\t " +
                      "Размер диска (ГБ): {2}\n\t Доступное свободное место (ГБ): {3}\n",
                      dI.Name, dI.DriveFormat, (double)dI.TotalSize / 1024 / 1024 / 1024, (double)dI.AvailableFreeSpace / 1024 / 1024 / 1024);
                Console.WriteLine();
            }


            //Console.WriteLine("Операционная система (номер версии):  {0}", Environment.OSVersion);
            //Console.WriteLine("Разрядность процессора:  {0}", Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"));
            //Console.WriteLine("Модель процессора:  {0}", Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER"));
            //Console.WriteLine("Путь к системному каталогу:  {0}", Environment.SystemDirectory);
            //Console.WriteLine("Число процессоров:  {0}", Environment.ProcessorCount);
            //Console.WriteLine("Имя пользователя: {0}", Environment.UserName);
            
            
        }

        private void AboutSoftwareForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
