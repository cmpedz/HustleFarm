using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HustleFarmServer.Controllers.Model
{
    public class FireStoreSetup
    {

        private readonly FirestoreDb _firestoreDb;
        public FirestoreDb FireStoreDb
        {
            get { return _firestoreDb; }
        }

        private static FireStoreSetup? instance;

        private FireStoreSetup() {

            _firestoreDb = FirestoreDb.Create("hustlefarm-fb89d");

        }

        public static FireStoreSetup GetInstace() {

            if (instance == null) { 
                instance = new FireStoreSetup();
            }

            return instance;
        }


    }
}
