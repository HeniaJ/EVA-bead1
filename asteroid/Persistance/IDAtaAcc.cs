using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteroid.Persistance
{
    internal interface IDAtaAcc
    {
        Task<Table> LoadAsync(String path);
        Task SaveAsync(String path, Table table);
    }
}
