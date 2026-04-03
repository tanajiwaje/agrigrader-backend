using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System;
using System.Threading.Tasks;

using AgriGrader.Application.Interfaces;

namespace AgriGrader.Infrastructure.Services
{
    public class FirebaseOtpService : IFirebaseOtpService
    {
        private readonly FirebaseClient _firebaseClient;

        public FirebaseOtpService()
        {
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromFile("firebase_credentials.json")
                });
            }

            _firebaseClient = new FirebaseClient("https://mysmsgateway-3136e-default-rtdb.firebaseio.com/");
        }

        private string GenerateOtp()
        {
            return new Random().Next(100000, 999999).ToString();
        }

        public async Task SendOtpToFirebaseAsync(string phoneNumber, string otp)
        {
            var data = new
            {
                phone = phoneNumber,
                otp = otp,
                sent = false,
                timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };

            await _firebaseClient.Child("otp_requests").PostAsync(data);
        }
    }
}
