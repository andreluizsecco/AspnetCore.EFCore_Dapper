# AspnetCore.EFCore_Dapper
Projeto ASP.NET Core + Entity Framework Core + Dapper, demonstrando o uso de ambos separadamente e em um cenário híbrido.

[![Build status](https://ci.appveyor.com/api/projects/status/w5p8cerx1mfxvkyl?svg=true)](https://ci.appveyor.com/project/andreluizsecco/aspnetcore-efcore-dapper)
[![Issues open](https://img.shields.io/github/issues-raw/andreluizsecco/aspnetcore.efcore_dapper.svg)](https://github.com/andreluizsecco/AspnetCore.EFCore_Dapper/issues)

## Estrutura
### AspnetCore.EFCore_Dapper.Domain

* Entidades de domínio e interfaces.

### AspnetCore.EFCore_Dapper.Data

* Entity Framework Context com aplicação dos mapeamentos das entidades e configurações para o uso de Migrations;
* DbInitializer para a criação de dados de exemplo na inicialização do projeto;
* Mapeamentos das entidades (Configuração do tipo e tamanho das colunas, chaves primárias, relacionamentos, etc) tanto do EF Core, quanto do Dapper;
* Repositórios EF Core e Dapper para a manipulação de dados do banco de dados.

### AspnetCore.EFCore_Dapper.IoC

* Camada de inversão de controle com a configuração do mecanismo nativo de injeção de dependência do ASP.NET Core.

### AspnetCore.EFCore_Dapper.MVC

* Camada de apresentação, utilizando as demais estruturas;
* Cadastro simples de livros utilizando exclusivamente o EF Core;
* Cadastro simples de livros utilizando exclusivamente o Dapper;
* Cadastro simples de livros utilizando o Dapper para consulta e o EF Core para inclusão, atualização e exclusão.
