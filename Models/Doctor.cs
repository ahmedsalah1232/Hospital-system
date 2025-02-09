using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string DoctorName { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public string Img { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
