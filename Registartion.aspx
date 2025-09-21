<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registartion.aspx.cs" Inherits="Banking_Customer_Regstartion_App.Registartion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="bootstrap.css" rel="stylesheet" />
     <script>
         function validate() {
             let name = document.getElementById("txtName").value;
             let address = document.getElementById("txtAdd").value;
             let accountSelected = document.getElementById("ddlAccounts").SelectedIndex;

             if (name.trim().length ==0) {
                 document.getElementById("lblMsg").innerHTML = "Enter Your Name Please";
                 document.getElementById("lblMsg").style = "color:red";
                 return false
             }
             else if (address.trim().length == 0) {
                 document.getElementById("lblMsg").innerHTML = "Enter Your Address Please";
                 document.getElementById("lblMsg").style = "color:red";
                 return false;
             }
             else if (accountSelected==0) {
                 document.getElementById("lblMsg").innerHTML = "Please Choose Your Account Type";
                 document.getElementById("lblMsg").style = "color:red";
                 return false;
             }
         }
     </script>
</head>

<body>
    <form id="form1" runat="server">
       <center> <div>
            <div style="width:50%; border:solid thin black; padding:20px;">
                <center>
                    <h1>Customer  Managemnet</h1>
                </center>
            </div>
             <hr />

 <div>
     <div style="width:40%; border:solid thin black; padding:20px;  display:inline-block" >
         <div >
             Account No: 
             <asp:Label ID="lblAccNum" runat="server" Text="Label"></asp:Label>
              
         </div><br />
         <div>Name : 
             <asp:TextBox ID="txtName" runat="server" CssClass="form-control" ></asp:TextBox>
              
         </div><br />

         <div>Address : 
             <asp:TextBox ID="txtAdd" runat="server" CssClass="form-control"></asp:TextBox>
              
         </div><br />
         <div>Preferred Account : 
             <asp:DropDownList ID="ddlAccounts" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="264px"></asp:DropDownList>
                    
                    <br />
         </div><br />

         <div>Activate Account : 
             <asp:CheckBox ID="cbStatus" runat="server" CssClass="form-control" OnCheckedChanged="CheckBox1_CheckedChanged" />
             <br />
         </div><br />
         <div>

         <div>
             <asp:Button ID="btnCancel" runat="server" Text="Cancel"  CssClass="btn btn-warning form-control" style="padding:10px; background-color:red; margin-right:50px" Width="146px" OnClick="btnCancel_Click" />
             <asp:Button ID="btnSave" runat="server" Text="Save"  OnClientClick="return validate()" cssClass="btn btn-primary form-control"  style="background-color:green; margin-left:20px; padding:10px" Width="135px" OnClick="Button3_Click" />
             <br />
         </div>
 
         </div>
           <div>
             <asp:Label ID="lblMsg" runat="server" Text=" "></asp:Label>
         </div><br />

     </div>
                 </div>
        </div>
           </center>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>