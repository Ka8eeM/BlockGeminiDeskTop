using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestDataAccessLayer.Models;
using System.Data.Entity;

namespace TestBusinessLayer.ViewModels
{
    public class UserViewModel : IDisposable
    {

        private BlockGeminiTestEntities dbContext;

        public UserViewModel() => dbContext = new BlockGeminiTestEntities();

        public BindingSource UserBindingSource { get; set; }

        public void Load()
        {
            dbContext.Users.Load();
            UserBindingSource.DataSource = dbContext.Users;
        }


        public async Task<bool> login(string userName, string password)
        {
            var ret = (await dbContext.Users.Where(user => user.UserName.Equals(userName) && user.Password.Equals(password)).FirstOrDefaultAsync())?.UserName;

            if (string.IsNullOrEmpty(ret)) // meas no such user
                return false;
            return true; // user exists
        }

        public void Dispose()
        {

            dbContext.Dispose();
        }
    }
}
