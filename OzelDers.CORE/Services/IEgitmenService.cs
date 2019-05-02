using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.DAL;
using OzelDers.ENT;
using static OzelDers.ENT.Entities;

namespace OzelDers.CORE.Services
{
    public interface IEgitmenService
    {
        Egitmen Authenticate(string username, string password);
        IEnumerable<Egitmen> GetAll();
        Egitmen GetById(int id);
        Egitmen Create(Egitmen egitmen, string password);
        void Update(Egitmen egitmen, string password = null);
        void Delete(int id);
    }
    public class EgitmenService : IEgitmenService
    {
        private OzelDersContext _context;
        public EgitmenService(OzelDersContext _db)
        {
            _context = _db;
        }
        public Egitmen Authenticate(string eMail, string password)
        {
            if (string.IsNullOrEmpty(eMail) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Egitmen.SingleOrDefault(x => x.eMail == eMail);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public Egitmen Create(Egitmen egitmen, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Egitmen> GetAll()
        {
            return _context.Egitmen;

        }

      

        public void Update(Egitmen egitmen, string password = null)
        {
            throw new NotImplementedException();
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public Egitmen GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
