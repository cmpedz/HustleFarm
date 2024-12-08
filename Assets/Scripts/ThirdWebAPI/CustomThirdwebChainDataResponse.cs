#region Assembly Thirdweb, Version=2.5.1.0, Culture=neutral, PublicKeyToken=null
// D:\Unity(new)\myProject\HustleFarm\Assets\Thirdweb\Runtime\NET\Thirdweb.dll
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using Newtonsoft.Json;

using Thirdweb;

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class CustomThirdwebChainDataResponse
{
    public CustomThirdwebChainDataResponse() { }

    [JsonProperty("data")]
    public CustomThirdwebChainData Data { get; set; }

    [JsonProperty("error")]
    public object Error { get; set; }
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
