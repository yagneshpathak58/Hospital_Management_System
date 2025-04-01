<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.Index" %>

<!DOCTYPE html>

<html class="h-100" lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <title>Quixlab - Bootstrap Admin Dashboard Template by Themefisher.com</title>
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="../../assets/images/favicon.png">
    <!-- <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous"> -->
    <link href="css/style.css" rel="stylesheet">
</head>
<body class="h-100">

    <!--*******************
        Preloader start
    ********************-->
    <div id="preloader">
        <div class="loader">
            <svg class="circular" viewBox="25 25 50 50">
                <circle class="path" cx="50" cy="50" r="20" fill="none" stroke-width="3" stroke-miterlimit="10" />
            </svg>
        </div>
    </div>
    <!--*******************
        Preloader end
    ********************-->

    <div class="login-form-bg h-100">
        <div class="container h-100">
            <div class="row justify-content-center h-100">
                <div class="col-xl-6">
                    <div class="form-input-content">
                        <div class="card login-form mb-0">
                            <div class="card-body pt-5">
                                <a class="text-center">
                                    <h4>HMS</h4>
                                </a>

                                <form class="mt-5 mb-5 login-input" runat="server">
                                    <asp:Panel ID="pnlAlertD" runat="server" CssClass="alert alert-danger" Visible="false">
                                        <asp:Label ID="lblMessageD" runat="server" Text="This is a danger alert—check it out!"></asp:Label>
                                    </asp:Panel>
                                    <div class="form-group">
                                        <%--<input type="email" class="form-control" placeholder="Email">--%>
                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter User"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <%--<button class="btn login-form__btn submit w-100">Sign In</button>--%>
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn login-form__btn submit w-100" OnClick="btnLogin_Click" />
                                </form>
                                <p class="mt-5 login-form__footer">Dont have account? <a href="page-register.html" class="text-primary">Sign Up</a> now</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>




    <!--**********************************
        Scripts
    ***********************************-->
    <script src="plugins/common/common.min.js"></script>
    <script src="js/custom.min.js"></script>
    <script src="js/settings.js"></script>
    <script src="js/gleek.js"></script>
    <script src="js/styleSwitcher.js"></script>
</body>
</html>
