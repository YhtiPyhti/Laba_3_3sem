using System;
using System.Runtime.Serialization;


namespace WpfApp1
{
    [Serializable]
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string serializationStatus { get; set; }
        public string deserializationStatus { get; set; }

        public User() { }

        public User(string login, string password, string email)
        {
            this.login = login;
            this.password = password;
            this.email = email;

            Random rnd = new Random();
            this.id = rnd.Next(0,999);

        }
        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            serializationStatus = "serialization";
        }

        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context)
        {
            serializationStatus = "serialization was successful";
        }

        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            deserializationStatus = "deserialization";
        }

        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            deserializationStatus = "deserialization was successful";
        }
    }
}
