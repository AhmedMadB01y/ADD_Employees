using EmployeesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EmployeesWeb.Controllers
{
    public class EmployeesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7083/api");
        private readonly HttpClient _httpClient;

        public EmployeesController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {

            List<Employee> employees = new List<Employee>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employees/").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<Employee>>(data);
            }

            return View(employees);
        }

        public IActionResult Details(int id)
        {
            Employee employee = new Employee();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employees/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string? data = response.Content?.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<Employee>(data);
            }

            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            string data = JsonConvert.SerializeObject(employee);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Employees/", stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            Employee employee = new Employee();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employees/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content?.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<Employee>(data);
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(int id, Employee employee)
        {
            string data = JsonConvert.SerializeObject(employee);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/Employees/" + id, stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            Employee employee = new Employee();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employees/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content?.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<Employee>(data);
            }

            return View(employee);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "/Employees/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
