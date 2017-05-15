using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class MyExtension
{
    public static string GetBase64String(this byte[] data)
    {
        return Convert.ToBase64String(data);
    }

    public static string GetClearString(this byte[] data, Encoding encoding = null)
    {
        if (encoding == null) encoding = Encoding.UTF8;
        return encoding.GetString(data);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="encoding">default is Encoding.UTF8</param>
    /// <returns></returns>
    public static byte[] GetByteArray(this string data, Encoding encoding = null)
    {
        if (encoding == null) encoding = Encoding.UTF8;
        return encoding.GetBytes(data);
    }

    public static byte[] FromBase64String(this string data)
    {
        return Convert.FromBase64String(data);
    }
    
}
