using System;
using PalsPolls.Tables;
using SQLite;
using PalsPolls.Views;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PalsPolls.Services
{
    public class PollServices
    {
        private readonly SQLiteAsyncConnection db1;

        public PollServices(string dbPath)
        {
            db1 = new SQLiteAsyncConnection(dbPath);
            db1.CreateTableAsync<PollTable>();
        }

        public Task CreatePoll(PollTable m_poll)
        {
            return db1.InsertAsync(m_poll);
        }

        public Task<List<PollTable>> ReadPosts()
        {
            return db1.Table<PollTable>().ToListAsync();
        }

        public Task DeletePost(PollTable m_Table)
        {
            return db1.DeleteAsync(m_Table);
        }
    }
}

