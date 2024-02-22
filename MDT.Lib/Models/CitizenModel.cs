﻿namespace MDT.Lib.Models;

public class CitizenModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Postal { get; set; }
}