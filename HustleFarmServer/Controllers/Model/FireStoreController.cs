using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HustleFarmServer.Controllers.Model
{
    public class FireStoreController
    {

        private readonly FirestoreDb _firestoreDb;
        public FirestoreDb FireStoreDb
        {
            get { return _firestoreDb; }
        }

        private static FireStoreController? instance;

        private FireStoreController() {

            _firestoreDb = FirestoreDb.Create("hustlefarm-fb89d");

        }

        public static FireStoreController GetInstace() {

            if (instance == null) { 
                instance = new FireStoreController();
            }

            return instance;
        }


    }
}
