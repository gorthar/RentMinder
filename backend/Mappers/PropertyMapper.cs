namespace backend;

public static class PropertyMapper
{
    public static PropertyDto ToPropertyDto(this Property property)
    {
        return new PropertyDto
        {
            OwnerId = property.OwnerId,
            Address = property.Address,
            City = property.City,
            Province = property.Province,
            PostalCode = property.PostalCode
        };
    }

    public static Property ToPropertyModel(this PropertyDto propertyDto)
    {
        return new Property
        {
            OwnerId = propertyDto.OwnerId,
            Address = propertyDto.Address,
            City = propertyDto.City,
            Province = propertyDto.Province,
            PostalCode = propertyDto.PostalCode
        };
    }

}
