using System;
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


        /*
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
        */
        struct Firewall
        {
            internal string id;
            internal string chain;
            internal string action;
            internal string protocol;
            internal string comment;    //последний столбец таблицы
            internal string in_interface;
            internal string src_address_list;
            internal string dst_port;
            internal string status;
        }

        private List<Firewall> Firewalls = new List<Firewall>();
        struct Interface
        {
            internal string id;
            internal string name;
            internal string type;
            internal string mac;
            internal string download;
            internal string upload;
            internal string connection;
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
        private bool FirewallEnd = true;

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

        /*
        internal void SetConnCred()
        {
            conn.name = connt.name;
            //connt[0];
            conn.host = connt[1];
            conn.port = Convert.ToInt32(connt[2]);
            conn.login = connt[3];
            conn.password = connt[4];
        }
        */
        internal void FirstStart()
        {
            mikrotik = new MK(connt.host, Convert.ToInt32(connt.port));
            mikrotik.Login(connt.login, connt.password);
        }
        //запрос на обновление ресурсов

        internal void SendResource()
        {
            mikrotik.Send("/system/resource/print");
            mikrotik.Send(".tag=res", true);

        }

        internal void SendRequestForGetInterface()
        {
            mikrotik.Send("/interface/print");
            mikrotik.Send(".tag=interface", true);
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
                temp.Add(Interfaces[i].connection);
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


        internal List<List<string>> GetTableFirewall()
        {
            List<List<string>> all = new List<List<string>>();
            for (int i = 0; i < Firewalls.Count(); i++)
            {
                List<string> temp = new List<string>();
                temp.Add(Firewalls[i].id);
                temp.Add(Firewalls[i].action);
                temp.Add(Firewalls[i].chain);
                temp.Add(Firewalls[i].in_interface);
                temp.Add(Firewalls[i].protocol);
                temp.Add(Firewalls[i].dst_port);
                
                temp.Add(Firewalls[i].src_address_list);
                temp.Add(Firewalls[i].comment);
                temp.Add(Firewalls[i].status);
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

        /*
        internal List<string> GetCred()
        {
            List<string> temp = new List<string>();
            temp.Add(connt.name);
            temp.Add(connt.host);
            temp.Add((connt.port).ToString());
            temp.Add(connt.login);
            temp.Add(connt.password);
            return temp;
        }
        */

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

        //Создание нового пользователя
        internal void SendCreateNewUser(List<string> inform)
        {
            mikrotik.Send("/user/add");
            mikrotik.Send("=name=" + inform[0]);
            mikrotik.Send("=password=" + inform[1]);
            mikrotik.Send("=group=" + inform[2], true);
        }

        //Создание новой группы пользователей
        internal void SendCreateNewGroup(string name, string inform_politics)
        {
            mikrotik.Send("/user/group/add");
            mikrotik.Send("=name=" + name);     //наименование группы
            mikrotik.Send("=policy=" + inform_politics);        //перечисление политик, доступных группе (e.g. "ftp,local")
            mikrotik.Send(".tag=newusergroup", true);           //tag
        }


        //отправка запроса на получение log
        internal void SendRequestForGetLog()
        {
            mikrotik.Send("/log/print");
            mikrotik.Send(".tag=log", true);
        }

        //Получение статусов из IP --> Service
        internal void SendRequestForGetService()
        {
            mikrotik.Send("/ip/service/print");
            mikrotik.Send(".tag=ipservice", true);
        }

        //Получение списка пользователей
        internal void SendRequestForGetUser()
        {
            mikrotik.Send("/user/print");
            mikrotik.Send(".tag=user", true);
        }

        //Загрузка конфигурационного файла
        internal bool DownloadConfig()
        {
            string inputfilepath = @"C:\!___TEST\" + config_name + ".backup";
            string ftphost = "192.168.0.1";
            string ftpfilepath = "/" + config_name + ".backup";

            string ftpfullpath = "ftp://" + ftphost + ftpfilepath + ":5100";
            //создание подключения
            using (WebClient request = new WebClient())
            {
                bool rez = false;
                try
                {
                    request.Credentials = new NetworkCredential(connt.login, connt.password);
                    byte[] fileData = request.DownloadData(ftpfullpath);

                    using (FileStream file = File.Create(inputfilepath))
                    {
                        file.Write(fileData, 0, fileData.Length);
                        file.Close();
                    }
                    return true;
                }
                catch
                {

                }
                return false;
            }
            System.IO.File.SetAttributes(@"C:\!___TEST\" + config_name + ".backup", System.IO.FileAttributes.Hidden);
        }

        internal bool SendSaveConfig()
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

            //Загрузка файла через FTP и уведомление пользователя о результате
            return (DownloadConfig());
        }

        //Запуск SafeMode
        internal void SendStartSafeMode()
        {
            string time = DateTime.Now.ToString("g", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
            //Создание скрипта (замена SafeMode)
            mikrotik.Send("/system/script/add");
            mikrotik.Send("=name=APISafeMode");
            mikrotik.Send("=source=system backup save name=backup_api\r\n" +
                //Удаление записи scheduler
                "/system scheduler remove \"API_" + time + "\"\r\n\r\n" +
                ":delay 900\r\n" +
                "/system backup load name=backup_api", true);

            Thread.Sleep(150);
            //Создание записи в планировщиеке для активации safe mode
            mikrotik.Send("/system/script/add");
            mikrotik.Send("=name=CreateScheduler");
            //получение времени
            mikrotik.Send("=source=:local a ([/sys clock get time] + 00:00:05)\r\n\r\n" +
                //Создание scheduler
                "/system scheduler add name=\"API_" + time + "\" start-time=$a on-event=APISafeMode\r\n\r\n" +
                //удалить текущий скрипт
                ":local arrIdScr [:toarray [/system script job find where script~\"[a-zA-Z0-9]{1,}\"]]\r\n" +
                ":local ScriptName [/system script job get ($arrIdScr->([:len $arrIdScr] - 1)) value-name=script]\r\n" +
                "/system script remove $ScriptName", true);
            Thread.Sleep(150);

            mikrotik.Send("/system/script/add");
            mikrotik.Send("=name=del_safe");
            mikrotik.Send("=source=/system script job remove [find where script=\"APISafeMode\"]\r\n" +
                //":delay 4\r\n" +
                "/system script remove APISafeMode\r\n" +
                "/system script remove del_safe", true);

            Thread.Sleep(150);
            //удаление работающего скрипта
            Thread.Sleep(50);
            mikrotik.Send("/system/script/run");
            mikrotik.Send("=.id=CreateScheduler", true);
        }

        //Прекращение работы SafeMode
        internal void SendEndSafeMode()
        {
            mikrotik.Send("/system/script/add");
            mikrotik.Send("=name=delsafe");
            mikrotik.Send("=source=/system script run del_safe\r\n\r\n" +
            //Удаление выполняемого скрипта
            ":local arrIdScr [:toarray [/system script job find where script~\"[a-zA-Z0-9]{1,}\"]]\r\n" +
            ":local ScriptName [/system script job get ($arrIdScr->([:len $arrIdScr] - 1)) value-name=script]\r\n" + 
            "/system script remove $ScriptName", true);

            Thread.Sleep(100);
            //Выполнение скрипта
            mikrotik.Send("/system/script/run");
            mikrotik.Send("=.id=delsafe", true);
        }

        //Отправка запроса на получение списка групп пользователей
        internal void SendRequestForGetUserGroup()
        {
            mikrotik.Send("/user/group/print");
            mikrotik.Send(".tag=user_group", true);
        }

        //Отправка запроса на получение таблицы address
        internal void SendRequestForGetAddress()
        {
            mikrotik.Send("/ip/address/print");
            mikrotik.Send(".tag=address", true);
        }


        internal void SendCreateRuleFirewall(string name_address, string chain, string action)
        {
            //place = 0 - самая верхняя стркоа правил
            mikrotik.Send("/ip/firewall/filter/add");
            mikrotik.Send("=chain=" + chain);
            mikrotik.Send("=src-address-list=" + name_address);
            mikrotik.Send("=action=" + action);
            mikrotik.Send("=comment=API Create" + DateTime.Now.ToString(CultureInfo.CreateSpecificCulture("en-US")));
            mikrotik.Send("=place-before=*0", true);
        }


        internal void SendDelFromFirewall()
        {
            mikrotik.Send("/system/script/add");
            mikrotik.Send("=name=del_firewall");
            mikrotik.Send("=source=/ip firewall filter remove numbers=[find src-address=\"" + WorkFirewall.host + "\"]\r\n\r\n" +
                "/ip firewal address-list remove [find address=\"" + WorkFirewall.host + "\"]\r\n\r\n" +
                //задержка перед удалением скрипта
                ":delay 2\r\n\r\n" +
                //удаление скрипта
                ":local arrIdScr [:toarray [/system script job find where script~\"[a-zA-Z0-9]{1,}\"]]\r\n" +
                ":local ScriptName [/system script job get ($arrIdScr->([:len $arrIdScr] - 1)) value-name=script]\r\n" +
                "system script remove $ScriptName", true);
            Thread.Sleep(50);
            //Выполнение скрипта
            mikrotik.Send("/system/script/run");
            mikrotik.Send("=.id=del_firewall", true);
        }


        internal void SendCreateAddressList(int timeout, string host, string name)
        {
            //Создание нового address-list
            mikrotik.Send("/ip/firewall/address-list/add");
            mikrotik.Send("=list=" + name);
            mikrotik.Send("=address=" + host);
            if (timeout > 0)
            {
                mikrotik.Send("=timeout=" + timeout);       //timeout указывается в секундах
            }
            
            mikrotik.Send("=disabled=no", true);
        }

        //Получение списка правил Firewall'а
        internal void SendRequestForGetFirewall()
        {
            mikrotik.Send("/ip/firewall/filter/print");
            mikrotik.Send(".tag=table_firewall", true);
        }

        //Получнение списка-таблицы ARP
        internal void SendRequestForGetARP()
        {
            mikrotik.Send("/ip/arp/print");
            mikrotik.Send(".tag=table_arp", true);
        }


        //Выключение роутера
        internal void Shutdown()
        {
            mikrotik.Send("/system/shutdown", true);
        }

        //Перезагрузка роутера
        internal void Reboot()
        {
            mikrotik.Send("/system/reboot", true);
        }

        //первичное заполнение объектов программы на основании данных с оборудования
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
                    this.SendRequestForGetARP();
                }
                else if (g % 6 == 2)
                {
                    this.SendRequestForGetUser();

                }
                else if (g % 6 == 3)
                {
                    this.SendRequestForGetUserGroup();
                }
                else if (g % 6 == 4)
                {
                    this.SendRequestForGetInterface();
                }
                else if (g % 6 == 5)
                {
                    this.SendRequestForGetService();
                }
                g++;

            }
        }

        internal void SendRequest()
        {
            this.SendRequestForGetARP();
            this.SendRequestForGetAddress();
            this.SendRequestForGetUser();
            this.SendRequestForGetInterface();
            this.SendRequestForGetUserGroup();
            this.SendRequestForGetService();
            this.SendRequestForGetLog();
            this.SendRequestForGetFirewall();

            while (true)
            {
                this.SendResource();
                Thread.Sleep(200);
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

        
        //internal bool stop_send = false;
        internal void ReadAnswer()
        {
            while (true)
            {
                List<string> answer = new List<string>();
                
                foreach (string h in mikrotik.Read())
                {
                    answer.Add(h);
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
                                    //Получение списка групп пользователей
                                    if (this.ARPEnd == true)
                                    {
                                        //очистка текущего листа
                                        ARP.Clear();
                                        this.ARPEnd = false;
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
                                else
                                {
                                    //Вся таблица ARP была заполнена
                                    this.ARPEnd = true;
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
                                        else if (words[j] == "running")
                                        {
                                            temp.connection = words[j + 1];
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
                            else if (words[1] == "table_firewall")
                            {

                                if (words[0] != "!done.tag")
                                {
                                    if (this.FirewallEnd == true)
                                    {
                                        this.Firewalls.Clear();
                                        this.FirewallEnd = false;
                                    }
                                    Firewall temp = new Firewall();
                                    for (int j = 0; j < words.Length; j++)
                                    {
                                        if (words[j] == ".id")
                                        {
                                            temp.id = words[j + 1];     //id
                                        }
                                        else if (words[j] == "chain")
                                        {
                                            temp.chain = words[j + 1];
                                        }    
                                        else if (words[j] == "action")
                                        {
                                            temp.action = words[j + 1];
                                        }
                                        else if (words[j] == "in-interface")
                                        {
                                            temp.in_interface = words[j + 1];
                                        }
                                        else if (words[j] == "disabled")
                                        {
                                            temp.status = words[j + 1];
                                        }
                                        else if (words[j] == "protocol")
                                        {
                                            temp.protocol = words[j + 1];
                                        }
                                        else if (words[j] == "src-address-list")
                                        {
                                            temp.src_address_list = words[j + 1];
                                        }
                                        else if (words[j] == "dst-port")
                                        {
                                            temp.dst_port = words[j + 1];
                                        }
                                        else if (words[j] == "comment")
                                        {
                                            temp.comment = words[j + 1];
                                        }
                                        
                                    }
                                    Firewalls.Add(temp);
                                }
                                else
                                {
                                    this.FirewallEnd = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

