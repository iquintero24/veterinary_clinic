using models;

public class Validations
{
    /// <summary>
    /// Validare if the age is a valid number and greater than 0
    /// </summary>
    /// <param name="age"></param>
    /// <returns></returns>
    public bool ValidationEdad(int age)
    {
        if (age > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Validate if the name is not empty and contains only letters and spaces
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>

    public bool ValidateName(string name )
    {
        if (string.IsNullOrEmpty(name))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}