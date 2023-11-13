# O Projeto
Este projeto tem como objetivo permitir testar um comportamento básico de uma API de garagem. 

![Api print](https://i.imgur.com/iX0U2al.png)
![Api print2](https://i.imgur.com/wecH1Z9.png)

## Para rodar o projeto:
01 Inicie o docker;
02 Rode o projeto;
03 Aguarde o SQL iniciar;
04 Altere o string de conexao para apontar para o server localhost, 1450;
04.1 Pare a execução;
05 Rode as migrations;
- dotnet ef migrations remove -p ETP.Infra -s ETP.API --force
- dotnet ef migrations add MigrationsV1 -p ETP.Infra -s ETP.API -o Persistence/Migrations/ -v
- dotnet ef database update -p ETP.Infra -s ETP.API
06 Altere o string de conexao para apontar para o server EstaparDB
07 Inicie o projeto clicando em docker compose;

## Detalhes
Para o projeto, escolhi dividir em 5 projetos: API, Domain, Infra, Applications e Testes. Trazendo dominios ricos, para conter as validações de maneira mais organizada. Trouxe o repository patterns e para fins de praticidade, já que é uma aplicação de teste, optei por ter apenas um serviço responsável por processar as requisições. No primeiro momento, é feito um seed dos dados básico para visualizarmos informações iniciais.

Escolhi separar a logica de cobrança em uma policy no domínio, adiconei apenas um teste básico para validar o fechamento; Adicionei métodos de adição e conclusão de passagem para podermos testar mais o comportamento. Utilizei Entity framework como ORM.
