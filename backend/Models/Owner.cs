﻿namespace backend;

public class Owner
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Notes { get; set; }

    public List<Property> Properties { get; set; }

}
