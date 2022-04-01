﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface IHttpClientService
    {
        Token Token_held { get;  }
        string UserToken { get; set; }
        AUTHSTATUS UserStatus { get; set; } 
        Task<List<T>> getCollection<T>(string EndPoint);

        Task<T> getSingle<T>(string EndPoint, int Id);
        void Post<T>(string EndPoint, T p);
        void Put<T>(string EndPoint, T p);
        Task<bool> login(string username, string password);
    }
}
