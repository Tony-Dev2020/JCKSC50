﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resetpassword.aspx.cs" Inherits="resetpassword" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Vendor User Register</title>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<script type="text/javascript" src="../js/jquery.autocomplete.min.js"></script>
<link rel="Stylesheet" href="../css/jquery.autocomplete.css" />
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
</script>
</head>
<body>
    <form id="form1" runat="server">

    
    <div class="formbody">   
    <div class="formtitle"><span>Reset Password</span></div>
    <!--用户信息-->
<div class="tab-content">
  
<dl>
    <dt>User Name</dt>
    <dd><asp:TextBox ID="txtUserName" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9\-\_]{2,50}$/" sucmsg=" " ></asp:TextBox> <span class="Validform_checktip">*leter、underline、number</span></dd>
  </dl> 

 <dl>
    <dt>Email</dt>
    <dd><asp:TextBox ID="txtEmailAddress" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
<dl>
    <dt>Temp Password</dt>
    <dd><asp:TextBox ID="txtTempPassword" runat="server" CssClass="input normal" TextMode="Password" datatype="*6-20" nullmsg="Please input temp password" errormsg="legth 6-20" sucmsg=" " ></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
<dl>
    <dt>Password</dt>
    <dd><asp:TextBox ID="txtPassword" runat="server" CssClass="input normal" TextMode="Password" datatype="*6-20" nullmsg="Please input password" errormsg="legth 6-20" sucmsg=" " ></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
  <dl>
    <dt>Confirm password</dt>
    <dd><asp:TextBox ID="txtPassword1" runat="server" CssClass="input normal" TextMode="Password" datatype="*" recheck="txtPassword" nullmsg="Please input password again" errormsg="password is not match" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
 <dl>
     <dt></dt>
     <dd>
        <div class="btn-list">
            <asp:Button ID="btnSubmit" runat="server" Text="Reset" CssClass="btn sliver" onclick="btnSubmit_Click"  />
        </div>
    </dd>
  </dl>

</div> 
    </div>



    
    </form>
</body>
</html>
