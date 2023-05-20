amazon.Pay.renderButton('#AmazonPayButton',
    {        
        merchantId: 'A11TDGUOI15DHQ',
        ledgerCurrency: 'USD',
        sandbox: true,        
        checkoutLanguage: 'en_US',
        productType: 'PayAndShip',
        placement: 'Cart',
        buttonColor: 'Gold',        
        createCheckoutSessionConfig:
        {
            payloadJSON: '@Html.Raw(Model.Payload)',
            signature: '@Html.Raw(Model.Signature)',
            publicKeyId: 'SANDBOX-AHWZZO6U5W52OQKJXLCV3RUJ',
            algorithm: 'AMZN-PAY-RSASSA-PSS-V2'
        }
    });
    

   
    
