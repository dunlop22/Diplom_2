using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;     //Шифрование данных для записи или чтения из файла

namespace Diplom_2
{
    class Shifr
    {
        //passPhrase: парольная фраза, из которой будет выведен псевдослучайный пароль. Полученный пароль будет использоваться для создания ключа шифрования. Парольная фраза может быть любой строкой.
        //saltValue: значение соли, используемое вместе с парольной фразой для создания пароля. Соль может быть любой строкой.
        //hashAlgorithm: алгоритм хэширования, используемый для генерации пароля. Допустимые значения: «MD5″ и » SHA256”
        //initVector: вектор инициализации(или IV). Значение для шифрования первого блока текстовых данных. Равно 16 символов ASCII длиной.
        //keySize: размер ключа шифрования в битах. Допустимые значения: 128, 192 и 256.

        //Шифровка
        public static string Encrypt
        (
            string plainText,
            string passPhrase,
            string saltValue,
            string hashAlgorithm,
            int passwordIterations,
            string initVector,
            int keySize

        )
        {
            //Строки содержат только коды ASCII
            //Если строки содержат символы Юникода, используйте Юникод, UTF7 или UTF8 кодировки
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            //Преобразование открытого текста в массив байтов
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            //Создание пароля, из которого будет получен ключ
            //Этот пароль будет создан из указанной парольной фразы и соли
            //Пароль будет создан с использованием указанного хэша алгоритма
            //Создание пароля может выполняться в нескольких итерациях.
            PasswordDeriveBytes password = new PasswordDeriveBytes
            (
                passPhrase,
                saltValueBytes,
                hashAlgorithm,
                passwordIterations
            );

            //Использование пароля для создания псевдослучайных байтов для шифрования ключа.
            //Указать размер ключа в байтах (вместо битов).
            byte[] keyBytes = password.GetBytes(keySize / 8);

            //Создание неинициализированного объекта шифрования Rijndael.
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            //Создание шифратора из существующих байтов ключа и инициализации вектор
            //Размер ключа определяется на основе количества байтов ключа.
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor
            (
                keyBytes,
                initVectorBytes
            );

            //Определение потока памяти, который будет использоваться для хранения зашифрованных данных
            MemoryStream memoryStream = new MemoryStream();

            //Определение криптографического потока (принудительное использование режима записи для шифрования).
            CryptoStream cryptoStream = new CryptoStream
            (
                memoryStream,
                encryptor,
                CryptoStreamMode.Write
            );

            //Начните шифровать.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            //Шифровка конца.
            cryptoStream.FlushFinalBlock();

            //Преобразование зашифрованных данных из потока памяти в массив байтов.
            byte[] cipherTextBytes = memoryStream.ToArray();

            //Закрытие обоих потоков
            memoryStream.Close();
            cryptoStream.Close();

            //Преобразование зашифрованных данных в строку в кодировке base64.
            string cipherText = Convert.ToBase64String(cipherTextBytes);

            //Возврат зашифрованной последовательности.
            return cipherText;
        }

        public static string Decrypt
        (
            string cipherText,
            string passPhrase,
            string saltValue,
            string hashAlgorithm,
            int passwordIterations,
            string initVector,
            int keySize
        )
        {
            //Преобразование строк, определяющих характеристики ключа шифрования, в байтовые массивы
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            //Преобразование нашего зашифрованного текста в массив байтов
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            //Создание пароля, из которого будет получен ключ
            //Пароль будет создан из указанной парольной фразы и значения соли
            //Пароль будет создан с использованием указанного алгоритма хэша
            //Создание пароля может выполняться в нескольких итерациях.
            PasswordDeriveBytes password = new PasswordDeriveBytes
            (
                passPhrase,
                saltValueBytes,
                hashAlgorithm,
                passwordIterations
            );

            //Используйте пароль для создания псевдослучайных байтов для шифрования ключа
            //Размер ключа в байтах (вместо битов)
            byte[] keyBytes = password.GetBytes(keySize / 8);

            //Создание неинициализированного объекта шифрования Rijndael.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            //Режим шифрования - "Цепочка блоков шифрования" (CBC)
            //Используйте параметры по умолчанию для других симметричных ключевых параметров.
            symmetricKey.Mode = CipherMode.CBC;

            //Создать дешифратор из существующих байтов ключа и инициализации вектора
            //Размер ключа определяется на основе номера ключа байты
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor
            (
                keyBytes,
                initVectorBytes
            );

            //Определение потока памяти, который будет использоваться для хранения зашифрованных данных
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            //Определение криптографического потока (всегда используется режим чтения для шифрования)
            CryptoStream cryptoStream = new CryptoStream
            (
                memoryStream,
                decryptor,
                CryptoStreamMode.Read
            );
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            //Начните расшифровывать.
            int decryptedByteCount = cryptoStream.Read
            (
                plainTextBytes,
                0,
                plainTextBytes.Length
            );

            //Закрытие обоих потоков.
            memoryStream.Close();
            cryptoStream.Close();

            //Преобразование расшифрованных данных в строку.
            //Исходная строка открытого текста была UTF8-encoded.
            string plainText = Encoding.UTF8.GetString
            (
                plainTextBytes,
                0,
                decryptedByteCount
            );

            //Возврат расшифрованной последовательность
            return plainText;
        }

    }
}
