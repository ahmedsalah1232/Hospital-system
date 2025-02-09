using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public string PatientName { get; set; }

    public DateOnly AppointmentDate { get; set; }

    public TimeOnly AppointmentTime { get; set; }

    public int? DoctorId { get; set; }

    public virtual Doctor? Doctor { get; set; }
}
