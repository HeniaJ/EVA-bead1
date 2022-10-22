using asteroid.Persistance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace asteroid.Persistance
{
    internal class FileDataAcces : IDAtaAcc
    {
        public async Task<Table> LoadAsync(String path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path)) // fájl megnyitása
                {
                    Table table = new Table(); // létrehozzuk a táblát

                   
                    return table;
                }
            }
            catch
            {
                throw new DataException();
            }
        }

        /// <summary>
        /// Fájl mentése.
        /// </summary>
        /// <param name="path">Elérési útvonal.</param>
        /// <param name="table">A fájlba kiírandó játéktábla.</param>
        public async Task SaveAsync(String path, Table table)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path)) // fájl megnyitása
                {
                   // await writer.WriteLineAsync(" " + table.RegionSize);
                    //rocket.Left rocker.Top
                    //meteor
                }
            }
            catch
            {
                throw new DataException();
            }
        }
    }
}
