<%@ Page Language="C#" AutoEventWireup="true" CodeFile="plans.aspx.cs" Inherits="app_plans" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>     
    <link href="styling/css/reset.css" rel="stylesheet"/> 
    <link href="styling/css/idecode.css" rel="stylesheet"/>
    <link href='http://fonts.googleapis.com/css?family=PT+Sans:400,700,400italic,700italic' rel='stylesheet' type='text/css'/>
    <style>
        * {
            font-family: 'PT Sans', sans-serif !Important;
        }
        h1 {
            font-weight:normal !Important;
            margin:0px auto 20px auto;
            text-align:center;
            font-size:40px;
            color:#fff;
            padding-top:80px;
            
        }
        body {
            background-color:#fff;
        }
        span {
            color:#fff;
            text-align:center;
            display:block;
            color:#8e9aab;
        }
        .Packages {
            width: 600px;
            margin: -120px auto 0 auto;
            box-shadow: 0px 3px 15px #000;
            min-height: 450px;
            margin-bottom:50px;
        }
        .PackageItemHeader{
            background-color:#ecf0f6;
            width:300px;
            height:120px;
            color:#8e9aab;
            text-align:center;
        }
        .PackageItem {
            float:left;
            width:300px;
            min-height: 450px;
        }
        .p {
          font-size: 60px;
          padding-top: 42px;
          margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <div>
                <div style="background-color: #222;border-color: #090909;height:70px">
                    <div style="width:960px; margin:0 auto"><img src="styling/images/logo.png" style="width: 230px;margin-top: 10px;" /></div>
                </div>
            </div>
            <div style="width:100%; background-color:#3b4557; height:300px">
                <h1>Choose Your Package</h1>
                <span>No setup fee, minimum 12 months for paid-for subscriptions.</span>
            </div>
            <div class="Packages">
                <div class="PackageItem">
                    <div class="PackageItemHeader">
                        <div class="PackagePrice">
                            <span class="p">FREE</span><span>for 6 months.</span>
                        </div>
                    </div>
                    <div class="PackageItemContent">
                        <div></div>
                    </div>
                    <div class="GetPackageButton">
                        <asp:Button runat="server" ID="btnGetFreePackage" Text="Get Package" OnClick="btnGetFreePackage_Click" /> 
                    </div>
                </div>
                <div class="PackageItem">
                    <div class="PackageItemHeader">
                        <div class="PackagePrice">
                            <span class="p">99<span style="  font-size: 15px;margin-top: -28px; margin-left: 86px;">00</span></span><span style="padding-top: 12px;">ZAR/month</span>
                        </div>
                    </div>
                    <div class="PackageItemContent">

                    </div>
                    <div class="GetPackageButton">
                        <asp:Button runat="server" ID="btnGet99Package" Text="Get Package" OnClick="btnGet99Package_Click" /> 
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
