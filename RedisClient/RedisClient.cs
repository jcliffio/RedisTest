using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisClientProject
{
    public class RedisClient
    {
        private static ConnectionMultiplexer redis;

        public RedisClient()
        {
            if (redis == null)
            {
                redis = ConnectionMultiplexer.Connect("localhost");
            }
        }

        public void SetStringByKey(string key, string value)
        {
            var db = redis.GetDatabase(0);

            db.StringSet(key, value);
        }

        public string GetStringByKey(string key)
        {
            var db = redis.GetDatabase(0);

            var result = db.StringGet(key);

            return result;
        }
    }
}
