using System;
using System.Collections.Generic;

namespace ClientManagement.Core.Entities.DTO
{
    public class BusinessScheduledServiceRequestItemDto
    {
        public int ServiceRequestId { get; set; }
        public string Notes { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public bool IsApproved { get; set; }
        public List<BServiceDTO> Services { get; set; }
    }
}