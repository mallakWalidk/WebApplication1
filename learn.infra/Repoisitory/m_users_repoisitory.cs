using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using lear.core.data;
using lear.core.domain;
using lear.core.DTO;
using lear.core.Repoisitory;
using Nancy.Json;

namespace learn.infra.Repoisitory
{
    public class m_users_repoisitory : Im_users_repoisitory
    {

        private readonly IDBContext dbContext;
        public m_users_repoisitory(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ResultViewModel weather(int id)
        {
            string apik = "2960b0e6e66bfea8c1b79602a9ff5488";
            var user = getbyid(id);
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", user.address, apik);
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                RootObject weatherInfo = (new JavaScriptSerializer()).Deserialize<RootObject>(json);
                ResultViewModel rslt = new ResultViewModel();
                rslt.Country = weatherInfo.sys.country;
                rslt.City = weatherInfo.name;
                rslt.Lat = Convert.ToString(weatherInfo.coord.lat);
                rslt.Lon = Convert.ToString(weatherInfo.coord.lon);
                rslt.Description = weatherInfo.weather[0].description;
                rslt.Humidity = Convert.ToString(weatherInfo.main.humidity);
                rslt.Temp = Convert.ToString(weatherInfo.main.temp);
                rslt.TempFeelsLike = Convert.ToString(weatherInfo.main.feels_like);
                rslt.TempMax = Convert.ToString(weatherInfo.main.temp_max);
                rslt.TempMin = Convert.ToString(weatherInfo.main.temp_min);
                return rslt;


            }
        }

        public ResultViewModel weatherbycity(string city)
        {
            string apik = "2960b0e6e66bfea8c1b79602a9ff5488";
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", city, apik);
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                RootObject weatherInfo = (new JavaScriptSerializer()).Deserialize<RootObject>(json);
                ResultViewModel rslt = new ResultViewModel();
                rslt.Country = weatherInfo.sys.country;
                rslt.City = weatherInfo.name;
                rslt.Temp = Convert.ToString(weatherInfo.main.temp);
                rslt.TempMax = Convert.ToString(weatherInfo.main.temp_max);
                rslt.TempMin = Convert.ToString(weatherInfo.main.temp_min);
                return rslt;


            }
        }

        public List<ResultViewModel> weather()
        {
            List <ResultViewModel> result = new List<ResultViewModel>();
            string[] cities = { "Amman", "Ajloun", "Irbid", "Zarqa", "Jerash", "Balqa", "Mafraq", "Madaba", "Karak", "Tafilah", "Ma'an", "Aqaba" };
            foreach(var city in cities)
            {
                var w = weatherbycity(city);
                result.Add(new ResultViewModel { Country=w.Country,City=w.City,Temp=w.Temp,TempMax=w.TempMax,TempMin=w.TempMin});
            }
            return result;
        }

            public bool insert5record(List<m_users> users)
        {
            foreach (var user in users)
            {
                insertone(user);
            }
            return true;
        }

        public bool backup(int id)
        {
            
            var user = getbyid(id);
            if (user != null) { 
            FileStream f = new FileStream("C:\\Users\\Malla\\OneDrive\\Desktop\\backup.txt", FileMode.Create);
            StreamWriter s = new StreamWriter(f);

            s.WriteLine("firstname: "+user.firstname);
            s.WriteLine("secondname: " + user.secondname);
            s.WriteLine("email: " + user.email);
            s.WriteLine("address: " + user.address);


            s.Close();
            f.Close();
                return true;

            }
            return false;
        }

        public bool insertusers(string filename)
        {
            var fileStream = new FileStream(@"C:\Users\Malla\OneDrive\Desktop\"+ filename+ ".txt", FileMode.Open, FileAccess.Read);
            string ts = "mm";
            var emails = new List<string>()
                    {
                        "@gmail.com",
                        "@outlook.com",
                        "@yahoo.com"};
            var cities = new List<string>()
                    {"irbid", "ajloun", "amman", "aqaba","ma'an","mafraq","zarqa","jarash","karak"};
            m_users newuser = new m_users();
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] name = line.Split(' ');

                    newuser.firstname = name[0];
                    newuser.secondname = name[1];
                    var random = new Random();
                    int index = random.Next(emails.Count());
                    int index2 = random.Next(cities.Count());
                    newuser.email = name[0] +name[1]+ random.Next()+emails[index];
                    newuser.address = cities[index2];
                    insertone(newuser);
                }
            }
            return true;

        }
        public List<citycount> citycounts()
        {
            IEnumerable<citycount> result = dbContext.dbConnection.Query<citycount>("m_users_package.countcity", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }
        public List<visacount> visa_count()
        {
            IEnumerable<visacount> result = dbContext.dbConnection.Query<visacount>("m_users_package.countvisa", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }


        public bool deleteone(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("usersid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("m_users_package.deleteone", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<m_users> getall()
        {
            IEnumerable<m_users> result = dbContext.dbConnection.Query<m_users>("m_users_package.getall", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public m_users getbyid(int? id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("usersid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<m_users> result = dbContext.dbConnection.Query<m_users>("m_users_package.getbyid", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public bool insertone(m_users users)
        {
            var parameter = new DynamicParameters();

            parameter.Add("firstname", users.firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("secondname", users.secondname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("email", users.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("address", users.address, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.dbConnection.ExecuteAsync("m_users_package.creatone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }

        public bool updateone(m_users users)
        {
            var parameter = new DynamicParameters();


            parameter.Add("usersid", users.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("firstname", users.firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("secondname", users.secondname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("email", users.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("address", users.address, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.dbConnection.ExecuteAsync("m_users_package.updateone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }
    }

}
