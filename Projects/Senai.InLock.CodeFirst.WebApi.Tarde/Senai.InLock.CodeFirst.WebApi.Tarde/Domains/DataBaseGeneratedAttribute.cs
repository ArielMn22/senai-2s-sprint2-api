using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.InLock.CodeFirst.WebApi.Tarde.Domains
{
    internal class DataBaseGeneratedAttribute : Attribute
    {
        private DatabaseGeneratedOption identity;

        public DataBaseGeneratedAttribute(DatabaseGeneratedOption identity)
        {
            this.identity = identity;
        }
    }
}