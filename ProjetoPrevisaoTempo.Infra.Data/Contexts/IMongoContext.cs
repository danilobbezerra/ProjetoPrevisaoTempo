﻿using MongoDB.Driver;

namespace ProjetoPrevisaoTempo.Infra.Data.Contexts
{
    public interface IMongoContext : IDisposable
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
