public class LoginController : Controller
{
    private readonly IUserService _userService;
    private readonly IHashingService _hashingService;
    
    public LoginController(IUserService userService, IHashingService hashingService)
    {
        _userService = userService;
        _hashingService = hashingService;
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Get user from the database
        var user = _userService.GetByUsername(username);

        if (user == null)
        {
            // Handle non-existing user scenario
            return Unauthorized();
        }

        // Validate user password
        if (_hashingService.VerifyHash(password, user.PasswordHash))
        {
            // Passwords match, log the user in

            // Create user session or token

            // Encrypt sensitive data
            string sensitiveData = "some sensitive data";
            string encryptedData = AesEncryption.EncryptString(sensitiveData);

            // Store encrypted data in the user session or return in the login response
        }
        else
        {
            // Handle password mismatch scenario
            return Unauthorized();
        }

        return Ok();
    }
}
