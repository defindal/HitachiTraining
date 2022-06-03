using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace HitachiTraining
{
    class ExceptionHandling
    {
        private static readonly ILog log =
            LogManager.GetLogger(
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        void methodA()
        {
            // alt 1 : try - catch - finally
            // alt 2 : try - finally
            // alt 3 : try - catch 
            try
            {
                // step 1 
                // step 2 
                // step 3 
            } catch (Exception ex)  // bisa banyak 
            {
                // raise error
            }
            finally
            {
                // pasti dijalankan 
                try
                {

                }
                finally
                {

                }
            }
        }

        public int cicilanPerBulan(int jumlahPinjaman, int durasi)
        {
            try
            {
                if (durasi <= 0) throw new Exception("Durasi harus lebih besar dari 0");
                return jumlahPinjaman / durasi;
            } catch(Exception ex)
            {
                log.Error(ex.Message);
            }
            return -1;   
        }
    }
}
