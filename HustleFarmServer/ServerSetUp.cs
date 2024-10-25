using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using HustleFarmServer.Controllers.Model;

public class ServerSetUp
{
    public static void ConfigureServices(IServiceProvider service)
    {
        // Initialize Firebase using the service account JSON file
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.GetApplicationDefault()
        });

        // get data from firebase into model
        ItemsGachaRateManager.GetInstance();

        ItemGachaStorageManager.GetInstance();

    }

    
}