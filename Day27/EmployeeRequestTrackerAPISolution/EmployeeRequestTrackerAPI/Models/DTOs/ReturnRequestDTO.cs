namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class ReturnRequestDTO
    {
        public int Id { get; set; }

        public string RequestMessage { get; set; }

        public DateTime RequestDate { get; set; } 

        public DateTime? ClosedDate { get; set; } = null;

        public string RequestStatus { get; set; }

        public int RequestRaisedBy { get; set; }

        public int? RequestClosedBy { get; set; }
    }
}
