// Assets/Scripts/WalletSystem/UserWalletController.cs
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Thirdweb;
using System.Numerics;
using System.Threading.Tasks;
using Thirdweb.Unity;

public class UserWalletController : MonoBehaviour
{
    [SerializeField] private Button despositeButton;
    [SerializeField] private Button widthDrawButton;
    [SerializeField] private TextMeshProUGUI balance;

    private ThirdwebContract tokenContract;
    private const string TOKEN_CONTRACT_ADDRESS = "0xb99192491aB525d7b1775b95A2560b8095B89B89";
    private const string DEV_WALLET_ADDRESS = "0x9eD54f75893Fa84f1aAC8a3a883fdDaF42c79Dae";
    private const int CHAIN_ID = 56; // BSC Mainnet

    async void Start()
    {
        try 
        {
            // Kết nối với smart contract token thông qua ThirdwebManager
            tokenContract = await ThirdwebManager.Instance.GetContract(TOKEN_CONTRACT_ADDRESS, CHAIN_ID);

            // Thêm listener cho các button
            despositeButton.onClick.AddListener(OnDepositButtonClicked);
            widthDrawButton.onClick.AddListener(OnWithdrawButtonClicked);

            // Cập nhật số dư ban đầu
            await UpdateBalance();
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error initializing contract: {e.Message}");
        }
    }

    private async void OnDepositButtonClicked()
    {
        await DepositToken();
    }

    private async void OnWithdrawButtonClicked()
    {
        await WithdrawToken();
    }

    private async Task UpdateBalance()
    {
       
    }

    private async Task DepositToken()
    {
        try 
        {
            BigInteger _default = BigInteger.Pow(10,18);
            await tokenContract.ERC20_Transfer(ThirdwebManager.Instance.ActiveWallet, DEV_WALLET_ADDRESS, _default);

        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error minting tokens: {e.Message}");
        }
    }

    private async Task WithdrawToken()
    {
        try
        {
            BigInteger _default = BigInteger.Pow(10, 18);
            await tokenContract.ERC20_Transfer(ThirdwebManager.Instance.ActiveWallet, ThirdwebManager.Instance.ActiveWallet.GetAddress().Result, _default);

        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error minting tokens: {e.Message}");
        }
    }
}