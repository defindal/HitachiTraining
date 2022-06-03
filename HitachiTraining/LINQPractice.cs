using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace HitachiTraining
{
    class LINQPractice
    {
        private static String connectionString =
            "server=localhost;user id=root;persistsecurityinfo=True;database=sakila";
        static int parse(String x)
        {
            return Int32.Parse(x);
        }

        public static void fromCollection(ICollection myCollection)
        {
            //var result = from item in myCollection.AsQueryable()
            // select item;

            int[] idx = new int[] { 4, 8, 9, 20, 27 };
            List<int> idy = new List<int>() { 3, 9, 17, 21, 80, 65, 44, 0 };

            var idzString = File.ReadAllLines("idz.txt");
            var idz = new List<int>();

            idzString.ToList().ForEach(x =>
            {
                idz.Add(Int32.Parse(x));
            });

            foreach (var x in idzString)
            {
                idz.Add(parse(x));
            }

            var odd = from i in idz
                      where i % 2 == 1
                      select i;

            // Console.WriteLine(odd.ToArray());

            odd.ToList().ForEach(i => Console.WriteLine(i));

        }

        public static void fromRDBMS()
        {
            var query = "SELECT* FROM actor;";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                //var command = new MySqlCommand(query, conn);
                //var queryResult = command.ExecuteReader();

                //while (queryResult.Read())
                //{
                //    Console.Write(queryResult.GetString(1));
                //    Console.Write(" - ");
                //    Console.WriteLine(queryResult.GetString(2));
                //}

                using (var adapter = new MySqlDataAdapter(query, conn))
                {
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    var result = from actor in dataSet.Tables[0].AsEnumerable()
                                 where actor.Field<String>("first_name").
                                        StartsWith("a", true, null)
                                 select new
                                 {
                                     FirstName = actor.Field<String>("first_name"),
                                     LastName = actor.Field<String>("last_name")
                                 };

                    result.ToList().ForEach(
                        actor =>
                        {
                            Console.Write(actor.FirstName);
                            Console.Write(" - ");
                            Console.WriteLine(actor.LastName);
                        });
                }
            }
        }

        public static void fromJSON()
        {
            var url = "https://data.bmkg.go.id/DataMKG/TEWS/gempadirasakan.json";

            using (var client = new WebClient())
            {
                // var myJSONString = @"{'Infogempa':{'gempa':[{'Tanggal':'03 Jun 2022','Jam':'03:19:10 WIB','DateTime':'2022-06-02T20:19:10+00:00','Coordinates':'-3.43,128.83','Lintang':'3.43 LS','Bujur':'128.83 BT','Magnitude':'3.9','Kedalaman':'10 km','Wilayah':'Pusat gempa berada di laut 15 km baratdaya Masohi','Dirasakan':'II-III Amahai, II-III Saparua'},{'Tanggal':'03 Jun 2022','Jam':'02:19:55 WIB','DateTime':'2022-06-02T19:19:55+00:00','Coordinates':'-0.62,124.42','Lintang':'0.62 LS','Bujur':'124.42 BT','Magnitude':'5.0','Kedalaman':'10 km','Wilayah':'Pusat gempa berada di laut 120 km tenggara Bolaanguki-Bolaang Mongondow Selatan','Dirasakan':'III Kotamobagu'},{'Tanggal':'03 Jun 2022','Jam':'00:31:27 WIB','DateTime':'2022-06-02T17:31:27+00:00','Coordinates':'-2.12,120.55','Lintang':'2.12 LS','Bujur':'120.55 BT','Magnitude':'4.8','Kedalaman':'10 km','Wilayah':'Pusat gempa berada di darat 66 km TimurLaut LUWU UTARA','Dirasakan':'IV Masamba, III Luwu Timur, II Palopo'},{'Tanggal':'02 Jun 2022','Jam':'15:02:55 WIB','DateTime':'2022-06-02T08:02:55+00:00','Coordinates':'-8.31,120.58','Lintang':'8.31 LS','Bujur':'120.58 BT','Magnitude':'3.6','Kedalaman':'11 km','Wilayah':'Pusat gempa berada di darat 35 km timur laut Ruteng','Dirasakan':'III Manggarai Timur, II-III Ruteng'},{'Tanggal':'02 Jun 2022','Jam':'14:04:47 WIB','DateTime':'2022-06-02T07:04:47+00:00','Coordinates':'-8.62,120.44','Lintang':'8.62 LS','Bujur':'120.44 BT','Magnitude':'2.7','Kedalaman':'10 km','Wilayah':'Pusat gempa berada di darat 2 km BaratDaya RUTENG-MANGGARAI','Dirasakan':'II - III Ruteng'},{'Tanggal':'02 Jun 2022','Jam':'07:26:40 WIB','DateTime':'2022-06-02T00:26:40+00:00','Coordinates':'1.66,99.18','Lintang':'1.66 LU','Bujur':'99.18 BT','Magnitude':'4.2','Kedalaman':'2 km','Wilayah':'Pusat gempa berada di darat 12 km BaratLaut Tapanuli Selatan','Dirasakan':'III Pinangsori, III Sibolga'},{'Tanggal':'02 Jun 2022','Jam':'05:55:45 WIB','DateTime':'2022-06-01T22:55:45+00:00','Coordinates':'-1.11,127.18','Lintang':'1.11 LS','Bujur':'127.18 BT','Magnitude':'5.0','Kedalaman':'10 km','Wilayah':'Pusat gempa berada di laut 62 km BaratDaya Labuha','Dirasakan':'II Obi, II Labuha'},{'Tanggal':'31 Mei 2022','Jam':'14:10:06 WIB','DateTime':'2022-05-31T07:10:06+00:00','Coordinates':'-6.18,104.11','Lintang':'6.18 LS','Bujur':'104.11 BT','Magnitude':'5.4','Kedalaman':'10 km','Wilayah':'Pusat gempa berada di laut 100 km barat daya Tanggamus','Dirasakan':'II Kota Bengkulu, II Kepahiang, II Kota Agung, II Pesawaran, II - III Tanggamus, III-IV Lampung Barat, III Liwa, III Lemong, II Pringsewu, II OKU Selatan'},{'Tanggal':'31 Mei 2022','Jam':'08:10:26 WIB','DateTime':'2022-05-31T01:10:26+00:00','Coordinates':'3.86,97.33','Lintang':'3.86 LU','Bujur':'97.33 BT','Magnitude':'4.1','Kedalaman':'5 km','Wilayah':'Pusat gempa berada di darat 15 km baratdaya Gayo Lues','Dirasakan':'III Gayo Lues'},{'Tanggal':'30 Mei 2022','Jam':'13:42:40 WIB','DateTime':'2022-05-30T06:42:40+00:00','Coordinates':'-1.75,100.29','Lintang':'1.75 LS','Bujur':'100.29 BT','Magnitude':'4.1','Kedalaman':'23 km','Wilayah':'Pusat gempa berada di laut 55 km BaratDaya Painan-Pesisir Selatan','Dirasakan':'I - II Painan, I - II Padang'},{'Tanggal':'27 Mei 2022','Jam':'09:36:06 WIB','DateTime':'2022-05-27T02:36:06+00:00','Coordinates':'-8.64,127.20','Lintang':'8.64 LS','Bujur':'127.20 BT','Magnitude':'6.5','Kedalaman':'104 km','Wilayah':'Pusat gempa berada di laut 85 km BaratDaya Maluku Barat Daya','Dirasakan':'III-IV Alor, II Kupang, IV-V Timor Leste, IV Tiakur, IV Kisar, III Damer'},{'Tanggal':'27 Mei 2022','Jam':'07:38:50 WIB','DateTime':'2022-05-27T00:38:50+00:00','Coordinates':'-8.16,107.92','Lintang':'8.16 LS','Bujur':'107.92 BT','Magnitude':'4.0','Kedalaman':'25 km','Wilayah':'Pusat gempa berada di laut 81 km BaratDaya Pangandaran','Dirasakan':'III Cipatujah, III Pangandaran, III Ciamis, III Karangnunggal, III Cikalong, II Singajaya, II cikajang'},{'Tanggal':'26 Mei 2022','Jam':'23:55:12 WIB','DateTime':'2022-05-26T16:55:12+00:00','Coordinates':'-0.91,119.94','Lintang':'0.91 LS','Bujur':'119.94 BT','Magnitude':'3.0','Kedalaman':'7 km','Wilayah':'Pusat gempa berada di darat 8 km Timur Palu','Dirasakan':'II - III Palu, II - III Sigi'},{'Tanggal':'26 Mei 2022','Jam':'20:53:21 WIB','DateTime':'2022-05-26T13:53:21+00:00','Coordinates':'4.85,96.06','Lintang':'4.85 LU','Bujur':'96.06 BT','Magnitude':'3.7','Kedalaman':'4 km','Wilayah':'Pusat gempa berada di darat 29 km barat daya Kab. Pidie Jaya','Dirasakan':'III Mane Pidie, II Tangse Pidie'},{'Tanggal':'26 Mei 2022','Jam':'03:24:45 WIB','DateTime':'2022-05-25T20:24:45+00:00','Coordinates':'5.89,95.19','Lintang':'5.89 LU','Bujur':'95.19 BT','Magnitude':'3.1','Kedalaman':'2 km','Wilayah':'Pusat gempa berada di laut 14 km BaratDaya Kota Sabang','Dirasakan':'I-II Kota Sabang'}]}}";
                var response = client.DownloadString(url);
                JObject myJSON = JObject.Parse(response);

                var result = from gempa in myJSON["Infogempa"]["gempa"]
                             where gempa["Lintang"].ToString().Contains("LU")
                             orderby gempa["Tanggal"]
                             select gempa;

                result.ToList().ForEach(
                            gempa =>
                            {
                                Console.Write(gempa["Tanggal"]);
                                Console.Write(" - ");
                                Console.WriteLine(gempa["Lintang"]);
                            });

            }
        }
    }
}
