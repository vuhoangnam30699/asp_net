using Newtonsoft.Json;

namespace ShoppingCart.Utils
{
    public static class SessionExtensions
    {
        public static void SetObject (this ISession session, string key ,object obj)
        {
            session.SetString(key, JsonConvert.SerializeObject(obj));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetObject<T>(key);
            return (T)value;
        }
    }
}
