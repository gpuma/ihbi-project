using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ihbiproject.Models;

namespace ihbiproject.Data
{
    public static class db
    {
        //static constructors are executed the first time a static class field is accessed
        static db()
        {
            //todo: implement actual data
            InsertDummyData();
        }
        static List<IHBIUser> users;
        public static void InsertDummyData()
        {
            users = new List<IHBIUser>(new IHBIUser[]
            {
                new IHBIUser() { Username = "johndoe", Email = "johndoe@gmail.com", Password = "johndoe" },
                new IHBIUser() { Username = "mary", Email = "mary@gmail.com", Password = "mary" },
                new IHBIUser() { Username = "amy", Email = "amy@gmail.com", Password = "amy" },
            });
        }
        public static IHBIUser GetUser(string username, string password)
        {
            //should only have one value and default is null for any reference type
            var user = users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            return user;
        }
    }
}
