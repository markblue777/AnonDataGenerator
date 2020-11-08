using AnonDataGenerator.Entities;
using System;

namespace AnonDataGenerator
{
    public static class DataFactory
    {
        public static DataTypeBase GenerateDataType(DataTypes dataType, int rowsToGenerate = 1) => dataType switch
        {
            DataTypes.Name => new Name(rowsToGenerate),
            DataTypes.FirstName => new FirstName(rowsToGenerate),
            DataTypes.LastName => new LastName(rowsToGenerate),
            DataTypes.HouseNumber => new HouseNumber(rowsToGenerate),
            DataTypes.Street => new Street(rowsToGenerate),
            DataTypes.City => new City(rowsToGenerate),
            DataTypes.County => new County(rowsToGenerate),
            DataTypes.Country => new Country(rowsToGenerate),
            DataTypes.Email => new Email(rowsToGenerate),
            DataTypes.Postcode => new Postcode(rowsToGenerate),
            DataTypes.Username => new Username(rowsToGenerate),
            DataTypes.LandLine => new LandLine(rowsToGenerate),
            DataTypes.Mobile => new Mobile(rowsToGenerate),
            DataTypes.Fax => new Fax(rowsToGenerate),
            DataTypes.DateTime => new Entities.DateTime(rowsToGenerate),
            DataTypes.UUID => new UUID(rowsToGenerate),
            { } => throw new Exception($"Type Not Supported! -  { dataType }")
        };
    } }