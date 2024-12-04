
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Thirdweb;
using System.Numerics;
using System.Threading.Tasks;
using Thirdweb.Unity;

using Nethereum.BlockchainProcessing.BlockStorage.Entities;
using Newtonsoft.Json;

public class UserWalletController : Singleton<UserWalletController>
{

    private ThirdwebContract tokenContract;
    private ThirdwebContract nftContract;
    private const string TOKEN_CONTRACT_ADDRESS = "0xb99192491aB525d7b1775b95A2560b8095B89B89";
    private const string NFT_CONTRACT_ADDRESS = "0x59526D97Bdd2450Ba8C246d58434d8942256eE39";
    private const string DEV_WALLET_ADDRESS = "0x9eD54f75893Fa84f1aAC8a3a883fdDaF42c79Dae";
    private const int CHAIN_ID = 56; // BSC Mainnet

    private string activeWalletAddress;

    private const int MAX_NFT_TYPE = 8;

    async void Start()
    {
        //try
        //{
        //    // Kết nối với smart contract token thông qua ThirdwebManager
        //    tokenContract = await ThirdwebManager.Instance.GetContract(TOKEN_CONTRACT_ADDRESS, CHAIN_ID);

        //    activeWalletAddress = await ThirdwebManager.Instance.GetActiveWallet().GetAddress(); 
           
        //}
        //catch (System.Exception e)
        //{
        //    Debug.LogError($"Error initializing contract: {e.Message}");
        //}

        //List<int> result = await GetNftOwn();

        //Debug.Log(JsonConvert.SerializeObject(result));
    }

    public async Task<bool> DepositToken(int cost)
    {
        try
        {
            BigInteger amount = cost * BigInteger.Pow(10, 18);
            //token
            await tokenContract.ERC20_Transfer(ThirdwebManager.Instance.ActiveWallet, DEV_WALLET_ADDRESS, amount);

        }
        catch (System.Exception e)
        {
            return false;
        }

        return true;
    }

    public async Task<List<int>> GetNftOwn()
    {
        List<int> nftOwned = new List<int>();

        try
        {
            nftContract = await ThirdwebManager.Instance.GetContract(NFT_CONTRACT_ADDRESS, CHAIN_ID);

            for(int i =0; i < MAX_NFT_TYPE; i++)
            {
                string addressWalletOwn = await nftContract.ERC721_OwnerOf(i);

                if (addressWalletOwn == activeWalletAddress)
                {
                    nftOwned.Add(i);
                }
            }

          
        }
        catch (System.Exception e)
        {
            Debug.Log("error when get nft : " + e.Message);
        }

        return nftOwned;
    }

}