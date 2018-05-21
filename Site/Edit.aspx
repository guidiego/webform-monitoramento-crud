<%@ Page Title="Editar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 0 auto; max-width: 280px; padding: 10px 20px; border: 1px solid #ddd">
        <label>
            Nome:<br />
            <asp:TextBox ID="Name" runat="server" class="form-control"/>
        </label>
        <label>
            Descrição:<br />
            <asp:TextBox ID="Description" runat="server" class="form-control"/>
        </label>
        <div class="row">
            <label class="col-md-6">
                Preço:<br />
                <asp:TextBox ID="Price" runat="server" class="form-control"/>
            </label>
            <label class="col-md-6">
                Cameras:<br />
                <asp:TextBox ID="Cams" runat="server"  class="form-control"/>
            </label>
        </div>
        <label>
            Fidelidade:<br />
            <asp:RadioButtonList runat="server" ID="Fidelity">
                <asp:ListItem Text="Sim" Value="true" />
                <asp:ListItem Text="Não" Value="false" />
            </asp:RadioButtonList>
        </label>
        <asp:Button Text="Salvar" OnClick="updateClient" 
            runat="server" class="btn btn-primary btn-block"/>
    </div>
</asp:Content>
