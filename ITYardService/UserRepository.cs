using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITYardService
{
    public class UserRepository
    {

        public static Dictionary<Guid, user> _users = new Dictionary<Guid, user>();

        public user[] All()
        {
            return _users.Values.ToArray();
        }

        public void Insert(user user)
        {
            _users.Add(user._id, user);
        }

        public user GetById(Guid id)
        {
            return _users[id];
        }

        public void Update(Guid id, string username, string password) 
        {
            _users[id]._username = username;
            _users[id]._password = password;
        }

        public void Delete(Guid id)
        {
            _users.Remove(id);
        }

        public void DisplayUserInfo(Guid id)
        {
            Console.WriteLine($"\nUsername: {_users[id]._username}\nPassword: {Decrypt( _users[id]._username, Encrypt(id) )}");
        }

        public char[] RealKey(string username, string password)
        {

            int passwordLength = password.Length;
            int KeyIterator = 0;
            char[] RealKey = new char[passwordLength];


            for (int i = 0; i < passwordLength; i++)
            {
                RealKey[i] = username[KeyIterator];
                KeyIterator++;
                KeyIterator %= username.Length - 1;
            }
            return RealKey;
        }


        public string Encrypt(Guid id)
        {
            string username = _users[id]._username;
            string password = _users[id]._password;

            int passwordLength = password.Length;

            char[] EncryptText = new char[passwordLength];
            char[] realKey = RealKey(username, password);

            for (int i = 0; i < passwordLength; i++)
            {
                EncryptText[i] = (char)( ((int)password[i] * (int)realKey[i]) %  128  );

            }

            return new string(EncryptText);

        }


        public string Decrypt(string username, string passwordEncrypt)
        {
            int passwordLength = passwordEncrypt.Length;

            char[] DecryptText = new char[passwordLength];
            char[] realKey = RealKey(username, passwordEncrypt);

            for (int i = 0; i < passwordLength; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    if (passwordEncrypt[i] == (j* realKey[i])%128)
                    {
                        DecryptText[i] = (char)j;
                        //break;
                    }
                }
            }

            return new string(DecryptText);
        }
    }
}
