using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;        //Работа с файлами (File)
using System.Security.Cryptography;  //Шифровка-дешифровка файлов

namespace Diplom_2
{
    class file_work
    {
        //Проверка наличия файла с подключениями
        public bool check_file()
        {
            /*
            string path = Path.GetTempFileName();
            FileInfo fi1 = new FileInfo(path);

            if (!fi1.Exists)
            {
                //Create a file to write to.
                using (StreamWriter sw = fi1.CreateText())
                { }
                { }
                System.IO.File.SetAttributes(@"C:\temp\mikro.txt", System.IO.FileAttributes.Hidden);
            }
            
            */
            //фиксированная директория?
            var path = @"C:\temp\mikro.txt";
            var exist = File.Exists(path);
            if (exist)  //файл существует
            {

                return true;    //файл имеется, необходимо прочитать с него данные о сессии
            }
            else
            {
                System.IO.File.Create(@"C:\temp\mikro.txt");        //Создание файла
                System.IO.File.SetAttributes(@"C:\temp\mikro.txt", System.IO.FileAttributes.Hidden);    //скрытие только что созданного файла
                //return (create_new_file());

            }   
            return false;
        }
        
        public bool create_new_file()
        {
            //скрытый
            System.IO.File.SetAttributes(@"C:\temp\mikro.txt", System.IO.FileAttributes.Hidden);
            var path = @"C:\temp\mikro.txt";
            var exist = File.Exists(path);
            if (exist)  //файл существует
            {
                return true;
            }
            return false;
        }



        //Запись нового подключения к файл

        //Чтение подключений из файла

    }
}
