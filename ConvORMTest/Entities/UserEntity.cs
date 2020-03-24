using ConvORM.Repository;
using ConvORM.Repository.Entities;
using System;

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
            Repository userRepository = new Repository();
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

    }
}
