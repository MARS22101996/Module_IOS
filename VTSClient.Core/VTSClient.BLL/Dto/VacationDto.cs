using System;
using VTSClient.DataAccess.Enums;

namespace VTSClient.BLL.Dto
{
    public class VacationDto
    {
        public Guid Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public VacationStatus VacationStatus { get; set; }

        public VacationType VacationType { get; set; }
    }
}
