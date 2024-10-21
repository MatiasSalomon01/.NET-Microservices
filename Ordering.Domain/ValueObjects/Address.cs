public record Address
{

    public string FirstName { get; }
    public string Lastname { get; }
    public string? EmailAddress { get; }
    public string AddressLine { get; }
    public string Country { get; }
    public string State { get; }
    public string ZipCode { get; }
    
    private Address(string firstName, string lastname, string? emailAddress, string addressLine, string country, string state, string zipCode)
    {
        FirstName = firstName;
        Lastname = lastname;
        EmailAddress = emailAddress;
        AddressLine = addressLine;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }

    public static Address Of(string firstName, string lastname, string? emailAddress, string addressLine, string country, string state, string zipCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
        ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);

        return new Address(firstName, lastname, emailAddress, addressLine, country, state, zipCode);
    }
}
