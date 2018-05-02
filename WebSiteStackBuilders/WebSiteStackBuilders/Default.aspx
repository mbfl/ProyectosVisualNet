<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <table style="display: inline-block; margin: 0 auto;">
            <tr>
                <td colspan="3">
                      <h1>The Musical Lake</h1>
                       <p class="lead">You are an explorer, select a sound produced by an animal and clic on GO, you will see something amazing happens.</p>
                </td>
            </tr>
            <tr>
                <td style="width:30%" >
                    <asp:Label Text="Frog:" runat="server"></asp:Label>
                    <asp:DropDownList ID="ddlFrog" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFrog_SelectedIndexChanged">
                       
                    </asp:DropDownList>
                </td>
                <td style="width:30%" >
                    <asp:Label Text="Dragonfly:" runat="server"></asp:Label>
                      <asp:DropDownList ID="ddlDragonFly" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDragonFly_SelectedIndexChanged">
                                  
                      </asp:DropDownList>
                </td>
                <td style="width:30%" >
                    <asp:Label Text="Criket:" runat="server"></asp:Label>
                      <asp:DropDownList ID="ddlCriket" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlCriket_SelectedIndexChanged">
                       
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                 <td colspan="3">
                     <p> <!--<a href="http://www.asp.net" class="btn btn-primary btn-lg">GO &raquo;</a>-->
                         <button  runat="server" title="GO" class="btn btn-primary btn-lg" id="btnGo" onserverclick="btnGo_Click"> GO </button>

                     </p>
                </td>                   
            </tr>
          
        </table>         
    </div>

    <div class="row">
        <div class="col-md-12">
            <h2>Song reproduced</h2>
           
        </div>
         <div class="col-md-12">
            <p><asp:Label Text="" ID="lblMensaje" runat="server" CssClass="errorLabel"></asp:Label></p>
           
        </div>

    </div>
</asp:Content>
