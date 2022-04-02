namespace SchoolModel;

public partial class Person
{
    /// <summary>
    /// Converts the string discriminator field into an enumerated value, or null if it isn't a valid enum value.
    /// </summary>
    /// <returns>A Discriminator enum, or null if no value matches.</returns>
    public Discriminator? GetDiscriminatorEnum()
    {
        if (Enum.TryParse<Discriminator>(this.Discriminator, out Discriminator result))
        {
            return result;
        }
        return null;
    }

}