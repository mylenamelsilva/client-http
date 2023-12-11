<h1 align="center"> Client HTTP </h1>
<p align="center"> Aplicação criada com o objetivo de praticar e fixar mais os conceitos sobre HTTP, funcionando como um cliente que envia requisições para o servidor. </p>
<table align="center">
  <tbody>
    <tr>
      <td>C# 11</td>
      <td>.NET 7</td>
    </tr>
  </tbody>
</table>
</br></br></br>
 
**O cliente consegue fazer as quatro operações básicas de um crud sobre cadastro de produtos via terminal.**  

![image](https://github.com/mylenamelsilva/client-http/assets/98224998/556ab9e1-c451-4b47-ab89-1c3b577817ee)   
<table >
  <thead>
    <tr>
      <th>Endpoints</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>GET</td>
      <td>POST</td>
      <td>PUT</td>
      <td>DELETE</td>
    </tr>
  </tbody>
</table>

* Todo o desenvolvimento foi feito com auxílio das classes HttpListener e HttpClient para administrar as requisições e as respostas entre client-server.
* O servidor não lida com banco de dados. Toda a inclusão, alteração e exclusão é feita manipulando um `List<>`.

## Como rodar

* `git clone` para fazer uma cópia do repositório (Faça o clone do repositório do server para rodar em conjunto: [Server HTTP](https://github.com/mylenamelsilva/server-http))
* Abra o terminal dentro da pasta da aplicação
* `dotnet run Client` para iniciar a aplicação e fazer requisições.
* **Observação:** Para fazer a alteração e exclusão de um produto, é necessário ter o id, então liste os produtos antes para saber qual id do respectivo produto
