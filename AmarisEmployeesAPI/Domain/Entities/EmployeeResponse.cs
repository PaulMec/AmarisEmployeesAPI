using Newtonsoft.Json;

namespace AmarisEmployeesAPI.Domain.Entities
{
    public class EmployeeResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public List<Employee> Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
