using System;
using System.Configuration;

using My2C2PPKCS7;


/// <summary>
/// Summary description for pkcs7Helper
/// </summary>
public class pkcs7Helper
{

    private PKCS7 myPKCS7 = new PKCS7();


    public pkcs7Helper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string doEncrypt(string clearData, string merPublicKey)
    {
        string encryptedData = "";
        try
        {
            encryptedData = myPKCS7.encryptMessage(clearData, myPKCS7.getPublicCert(merPublicKey));
        }
        catch (Exception ex)
        {

        }
        return encryptedData;
    }

    public string doDecrypt(string encryptedData, string certPath, string password)
    {
        string clearData = "";
        if (System.IO.File.Exists(certPath))
        {
            try
            {
                clearData = myPKCS7.decryptMessage(encryptedData, myPKCS7.getPrivateCert(certPath, password));
            }
            catch (Exception ex)
            {

            }
        }
        else
        {
            clearData = "'" + certPath + "' does not exists.";
        }
        return clearData;
    }

    public string doDecryptUsingBase64(string encryptedData, string certificate, string password)
    {
        string clearData = "";
        if (!string.IsNullOrEmpty(certificate))
        {
            try
            {
                clearData = myPKCS7.decryptMessage(encryptedData, myPKCS7.getPrivateCertWithBase64(certificate, password));
            }
            catch (Exception ex)
            {

            }
        }
        else
        {
            clearData = "'" + certificate + "' is not valid.";
        }
        return clearData;
    }



}
