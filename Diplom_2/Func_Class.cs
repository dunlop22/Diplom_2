using System;
using System.Collections;   //поддержка ArrayList
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;    //для PING
using Renci.SshNet;         //ssh подключение
using MikrotikDotNet;       //API подключение MikroTik
using System.Net;           //работа с портами (проверка открытости)
using System.Net.Security;        //поддержка ssl
using System.Net.Sockets;   //работа с портами (проверка открытости)
using System.IO;            //для Stream (класс MK)
using System.Runtime.InteropServices;       //Вызов консоли
using System.Diagnostics;                   //Вызов консоли
using System.Security.Cryptography.X509Certificates;    //поддержка SSL
//using TcpClient;


//использование
namespace Diplom_2
{
   
    class MK
    {
        Stream connection;
        TcpClient con;

        public MK(string ip, int port)
        {
            con = new TcpClient();
            con.Connect(ip, port);
            connection = (Stream)con.GetStream();
        }
        public void Close()
        {
            connection.Close();
            con.Close();
        }
        public bool Login(string username, string password)
        {
            Send("/login");
            Send("=name=" + username);
            Send("=password=" + password, true);
            if (Read()[0] == "!done")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void Send(string co)
        {
            Send(co, false);
        }
        public void Send(string co, bool endsentence)
        {
            byte[] bajty = Encoding.ASCII.GetBytes(co.ToCharArray());
            byte[] velikost = EncodeLength(bajty.Length);
            try
            {
                connection.Write(velikost, 0, velikost.Length);
                connection.Write(bajty, 0, bajty.Length);
                if (endsentence)
                {
                    connection.WriteByte(0);
                }
                return;
            }
            catch
            {

            }
            this.Close();
            this.Login("test", "test");
            Send(co, endsentence);
        }
        public List<string> Read()
        {
            List<string> output = new List<string>();
            string o = "";
            byte[] tmp = new byte[4];
            long count;
            while (true)
            {
                bool rez = false;
                try
                {
                    tmp[3] = (byte)connection.ReadByte();
                    //if(tmp[3] == 220) tmp[3] = (byte)connection.ReadByte(); it sometimes happend to me that 
                    //mikrotik send 220 as some kind of "bonus" between words, this fixed things, not sure about it though
                    rez = true;
                    if (tmp[3] == 0)
                    {
                        output.Add(o);
                        if (o.Substring(0, 5) == "!done")
                        {
                            break;
                        }
                        else
                        {
                            o = "";
                            continue;
                        }
                    }
                    else
                    {
                        if (tmp[3] < 0x80)
                        {
                            count = tmp[3];
                        }
                        else
                        {
                            if (tmp[3] < 0xC0)
                            {
                                int tmpi = BitConverter.ToInt32(new byte[] { (byte)connection.ReadByte(), tmp[3], 0, 0 }, 0);
                                count = tmpi ^ 0x8000;
                            }
                            else
                            {
                                if (tmp[3] < 0xE0)
                                {
                                    tmp[2] = (byte)connection.ReadByte();
                                    int tmpi = BitConverter.ToInt32(new byte[] { (byte)connection.ReadByte(), tmp[2], tmp[3], 0 }, 0);
                                    count = tmpi ^ 0xC00000;
                                }
                                else
                                {
                                    if (tmp[3] < 0xF0)
                                    {
                                        tmp[2] = (byte)connection.ReadByte();
                                        tmp[1] = (byte)connection.ReadByte();
                                        int tmpi = BitConverter.ToInt32(new byte[] { (byte)connection.ReadByte(), tmp[1], tmp[2], tmp[3] }, 0);
                                        count = tmpi ^ 0xE0000000;
                                    }
                                    else
                                    {
                                        if (tmp[3] == 0xF0)
                                        {
                                            tmp[3] = (byte)connection.ReadByte();
                                            tmp[2] = (byte)connection.ReadByte();
                                            tmp[1] = (byte)connection.ReadByte();
                                            tmp[0] = (byte)connection.ReadByte();
                                            count = BitConverter.ToInt32(tmp, 0);
                                        }
                                        else
                                        {
                                            //Error in packet reception, unknown length
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    for (int i = 0; i < count; i++)
                    {
                        o += (Char)connection.ReadByte();
                    }

                }
                catch { }
                if (rez == false)
                {
                    this.Login("test", "test");
                    this.Read();
                }


            }
            return output;
        }
        byte[] EncodeLength(int delka)
        {
            if (delka < 0x80)
            {
                byte[] tmp = BitConverter.GetBytes(delka);
                return new byte[1] { tmp[0] };
            }
            if (delka < 0x4000)
            {
                byte[] tmp = BitConverter.GetBytes(delka | 0x8000);
                return new byte[2] { tmp[1], tmp[0] };
            }
            if (delka < 0x200000)
            {
                byte[] tmp = BitConverter.GetBytes(delka | 0xC00000);
                return new byte[3] { tmp[2], tmp[1], tmp[0] };
            }
            if (delka < 0x10000000)
            {
                byte[] tmp = BitConverter.GetBytes(delka | 0xE0000000);
                return new byte[4] { tmp[3], tmp[2], tmp[1], tmp[0] };
            }
            else
            {
                byte[] tmp = BitConverter.GetBytes(delka);
                return new byte[5] { 0xF0, tmp[3], tmp[2], tmp[1], tmp[0] };
            }
        }

        public string EncodePassword(string Password, string hash)
        {
            byte[] hash_byte = new byte[hash.Length / 2];
            for (int i = 0; i <= hash.Length - 2; i += 2)
            {
                hash_byte[i / 2] = Byte.Parse(hash.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            }
            byte[] heslo = new byte[1 + Password.Length + hash_byte.Length];
            heslo[0] = 0;
            Encoding.ASCII.GetBytes(Password.ToCharArray()).CopyTo(heslo, 1);
            hash_byte.CopyTo(heslo, 1 + Password.Length);

            Byte[] hotovo;
            System.Security.Cryptography.MD5 md5;

            md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            hotovo = md5.ComputeHash(heslo);

            //Convert encoded bytes back to a 'readable' string
            string navrat = "";
            foreach (byte h in hotovo)
            {
                navrat += h.ToString("x2");
            }
            return navrat;
        }
    }



    //public class MikrotikAPI
    //{
    //    string _IPAddress;
    //    int _APIPort;
    //    bool _UseSSL;
    //    Stream _Stream;
    //    SslStream _SslStream;
    //    TcpClient _TcpClient;

    //    public MikrotikAPI(string IPAddress, bool UseSSL = false, int APIPort = 8728)
    //    {
    //        _IPAddress = IPAddress;
    //        _APIPort = APIPort;
    //        _UseSSL = UseSSL;
    //    }

    //    public static bool ValidateServerCertificate(
    //          object sender,
    //          X509Certificate certificate,
    //          X509Chain chain,
    //          SslPolicyErrors sslPolicyErrors)
    //    {
    //        return true;
    //    }

    //    public void Connect()
    //    {
    //        if (_UseSSL && _APIPort == 8728) _APIPort = 8729;

    //        _TcpClient = new TcpClient();
    //        _TcpClient.Connect(_IPAddress, _APIPort);

    //        if (_UseSSL)
    //        {
    //            _SslStream = new SslStream(_TcpClient.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
    //            //_SslStream = new SslStream(_TcpClient.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
                
    //            _SslStream.AuthenticateAsClient(_IPAddress);
    //        }
    //        else
    //            _Stream = (Stream)_TcpClient.GetStream();
    //    }
    //    public void Disconnect()
    //    {
    //        if (_UseSSL)
    //            _Stream.Close();
    //        else
    //            _SslStream.Close();

    //        _TcpClient.Close();
    //    }

    //    public bool LoginDeprecated(string Username, string Password)
    //    {
    //        Send("/login", true);
    //        string hash = Receive()[0].Split(new string[] { "ret=" }, StringSplitOptions.None)[1];
    //        Send("/login");
    //        Send("=name=" + Username);
    //        Send("=response=00" + EncodePassword(Password, hash), true);
    //        List<string> ReceiveResult = Receive();
    //        if (ReceiveResult[0] == "!done")
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }

    //    public bool Login(string Username, string Password, out string OutMessageDesc)
    //    {
    //        OutMessageDesc = "";

    //        Send("/login");
    //        Send("=name=" + Username);
    //        Send("=password=" + Password, true);
    //        List<string> ReceiveResult = Receive();
    //        if (ReceiveResult[0] == "!done")
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            OutMessageDesc = ReceiveResult[1];
    //            return false;
    //        }
    //    }

    //    public void Send(string DataToSend, bool EndofPacket = false)
    //    {
    //        if (_UseSSL)
    //            DoSendSSL(DataToSend, EndofPacket);
    //        else
    //            DoSend(DataToSend, EndofPacket);
    //    }

    //    private void DoSend(string DataToSend, bool EndofPacket = false)
    //    {
    //        byte[] DataToSendasByte = Encoding.ASCII.GetBytes(DataToSend.ToCharArray());
    //        byte[] SendSize = EncodeLength(DataToSendasByte.Length);
    //        _Stream.Write(SendSize, 0, SendSize.Length);
    //        _Stream.Write(DataToSendasByte, 0, DataToSendasByte.Length);
    //        if (EndofPacket) _Stream.WriteByte(0);
    //    }

    //    private void DoSendSSL(string DataToSend, bool EndofPacket = false)
    //    {
    //        byte[] DataToSendasByte = Encoding.ASCII.GetBytes(DataToSend.ToCharArray());
    //        byte[] SendSize = EncodeLength(DataToSendasByte.Length);
    //        _SslStream.Write(SendSize, 0, SendSize.Length);
    //        _SslStream.Write(DataToSendasByte, 0, DataToSendasByte.Length);
    //        if (EndofPacket) _SslStream.WriteByte(0);
    //    }

    //    public ArrayList ReceiveList()
    //    {
    //        List<string> ReceivedDataList;

    //        if (_UseSSL)
    //            ReceivedDataList = DoReceiveSSL();
    //        else
    //            ReceivedDataList = DoReceive();

    //        ArrayList DataList = new ArrayList();
    //        List<string> ReceivedData = new List<string>();
    //        foreach (string DataLine in ReceivedDataList)
    //        {
    //            if (DataLine == "!re" || DataLine == "!done" || DataLine == "!trap")
    //            {
    //                DataList.Add(ReceivedData);
    //                ReceivedData = new List<string>();
    //            }
    //            else
    //                ReceivedData.Add(DataLine);
    //        }
    //        if (DataList.Count > 1) DataList.RemoveAt(0);

    //        return DataList;
    //    }


    //    public List<string> Receive()
    //    {
    //        if (_UseSSL)
    //            return DoReceiveSSL();
    //        else
    //            return DoReceive();
    //    }

    //    private List<string> DoReceive()
    //    {
    //        List<string> OutputList = new List<string>();
    //        long TempReceiveSize;
    //        string TempString = "";
    //        long ReceiveSize = 0;
    //        while (true)
    //        {
    //            TempReceiveSize = (byte)_Stream.ReadByte();
    //            if (TempReceiveSize > 0)
    //            {
    //                if ((TempReceiveSize & 0x80) == 0)
    //                {
    //                    ReceiveSize = TempReceiveSize;
    //                }
    //                else if ((TempReceiveSize & 0xC0) == 0x80)
    //                {
    //                    TempReceiveSize &= ~0xC0;
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_Stream.ReadByte();
    //                    ReceiveSize = TempReceiveSize;
    //                }
    //                else if ((TempReceiveSize & 0xE0) == 0xC0)
    //                {
    //                    TempReceiveSize &= ~0xE0;
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_Stream.ReadByte();
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_Stream.ReadByte();
    //                    ReceiveSize = TempReceiveSize;
    //                }
    //                else if ((TempReceiveSize & 0xF0) == 0xE0)
    //                {
    //                    TempReceiveSize &= ~0xF0;
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_Stream.ReadByte();
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_Stream.ReadByte();
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_Stream.ReadByte();
    //                    ReceiveSize = TempReceiveSize;
    //                }
    //                else if ((TempReceiveSize & 0xF8) == 0xF0)
    //                {
    //                    TempReceiveSize += (byte)_Stream.ReadByte();
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_Stream.ReadByte();
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_Stream.ReadByte();
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_Stream.ReadByte();
    //                    ReceiveSize = TempReceiveSize;
    //                }
    //            }
    //            else
    //                ReceiveSize = TempReceiveSize;

    //            for (int i = 0; i < ReceiveSize; i++)
    //            {
    //                Char TempChar = (Char)_Stream.ReadByte();
    //                TempString += TempChar;
    //            }

    //            if (ReceiveSize > 0)
    //            {
    //                OutputList.Add(TempString);
    //                if (TempString == "!done") break;
    //                TempString = "";
    //            }
    //        }
    //        return OutputList;
    //    }

    //    private List<string> DoReceiveSSL()
    //    {
    //        List<string> OutputList = new List<string>();
    //        long TempReceiveSize;
    //        string TempString = "";
    //        long ReceiveSize = 0;
    //        while (true)
    //        {
    //            TempReceiveSize = (byte)_SslStream.ReadByte();
    //            if (TempReceiveSize > 0)
    //            {
    //                if ((TempReceiveSize & 0x80) == 0)
    //                {
    //                    ReceiveSize = TempReceiveSize;
    //                }
    //                else if ((TempReceiveSize & 0xC0) == 0x80)
    //                {
    //                    TempReceiveSize &= ~0xC0;
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_SslStream.ReadByte();
    //                    ReceiveSize = TempReceiveSize;
    //                }
    //                else if ((TempReceiveSize & 0xE0) == 0xC0)
    //                {
    //                    TempReceiveSize &= ~0xE0;
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_SslStream.ReadByte();
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_SslStream.ReadByte();
    //                    ReceiveSize = TempReceiveSize;
    //                }
    //                else if ((TempReceiveSize & 0xF0) == 0xE0)
    //                {
    //                    TempReceiveSize &= ~0xF0;
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_SslStream.ReadByte();
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_SslStream.ReadByte();
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_SslStream.ReadByte();
    //                    ReceiveSize = TempReceiveSize;
    //                }
    //                else if ((TempReceiveSize & 0xF8) == 0xF0)
    //                {
    //                    TempReceiveSize += (byte)_SslStream.ReadByte();
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_SslStream.ReadByte();
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_SslStream.ReadByte();
    //                    TempReceiveSize <<= 8;
    //                    TempReceiveSize += (byte)_SslStream.ReadByte();
    //                    ReceiveSize = TempReceiveSize;
    //                }
    //            }
    //            else
    //                ReceiveSize = TempReceiveSize;

    //            for (int i = 0; i < ReceiveSize; i++)
    //            {
    //                Char TempChar = (Char)_SslStream.ReadByte();
    //                TempString += TempChar;
    //            }

    //            if (ReceiveSize > 0)
    //            {
    //                OutputList.Add(TempString);
    //                if (TempString == "!done") break;
    //                TempString = "";
    //            }
    //        }
    //        return OutputList;
    //    }

    //    private byte[] EncodeLength(int delka)
    //    {
    //        if (delka < 0x80)
    //        {
    //            byte[] tmp = BitConverter.GetBytes(delka);
    //            return new byte[1] { tmp[0] };
    //        }
    //        if (delka < 0x4000)
    //        {
    //            byte[] tmp = BitConverter.GetBytes(delka | 0x8000);
    //            return new byte[2] { tmp[1], tmp[0] };
    //        }
    //        if (delka < 0x200000)
    //        {
    //            byte[] tmp = BitConverter.GetBytes(delka | 0xC00000);
    //            return new byte[3] { tmp[2], tmp[1], tmp[0] };
    //        }
    //        if (delka < 0x10000000)
    //        {
    //            byte[] tmp = BitConverter.GetBytes(delka | 0xE0000000);
    //            return new byte[4] { tmp[3], tmp[2], tmp[1], tmp[0] };
    //        }
    //        else
    //        {
    //            byte[] tmp = BitConverter.GetBytes(delka);
    //            return new byte[5] { 0xF0, tmp[3], tmp[2], tmp[1], tmp[0] };
    //        }
    //    }

    //    private string EncodePassword(string Password, string hash)
    //    {
    //        byte[] hash_byte = new byte[hash.Length / 2];
    //        for (int i = 0; i <= hash.Length - 2; i += 2)
    //        {
    //            hash_byte[i / 2] = Byte.Parse(hash.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
    //        }
    //        byte[] heslo = new byte[1 + Password.Length + hash_byte.Length];
    //        heslo[0] = 0;
    //        Encoding.ASCII.GetBytes(Password.ToCharArray()).CopyTo(heslo, 1);
    //        hash_byte.CopyTo(heslo, 1 + Password.Length);

    //        Byte[] hotovo;
    //        System.Security.Cryptography.MD5 md5;

    //        md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

    //        hotovo = md5.ComputeHash(heslo);

    //        //Convert encoded bytes back to a 'readable' string
    //        string navrat = "";
    //        foreach (byte h in hotovo)
    //        {
    //            navrat += h.ToString("x2");
    //        }
    //        return navrat;
    //    }

    //}

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
                ;
            }
            return false;
        }

        /*
        //НЕ ИСПОЛЬЗУЕТСЯ
        public void ConnectOfficial()
        {
            //Создание консоли для вывода принятой информации от оборудования
            Process cmd = new Process();
            cmd.StartInfo = new ProcessStartInfo(@"cmd.exe");
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            
            MK mikrotik = new MK("109.195.38.77", 8728);
            if (mikrotik.Login("test", "test"))
            {
                mikrotik.Send("/ip/firewall/address-list/print");
                mikrotik.Send("?list=listName", true);

                foreach (string h in mikrotik.Read())
                {
                    cmd.StandardInput.WriteLine(h);
                }
            }
        }
        */
        /*
        //НЕ ИСПОЛЬЗУЕТСЯ
        //Просмотр нагрузки на процессор
        public bool CPULoad(string host, int port, string login, string password, string [, ] resource)
        {
            MK mikrotik = new MK(host, port);
            if (mikrotik.Login(login, password))
            {
                //mikrotik.Send("/ip/arp/print", true);
                mikrotik.Send("/system/resource/print");
                mikrotik.Send(".tag=res", true);

                //mikrotik.Send("?list=wifi", true);

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
                    return true;
                }
                Console.WriteLine(resource[4, 1]);
               
            }
            //подключение неудалось
            return false;

        }
        */



        //проверка порта на "реальность"
        public bool CheckPortFormat(string num_port)
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
                if ((host[i] == '.') || (host[i] == ':') || ((host[i] >= '0') && (host[i] <= '9')) || (host[i] >= 'A' && host[i] <= 'Z') || (host[i] >= 'a' && host[i] <= 'z'))
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
                    if ((host[i] >= 'A' && host[i] <= 'z') || host[i] == ':')
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
        }
    }
}
