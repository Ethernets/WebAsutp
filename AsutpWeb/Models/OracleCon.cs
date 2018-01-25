using System;
using System.Collections.Generic;
using System.Data.OracleClient;

namespace AsutpWeb.Models
{
    public class OracleCon
    {
#pragma warning disable CS0618 // Тип или член устарел
        private readonly OracleConnection _connection = new OracleConnection("Data Source = 192.168.137.70/zxp; " +
                                        "User id = useridb; Password = zxp1234");
#pragma warning restore CS0618 // Тип или член устарел
        public OracleCon()
        {
            try
            {
                _connection.Open();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public List<object> OracleQury(string qury, int lenght)
        {
            var dt = new List<object>();

#pragma warning disable 618
            var cmd = new OracleCommand
            {
                Connection = _connection,
                CommandText = qury
            };
#pragma warning restore 618

            var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var models = new SheetGageModels.SheetGage
                {
                    DateStart = dr.GetDateTime(0),
                   // Shift = dr.GetInt32(1)
                };
                //var test = (dr.GetValue(a));
                //dt = (dr.GetDateTime(a));


                dt.Add(models); 

               
            }

            dr.Close();

            return dt;
        }

        public void OracleCloseCon()
        {
            _connection.Close();
        }
    }
}

/*





            var cmd = new OracleCommand
            {
                Connection = connection,
                CommandText = qury //"Select max(datetime) from test"
            };

#pragma warning restore 618
                
            var dr = cmd.ExecuteReader();

            dr.Read();

            //var dt = Convert.ToDateTime(dr.GetDateTime(0));

           dr.Close();


        }
          catch
              (Exception)
          {
              // ignored
          }
          //return IAsyncResult;
      }
       public List<int> TestList() { return new List<int>(0); }
    }
}
*/