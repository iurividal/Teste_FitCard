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


