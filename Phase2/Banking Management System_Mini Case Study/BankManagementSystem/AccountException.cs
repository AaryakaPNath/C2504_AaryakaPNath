﻿using System;
using System.Runtime.Serialization;

namespace BankManagementProject
{
    [Serializable]
    internal class AccountException : Exception
    {
        public AccountException()
        {
        }

        public AccountException(string message) : base(message)
        {
        }

        public AccountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}