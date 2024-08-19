﻿using System.ComponentModel.DataAnnotations;

namespace OutfitTrack.Arguments;

public class InputCreateCustomer
{
    [Required][MaxLength(50, ErrorMessage = "Quantidade de caracteres inválida")] public string? FirstName { get; set; }
    [MaxLength(50, ErrorMessage = "Quantidade de caracteres inválida")] public string? LastName { get; set; }
    [Required] public DateTime? BirthDate { get; set; }
    [Required][Length(11, 11, ErrorMessage = "Quantidade de caracteres inválida")] public string? Cpf { get; set; }
    [Required][MaxLength(100, ErrorMessage = "Quantidade de caracteres inválida")] public string? Street { get; set; }
    [MaxLength(100, ErrorMessage = "Quantidade de caracteres inválida")] public string? Complement { get; set; }
    [Required][MaxLength(50, ErrorMessage = "Quantidade de caracteres inválida")] public string? Neighborhood { get; set; }
    [Required][MaxLength(10, ErrorMessage = "Quantidade de caracteres inválida")] public string? Number { get; set; }
    [Required][MaxLength(50, ErrorMessage = "Quantidade de caracteres inválida")] public string? CityName { get; set; }
    [Required][Length(2, 2, ErrorMessage = "Quantidade de caracteres inválida")] public string? StateAbbreviation { get; set; }
    [Length(9, 9, ErrorMessage = "Quantidade de caracteres inválida")] public string? Rg { get; set; }
    [Required][Length(13, 13, ErrorMessage = "Quantidade de caracteres inválida")] public string? MobilePhoneNumber { get; set; }
    [MaxLength(256, ErrorMessage = "Quantidade de caracteres inválida")] public string? Email { get; set; }

    public InputCreateCustomer() { }

    public InputCreateCustomer(string firstName, string? lastName, DateTime birthDate, string cpf, string street, string? complement, string neighborhood, string number, string cityName, string stateAbbreviation, string rg, string mobilePhoneNumber, string? email)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Cpf = cpf;
        Street = street;
        Complement = complement;
        Neighborhood = neighborhood;
        Number = number;
        CityName = cityName;
        StateAbbreviation = stateAbbreviation;
        Rg = rg;
        MobilePhoneNumber = mobilePhoneNumber;
        Email = email;
    }
}