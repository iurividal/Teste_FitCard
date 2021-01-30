FIT CARD
Teste Prático


Teste base-se em criar um sistema web onde é possível cadastrar, atualizar, ler e deletar informações de estabelecimentos.

Para realizar o cadastro somente 2(dois) campos seriam obrigatórios Nome Social e CNPJ.

Adicionado Mascara ao CNPJ e realizar sua validação,

Para campo de Data Cadastro (Data de abertura) utlizar mascara de data.

Tecnologia Utilizada:
- Asp .net MVC 5
- Razor
- jquery
- javascript
- BootStrap 4.*
- Banco de dados SQL

Previa do sistema funcionando você encontra aqui http://iurisvidal.azurewebsites.net/

* Detalhes de Modelagem do Banco

Entidades
Pessoa,Categoria,Estabelecimento

Sistema está preparado para uma alteração no futuro caso uma Empresa tenha mais de um estabelecimento em cima do mesmo CNPJ, por isso a entidade Pessoa dessa forma consigo cadastrar 1-N estabelecimentos para o mesmo CNPJ.

Algumas imagens do Sistema

![home](https://user-images.githubusercontent.com/25581909/106340550-ee631300-6278-11eb-8c7c-cb0b4d7b73e9.png)

![cadastro de categorias](https://user-images.githubusercontent.com/25581909/106340563-fcb12f00-6278-11eb-9d7a-df44614672cd.png)

![cadastro_estabelecimento](https://user-images.githubusercontent.com/25581909/106340568-03d83d00-6279-11eb-85d1-e2aa7d2134ce.png)

![Lista Estabelecimentos](https://user-images.githubusercontent.com/25581909/106340571-09358780-6279-11eb-9d13-e47594763811.png)
