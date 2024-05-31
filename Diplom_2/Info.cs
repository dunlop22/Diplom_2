﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Renci.SshNet;
using System.Globalization;     //форматирование времени
using System.Net;   //работа с FTP
using System.IO;    //работа с FileStream 

namespace Diplom_2
{
    class Info
    {
        //Переменные

        //Наименование конфигурации при выгрузке
        string config_name = "api_config";



        //данные для подключения к устройству
        struct Connection
        {
            internal string name;
            internal string host;
            internal int port;
            internal string login;
            internal string password;
        }
        Connection conn = new Connection();

        struct Interface
        {
            internal string id;
            internal string name;
            internal string type;
            internal string mac;
            internal string download;
            internal string upload;
            internal string status;
        }
        private List<Interface> Interfaces = new List<Interface>();

        struct Address
        {
            internal string id;
            internal string address;
            internal string network;
            internal string inter;
            internal string dynamic;
            internal string status;
        }

        private List<Address> Addresses = new List<Address>();

        //Сервисы (API, SSH, WWW, Winbox,...)
        struct Service
        {
            internal string id;
            internal string name;
            internal string port;
            internal string status;      //bool?

        }
        List<Service> Services = new List<Service>();

        struct User
        {
            internal string id;
            internal string name;
            internal string group;
            internal string last_login;
            internal string disabled;
        }
        private List<User> Users = new List<User>();

        struct UserGroup
        {
            internal string id;
            internal string name;

            internal string[] polic;
            //= new int[4];
            //internal List<string> policy;
            //internal string policy;  //доступные политики
            //перечисление политик в строке policy      //true oor false
            //local, telnet,
            //ssh, ftp,
            //reboot, read,
            //write, policy,
            //test, winbox,
            //password, web,
            //sniff, sensitive,
            //api, romon,
            //dude, tikapp;

        }
        private List<UserGroup> UserGroups = new List<UserGroup>();
        private bool LogEnd = true;
        private bool UserEnd = true;
        private bool ServiceEnd = true;
        private bool UserGroupEnd = true;
        private bool ARPEnd = true;
        private bool InterfaceEnd = true;
        private bool AddressEnd = true;

        MK mikrotik;
        //ресурсы устройства
        private string[,] resource = new string[19, 2];

        private struct Machine
        {
            internal string id;
            internal string ip;
            internal string mac;
            internal string dhcp;      //true - dhcp, false - static
            internal string interface_l;
        }
        private List<Machine> ARP = new List<Machine>();


        //Логи / События
        private struct LogMes
        {
            internal string id;
            internal string time;
            internal string topics;
            internal string message;
            internal string level;   //error / info / message / warning
        }
        List<LogMes> Log = new List<LogMes>();

        internal void SetConnCred(List<string> connt)
        {
            conn.name = connt[0];
            conn.host = connt[1];
            conn.port = Convert.ToInt32(connt[2]);
            conn.login = connt[3];
            conn.password = connt[4];
        }
        internal void FirstStart()
        {

            mikrotik = new MK(conn.host, conn.port);
            mikrotik.Login(conn.login, conn.password);





        }
        //запрос на обновление ресурсов

        internal void SendResource()
        {
            mikrotik.Send("/system/resource/print");
            mikrotik.Send(".tag=res", true);

            /*
             MK mikrotik = new MK(conn.host);
            */

            /*
            if (mikrotik.Login(conn.login, conn.password))
            {

                mikrotik.Send("/system/resource/print");
                mikrotik.Send(".tag=res", true);
            }
            else
            {
                return;
            }
            */
        }

        internal void SendInterface()
        {
            mikrotik.Send("/interface/print");
            mikrotik.Send(".tag=interface", true);
            /*
            if (mikrotik.Login(conn.login, conn.password))
            {
                mikrotik.Send("/interface/print");
                mikrotik.Send(".tag=interface", true);
            }
            */
        }
        internal List<List<string>> GetTableAddress()
        {
            List<List<string>> all = new List<List<string>>();
            for (int i = 0; i < Addresses.Count(); i++)
            {
                List<string> temp = new List<string>();
                temp.Add(Addresses[i].address);
                temp.Add(Addresses[i].network);
                temp.Add(Addresses[i].inter);
                temp.Add(Addresses[i].dynamic);
                temp.Add(Addresses[i].status);
                all.Add(temp);
            }
            return all;
        }

        internal List<List<string>> GetLog()
        {
            List<List<string>> all = new List<List<string>>();
            for (int i = 0; i < Log.Count(); i++)
            {
                List<string> tr = new List<string>();
                LogMes temp = Log[i];
                tr.Add(temp.time);
                tr.Add(temp.topics);
                tr.Add(temp.message);
                all.Add(tr);
            }
            return all;
        }

        internal List<string> GetResource()
        {

            List<string> res = new List<string>();
            res.Add(resource[10, 1]);   //Нагрузка процессора

            res.Add(resource[5, 1]);    //свободная RAM
            res.Add(resource[6, 1]);    //Общая RAM

            res.Add(resource[11, 1]);    //занятая память
            res.Add(resource[12, 1]);    //Общая память

            res.Add(resource[1, 1]);    //uptime

            res.Add(resource[2, 1]);    //RouterOS
            res.Add(resource[16, 1]);    //Архитектура
            res.Add(resource[17, 1]);    //Модель

            res.Add(resource[7, 1]);    //Архитектура процессора
            res.Add(resource[9, 1]);    //Частота процессора
            res.Add(resource[8, 1]);    //Количество ядер

            res.Add(resource[13, 1]);    //сектора после reboot
            res.Add(resource[14, 1]);    //сектора всего
            res.Add(resource[15, 1]);    //bad blocks
            res.Add(resource[4, 1]);    //factory software


            return res;
        }


        internal List<List<string>> GetTableInterface()
        {
            List<List<string>> all = new List<List<string>>();
            for (int i = 0; i < Interfaces.Count(); i++)
            {
                List<string> temp = new List<string>();

                temp.Add(Interfaces[i].name);
                temp.Add(Interfaces[i].mac);
                temp.Add(Interfaces[i].type);
                temp.Add((Math.Round((Convert.ToDouble(Interfaces[i].download) / 1024 / 1024 / 953.7), 2).ToString()) + " GB");
                temp.Add((Math.Round((Convert.ToDouble(Interfaces[i].upload) / 1024 / 1024 / 953.7), 2).ToString()) + " GB");
                temp.Add(Interfaces[i].status);
                all.Add(temp);
            }
            return all;
        }


        internal List<List<string>> GetTableService()
        {
            List<List<string>> all = new List<List<string>>();
            for (int i = 0; i < Services.Count(); i++)
            {
                List<string> temp = new List<string>();

                temp.Add(Services[i].id);
                temp.Add(Services[i].name);
                temp.Add(Services[i].port);
                temp.Add(Services[i].status);
                all.Add(temp);
            }
            return all;
        }
        internal List<List<string>> GetTableUser()
        {
            List<List<string>> all = new List<List<string>>();
            for (int i = 0; i < Users.Count(); i++)
            {
                List<string> temp = new List<string>();

                temp.Add(Users[i].id);
                temp.Add(Users[i].name);
                temp.Add(Users[i].group);
                temp.Add(Users[i].last_login);
                all.Add(temp);
            }

            return all;
        }
        internal List<List<string>> GetTableARP()
        {
            List<List<string>> all = new List<List<string>>();

            for (int i = 0; i < ARP.Count(); i++)
            {
                List<string> temp = new List<string>();
                temp.Add(ARP[i].ip);
                temp.Add(ARP[i].mac);
                temp.Add(ARP[i].dhcp);
                temp.Add(ARP[i].interface_l);
                all.Add(temp);
            }

            return all;
            //return temp.ip;
        }

        internal List<string> GetTableUserGroupName()
        {
            List<string> all = new List<string>();
            for (int i = 0; i < UserGroups.Count(); i++)
            {
                all.Add(UserGroups[i].name);
            }
            return all;
        }


        internal List<List<string>> GetTableUserGroup()
        {
            List<List<string>> all = new List<List<string>>();
            for (int i = 0; i < UserGroups.Count(); i++)
            {
                List<string> temp = new List<string>();
                temp.Add(UserGroups[i].name);
                //разбивка в лист
                UserGroup temp_u = UserGroups[i];
                for (int j = 0; j < temp_u.polic.Count(); j++)
                {
                    //temp.Add("13");
                    temp.Add(temp_u.polic[j]);
                    //temp.Add(temp_u.policy[j]);
                }

                //temp.Add(UserGroups[i].policy);

                all.Add(temp);
            }
            return all;
        }


        internal List<string> GetCred()
        {
            List<string> temp = new List<string>();
            temp.Add(conn.name);
            temp.Add(conn.host);
            temp.Add((conn.port).ToString());
            temp.Add(conn.login);
            temp.Add(conn.password);
            return temp;
        }

        //Обновление вкладки IP --> Service
        internal async void SendUpdateService(List<List<string>> command)
        {
            for (int i = 0; i < command.Count(); i++)
            {
                for (int j = 0; j < command[i].Count(); j++)
                {
                    if (j < command[i].Count() - 1)
                    {
                        mikrotik.Send(command[i][j]);
                    }
                    else
                    {
                        mikrotik.Send(command[i][j], true);
                    }
                }
            }
        }


        //Создание новой группы пользователей
        internal void SendCreateNewGroup(List<string> inform)
        {
            if (mikrotik.Login(conn.login, conn.password))
            {
                //успешное подключение
                mikrotik.Send("/user/group/add");
                //перечисление политик
                mikrotik.Send("=name=" + inform[0]);
                for (int i = 1; i < inform.Count(); i++)
                {
                    mikrotik.Send("=policy=" + inform[i]);
                }

                mikrotik.Send(".tag=newusergroup", true);
            }
        }


        //отправка запроса на получение log
        internal void SendLog()
        {
            mikrotik.Send("/log/print");
            mikrotik.Send(".tag=log", true);
        }

        //Получение статусов из IP --> Service
        internal void SendService()
        {
            mikrotik.Send("/ip/service/print");
            mikrotik.Send(".tag=ipservice", true);
        }

        //Получение списка пользователей
        internal void SendUser()
        {
            mikrotik.Send("/user/print");
            mikrotik.Send(".tag=user", true);
        }

        internal void DownloadConfig()
        {

            string inputfilepath = @"C:\!___TEST\" + config_name + ".backup";
            string ftphost = "192.168.0.1";
            string ftpfilepath = "/" + config_name + ".backup";

            string ftpfullpath = "ftp://" + ftphost + ftpfilepath + ":5100";

            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential(conn.login, conn.password);
                byte[] fileData = request.DownloadData(ftpfullpath);

                using (FileStream file = File.Create(inputfilepath))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }
                //MessageBox.Show("Download Complete");
            }
            System.IO.File.SetAttributes(@"C:\!___TEST\" + config_name + ".backup", System.IO.FileAttributes.Hidden);
        }

        internal void SendSaveConfig()
        {
            //Создание скрипта создания конфигурации оборудования
            mikrotik.Send("/system/script/add");
            mikrotik.Send("=name=CreateConfigApi");
            
            
            mikrotik.Send("=source=" +
                "/file remove [find name=\"" + config_name + "\"]\r\n\r\n" + 
                //Создание конфигурации
                "/system backup save name=\"" + config_name + "\";\r\n\r\n" +
                //Задержка перед удалением скрипта
                ":delay 5\r\n\r\n\r\n" +
                //Удаление скрипта
                ":local arrIdScr [:toarray [/system script job find where script~\"[a-zA-Z0-9]{1,}\"]]\r\n" +
                ":local ScriptName [/system script job get ($arrIdScr->([:len $arrIdScr] - 1)) value-name=script]\r\n\r\n" +
                "system script remove $ScriptName", true);
            
            //Запуск скрипта
            Thread.Sleep(200);
            mikrotik.Send("/system/script/run");
            mikrotik.Send("=.id=CreateConfigApi", true);





            //Загрузка файла через FTP
            DownloadConfig();

        }

        //Запуск SafeMode
        internal void SendStartSafeMode()
        {
            //Thread.Sleep(200);

            //Создание скрипта для деактивации существующего скрипта и удаления записей
            mikrotik.Send("/system/script/add");
            mikrotik.Send("=name=del_safe");
            mikrotik.Send("=source=/system script job remove [find where script=\"safe\"]\r\n\r\nsystem script remove safe\r\nsystem script remove del_safe", true);

            //Создание скрипта для активации safe mode
            mikrotik.Send("/system/script/add");
            mikrotik.Send("=name=api_safe_mode");
            mikrotik.Send("=source=system backup save name=backup_api\r\ndelay 900\r\nsystem backup load name=backup_api", true);


            mikrotik.Send("/system/script/run");
            mikrotik.Send("=.id=api_safe_mode", true);
            //Thread.Sleep(200);

            /*
            //выполнить скрипт
            var client = new SshClient("109.195.38.77", "Admin_Adm_Adm", "GfhjkzYtn1");
            client.Connect();
            var command = client.CreateCommand("/system script run safe");
            command.Execute();
            client.Disconnect();
            */


        }

        //Прекращение работы SafeMode
        internal void SendEndSafeMode()
        {
            /*
             * var client = new SshClient(conn.host, conn.login, conn.password);
            client.Connect();
            var command = client.CreateCommand("/system script run del_safe");
            command.Execute();
            client.Disconnect();
            */

            //Thread.Sleep(500);
            /*
            //добавить скрипт
            mikrotik.Send("/system/script/add");
            mikrotik.Send("=name=del_safe");
            //mikrotik.Send("=source=/system script job remove [ find where script=\"safe\" ]\r\ndelay 4\r\nsystem script remove safe\r\nsystem script remove del_safe", true);
            mikrotik.Send("=source=/system script job remove [ find where script=\"safe\" ]", true);
            */

            //Thread.Sleep(500);
            //mikrotik.Login(conn.login, conn.password);

        }

        internal void SendUserGroup()
        {
            mikrotik.Send("/user/group/print");
            mikrotik.Send(".tag=user_group", true);
            /*
            if (mikrotik.Login(conn.login, conn.password))
            {

                mikrotik.Send("/user/group/print");
                mikrotik.Send(".tag=user_group", true);

            }
            */
        }

        internal void SendAddress()
        {
            mikrotik.Send("/ip/address/print");
            mikrotik.Send(".tag=address", true);
        }
        internal void SendARP()
        {
            mikrotik.Send("/ip/arp/print");
            mikrotik.Send(".tag=table_arp", true);
            /*
            if (mikrotik.Login(conn.login, conn.password))
            {
                //успешное подключение
                mikrotik.Send("/ip/arp/print");
                mikrotik.Send(".tag=table_arp", true);
            }
            else
            {
                //неудачное подключение
                return;
            }

            */
        }


        //Выключение роутера
        internal void Shutdown()
        {
            if (mikrotik.Login(conn.login, conn.password))
            {
                mikrotik.Send("/system/shutdown", true);
            }
        }

        //Перезагрузка роутера
        internal void Reboot()
        {
            mikrotik.Send("/system/reboot", true);
            /*
            if (mikrotik.Login(conn.login, conn.password))
            {
                mikrotik.Send("/system/reboot", true);
            }
            else
            {
            return;
            }
            */
        }


        internal void SendPreset()
        {

            int g = 0;
            while (true)
            {
                if (g % 6 == 0)
                {
                    this.SendResource();
                }
                else if (g % 6 == 1)
                {
                    this.SendARP();
                }
                else if (g % 6 == 2)
                {
                    this.SendUser();

                }
                else if (g % 6 == 3)
                {
                    this.SendUserGroup();
                }
                else if (g % 6 == 4)
                {
                    this.SendInterface();
                }
                else if (g % 6 == 5)
                {
                    this.SendService();
                }
                g++;

            }
        }



        internal void GetGlobalIP()
        {
            //Добавление скрипта на устройство

            //Удаленное подключение по SSH
            /*
            var client = new SshClient(conn.host, conn.login, conn.password);
            client.Connect();
             */
            /*
            mikrotik.Send("/system/script/add");
            mikrotik.Send("=name=GetGlobalIP");
            */
            ////mikr.Send("=source=/tool fetch mode = http address = \"checkip.dyndns.org\" src - path = \" / \" dst - path = \" / dyndns.checkip.html\" :local result[/ file get dyndns.checkip.html contents] :local resultLen[:len $result] :local startLoc[:find $result \": \" - 1] :set startLoc($startLoc + 2) :local endLoc[:find $result \"</body>\" - 1] :global currentIP[:pick $result $startLoc $endLoc]", true);
            /*
            mikrotik.Send("=source=/global currentIP\r\n/file remove [find name=\"dyndns.checkip.html\"]\r\n" +
                "/tool fetch mode=http address=\"checkip.dyndns.org\" src-path=\"/\" dst-path=\"/dyndns.checkip.html\";\r\n" +
                ":delay 2\r\n" +
                ":local result [/file get dyndns.checkip.html contents]\r\n" +
                ":global currentIP [:pick $result ([:find $result \": \" -1]+2) [:find $result \"</body>\" -1]]\r\n" +
                "/file remove dyndns.checkip.html\r\n" +
                ":delay 2\r\n\r\n" +
                ":local arrIdScr [:toarray [/system script job find where script~\"[a-zA-Z0-9]{1,}\"]]\r\n" +
                ":local ScriptName [/system script job get ($arrIdScr->([:len $arrIdScr] - 1)) value-name=script]\r\n\r\n" +
                "/system script remove $ScriptName", true);
            */

            /*
            mikrotik.Send("=source=:delay 1;\r\n:global currentIP \"0\";\r\n/file remove [find name=\"dyndns.checkip.html\"]\r\n" +
                "/tool fetch mode=http address=\"checkip.dyndns.org\" src-path=\"/\" dst-path=\"/dyndns.checkip.html\";\r\n" +
                ":delay 2\r\n" +
                ":local result [/file get dyndns.checkip.html contents]\r\n" +
                ":global currentIP [:pick $result ([:find $result \": \" -1]+2) [:find $result \"</body>\" -1]]\r\n" +
                "/file remove dyndns.checkip.html\r\n" +
                ":delay 2\r\n\r\n" +
                ":local arrIdScr [:toarray [/system script job find where script~\"[a-zA-Z0-9]{1,}\"]]\r\n" +
                ":local ScriptName [/system script job get ($arrIdScr->([:len $arrIdScr] - 1)) value-name=script]\r\n\r\n", true);
            */
            Thread.Sleep(500);

            mikrotik.Send("/system/script/run");
            mikrotik.Send("=.id=GetGlobalIP", true);
            /*
            / tool fetch mode = http address = "checkip.dyndns.org" src - path = "/" dst - path = "/dyndns.checkip.html"
            :local result[/ file get dyndns.checkip.html contents]
            :local resultLen[:len $result]
            :local startLoc[:find $result ": " - 1]
            :set startLoc($startLoc +2)
            :local endLoc[:find $result "</body>" - 1]
            :global currentIP[:pick $result $startLoc $endLoc]
            */



            //Добавление скрипта
            //var command = client.CreateCommand("/system script run del_safe");
            
            /*
            command.Execute();
            client.Disconnect();
            */

            //Выполнение скрипта

            //Ожидание ответа

            //Получение IP из глобальной переменной
        }
        
        internal bool stop_send = false;
        internal void ReadAnswer()
        {
            //bool rez = false;
            int g = 0;
            while (true)
            {
                /*
                if (!rez)
                {
                    if (mikrotik.Login(conn.login, conn.password))
                    {
                        rez = true;
                    }
                    else
                    { 
                    }
                }
                */
                if (g % 7 == 0)
                {
                    this.SendResource();
                }

                else if (g % 7 == 1)
                {
                    this.SendARP();
                    this.SendAddress();
                }
                else if (g % 7 == 2)
                {
                    this.SendUser();
                }
                else if (g % 7 == 3)
                {
                    this.SendUserGroup();
                }
                else if (g % 7 == 4)
                {
                    this.SendInterface();
                }
                else if (g % 7 == 5)
                {
                    this.SendService();
                }
                else if (g % 10 == 6)
                {
                    this.SendLog();
                }



                g++;
                List<string> answer = new List<string>();
                foreach (string h in mikrotik.Read())
                {
                    answer.Add(h);
                    //Console.WriteLine(h);
                }
                for (int i = 0; i < answer.Count; i++)
                {
                    if (answer.Count() > 0)
                    {
                        string[] words = answer[i].Split(new char[] { '=' });
                        if (words.Length > 1)
                        {
                            if (words[1] == "table_arp")
                            {
                                if (words[0] != "!done.tag")
                                {
                                    //информация из ARP таблицы
                                    if (i == 0)
                                    {
                                        //очистка текущего листа
                                        ARP.Clear();
                                    }
                                    Machine temp = new Machine();
                                    for (int j = 0; j < words.Length; j++)
                                    {
                                        if (words[j] == "address")
                                        {
                                            temp.ip = words[j + 1];
                                        }
                                        else if (words[j] == "interface")
                                        {
                                            temp.interface_l = words[j + 1];
                                        }
                                        else if (words[j] == "DHCP")
                                        {
                                            temp.dhcp = words[j + 1];
                                            /*
                                            if (words[j + 1] == "true")
                                            {
                                                temp.dhcp = true;
                                            }
                                            else
                                            {
                                                temp.dhcp = false;
                                            }
                                            */
                                        }
                                        else if (words[j] == "mac-address")
                                        {
                                            temp.mac = words[j + 1];
                                        }

                                        else if (words[j] == ".id")
                                        {
                                            temp.id = words[j + 1];
                                        }
                                    }
                                    ARP.Add(temp);
                                }
                            }
                            else if (words[1] == "res")
                            {
                                //Информация о ресурсах оборудования
                                int k = 0;
                                for (int j = 0; j < words.Length; j = j + 2, k++)
                                {
                                    resource[k, 0] = words[j];
                                    resource[k, 1] = words[j + 1];
                                }
                                break;
                            }
                            else if (words[1] == "log")
                            {
                                if (words[0] != "!done.tag")
                                {
                                    //Получение списка пользователей
                                    if (this.LogEnd == true)
                                    {
                                        //очистка текущего листа
                                        Log.Clear();
                                        this.LogEnd = false;
                                    }

                                    LogMes temp = new LogMes();
                                    for (int j = 0; j < words.Length; j++)
                                    {
                                        if (words[j] == ".id")
                                        {
                                            temp.id = words[j + 1];     //id
                                        }
                                        if (words[j] == "time")
                                        {
                                            //проверка форматирования
                                            if (words[j + 1].Length < 10)
                                            {

                                                temp.time = (DateTime.Now.ToString("MMM/d ", CultureInfo.GetCultureInfo("en-US"))).ToLower() + words[j + 1];     //time
                                            }
                                            else
                                            {
                                                temp.time = words[j + 1];     //time
                                            }
                                        }
                                        if (words[j] == "topics")
                                        {
                                            temp.topics = words[j + 1];     //topics
                                        }
                                        if (words[j] == "message")
                                        {
                                            temp.message = words[j + 1];     //messaage
                                        }
                                    }
                                    Log.Add(temp);

                                }
                                else
                                {
                                    //Весь список пользователей был заполнен
                                    this.LogEnd = true;
                                }
                            }
                            else if (words[1] == "user")
                            {
                                if (words[0] != "!done.tag")
                                {

                                    //Получение списка пользователей
                                    if (this.UserEnd == true)
                                    {
                                        //очистка текущего листа
                                        Users.Clear();
                                        this.UserEnd = false;
                                    }
                                    User temp = new User();
                                    temp.id = words[3];
                                    temp.name = words[5];
                                    temp.group = words[7];
                                    temp.last_login = words[11];
                                    temp.disabled = "s";
                                    Users.Add(temp);
                                }
                                else
                                {
                                    //Весь список пользователей был заполнен
                                    this.UserEnd = true;
                                }
                            }
                            else if (words[1] == "user_group")
                            {
                                if (words[0] != "!done.tag")
                                {

                                    //Получение списка групп пользователей
                                    if (this.UserGroupEnd == true)
                                    {
                                        //очистка текущего листа
                                        UserGroups.Clear();
                                        this.UserGroupEnd = false;
                                    }
                                    UserGroup temp = new UserGroup();
                                    temp.polic = new string[18];
                                    //temp.policy = "";

                                    temp.id = words[3];         //id группы
                                    temp.name = words[5];       //наименование группы
                                                                //политики, доступные группе
                                    string[] policy_one = words[7].Split(new char[] { ',' });
                                    List<string> temp_policy = new List<string>();
                                    for (int k = 0; k < policy_one.Length; k++)
                                    {
                                        int u = -1;
                                        if (policy_one[k] == "local" || policy_one[k] == "!local")
                                        {
                                            u = 0;
                                        }
                                        if (policy_one[k] == "telnet" || policy_one[k] == "!telnet")
                                        {
                                            u = 1;
                                        }
                                        if (policy_one[k] == "ssh" || policy_one[k] == "!ssh")
                                        {
                                            u = 2;
                                        }
                                        if (policy_one[k] == "ftp" || policy_one[k] == "!ftp")
                                        {
                                            u = 3;
                                        }
                                        if (policy_one[k] == "reboot" || policy_one[k] == "!reboot")
                                        {
                                            u = 4;
                                        }
                                        if (policy_one[k] == "read" || policy_one[k] == "!read")
                                        {
                                            u = 5;
                                        }
                                        if (policy_one[k] == "write" || policy_one[k] == "!write")
                                        {
                                            u = 6;
                                        }
                                        if (policy_one[k] == "policy" || policy_one[k] == "!policy")
                                        {
                                            u = 7;
                                        }
                                        if (policy_one[k] == "test" || policy_one[k] == "!test")
                                        {
                                            u = 8;
                                        }
                                        if (policy_one[k] == "winbox" || policy_one[k] == "!winbox")
                                        {
                                            u = 9;
                                        }
                                        if (policy_one[k] == "password" || policy_one[k] == "!password")
                                        {
                                            u = 10;
                                        }
                                        if (policy_one[k] == "web" || policy_one[k] == "!web")
                                        {
                                            u = 11;
                                        }
                                        if (policy_one[k] == "sniff" || policy_one[k] == "!sniff")
                                        {
                                            u = 12;
                                        }
                                        if (policy_one[k] == "sensitive" || policy_one[k] == "!sensitive")
                                        {
                                            u = 13;
                                        }
                                        if (policy_one[k] == "api" || policy_one[k] == "!api")
                                        {
                                            u = 14;
                                        }
                                        if (policy_one[k] == "romon" || policy_one[k] == "!romon")
                                        {
                                            u = 15;
                                        }
                                        if (policy_one[k] == "dude" || policy_one[k] == "!dude")
                                        {
                                            u = 16;
                                        }
                                        if (policy_one[k] == "tikapp" || policy_one[k] == "!tikapp")
                                        {
                                            u = 17;
                                        }
                                        if (u >= 0)
                                        {
                                            if (policy_one[k][0] == '!')
                                            {
                                                temp.polic[u] = "false";
                                            }
                                            else
                                            {
                                                temp.polic[u] = "true";
                                            }
                                        }
                                        else
                                        {
                                            //TODO:
                                            //MessageBox: произошла внутренняя ошибка
                                            ;
                                        }

                                    }
                                    //temp.policy = temp_policy;
                                    UserGroups.Add(temp);
                                }
                                else
                                {
                                    this.UserGroupEnd = true;
                                }
                            }
                            else if (words[1] == "interface")
                            {
                                if (words[0] != "!done.tag")
                                {
                                    if (this.InterfaceEnd == true)
                                    {
                                        this.Interfaces.Clear();
                                        this.InterfaceEnd = false;
                                    }
                                    Interface temp = new Interface();
                                    for (int j = 0; j < words.Length; j++)
                                    {
                                        if (words[j] == ".id")
                                        {
                                            temp.id = words[j + 1]; //id
                                        }
                                        else if (words[j] == "name")
                                        {
                                            temp.name = words[j + 1];   //name
                                        }
                                        else if (words[j] == "type")
                                        {
                                            temp.type = words[j + 1];   //тип
                                        }
                                        else if (words[j] == "mac-address")
                                        {
                                            temp.mac = words[j + 1];
                                        }
                                        else if (words[j] == "rx-byte")
                                        {
                                            temp.download = words[j + 1];
                                        }
                                        else if (words[j] == "tx-byte")
                                        {
                                            temp.upload = words[j + 1];
                                        }
                                        else if (words[j] == "disabled")
                                        {
                                            temp.status = words[j + 1];
                                        }

                                    }
                                    Interfaces.Add(temp);
                                }

                                else
                                {
                                    this.InterfaceEnd = true;
                                }
                            }
                            else if (words[1] == "ipservice")
                            {
                                if (words[0] != "!done.tag")
                                {
                                    if (this.ServiceEnd == true)
                                    {
                                        this.Services.Clear();
                                        this.ServiceEnd = false;
                                    }
                                    Service temp = new Service();

                                    for (int j = 0; j < words.Length; j++)
                                    {
                                        if (words[j] == ".id")
                                        {
                                            temp.id = words[j + 1]; //id
                                        }
                                        else if (words[j] == "name")
                                        {
                                            temp.name = words[j + 1];   //name
                                        }
                                        else if (words[j] == "port")
                                        {
                                            temp.port = words[j + 1];   //порт
                                        }
                                        else if (words[j] == "disabled")
                                        {
                                            temp.status = words[j + 1];
                                        }
                                    }
                                    Services.Add(temp);
                                }
                                else
                                {
                                    this.ServiceEnd = true;
                                }
                            }
                            else if (words[1] == "address")
                            {
                                if (words[0] != "!done.tag")
                                {
                                    if (this.AddressEnd == true)
                                    {
                                        this.Addresses.Clear();
                                        this.AddressEnd = false;
                                    }
                                    Address temp = new Address();
                                    for (int j = 0; j < words.Length; j++)
                                    {
                                        if (words[j] == ".id")      
                                        {
                                            temp.id = words[j + 1];     //id
                                        }
                                        else if (words[j] == "address")
                                        {
                                            temp.address = words[j + 1]; //address
                                        }
                                        else if (words[j] == "network")
                                        {
                                            temp.network = words[j + 1];   //network
                                        }
                                        else if (words[j] == "interface")
                                        {
                                            temp.inter = words[j + 1];   //интерфейс
                                        }
                                        else if (words[j] == "dynamic")
                                        {
                                            temp.dynamic = words[j + 1];
                                        }
                                        else if (words[j] == "disabled")
                                        {
                                            temp.status = words[j + 1];
                                        }
                                    }
                                    Addresses.Add(temp);
                                }
                                else
                                {
                                    this.AddressEnd = true;
                                }
                            }

                        }
                    }
                }

                //разбор
            }


        }

        /*
        internal void ReadResource()
        {
            MK mikrotik = new MK(conn.host, conn.port);
            if (mikrotik.Login(conn.login, conn.password))
            {
                mikrotik.Send("/system/resource/print");
                mikrotik.Send(".tag=res", true);


                string h = mikrotik.Read()[0];
                Console.WriteLine(h);


                string[] words = h.Split(new char[] { '=' });
                Console.WriteLine(words.Length);
                Console.WriteLine(words[36]);

                int j = 0;
                if (words[0] == "!re.tag")        //данные успешно получены
                {

                    for (int i = 0; i < words.Length; i = i + 2, j++)
                    {
                        resource[j, 0] = words[i];
                        resource[j, 1] = words[i + 1];
                    }
                    //return true;
                }
                Console.WriteLine(resource[4, 1]);
            }
            //подключение не удалось
            //return false;


            List <Machine> th = new List<Machine>();
            Machine o = new Machine();
            th.Add(o);



            Machine thf = th[0];
            thf.id = "1";
            //Machine people[];

        }
        */

        //запрос на обновление таблицы arp

        //запрос на обновление портов

        //запрос на обновление 


        //данные об устройстве
        

        //данные о подключенных устройствах
        /*class machine
        {
            string ip;
            string mac;
            bool dhcp;      //true - dhcp, false - static

        }
        */


    }
}

