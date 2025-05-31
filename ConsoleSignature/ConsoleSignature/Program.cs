// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;

Console.WriteLine("Hello, World!");

//1. create Digital signed Document 
static byte[] SignData(string data, string privateKey)
{
    using (var rsa = new RSACryptoServiceProvider())
    {
        // Load the private key
        rsa.FromXmlString(privateKey);

        // Convert the data to bytes
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);

        // Sign the data
        byte[] signature = rsa.SignData(dataBytes, new SHA256CryptoServiceProvider());

        return signature;
    }
}

//2. verify Signed Document

static bool VerifySignature(string data, byte[] signature, string publicKey)
{
    using (var rsa = new RSACryptoServiceProvider())
    {
        // Load the public key
        rsa.FromXmlString(publicKey);

        // Convert the data to bytes
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);

        // Verify the signature
        return rsa.VerifyData(dataBytes, new SHA256CryptoServiceProvider(), signature);
    }
}



Console.WriteLine("Digital Signature!");

var rsa = new RSACryptoServiceProvider(2048);

string publicKey = rsa.ToXmlString(false);  
string privateKey = rsa.ToXmlString(true);

// Save keys to files (in a real-world scenario, handle key storage more securely)
File.WriteAllText("publicKey.xml", publicKey);
File.WriteAllText("privateKey.xml", privateKey);

//This is document to sign and send to receiver
string dataToSign = "Document to sign, and send. This can be a PDF";

//get signature from data and private key
byte[] signature = SignData(dataToSign, privateKey);

foreach (byte b in signature)
{
    Console.Write((char)b);
}


//signature = dataToSign + signed
bool isSignatureValid 
    = VerifySignature("Document to sign, and send. This can be a PD", signature, publicKey);

if (isSignatureValid)
{
    Console.WriteLine("Right Document!!!");
}
else
{
    Console.WriteLine("Fake document");
}