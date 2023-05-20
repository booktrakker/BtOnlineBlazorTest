using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using ErrorReporting;
//using Amazon.CBUI;
using Amazon.FPS;
using Amazon.FPS.Model;
using System.Collections.Specialized;
using Amazon.IpnReturnUrlValidation;
using ErrorReporting;
using System.Configuration;

namespace BTOnlineBlazor
{
    class AmazonFpsUtils
    {

        private static ErrorReporter errReport;

        private string amzCBUI = "";

        //Sandbox Here

        //Developer@booktrakker.com  Keys
        private static string AWSaccessKey = "1S84GVBG6NM3C23VACR2";
        private static string btSecretKey = "ZUqBjFVvcJepaEE5pdLFNz+xkF6Gw/fLM0SFCHel"; 

        
        //support@booktrakker.com keys
        //private static string AWSaccessKey = "AKIAJ4QTK2RAULLYCZMQ";
        //private static string btSecretKey = "ZojTPvlDvN9SP1Kd1L" + "rMuvXpAg8guOjDXNqG1oPY";


        //Unknown keys
        //private static string AWSaccessKey = "AKIAIB7AQAM7H5YZ7MKQ";
        //private static string btSecretKey = "tnCQjpLaxlAocbp4/O" + "9ip1J4fqgQ8Lm3rRY8Z1L5";

        //Production BT Endpoints
        private static string ReturnUrl = "http://www.booktrakker.net/AmazonCBUIcomplete.aspx";
        private static string IPNurl = "https://www6554.ssldomain.com/booktrakker/AmazonIPN.ashx";

        //WIN7DEV Endpoints
        //private static string IPNurl = "http://xgecko.dyndns.org/BT_Online/AmazonIPN.ashx";
        //private static string ReturnUrl = "http://xgecko.dyndns.org/BT_Online/AmazonCBUIcomplete.aspx";

        //Geckoserver Endpoints
        //private static string IPNurl = "http://xgecko.dyndns.org/AmazonIPN.ashx";
        //private static string ReturnUrl = "http://xgecko.dyndns.org/AmazonCBUIcomplete.aspx";

        //public AmazonFPS()
        //{
        //    try
        //    {
        //        SetupErrorReporting();
        //    }
        //    catch (Exception ex)
        //    {
        //        errReport.LogErr(ex);
        //    }
        //}

        //private void SetupErrorReporting()
        //{
        //    try
        //    {
        //        Guid refID = new Guid();

        //        amzCBUI = "https://authorize.payments-sandbox.amazon.com/cobranded-ui/actions/start?";
        //        amzCBUI += "callerKey=AKIAIB7AQAM7H5YZ7MKQ";
        //        amzCBUI += "&callerReference=" + refID.ToString();
        //        amzCBUI += "&currencyCode=USD";
        //        amzCBUI += "&paymentMethod=ABT,ACH,CC";
        //        amzCBUI += "&paymentReason=BookTrakker%20Subscription";
        //        amzCBUI += "&pipelineName=Recurring-use";
        //        amzCBUI += "&returnURL=" + ReturnUrl;
        //        amzCBUI += "&signature=[calculated signature value]";
        //        amzCBUI += "&signatureMethod=HmacSHA256";
        //        amzCBUI += "&signatureVersion=2";
        //        amzCBUI += "&transactionAmount=0.90";
        //        amzCBUI += "&version=2009-01-09";
        //    }
        //    catch (Exception ex)
        //    {
        //        errReport.LogErr(ex);
        //    }
        //}
        private static void Initialize()
        {
            try
            {
                string connection = ConfigurationManager.ConnectionStrings["Subscription_DatabaseConnectionString"].ConnectionString;
                errReport = new ErrorReporter("BTOnline", "1.0.0", connection, ErrorReporter.DbMode);
                //errReport.LogMessage("Test Message");
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }
        }


        //public static string GetCBUI_URL(string PaymentAmount, string PaymentTerm, int TermLength, string callerReference)
        //{
        //    string url = "";
        //    try
        //    {
        //        Initialize();
        //        if (PaymentAmount != "")
        //        {
        //            TermLength = TermLength * 12;

        //            decimal globalAmount = decimal.Parse(PaymentAmount) * TermLength;

        //            DateTime expireDate = DateTime.Now.AddMonths(TermLength);

        //            DateTime epoch = new DateTime(1970, 1, 1);

        //            double expireTime = expireDate.Subtract(epoch).TotalSeconds;

        //            expireTime = Math.Round(expireTime, 0);

        //            errReport.LogMessage("Expire Time Value: " + expireTime.ToString());
        //            AmazonFPSMultiUsePipeline pipeline = new AmazonFPSMultiUsePipeline(AWSaccessKey, btSecretKey);

        //            pipeline.setMandatoryParameters("callerReferenceMultiUse", ReturnUrl, PaymentAmount);

        //            //optional parameters
        //            pipeline.addParameter("paymentMethod", "ABT,ACH,CC"); //accept credit card payments, Bank transfers and Amazon AccountID Transfers
        //            pipeline.addParameter("paymentReason", "BookTrakker Subscription");
        //            pipeline.addParameter("callerReference", callerReference);
        //            pipeline.addParameter("amountType", "Exact");
        //            pipeline.addParameter("transactionAmount", PaymentAmount);
        //            //pipeline.addParameter("usageLimitType1", "Amount");
        //            //pipeline.addParameter("usageLimitValue1", PaymentAmount);
        //            //pipeline.addParameter("usageLimitPeriod1", PaymentTerm);
        //            pipeline.addParameter("usageLimitType1", "Count");
        //            pipeline.addParameter("usageLimitValue1", TermLength.ToString());
        //            pipeline.addParameter("usageLimitPeriod1", TermLength.ToString() + " Months"); 
        //            pipeline.addParameter("globalAmountLimit", globalAmount.ToString());
        //            pipeline.addParameter("validityExpiry", expireTime.ToString());
        //            //pipeline.addParameter("websiteDescription", "BookTrakker");




        //            //RecurringToken url
        //            url = pipeline.getURL();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        errReport.LogErr(ex);
        //    }
        //    return url;
        //}

        public static PayResult GetPayment(string CallerReference, string TokenID, decimal TransactionAmount)
        {
            
            try
            {
                Initialize();
                Amount amount = new Amount();
                amount.Value = TransactionAmount.ToString();
                amount.CurrencyCode = CurrencyCode.USD;

                /************************************************************************
                * Instantiate  Implementation of Amazon FPS 
                ***********************************************************************/
                AmazonFPS service = new AmazonFPSClient(AWSaccessKey, btSecretKey);

                /************************************************************************
                * Uncomment to invoke Pay Action
                ***********************************************************************/
                PayRequest request = new PayRequest();
                // @TODO: set request parameters here
                request.CallerReference = CallerReference;
                request.SenderTokenId = TokenID;
                request.TransactionAmount = amount;
                request.OverrideIPNURL = IPNurl;
                
                return InvokePay(service, request);
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }

            return null;
        }

        /// <summary>
        /// 
        /// Allows calling applications to move money from a sender to a recipient.
        /// 
        /// </summary>
        /// <param name="service">Instance of AmazonFPS service</param>
        /// <param name="request">PayRequest request</param>
        public static PayResult InvokePay(AmazonFPS service, PayRequest request)
        {
            try
            {
                Initialize();
                PayResponse response = service.Pay(request);
                
                if (response.IsSetPayResult())
                {
                    
                    PayResult payResult = response.PayResult;

                    return payResult;
                }
                //if (response.IsSetResponseMetadata())
                //{
                    
                //    ResponseMetadata responseMetadata = response.ResponseMetadata;
                //    if (responseMetadata.IsSetRequestId())
                //    {
                //        responseMetadata.RequestId;
                //    }
                //}

            }
            catch (AmazonFPSException ex)
            {
                //errReport.LogErr(ex);
                string msg = "Amazon Payments Error: ";
                
                msg += "CallerReference: " + request.CallerReference;
                msg += " Caught Exception: " + ex.Message;
                msg += " Response Status Code: " + ex.StatusCode;
                msg += " Error Code: " + ex.ErrorCode;
                msg += " Error Type: " + ex.ErrorType;
                msg += " Request ID: " + ex.RequestId;
                msg += " XML: " + ex.XML;
                errReport.LogMessage(msg);
                
            }
            return null;
        }

        public static string GetTransactionStatus(string TransactionID)
        {
            string status = "";
            try
            {
                Initialize();
                AmazonFPS service = new AmazonFPSClient(AWSaccessKey, btSecretKey);

                GetTransactionStatusRequest request = new GetTransactionStatusRequest();

                request.TransactionId = TransactionID;

                GetTransactionStatusResponse response = service.GetTransactionStatus(request);

                if (response.IsSetGetTransactionStatusResult())
                {
                    
                    GetTransactionStatusResult getTransactionStatusResult = response.GetTransactionStatusResult;
                    if (getTransactionStatusResult.IsSetTransactionId())
                    {
                        //getTransactionStatusResult.TransactionId;
                    }
                    if (getTransactionStatusResult.IsSetTransactionStatus())
                    {
                        //TransactionStatus transactionStatus = 
                        status = getTransactionStatusResult.TransactionStatus.ToString().ToUpper();
                    }
                    //if (getTransactionStatusResult.IsSetCallerReference())
                    //{
                    //    Console.WriteLine("                CallerReference");
                    //    Console.WriteLine("                    {0}", getTransactionStatusResult.CallerReference);
                    //}
                    //if (getTransactionStatusResult.IsSetStatusCode())
                    //{
                    //    Console.WriteLine("                StatusCode");
                    //    Console.WriteLine("                    {0}", getTransactionStatusResult.StatusCode);
                    //}
                    //if (getTransactionStatusResult.IsSetStatusMessage())
                    //{
                    //    Console.WriteLine("                StatusMessage");
                    //    Console.WriteLine("                    {0}", getTransactionStatusResult.StatusMessage);
                    //}
                }

            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }

            return status;
        }

        public static bool VerifyIPN(string Parameters)
        {
            bool result = false;
            try
            {
                Initialize();
                if (Parameters != "")
                {
                    AmazonFPS service = new AmazonFPSClient(AWSaccessKey, btSecretKey);
                    VerifySignatureRequest request = new VerifySignatureRequest();

                    request.UrlEndPoint = IPNurl;
                    request.HttpParameters = Parameters;

                    VerifySignatureResponse response = service.VerifySignature(request);

                    if (response.IsSetVerifySignatureResult())
                    {

                        VerifySignatureResult verifyResult = response.VerifySignatureResult;

                        if (verifyResult.IsSetVerificationStatus())
                        {
                            result = verifyResult.VerificationStatus == VerificationStatus.Success;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }
            return result;
        }

        public static bool VerifyIPN(NameValueCollection urlParameters)
        {
            bool result = false;
            try
            {
                Initialize();
                IDictionary<String, String> parameters = new Dictionary<String, String>();

                SignatureUtilsForOutbound utils = new SignatureUtilsForOutbound();

                foreach (string key in urlParameters)
                {

                    parameters.Add(key,urlParameters[key]);

                }


                //Parameters present in ipn.
                //parameters.Add("transactionId", "14DRG2JGR7LK4J54P544DKKNDLQFFZLE323");
                //parameters.Add("transactionDate", "1251832057");
                //parameters.Add("status", "INITIATED");
                //parameters.Add("notificationType", "TransactionStatus");
                //parameters.Add("callerReference", "callerReference=ReferenceStringJYI1251832057319108");
                //parameters.Add("operation", "PAY");
                //parameters.Add("transactionAmount", "USD 1.00");
                //parameters.Add("buyerName", "BuyerName-SsUo3oDjHx");
                //parameters.Add("paymentMethod", "CC");
                //parameters.Add("paymentReason", "DescriptionString-1251832057319108");
                //parameters.Add("recipientEmail", "recipientemail@amazon.com");
                //parameters.Add("signatureMethod", "RSA-SHA1");
                //parameters.Add("signatureVersion", "2");
                //parameters.Add("certificateUrl", "https://fps.amazonaws.com/certs/090909/PKICert.pem");
                //parameters.Add("signature", "vKXXCbtxvSkRR+Zn8YNW6DNGpbi474h2iM4L+xaOi16kYKdYpuGbvKyXQ36uTZTVHdUGAAcvpXFL"
                //        + "wDfnTcqcckr2IUElrVJKQeT0WeWR+IqmABwSRGo+YqjzPNISSNXNzg6LFhouhUvmmwY15X3YgXfc"
                //        + "ERN5IhPwv04YkyCLPCA9P0/QgD8Jum/hc9jj0HYjj3s3MuuQ3yoIhf2x+2CBZRm5lslRqnoF/8OJ"
                //        + "1ZHmAHt9VvQSZ+QC3fwJgeqzJPAvtuOm930BP6hPYZVhXE5w7ByLt0qLk1ZFE/vzQ4io4vOyie6W"
                //        + "bhp5+AuNyAs+QrGMYO8VZruZJfkZO4b6QOgV2A==");

                //String urlEndPoint = "http://www.mysite.com/ipn.jsp"; //Your url end point receiving the ipn. 
                //Console.WriteLine("Verifying IPN signed using signature v2 ....");
                //IPN is sent as a http POST request and hence we specify POST as the http method.
                //Signature verification does not require your secret key

                result = utils.ValidateRequest(parameters, IPNurl, "POST");
                
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }
            return result;
        }

        public static string CancelToken(string TokenID, string Reason)
        {
            string result = "";

            try
            {
                Initialize();
                AmazonFPS service = new AmazonFPSClient(AWSaccessKey, btSecretKey);
                CancelTokenRequest request = new CancelTokenRequest();

                request.TokenId = TokenID;
                request.ReasonText = Reason;

                CancelTokenResponse response = service.CancelToken(request);

                if (response.IsSetResponseMetadata())
                {
                    
                    ResponseMetadata responseMetadata = response.ResponseMetadata;
                    if (responseMetadata.IsSetRequestId())
                    {

                        result = responseMetadata.RequestId;
                    }
                }

            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }

            return result;
        }
        
    }
}
