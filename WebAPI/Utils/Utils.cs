using System.Numerics;
using Nethereum.Util;
using WebAPI.Model;
using System;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace WebAPI.Utils
{
    public class Utils
    {
        static public BigInteger ConversionToWei(Decimal _value)
        {
            UnitConversion conversion = new UnitConversion();
            var value = (BigInteger)conversion.ToWeiFromUnit(_value, conversion.GetEthUnitValue(UnitConversion.EthUnit.Ether));

            return value;
        }

        static public Decimal ConversionFromWei(BigInteger _value)
        {
            UnitConversion conversion = new UnitConversion();

            return conversion.FromWei(_value, 18);
        }

        // static public string GetTxHash(Newtonsoft.Json.Linq.JArray _txLog)
        // {
        //     var jsonTxHash = JsonDocument.Parse(_txLog.First.ToString()).RootElement.EnumerateObject();

        //     string txHash = "";
        //     foreach (JsonProperty child in jsonTxHash)
        //     {
        //         if (child.Name.Equals("transactionHash"))
        //             txHash = child.Value.ToString();
        //     }

        //     return txHash;
        // }

        // static public EthReturn ReturnTxHashObj(Nethereum.RPC.Eth.DTOs.TransactionReceipt _txReceipt, string succMessage, string errMessage)
        // {
        //     EthReturn ethR = new EthReturn();

        //     if (!_txReceipt.HasErrors().Value)
        //     {
        //         ethR.Success = true;
        //         ethR.Message = succMessage;
        //         ethR.TxHash = Utils.GetTxHash(_txReceipt.Logs);
        //     }
        //     else
        //     {
        //         ethR.Success = false;
        //         ethR.Message = errMessage;
        //         ethR.TxHash = null;
        //     }
        //     return ethR;
        // }

        static public EthReturn ReturnTxHash(string _txHash, string message, bool success)
        {
            EthReturn ethR = new EthReturn();

            ethR.Success = success;
            ethR.Message = message;
            ethR.TxHash = _txHash;

            return ethR;
        }

        static public StringReturn ReturnStringObj(string _value, string message, bool success)
        {
            StringReturn strR = new StringReturn();

            strR.Value = _value;
            strR.Message = message;
            strR.Success = success;

            return strR;
        }

        static public DecimalReturn ReturnDecimalObj(decimal _value, string message, bool success)
        {
            DecimalReturn strR = new DecimalReturn();

            strR.Value = _value;
            strR.Message = message;
            strR.Success = success;

            return strR;
        }

        static public String textCompress(String textToCompress)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(textToCompress);
            MemoryStream ms = new MemoryStream();

            using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
            {
                zip.Write(buffer, 0, buffer.Length);
            }

            ms.Position = 0;
            MemoryStream outStream = new MemoryStream();

            byte[] compressed = new byte[ms.Length];
            ms.Read(compressed, 0, compressed.Length);

            byte[] gzBuffer = new byte[compressed.Length + 4];
            System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
            System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
            return Convert.ToBase64String(gzBuffer);
        }
        static public String textUncompress(String compressedText)
        {
            byte[] gzBuffer = Convert.FromBase64String(compressedText);
            using (MemoryStream ms = new MemoryStream())
            {
                int msgLength = BitConverter.ToInt32(gzBuffer, 0);
                ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

                byte[] buffer = new byte[msgLength];

                ms.Position = 0;
                using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
                {
                    zip.Read(buffer, 0, buffer.Length);
                }
                return Encoding.UTF8.GetString(buffer);
            }
        }

        static public String codifyJsonFields(String _json)
        {
            String result = _json.Replace("string", "*0*");
            result = result.Replace("orderno", "*1*");
            result = result.Replace("process", "*2*");
            result = result.Replace("operation", "*3*");
            result = result.Replace("production", "*4*");
            result = result.Replace("lastsequence", "*5*");
            result = result.Replace("tckr_type", "*6*");
            result = result.Replace("comments", "*7*");
            result = result.Replace("usage", "*8*");
            result = result.Replace("farmer", "*9*");
            result = result.Replace("variety", "*10*");
            result = result.Replace("weather", "*11*");
            result = result.Replace("region", "*12*");

            return result;
        }

        static public String decodifyJsonFields(String _json)
        {
            String result = _json.Replace("*0*", "string");
            result = result.Replace("*1*", "orderno");
            result = result.Replace("*2*", "process");
            result = result.Replace("*3*", "operation");
            result = result.Replace("*4*", "production");
            result = result.Replace("*5*", "lastsequence");
            result = result.Replace("*6*", "tckr_type");
            result = result.Replace("*7*", "comments");
            result = result.Replace("*8*", "usage");
            result = result.Replace("*9*", "farmer");
            result = result.Replace("*10*", "variety");
            result = result.Replace("*11*", "weather");
            result = result.Replace("*12*", "region");

            return result;
        }

        static public String CompressJson(String json)
        {
            String originalString = json;

            Console.WriteLine("originalString: [" + originalString + "], Size: " + originalString.Length);

            String codifyedString = Utils.codifyJsonFields(originalString);
            Console.WriteLine("codifyedString: [" + codifyedString + "], Size: " + codifyedString.Length);

            String compressedString = Utils.textCompress(codifyedString);
            Console.WriteLine("Compressed: [" + compressedString + "], Size: " + compressedString.Length);

            return  compressedString;
        }  

        static public String UncompressJson(String compressedJson)
        {
            Console.WriteLine("compressedJson: [" + compressedJson + "]");

            String uncompressedString = Utils.textUncompress(compressedJson);
            Console.WriteLine("Uncompressed: [" + uncompressedString + "]");

            String uncodifyedString = Utils.decodifyJsonFields(uncompressedString);
            Console.WriteLine("uncodifyedString: [" + uncodifyedString + "]");

            return  uncodifyedString;
        }              
    }
}