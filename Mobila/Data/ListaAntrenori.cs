using Mobila.Models;
using SQLite;
using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mobila.Data
{
    public class ListaAntrenori
    {
        readonly SQLiteAsyncConnection _database;

        public ListaAntrenori(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Antrenor>().Wait();
            _database.CreateTableAsync<Client>().Wait();
            _database.CreateTableAsync<ListaClient>().Wait();
        }
        public Task<int> SaveClientAsync(Client client)
        {
            if (client.ID != 0)
            {
                return _database.UpdateAsync(client);
            }
            else
            {
                return _database.InsertAsync(client);
            }
        }
        public Task<int> DeleteClientAsync(Client client)
        {
            return _database.DeleteAsync(client);
        }

        public Task<List<Client>> GetClientsAsync()
        {
            return _database.Table<Client>().ToListAsync();

        }

        public Task<List<Antrenor>> GetAntrenorsAsync()
        {
            return _database.Table<Antrenor>().ToListAsync();
        }
        public Task<Antrenor> GetAntrenorAsync(int id)
        {
            return _database.Table<Antrenor>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }

        public Task<int> SaveAntrenorAsync(Antrenor slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteAntrenorAsync(Antrenor slist)
        {
            return _database.DeleteAsync(slist);
        }
        public Task<int> SaveListaClientAsync(ListaClient listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Client>> GetListaClientiAsync(int antrenorid)
        {
            return _database.QueryAsync<Client>(
            "select P.ID, P.Nume from Client P"
            + " inner join ListaClient LP"
            + " on P.ID = LP.ClientID where LP.AntrenorID = ?",
            antrenorid);

        }
    }
}