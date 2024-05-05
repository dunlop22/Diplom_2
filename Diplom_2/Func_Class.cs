using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;    //для PING
using Renci.SshNet;         //ssh подключение
using MikrotikDotNet;       //API подключение MikroTik
using System.Net;           //работа с портами (проверка открытости)
using System.Net.Sockets;   //работа с портами (проверка открытости)

//using TcpClient;

namespace Diplom_2
{
    class Func_Class
    {
        //проверка открытости порта
        public bool check_port_open(string host, int port)
        {
            try
            {
                using (var tcpClient = new TcpClient())
                {
                    tcpClient.Connect(host, port);
                    return true;
                }
            }
            catch (SocketException)
            {
                return false;
            }
        }

        
        //0 - удачное подключение
        //1 - недоступен host
        //2 - недоступен порт
        //3 - общая ошибка подключения

        //попытка подключения
        public bool test_connect(string IP_ssh_server, int port_ssh_server, string ssh_user, string ssh_password)
        {
            //Проверка открытости порта
            if (!(check_port_open(IP_ssh_server, port_ssh_server)))
            {
                return false;
            }
            else
            {
                using (var conn = new MKConnection(IP_ssh_server, ssh_user, ssh_password))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {

                    }
                    return conn.IsOpen; //статус подключения

                    var cmd = conn.CreateCommand("ip address print");
                    var result = cmd.ExecuteReader();
                    foreach (var line in result)
                    {
                        //Console.WriteLine(line);
                    }
                }
            }


            /*
            //SSH подключение
            PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo(IP_ssh_server, port_ssh_server, ssh_user, ssh_password);
            connectionInfo.Timeout = TimeSpan.FromSeconds(30);      //установка timeout'a для подключения

            using (var client = new SshClient(connectionInfo))
            {
                try          
                {
                    client.Connect();
                    if (client.IsConnected)
                    {
                        client.RunCommand(":log info (\"SSH Connect\");");
                        return true;
                    }
                    else                     //ошибка при подключении
                    {
                        return false;
                    }
                }
                catch
                {
                    ;
                }
            }
            */
        }


        //проверка порта на "реальность"
        public bool check_port(string num_port)
        {
            //num_port - номер порта, указанного в соответствующем элементе формы (по умолчанию - 22)

            //проверка на длину
            if (num_port.Length > 0)
            {
                //проверка на посторонние элементы
                for (int i = 0; i < num_port.Length; i++)
                {
                    if (!(char.IsDigit(num_port[i])))
                    {
                        return false;
                    }
                }

                //проверка на принадлежность к диапазону портов (0-65535)
                if ((Int32.Parse(num_port) > 0) && (Int32.Parse(num_port) < 65536))
                {
                    return true;
                }
                
                return false;
            }
            else
            {
                return false;
            }
            
        }


        //проверка доступности хоста (ping)
        public bool ping_host(string host)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(host);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                //Возможен вывод ошибки или ....
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;

        }

        //первичная (быстрая) проверка введенного хоста
        //true - все элементы соответствуют
        //false - имеются ошибки в воде
        public bool check_valid_host(string host)
        {
            for (int i = 0; i < host.Length; i++)
            {
                if ((host[i] == '.') || ((host[i] >= '0') && (host[i] <= '9')) || (host[i] > 'A' && host[i] < 'z'))
                {
                }
                else
                {
                    return false;
                }
            }
            return true;
        }


        //0 - глобальная проблема
        //1 - ip
        //2 - доменное имя
        public int ip_or_domen(string host)
        {
            //повторная быстрая проверка
            if (check_valid_host(host))
            {
                //IP или доменное имя???
                //проверка на наличие букв в хосте
                for (int i = 0; i < host.Length; i++)
                {
                    if (host[i] > 'A' && host[i] < 'z')
                    {
                        return 2;
                    }
                }


                //проверка октетов в IP адресе
                //проверка на правильность оформления ip адреса
                string ip = host;
                string[] octets = ip.Split(new char[] { '.' });

                if (octets.Length != 4)
                {
                    return 0;
                }

                //проверка октетов (0-255)
                for (int j = 0; j < 4; j++)
                {
                    if ((Int32.Parse(octets[j]) < 0) || (Int32.Parse(octets[j]) > 255))
                    {
                        return 0;
                    }
                }

                //хост представлен в виде ip адреса
                return 1;
            }
            return 0;

            /*
            if (host.Length > 0)
            {
                //является ли хост ip адресом
                for (int i = 0; i < host.Length; i++)
                {
                    if ((System.Text.RegularExpressions.Regex.IsMatch(host, @"[a-z]$")) || 
                        (System.Text.RegularExpressions.Regex.IsMatch(host, "^\\d{1}$")) || 
                        (System.Text.RegularExpressions.Regex.IsMatch(host, @"[\@\.]$")))
                    {
                        if ((System.Text.RegularExpressions.Regex.IsMatch(host, "^\\d{1}$")) ||
                        (System.Text.RegularExpressions.Regex.IsMatch(host, @"[\.]$")))
                        {
                            //проверка на правильность оформления ip адреса
                            string ip = host;
                            string[] octets = ip.Split(new char[] { '.' });

                            if (octets.Length != 4)
                            {
                                return 0;
                            }

                            //проверка октетов (0-255)
                            for (int j = 0; j < 4; j++)
                            {
                                if ((Int32.Parse(octets[j]) < 0) || (Int32.Parse(octets[j]) > 255))
                                {
                                    return 0;
                                }
                            }

                            //хост представлен в виде ip адреса
                            return 1;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 0;
            */
        }
    }
}
