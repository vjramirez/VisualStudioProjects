<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-3">
            <input type="text" class="form-control" name="fechaIni" value="" id="fechaIni" placeholder="Fecha Inicio" />
        </div>
        <div class="col-md-3">
            <input type="text" class="form-control" name="fechaFin" value="" id="fechaFin" placeholder="Fecha Fin"/>
        </div>
        <div class="col-md-3">
            <button class="btn btn-primary" id="buscar" >Buscar</button>
        </div>
    </div>
    <br />
    <br />
    <div class="row">
        <table class="table" id="tabla">
          <thead class="thead-dark">
            <tr>
              <th scope="col">Fecha</th>
              <th scope="col">Cedula</th>
              <th scope="col">Nombre</th>
              <th scope="col">Apellido1</th>
              <th scope="col">Apellido2</th>
              <th scope="col">Es Cliente</th>
            </tr>
          </thead>
          <tbody>
          </tbody>
        </table>
    </div>

</asp:Content>
