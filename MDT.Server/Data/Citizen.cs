﻿namespace MDT.Server.Data;

public class Citizen
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Birthday { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Postal { get; set; }
    public List<Car>? Cars { get; set; }
    public List<Record>? Records { get; set; }
    public List<Fine>? Fines { get; set; }
    public List<Warrant>? Warrant { get; set; }
}