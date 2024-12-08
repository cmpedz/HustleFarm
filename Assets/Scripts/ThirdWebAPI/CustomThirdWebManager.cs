using System.Collections;
using System.Collections.Generic;
using Thirdweb.Unity.Examples;
using Thirdweb.Unity;
using Thirdweb;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.Events;

[System.Serializable]
public class WalletPanelUI
{
    public string Identifier;
 
}

public class CustomThirdWebManager : MonoBehaviour
{
    [field: SerializeField, Header("Wallet Options")]
    private ulong ActiveChainId = 421614;

    [field: SerializeField]
    private bool WebglForceMetamaskExtension = false;

    [field: SerializeField]
    private Button WalletConnectButton;

    [field: SerializeField, Header("Wallet Panels")]
    private List<WalletPanelUI> WalletPanels;

    private ThirdwebChainData _chainDetails;

  
    [SerializeField] private string userId;

    [SerializeField] private UnityEvent changeSceneEvent;

    private void Awake()
    {
        InitializePanels();
    }

    private async void Start()
    {
        try
        {
            _chainDetails = await Utils.GetChainMetadata(client: ThirdwebManager.Instance.Client, chainId: ActiveChainId);
        }
        catch
        {
            _chainDetails = new ThirdwebChainData()
            {
                NativeCurrency = new ThirdwebChainNativeCurrency()
                {
                    Decimals = 18,
                    Name = "ETH",
                    Symbol = "ETH"
                }
            };
        }
    }

    private void InitializePanels()
    {

      
        WalletConnectButton.onClick.RemoveAllListeners();
        WalletConnectButton.onClick.AddListener(() =>
        {
            var options = GetWalletOptions(WalletProvider.WalletConnectWallet);
            ConnectWallet(options);
            //InstanceUserGeneralInfors.Instance.UserId = "Errors";

            //changeSceneEvent.Invoke();
        });
    }

    private async void ConnectWallet(WalletOptions options)
    {
        // Connect the wallet

        var internalWalletProvider = options.Provider == WalletProvider.MetaMaskWallet ? WalletProvider.WalletConnectWallet : options.Provider;
        
        Debug.Log("check internalWalletProvider : " +  internalWalletProvider); 

        var currentPanel = WalletPanels.Find(panel => panel.Identifier == internalWalletProvider.ToString());


        var wallet = await ThirdwebManager.Instance.ConnectWallet(options);

        //get address 
        var address = await wallet.GetAddress();
        Debug.Log("check address : " + address);

        InstanceUserGeneralInfors.Instance.UserId = address;

        changeSceneEvent.Invoke();

    }


    private WalletOptions GetWalletOptions(WalletProvider provider)
    {
        switch (provider)
        {
            case WalletProvider.PrivateKeyWallet:
                return new WalletOptions(provider: WalletProvider.PrivateKeyWallet, chainId: ActiveChainId);
            case WalletProvider.InAppWallet:
                var inAppWalletOptions = new InAppWalletOptions(authprovider: AuthProvider.Google);
                return new WalletOptions(provider: WalletProvider.InAppWallet, chainId: ActiveChainId, inAppWalletOptions: inAppWalletOptions);
            case WalletProvider.WalletConnectWallet:
                var externalWalletProvider =
                    Application.platform == RuntimePlatform.WebGLPlayer && WebglForceMetamaskExtension ? WalletProvider.MetaMaskWallet : WalletProvider.WalletConnectWallet;
                return new WalletOptions(provider: externalWalletProvider, chainId: ActiveChainId);
            default:
                throw new System.NotImplementedException("Wallet provider not implemented for this example.");
        }
    }

 

   
   
}
