namespace CaseWork.Model
{
        public class ApiResponse<T> where T : class
        {
            public string Message { get; set; }

            public int StatusCode { get; set; }

            public T Data { get; set; }
      
    }
}
