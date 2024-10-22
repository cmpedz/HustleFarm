using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Initialize Firebase using the service account JSON file
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.GetApplicationDefault()
        });

        // Other service configurations
    }

    // Other configurations
}