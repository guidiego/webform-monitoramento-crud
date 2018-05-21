<%@ Page EnableEventValidation="false" Title="Listagem de Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-striped">
        <thead>
            <tr>
                <th>Nome</th>
                <th>Cameras</th>
                <th>Fidelidade</th>
                <th>Preço c/ Disconto</th>
                <th>Ações</th>
            </tr>
        </thead>
        <tbody>
            <%foreach (var item in Items) { %>
                <tr>
                    <td><%= item.Name %></td>
                    <td><%= item.Cams %></td>
                    <td>
                        <% if (item.Fidelity) { %>
                            <span style="color:#2ecc71">Sim</span>
                        <% } else { %>
                            <span style="color:#e74c3c">Não</span>
                        <% } %>
                    </td>
                    <td>
                        <div>
                            R$ <%= item.Price - ((float)item.Price * ((float)item.Discount/100)) %> 
                            <span style="color:#e74c3c">(-<%= item.Discount %>%)</span>
                        </div>
                    </td>
                    <td>
                        <a class="btn btn-danger" onClick="removeClient(<%= item.Id %>)" >
                            <i class="glyphicon glyphicon-trash" />
                        </a>
                        <a class="btn btn-success" href='/Edit?id=<%= item.Id %>'>
                            <i class="glyphicon glyphicon-pencil" />
                        </a>
                    </td>
                </tr>
            <% } %>
        </tbody>
        <div style="display:none">
            <asp:Button runat="server" ID="removeClientBtn" onClick="removeClient"/>
        </div>
    </table>

    <script>
        function removeClient(id) {
            if (window.confirm("Deseja realmente deletar o usuario?")) {
                __doPostBack("<%= removeClientBtn.UniqueID %>", id);
            }
        }
    </script>
</asp:Content>
