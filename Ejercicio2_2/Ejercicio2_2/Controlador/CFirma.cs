using Ejercicio2_2.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_2.Controlador
{
    public class CFirma
    {
        readonly SQLiteAsyncConnection _conexion;

        public CFirma(String dbPath)
        {
            _conexion = new SQLiteAsyncConnection(dbPath);
            _conexion.CreateTableAsync<MFirma>().Wait();
        }

        public Task<List<MFirma>> ObtenerDatos()
        {
            return _conexion.Table<MFirma>().ToListAsync();
        }

        public Task<int> GuardarDatos(MFirma datos)
        {
            if (datos.id != 0)
            {
                return _conexion.UpdateAsync(datos);
            }
            else
            {
                return _conexion.InsertAsync(datos);
            }
        }

        public Task<MFirma> ObtenerDatosId(int id)
        {
            return _conexion.Table<MFirma>()
                .Where(i => i.id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> BorrarDatos(MFirma datos)
        {
            return _conexion.DeleteAsync(datos);
        }
    }
}
