using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sk_chat_winform.Redis;

public static class Utility 
{
    public static string GetTimestamp() => DateTime.Now.ToString("yyyyMMddHHmmssffff");

    public static async void expireEntriesBefore(int exp_seconds, RedisConnection _rc, RedisKey _hk)
    {
        RedisValue[] _fields = await _rc.BasicRetryAsync(async (db) => (await db.HashKeysAsync(_hk)));
        DateTime _dt;
        DateTime now = DateTime.Now;
        foreach (var field in _fields) 
        {
            _dt = DateTime.ParseExact(field.ToString(), "yyyyMMddHHmmssffff", System.Globalization.CultureInfo.InvariantCulture);
            if (now.Subtract(_dt).TotalSeconds > exp_seconds) 
            {
                await _rc.BasicRetryAsync(async(db) => (await db.HashDeleteAsync(_hk, field)));
            }
        }
    }

}