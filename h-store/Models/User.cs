using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace h_store
{
    public partial class User
    {//This class adds the methods to check users against the DB

        private void FillAllDetailsFromGivenUser(User user){
            Id = user.Id;
            email = user.email;
            subscriptions = user.subscriptions;
        }
        public bool CheckIfUserExistsinDB()
        {
            User user = null;
            DBContextHandler dbContextHandler = new DBContextHandler();
            dbContextHandler.CreateDataContext();
            try
            {
                
                using (dbContextHandler.GetDataContext())
                {
                    user = (from userEntry in dbContextHandler.context.Users
                            where userEntry.username == username
                            select userEntry).ToList().FirstOrDefault<User>();
                    
                    

                }
            }
            catch
            {
                throw;
            }
            finally
            {
                dbContextHandler.DisposeContext();
            }
            if (user != null)
            {
                FillAllDetailsFromGivenUser(user);
                return true;
            }
            return false;
        }
        
        /*This method checks if the given user exists in the Database and the given credentials match 
         * with those present in DB
         * If User found with matching details, returns 1
         * If username not found, returns -1;
         * if username found, but password did not match, returns -2;
         */
        public int ValidateUser()
        {
            User user = null;
            DBContextHandler dbContextHandler = new DBContextHandler();
            dbContextHandler.CreateDataContext();
            try
            {

                using (dbContextHandler.GetDataContext())
                {
                    user = (from userEntry in dbContextHandler.context.Users
                            where userEntry.username == username
                            select userEntry).ToList().FirstOrDefault<User>();

                }
            }
            catch
            {
                throw;
            }
            finally
            {
                dbContextHandler.DisposeContext();
            }
            if (user == null)
            {
                return -1;
            }
            else
            {
                if (password != null)
                {
                    if (user.password != null && user.password == password)
                    {
                        FillAllDetailsFromGivenUser(user);

                        return 1;
                    }
                    else return -2;
                }
                else return -2;
            }
           
        }

        public int AddUser()
        {
            if (!CheckIfUserExistsinDB())
            {
                DBContextHandler dbContextHandler = new DBContextHandler();
                dbContextHandler.CreateDataContext();
                try
                {

                    using (dbContextHandler.GetDataContext())
                    {
                        dbContextHandler.context.Entry(this).State = EntityState.Added;
                        dbContextHandler.context.SaveChanges();
                              
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    dbContextHandler.DisposeContext();
                }
                return Id;
            }
            return 0;
        }

        public void DeleteUser()
        {
            if (!CheckIfUserExistsinDB())
            {
                DBContextHandler dbContextHandler = new DBContextHandler();
                dbContextHandler.CreateDataContext();
                try
                {

                    using (dbContextHandler.GetDataContext())
                    {
                        dbContextHandler.context.Entry(this).State = EntityState.Deleted;
                        dbContextHandler.context.SaveChanges();

                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    dbContextHandler.DisposeContext();
                }
                
            }
            
        }
    }
}