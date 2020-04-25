using ConvORM.Repository;
using ConvORM.Repository.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConvORMTest.Entities
{
    [EntitiesAttributes(TableName = "User")]
    public class UserEntity : Entity
    {
        [EntitiesColumnAttributes(
            Primary = true,
            Default = "0"
        )]
        public int UserId;

        public string Name;

        public string Login;

        public string Password;

        [EntitiesColumnAttributes(Default = "true")]
        public bool Active;

        public UserEntity Save()
        {
            var userRepository = new Repository();
            try
            {
                return (UserEntity)userRepository.Insert(this);
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        public IList GetAll()
        {
            var userRepository = new Repository();
            try
            {
                return userRepository.GetAll(this);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

    }
}
