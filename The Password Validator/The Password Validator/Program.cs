// See https://aka.ms/new-console-template for more information
while(true)
{
    Console.WriteLine("Enter a password");
    PasswordValidator user_password = new PasswordValidator(Console.ReadLine());
    user_password.ValidatePassword();
    

}
class PasswordValidator
{
    private string Password;
    public PasswordValidator (string password)
    {
        Password = password;
    }

    public void ValidatePassword()
    {
        int upperCount = 0;
        int lowerCount = 0;
        int numericCount = 0;
        Console.Clear();
        // Validate password length 6-13
        if (Password.Length > 13 || Password.Length < 6)
        {
            Console.WriteLine("Enter a password between length 6-13.");
        }
        else
        {
            foreach (char letter in Password)
            {
                if (letter == 'T' || letter == '&') 
                { 
                    Console.WriteLine("You cannot use an ampersand or capital T");
                    break;
                }
                if (char.IsNumber(letter)) { numericCount++; }
                if (char.IsUpper(letter)) { upperCount++; }
                if (char.IsLower(letter)) { lowerCount++; }
            }

            if (numericCount == 0 || upperCount == 0 || lowerCount == 0)
            {
                Console.WriteLine("Password needs at least one numeric, uppercase, and lowercase character");
            }
            else
            {
                Console.WriteLine("Valid Password");
            }
        }
    }
}