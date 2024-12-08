#region Assembly Thirdweb, Version=2.5.1.0, Culture=neutral, PublicKeyToken=null
// D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\Thirdweb.dll
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ADRaffy.ENSNormalize;
using Nethereum.ABI.EIP712;
using Nethereum.ABI.FunctionEncoding;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.ABI.Model;
using Nethereum.Contracts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.Signer;
using Nethereum.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Thirdweb;

public static class CustomUtils
{
    [FunctionOutput]
    private class ResolveReturnType
    {
        [Parameter("bytes", "", 1)]
        public byte[] Bytes { get; set; }

        [Parameter("address", "", 2)]
        public string Address { get; set; }
    }

    private static readonly Dictionary<BigInteger, bool> _eip155EnforcedCache = new Dictionary<BigInteger, bool>();

    private static readonly Dictionary<BigInteger, CustomThirdwebChainData> _chainDataCache = new Dictionary<BigInteger, CustomThirdwebChainData>();

    private static readonly Dictionary<string, string> _ensCache = new Dictionary<string, string>();

    private static readonly List<string[]> _errorSubstringsComposite = new List<string[]>
    {
        new string[2] { "account", "not found!" },
        new string[2] { "wrong", "chainid" }
    };

    public static string ComputeClientIdFromSecretKey(string secretKey)
    {
        using SHA256 sHA = SHA256.Create();
        return BitConverter.ToString(sHA.ComputeHash(Encoding.UTF8.GetBytes(secretKey))).Replace("-", "").ToLower()
            .Substring(0, 32);
    }

    public static string HexConcat(params string[] hexStrings)
    {
        StringBuilder stringBuilder = new StringBuilder("0x");
        foreach (string text in hexStrings)
        {
            string text2 = text;
            stringBuilder.Append(text2.Substring(2, text2.Length - 2));
        }

        return stringBuilder.ToString();
    }

    public static byte[] HashPrefixedMessage(this byte[] messageBytes)
    {
        return new EthereumMessageSigner().HashPrefixedMessage(messageBytes);
    }

    public static string HashPrefixedMessage(this string message)
    {
        return new EthereumMessageSigner().HashPrefixedMessage(Encoding.UTF8.GetBytes(message)).ToHex(prefix: true);
    }

    public static byte[] HashMessage(this byte[] messageBytes)
    {
        return Sha3Keccack.Current.CalculateHash(messageBytes);
    }

    public static string HashMessage(this string message)
    {
        return Sha3Keccack.Current.CalculateHash(message);
    }

    public static string BytesToHex(this byte[] bytes)
    {
        return bytes.ToHex(prefix: true);
    }

    public static byte[] HexToBytes(this string hex)
    {
        return hex.HexToByteArray();
    }

    public static BigInteger HexToBigInt(this string hex)
    {
        return new HexBigInteger(hex).Value;
    }

    public static string StringToHex(this string str)
    {
        return "0x" + Encoding.UTF8.GetBytes(str).ToHex();
    }

    public static string HexToString(this string hex)
    {
        byte[] array = hex.HexToBytes();
        return Encoding.UTF8.GetString(array, 0, array.Length);
    }

    public static long GetUnixTimeStampNow()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    public static long GetUnixTimeStampIn10Years()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 315360000;
    }

    public static string ReplaceIPFS(this string uri, string gateway = null)
    {
        if (gateway == null)
        {
            gateway = "https://ipfs.io/ipfs/";
        }

        if (string.IsNullOrEmpty(uri) || !uri.StartsWith("ipfs://"))
        {
            return uri;
        }

        return uri.Replace("ipfs://", gateway);
    }

    public static string ToWei(this string eth)
    {
        if (!double.TryParse(eth, NumberStyles.Number, CultureInfo.InvariantCulture, out var result))
        {
            throw new ArgumentException("Invalid eth value.");
        }

        return ((BigInteger)(result * 1E+18)).ToString();
    }

    public static string ToEth(this string wei, int decimalsToDisplay = 4, bool addCommas = false)
    {
        return wei.FormatERC20(decimalsToDisplay, 18, addCommas);
    }

    public static string FormatERC20(this string wei, int decimalsToDisplay = 4, int decimals = 18, bool addCommas = false)
    {
        if (!BigInteger.TryParse(wei, out var result))
        {
            throw new ArgumentException("Invalid wei value.");
        }

        double num = (double)result / Math.Pow(10.0, decimals);
        string text = (addCommas ? "#,0" : "#0");
        if (decimalsToDisplay > 0)
        {
            text += ".";
            text += new string('0', decimalsToDisplay);
        }

        return num.ToString(text);
    }

    public static string GenerateSIWE(LoginPayloadData loginPayloadData)
    {
        if (loginPayloadData == null)
        {
            throw new ArgumentNullException("loginPayloadData");
        }

        if (string.IsNullOrEmpty(loginPayloadData.Domain))
        {
            throw new ArgumentNullException("Domain");
        }

        if (string.IsNullOrEmpty(loginPayloadData.Address))
        {
            throw new ArgumentNullException("Address");
        }

        if (string.IsNullOrEmpty(loginPayloadData.Version))
        {
            throw new ArgumentNullException("Version");
        }

        if (string.IsNullOrEmpty(loginPayloadData.ChainId))
        {
            throw new ArgumentNullException("ChainId");
        }

        if (string.IsNullOrEmpty(loginPayloadData.Nonce))
        {
            throw new ArgumentNullException("Nonce");
        }

        if (string.IsNullOrEmpty(loginPayloadData.IssuedAt))
        {
            throw new ArgumentNullException("IssuedAt");
        }

        string text = ((loginPayloadData.Resources != null) ? ("\nResources:" + string.Join("", loginPayloadData.Resources.Select((string r) => "\n- " + r))) : string.Empty);
        return loginPayloadData.Domain + " wants you to sign in with your Ethereum account:\n" + loginPayloadData.Address + "\n\n" + (string.IsNullOrEmpty(loginPayloadData.Statement) ? "" : (loginPayloadData.Statement + "\n")) + (string.IsNullOrEmpty(loginPayloadData.Uri) ? "" : ("\nURI: " + loginPayloadData.Uri)) + "\nVersion: " + loginPayloadData.Version + "\nChain ID: " + loginPayloadData.ChainId + "\nNonce: " + loginPayloadData.Nonce + "\nIssued At: " + loginPayloadData.IssuedAt + (string.IsNullOrEmpty(loginPayloadData.ExpirationTime) ? "" : ("\nExpiration Time: " + loginPayloadData.ExpirationTime)) + (string.IsNullOrEmpty(loginPayloadData.InvalidBefore) ? "" : ("\nNot Before: " + loginPayloadData.InvalidBefore)) + text;
    }

    public static async Task<bool> IsZkSync(ThirdwebClient client, BigInteger chainId)
    {
        if (chainId.Equals(324L) || chainId.Equals(300L) || chainId.Equals(302L) || chainId.Equals(11124L) || chainId.Equals(4654L) || chainId.Equals(333271L) || chainId.Equals(37111L))
        {
            return true;
        }

        CustomThirdwebChainData thirdwebChainData = await GetChainMetadata(client, chainId).ConfigureAwait(continueOnCapturedContext: false);
        return !string.IsNullOrEmpty(thirdwebChainData.StackType) && thirdwebChainData.StackType.Contains("zksync", StringComparison.OrdinalIgnoreCase);
    }

    public static string ToChecksumAddress(this string address)
    {
        return new AddressUtil().ConvertToChecksumAddress(address);
    }

    public static List<EventLog<TEventDTO>> DecodeAllEvents<TEventDTO>(this ThirdwebTransactionReceipt transactionReceipt) where TEventDTO : new()
    {
        return transactionReceipt.Logs.DecodeAllEvents<TEventDTO>();
    }

    public static BigInteger AdjustDecimals(this BigInteger value, int fromDecimals, int toDecimals)
    {
        int num = fromDecimals - toDecimals;
        if (num > 0)
        {
            return value / BigInteger.Pow(10, num);
        }

        if (num < 0)
        {
            return value * BigInteger.Pow(10, -num);
        }

        return value;
    }

    public static async Task<CustomThirdwebChainData> GetChainMetadata(ThirdwebClient client, BigInteger chainId)
    {
        if (_chainDataCache.TryGetValue(chainId, out var value))
        {
            return value;
        }

        if (client == null)
        {
            throw new ArgumentNullException("client");
        }

        if (chainId <= 0L)
        {
            throw new ArgumentException("Invalid chain ID.");
        }

        string requestUri = $"https://api.thirdweb.com/v1/chains/{chainId}";
        try
        {
            CustomThirdwebChainDataResponse thirdwebChainDataResponse = JsonConvert.DeserializeObject<CustomThirdwebChainDataResponse>(await (await client.HttpClient.GetAsync(requestUri).ConfigureAwait(continueOnCapturedContext: false)).Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false));
            if (thirdwebChainDataResponse == null || thirdwebChainDataResponse.Error != null)
            {
                throw new Exception($"Failed to fetch chain data for chain ID {chainId}. Error: {JsonConvert.SerializeObject(thirdwebChainDataResponse?.Error)}");
            }

            thirdwebChainDataResponse.Data.Explorers = ((thirdwebChainDataResponse.Data.Explorers == null || thirdwebChainDataResponse.Data.Explorers.Count == 0) ? null : thirdwebChainDataResponse.Data.Explorers);
            _chainDataCache[chainId] = thirdwebChainDataResponse.Data;
            return thirdwebChainDataResponse.Data;
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"HTTP request error while fetching chain data for chain ID {chainId}: {ex.Message}", ex);
        }
        catch (JsonException ex2)
        {
            throw new Exception($"JSON deserialization error while fetching chain data for chain ID {chainId}: {ex2.Message}", ex2);
        }
        catch (Exception ex3)
        {
            throw new Exception($"Unexpected error while fetching chain data for chain ID {chainId}: {ex3.Message}", ex3);
        }
    }

    public static int GetEntryPointVersion(string address)
    {
        if (address == null)
        {
            return 6;
        }

        address = address.ToChecksumAddress();
        if (!(address == "0x5FF137D4b0FDCD49DcA30c7CF57E578a026d2789"))
        {
            if (address == "0x0000000071727De22E5E9d8BAf0edAc6f37da032")
            {
                return 7;
            }

            return 6;
        }

        return 6;
    }

    public static byte[] HexToBytes32(this string hex)
    {
        if (hex.StartsWith("0x"))
        {
            string text = hex;
            hex = text.Substring(2, text.Length - 2);
        }

        if (hex.Length > 64)
        {
            throw new ArgumentException("Hex string is too long to fit into 32 bytes.");
        }

        hex = hex.PadLeft(64, '0');
        byte[] array = new byte[32];
        for (int i = 0; i < hex.Length; i += 2)
        {
            array[i / 2] = byte.Parse(hex.AsSpan(i, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        }

        return array;
    }

    public static string ToJsonExternalWalletFriendly<TMessage, TDomain>(TypedData<TDomain> typedData, TMessage message)
    {
        typedData.EnsureDomainRawValuesAreInitialised();
        typedData.Message = MemberValueFactory.CreateFromMessage(message);
        JObject obj = (JObject)JToken.FromObject(typedData);
        JProperty jProperty = new JProperty("domain");
        object[] array = GetJProperties("EIP712Domain", typedData.DomainRawValues, typedData).ToArray();
        object[] content = array;
        jProperty.Value = new JObject(content);
        obj.Add(jProperty);
        JProperty jProperty2 = new JProperty("message");
        array = GetJProperties(typedData.PrimaryType, typedData.Message, typedData).ToArray();
        content = array;
        jProperty2.Value = new JObject(content);
        obj.Add(jProperty2);
        return obj.ToString();
    }

    private static bool IsReferenceType(string typeName)
    {
        if (!new Regex("bytes\\d+").IsMatch(typeName) && !new Regex("uint\\d+").IsMatch(typeName) && !new Regex("int\\d+").IsMatch(typeName))
        {
            switch (typeName)
            {
                default:
                    if (typeName.Contains('['))
                    {
                        return false;
                    }

                    return true;
                case "bytes":
                case "string":
                case "bool":
                case "address":
                    break;
            }
        }

        return false;
    }

    private static List<JProperty> GetJProperties(string mainTypeName, MemberValue[] values, TypedDataRaw typedDataRaw)
    {
        List<JProperty> list = new List<JProperty>();
        MemberDescription[] array = typedDataRaw.Types[mainTypeName];
        for (int i = 0; i < array.Length; i++)
        {
            string type = array[i].Type;
            string name = array[i].Name;
            if (IsReferenceType(type))
            {
                JProperty jProperty = new JProperty(name);
                if (values[i].Value != null)
                {
                    object[] array2 = GetJProperties(type, (MemberValue[])values[i].Value, typedDataRaw).ToArray();
                    object[] content = array2;
                    jProperty.Value = new JObject(content);
                }
                else
                {
                    jProperty.Value = null;
                }

                list.Add(jProperty);
            }
            else if (type.StartsWith("bytes"))
            {
                string name2 = name;
                if (values[i].Value is byte[] bytes)
                {
                    string content2 = bytes.BytesToHex();
                    list.Add(new JProperty(name2, content2));
                }
                else
                {
                    object value = values[i].Value;
                    list.Add(new JProperty(name2, value));
                }
            }
            else if (type.Contains('['))
            {
                JProperty jProperty2 = new JProperty(name);
                JArray jArray = new JArray();
                string text = type.Substring(0, type.LastIndexOf('['));
                if (values[i].Value == null)
                {
                    jProperty2.Value = null;
                    list.Add(jProperty2);
                    continue;
                }

                if (IsReferenceType(text))
                {
                    foreach (MemberValue[] item in (List<MemberValue[]>)values[i].Value)
                    {
                        object[] array2 = GetJProperties(text, item, typedDataRaw).ToArray();
                        object[] content3 = array2;
                        jArray.Add(new JObject(content3));
                    }

                    jProperty2.Value = jArray;
                    list.Add(jProperty2);
                    continue;
                }

                foreach (object item2 in (IList)values[i].Value)
                {
                    jArray.Add(item2);
                }

                jProperty2.Value = jArray;
                list.Add(jProperty2);
            }
            else
            {
                string name3 = name;
                object value2 = values[i].Value;
                list.Add(new JProperty(name3, value2));
            }
        }

        return list;
    }

    public static async Task<bool> IsEip155Enforced(ThirdwebClient client, BigInteger chainId)
    {
        if (_eip155EnforcedCache.TryGetValue(chainId, out var value))
        {
            return value;
        }

        bool result = false;
        ThirdwebRPC rpcInstance = ThirdwebRPC.GetRpcInstance(client, chainId);
        try
        {
            string text = "0xf8a58085174876e800830186a08080b853604580600e600039806000f350fe7fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffe03601600081602082378035828234f58015156039578182fd5b8082525050506014600cf31ba02222222222222222222222222222222222222222222222222222222222222222a02222222222222222222222222222222222222222222222222222222222222222";
            await rpcInstance.SendRequestAsync<string>("eth_sendRawTransaction", new object[1] { text });
        }
        catch (Exception ex)
        {
            string errorMsg = ex.Message.ToLower();
            result = new List<string>
            {
                "eip-155", "eip155", "protected", "invalid chain id for signer", "chain id none", "chain_id mismatch", "recovered sender mismatch", "transaction hash mismatch", "chainid no support", "chainid (0)",
                "chainid(0)", "invalid sender"
            }.Any(errorMsg.Contains) || _errorSubstringsComposite.Any((string[] arr) => arr.All((string substring) => errorMsg.Contains(substring)));
        }

        _eip155EnforcedCache[chainId] = result;
        return result;
    }

    public static bool IsEip1559Supported(string chainId)
    {
        switch (chainId)
        {
            case "56":
            case "97":
            case "204":
            case "248":
            case "841":
            case "842":
            case "2040":
            case "5611":
            case "9372":
            case "78600":
                return false;
            default:
                return true;
        }
    }

    public static byte[] PacketToBytes(string packet)
    {
        string text = new Regex("^\\.|\\.$").Replace(packet, "");
        if (string.IsNullOrEmpty(text))
        {
            return new byte[1];
        }

        string[] array = text.Split(".");
        using MemoryStream memoryStream = new MemoryStream();
        string[] array2 = array;
        foreach (string text2 in array2)
        {
            byte[] array3 = ((text2.Length <= 63) ? Encoding.UTF8.GetBytes(text2) : text2.HashMessage().HexToBytes());
            if (array3.Length > 255)
            {
                throw new ArgumentException("Label is too long after encoding.");
            }

            memoryStream.WriteByte((byte)array3.Length);
            memoryStream.Write(array3, 0, array3.Length);
        }

        memoryStream.WriteByte(0);
        return memoryStream.ToArray();
    }

    public static async Task<string> GetENSFromAddress(ThirdwebClient client, string address)
    {
        if (string.IsNullOrEmpty(address))
        {
            throw new ArgumentNullException("address");
        }

        if (!address.IsValidAddress())
        {
            throw new ArgumentException("Invalid address.");
        }

        if (_ensCache.TryGetValue(address, out var value))
        {
            return value;
        }

        ThirdwebContract contract = await ThirdwebContract.Create(client, "0xce01f8eee7E479C928F8919abD53E553a36CeF67", 1).ConfigureAwait(continueOnCapturedContext: false);
        string text = address.ToLower();
        byte[] array = PacketToBytes(text.Substring(2, text.Length - 2) + ".addr.reverse");
        string text2 = await contract.Read<string>("reverse", new object[1] { array }).ConfigureAwait(continueOnCapturedContext: false);
        _ensCache[address] = text2;
        return text2;
    }

    public static async Task<string> GetAddressFromENS(ThirdwebClient client, string ensName)
    {
        if (string.IsNullOrEmpty(ensName))
        {
            throw new ArgumentNullException("ensName");
        }

        if (ensName.IsValidAddress())
        {
            return ensName.ToChecksumAddress();
        }

        if (!ensName.Contains('.'))
        {
            throw new ArgumentException("Invalid ENS name.");
        }

        if (_ensCache.TryGetValue(ensName, out var value))
        {
            return value;
        }

        ThirdwebContract contract = await ThirdwebContract.Create(client, "0xce01f8eee7E479C928F8919abD53E553a36CeF67", 1).ConfigureAwait(continueOnCapturedContext: false);
        FunctionCallEncoder functionCallEncoder = new FunctionCallEncoder();
        byte[] array = "addr(bytes32)".HashMessage().HexToBytes().Take(4)
            .ToArray()
            .Concat(functionCallEncoder.EncodeParameters(new Parameter[1]
            {
                new Parameter("bytes32", "name")
            }, NameHash(ensName).HexToBytes()))
            .ToArray();
        string text = (await contract.Read<ResolveReturnType>("resolve(bytes name, bytes data)", new object[2]
        {
            PacketToBytes(ensName),
            array
        }).ConfigureAwait(continueOnCapturedContext: false)).Bytes.BytesToHex();
        string text2 = ("0x" + text.Substring(26, text.Length - 26)).ToChecksumAddress();
        _ensCache[ensName] = text2;
        return text2;
    }

    public static bool IsValidAddress(this string address)
    {
        if (string.IsNullOrEmpty(address))
        {
            return false;
        }

        if (address.StartsWith("0x") && address.Length == 42 && !address.Contains('.'))
        {
            return true;
        }

        return false;
    }

    private static string NameHash(string name)
    {
        string text = "0x0000000000000000000000000000000000000000000000000000000000000000";
        if (!string.IsNullOrEmpty(name))
        {
            name = ENSNormalize.ENSIP15.Normalize(name);
            string[] array = name.Split('.');
            for (int num = array.Length - 1; num >= 0; num--)
            {
                text = (text + array[num].HashMessage()).HexToByteArray().HashMessage().BytesToHex();
            }
        }

        return text.EnsureHexPrefix();
    }

    public static async Task<bool> IsDeployed(ThirdwebClient client, BigInteger chainId, string address)
    {
        return await ThirdwebRPC.GetRpcInstance(client, chainId).SendRequestAsync<string>("eth_getCode", new object[2] { address, "latest" }) != "0x";
    }

    public static async Task<BigInteger> FetchGasPrice(ThirdwebClient client, BigInteger chainId, bool withBump = true)
    {
        BigInteger bigInteger = (await ThirdwebRPC.GetRpcInstance(client, chainId).SendRequestAsync<string>("eth_gasPrice", Array.Empty<object>()).ConfigureAwait(continueOnCapturedContext: false)).HexToBigInt();
        return withBump ? (bigInteger * 10 / 9) : bigInteger;
    }

    public static async Task<(BigInteger maxFeePerGas, BigInteger maxPriorityFeePerGas)> FetchGasFees(ThirdwebClient client, BigInteger chainId, bool withBump = true)
    {
        ThirdwebRPC rpc = ThirdwebRPC.GetRpcInstance(client, chainId);
        if (chainId == (BigInteger)137 || chainId == (BigInteger)80002)
        {
            BigInteger bigInteger = await FetchGasPrice(client, chainId, withBump).ConfigureAwait(continueOnCapturedContext: false);
            return (bigInteger * 3 / 2, bigInteger * 4 / 3);
        }

        if (chainId == (BigInteger)42220 || chainId == (BigInteger)44787 || chainId == (BigInteger)62320)
        {
            BigInteger obj = await FetchGasPrice(client, chainId, withBump).ConfigureAwait(continueOnCapturedContext: false);
            return (obj, obj);
        }

        try
        {
            HexBigInteger hexBigInteger = (await rpc.SendRequestAsync<JObject>("eth_getBlockByNumber", new object[2] { "latest", true }).ConfigureAwait(continueOnCapturedContext: false))["baseFeePerGas"]?.ToObject<HexBigInteger>();
            BigInteger maxFeePerGas = hexBigInteger.Value * 2;
            BigInteger bigInteger2 = (await rpc.SendRequestAsync<HexBigInteger>("eth_maxPriorityFeePerGas", Array.Empty<object>()).ConfigureAwait(continueOnCapturedContext: false))?.Value ?? (maxFeePerGas / 2);
            if (bigInteger2 > maxFeePerGas)
            {
                bigInteger2 = maxFeePerGas / 2;
            }

            return (maxFeePerGas + bigInteger2 * 10 / 9, bigInteger2 * 10 / 9);
        }
        catch
        {
            BigInteger obj2 = await FetchGasPrice(client, chainId, withBump).ConfigureAwait(continueOnCapturedContext: false);
            return (obj2, obj2);
        }
    }

    public static IThirdwebHttpClient ReconstructHttpClient(IThirdwebHttpClient httpClient, Dictionary<string, string> defaultHeaders = null)
    {
        IThirdwebHttpClient thirdwebHttpClient = httpClient.GetType().GetConstructor(Type.EmptyTypes).Invoke(null) as IThirdwebHttpClient;
        if (defaultHeaders != null)
        {
            thirdwebHttpClient.SetHeaders(defaultHeaders ?? httpClient.Headers);
        }

        return thirdwebHttpClient;
    }

    public static async Task<SocialProfiles> GetSocialProfiles(ThirdwebClient client, string addressOrEns)
    {
        if (string.IsNullOrEmpty(addressOrEns))
        {
            throw new ArgumentNullException("addressOrEns");
        }

        if (!addressOrEns.IsValidAddress() && !addressOrEns.Contains('.'))
        {
            throw new ArgumentException("Invalid address or ENS.");
        }

        addressOrEns = (await GetAddressFromENS(client, addressOrEns).ConfigureAwait(continueOnCapturedContext: false)) ?? addressOrEns;
        string requestUri = "https://social.thirdweb.com/v1/profiles/" + addressOrEns;
        SocialProfileResponse socialProfileResponse = JsonConvert.DeserializeObject<SocialProfileResponse>(await (await client.HttpClient.GetAsync(requestUri).ConfigureAwait(continueOnCapturedContext: false)).Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false));
        if (socialProfileResponse == null || socialProfileResponse.Error != null)
        {
            throw new Exception("Failed to fetch social profiles for address " + addressOrEns + ". Error: " + socialProfileResponse?.Error);
        }

        return new SocialProfiles(socialProfileResponse.Data);
    }
}
#if false // Decompilation log
'262' items in cache
------------------
Resolve: 'netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Found single assembly: 'netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Load from: 'D:\Unity(new)\2022.3.17f1\Editor\Data\NetStandard\ref\2.1.0\netstandard.dll'
------------------
Resolve: 'Nethereum.Contracts, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Found single assembly: 'Nethereum.Contracts, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Load from: 'D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\Nethereum.Contracts.4.19.0\lib\netstandard2.0\Nethereum.Contracts.dll'
------------------
Resolve: 'Nethereum.ABI, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Found single assembly: 'Nethereum.ABI, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Load from: 'D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\Nethereum.ABI.4.19.0\lib\netstandard2.0\Nethereum.ABI.dll'
------------------
Resolve: 'Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed'
Found single assembly: 'Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed'
Load from: 'D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\Newtonsoft.Json.13.0.3\lib\netstandard2.0\Newtonsoft.Json.dll'
------------------
Resolve: 'Nethereum.Hex, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Found single assembly: 'Nethereum.Hex, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Load from: 'D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\Nethereum.Hex.4.19.0\lib\netstandard2.0\Nethereum.Hex.dll'
------------------
Resolve: 'Nethereum.Signer, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Found single assembly: 'Nethereum.Signer, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Load from: 'D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\Nethereum.Signer.4.19.0\lib\netstandard2.0\Nethereum.Signer.dll'
------------------
Resolve: 'Nethereum.Model, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Found single assembly: 'Nethereum.Model, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Load from: 'D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\Nethereum.Model.4.19.0\lib\netstandard2.0\Nethereum.Model.dll'
------------------
Resolve: 'Nethereum.RPC, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Found single assembly: 'Nethereum.RPC, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Load from: 'D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\Nethereum.RPC.4.19.0\lib\netstandard2.0\Nethereum.RPC.dll'
------------------
Resolve: 'Nethereum.JsonRpc.Client, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Found single assembly: 'Nethereum.JsonRpc.Client, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Load from: 'D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\Nethereum.JsonRpc.Client.4.19.0\lib\netstandard2.0\Nethereum.JsonRpc.Client.dll'
------------------
Resolve: 'Nethereum.Accounts, Version=4.14.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Found single assembly: 'Nethereum.Accounts, Version=4.14.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Load from: 'D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\Nethereum.Accounts.4.14.0\lib\netstandard2.0\Nethereum.Accounts.dll'
------------------
Resolve: 'Nethereum.Util, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Found single assembly: 'Nethereum.Util, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Load from: 'D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\Nethereum.Util.4.19.0\lib\netstandard2.0\Nethereum.Util.dll'
------------------
Resolve: 'ADRaffy.ENSNormalize, Version=0.1.5.0, Culture=neutral, PublicKeyToken=null'
Found single assembly: 'ADRaffy.ENSNormalize, Version=0.1.5.0, Culture=neutral, PublicKeyToken=null'
Load from: 'D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\ADRaffy.ENSNormalize.0.1.5\lib\netstandard2.0\ADRaffy.ENSNormalize.dll'
------------------
Resolve: 'Nethereum.RLP, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Found single assembly: 'Nethereum.RLP, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Load from: 'D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\Nethereum.RLP.4.19.0\lib\netstandard2.0\Nethereum.RLP.dll'
------------------
Resolve: 'Nethereum.Signer.EIP712, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Found single assembly: 'Nethereum.Signer.EIP712, Version=4.19.0.0, Culture=neutral, PublicKeyToken=8768a594786aba4e'
Load from: 'D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\Nethereum.Signer.EIP712.4.19.0\lib\netstandard2.0\Nethereum.Signer.EIP712.dll'
------------------
Resolve: 'BouncyCastle.Crypto, Version=1.9.0.0, Culture=neutral, PublicKeyToken=0e99375e54769942'
Found single assembly: 'BouncyCastle.Crypto, Version=1.9.0.0, Culture=neutral, PublicKeyToken=0e99375e54769942'
Load from: 'D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\Portable.BouncyCastle.1.9.0\lib\netstandard2.0\BouncyCastle.Crypto.dll'
------------------
Resolve: 'System.Runtime.InteropServices, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null'
Found single assembly: 'System.Runtime.InteropServices, Version=4.1.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
WARN: Version mismatch. Expected: '2.1.0.0', Got: '4.1.2.0'
Load from: 'D:\Unity(new)\2022.3.17f1\Editor\Data\NetStandard\compat\2.1.0\shims\netstandard\System.Runtime.InteropServices.dll'
------------------
Resolve: 'System.Runtime.CompilerServices.Unsafe, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null'
Could not find by name: 'System.Runtime.CompilerServices.Unsafe, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null'
#endif
