<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="REGISTRO.aspx.cs" Inherits="Prueba3.REGISTRO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            BIENVENIDO A LA SECCIÓNDE REGISTRO
            <br />
            <br />
            BUSCAR POR ID: <asp:TextBox ID="txtNombreBuscar" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="btnBuscar" runat="server" Text="BUSCAR" OnClick="BtnBuscar_Click"/>
            &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="ELIMINAR" OnClick="BtnEliminar_Click"/>
            <asp:Button ID="btnModificar" runat="server" Text="MODIFICAR" OnClick="BtnModificar_Click"/>
            <br />
            <br />
            ID USUARIO: <asp:TextBox ID="id_user" runat="server" ReadOnly="True" ></asp:TextBox>
            <br />
            <br />
            NOMBRE:<asp:TextBox ID="nombre" runat="server"></asp:TextBox>
            <br />
            <br />
            EMAIL:<asp:TextBox ID="email" runat="server"></asp:TextBox>
            <br />
            <br />
            EDAD:<asp:TextBox ID="edad" runat="server"></asp:TextBox>
            <br />
            <br />
            USUARIO:<asp:TextBox ID="nom_user" runat="server"></asp:TextBox>
            <br />
            <br />
            PASSWORD:<asp:TextBox ID="pass" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnRegistrar" runat="server" Text="REGISTRAR" OnClick="Reg_Click"/>
            <br />
<br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="id_user" HeaderText="id_user" InsertVisible="False" ReadOnly="True" SortExpression="id_user" />
                    <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                    <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                    <asp:BoundField DataField="edad" HeaderText="edad" SortExpression="edad" />
                    <asp:BoundField DataField="nom_user" HeaderText="nom_user" SortExpression="nom_user" />
                    <asp:BoundField DataField="pass" HeaderText="pass" SortExpression="pass" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=DANY-LAPTOP;Initial Catalog=bdprueba;Integrated Security=True;Encrypt=False;" SelectCommand="SELECT * FROM [usuarios]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
