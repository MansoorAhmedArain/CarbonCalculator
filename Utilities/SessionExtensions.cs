using Newtonsoft.Json;

namespace WTechAuth.Utilities
{
    public static class SessionExtensions

    {
        // Extension method for setting an object in session
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // Extension method for getting an object from session
        public static T? GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
