using System;
using System.Collections.Generic;

namespace EncarnacionCoop.Entities;

public partial class ClientInfo
{
    public int Id { get; set; }

    public int? UserType { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public int? ZipCode { get; set; }

    public DateTime? Birthday { get; set; }

    public int? Age { get; set; }

    public string? NameOfFather { get; set; }

    public string? NameOfMother { get; set; }

    public string? CivilStatus { get; set; }

    public string? Religion { get; set; }

    public string? Occupatioin { get; set; }


}
