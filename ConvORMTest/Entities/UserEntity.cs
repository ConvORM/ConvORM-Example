﻿using ConvORM.Connection.Classes;
using ConvORM.Connection.Classes.QueryBuilders;
using ConvORM.Repository;
using ConvORM.Repository.Entities;
using System;
using System.Collections;

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
                if (UserId != 0)
                    return (UserEntity)userRepository.Update(this);
                else
                    return (UserEntity)userRepository.Insert(this);
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        public IList FindAll()
        {
            var userRepository = new Repository();
            try
            {
                return userRepository.FindAll(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public IList Find(QueryConditionsBuilder conditionsBuilder)
        {
            var userRepository = new Repository();
            try
            {
                return userRepository.Find(this, conditionsBuilder);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public UserEntity Find(int id)
        {
            var userRepository = new Repository();
            try
            {
                return (UserEntity)userRepository.Find(this, new int[] {id});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

    }
}
