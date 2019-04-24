using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace School
{
    class Login_credentials
    {
        string login_id;
        string passwd;
        public Login_credentials(string login_id, string passwd)
        {
            this.login_id = login_id;
            this.passwd = passwd;
        }
        public bool check_credentials()
        {
            if(login_id=="karthik" && passwd=="1234")
            {
                //Console.WriteLine("login success");
                return true;
            }
            else
            {
                //Console.WriteLine("username or password are incorrect");
                return false;
            }
        }
    }

    class Teacher : Login_credentials
    {
        string joinedValue;
        
        public Teacher(string login_id, string passwd):base(login_id, passwd)
        {
            this.joinedValue = login_id + " " + passwd;
        }


        public void Add_student_details()
        {
            if (base.check_credentials() == true)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("invalid credentials");
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RestClientOperations obj = new RestClientOperations();

            obj.HitWebUrl();

            //string username, passwd;
            //Console.Write("Username:");
            //username = Console.ReadLine();
            //Console.Write("password:");
            //passwd = Console.ReadLine();
            ////Login_credentials login = new Login_credentials(username, passwd);
            //Teacher tec = new Teacher(username,passwd);
            //tec.check_credentials();
            //tec.Add_student_details();
            Console.ReadKey();
        }
    }

    class RestClientOperations
    {
        public void HitWebUrl()
        {
            RestClient client = new RestClient("https://ajax.googleapis.com");

            RestRequest request = new RestRequest("/ajax/libs/angularjs/1.6.9/angular.min.js");

            request.Method = Method.GET;

            request.RequestFormat = DataFormat.None;

            var Response = client.Execute(request);

            if(Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(Response.Content);
            }
            else
            {
                Console.WriteLine(Response.StatusCode + " " + Response.StatusDescription);
            }
        }
    }
}
