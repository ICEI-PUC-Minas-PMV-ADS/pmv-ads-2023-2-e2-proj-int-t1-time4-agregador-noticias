# Plano de Testes de Software

O plano de teste de software proposto para avaliação dos requisitos funcionais da aplicação é apresentado a seguir:

| **Caso de Teste** 	| **CT-01 – Cadastrar perfil** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 - O usuário deve ser capaz de criar uma conta pessoal
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastrar na aplicação. |
| Passos 	| - Acessar a aplicação <br> - Clicar em "Cadastre-se" <br> - Preencher os campos obrigatórios (Nome de usuário, Email e senha) <br> - Clicar em "Cadastrar" |
|Critério de Êxito | - O cadastro foi realizado com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-02 – Alterar dados de conta** 	|
|	Requisito Associado 	| RF-002 - O usuário deve ser capaz de alterar dados da sua conta pessoal	
| Objetivo do Teste 	| Verificar se o usuário consegue alterar seus dados de conta |
| Passos 	| - Acessar a aplicação <br> - Clicar em "Perfil" <br> - Alterar algum dos dados de conta (e-mail, senha ou nome de usuário) <br> - Clicar em "Salvar" |
|Critério de Êxito | - O cadastro foi atualizado com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-03 – Excluir conta** 	|
|	Requisito Associado 	| RF-003 - O usuário deve ser capaz de excluir sua conta pessoal	
| Objetivo do Teste 	| Verificar se o usuário consegue deletar seu próprio perfil |
| Passos 	| - Acessar a aplicação <br> - Clicar em "Perfil" <br> - Clicar em "Excluir conta" <br> - Confirmar exclusão de conta |
|Critério de Êxito | - O cadastro foi deletado com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-04 – Login de usuário** 	|
|	Requisito Associado 	| RF-005 - O usuário deve ser capaz de logar em sua própria conta	
| Objetivo do Teste 	| Verificar se o usuário consegue acessar seu próprio perfil |
| Passos 	| - Acessar a aplicação <br> - Clicar em "Login" <br> - Inserir os dados de conta (e-mail e senha) <br> - Clicar em "Entrar" |
|Critério de Êxito | - O login foi realizado com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-05 – Logout de usuário** 	|
|	Requisito Associado 	| RF-005 - O usuário deve ser capaz de fazer log out com sua conta pessoal		
| Objetivo do Teste 	| Verificar se o usuário consegue deslogar |
| Passos 	| - Acessar a aplicação <br> - Clicar em "Perfil" <br> - Clicar em "Logout" |
|Critério de Êxito | - O usuário volta à página inicial da aplicação como visitante |
|  	|  	|
| **Caso de Teste** 	| **CT-06 – Adicionar notícias** 	|
|	Requisito Associado 	| RF-006 - O usuário deve ser capaz de adicionar notícias		
| Objetivo do Teste 	| Verificar se o usuário consegue incluir notícias na aplicação |
| Passos 	| - Acessar a aplicação <br> - Clicar em "Adicionar notícia" <br> - Incluir os dados da notícia (link e manchete) e selecionar a Tag correspondente |
|Critério de Êxito | - A notícia é exibida na página inicial da aplicação |
|  	|  	|
| **Caso de Teste** 	| **CT-07 – Editar notícias** 	|
|	Requisito Associado 	| RF-007 - O usuário deve ser capaz de editar as notícias que postou		
| Objetivo do Teste 	| Verificar se o usuário consegue editar notícias na aplicação |
| Passos 	| - Acessar a aplicação <br> - Clicar em "Editar" na notícia desejada <br> - Alterar os dados da notícia (link, manchete e/ou tag) e clicar em "Confirmar alterações" |
|Critério de Êxito | - As edições são aplicadas à notícia |
|  	|  	|
| **Caso de Teste** 	| **CT-08 – Excluir notícias** 	|
|	Requisito Associado 	| RF-008 - O usuário deve ser capaz de excluir notícias		
| Objetivo do Teste 	| Verificar se o usuário consegue excluir notícias na aplicação |
| Passos 	| - Acessar a aplicação <br> - Clicar em "Excluir" na notícia desejada <br> - Clicar em "Confirmar exclusão" |
|Critério de Êxito | - A notícia é apagada da página inicial da aplicação |
|  	|  	|
| **Caso de Teste** 	| **CT-09 – Filtro de notícias** 	|
|	Requisito Associado 	| RF-009, RF-010, RF-011 - O usuário deve ser capaz de filtrar as notícias, O site deve ter um sistema de “tags”, Site deve ter um sistema de filtro por tempo					
| Objetivo do Teste 	| Verificar se o usuário consegue filtrar notícias na aplicação |
| Passos 	| - Acessar a aplicação <br> - Selecionar o campo de pesquisa, Tag desejada e/ou o período de tempo desejado <br> - Clicar em "Pesquisar" |
|Critério de Êxito | - As notícias com as palavras chave pesquisadas, com a Tag selecionada e/ou no período selecionado são exibidas |
|  	|  	|
| **Caso de Teste** 	| **CT-10 – Exibir Autor da Notícia** 	|
|	Requisito Associado 	| RF-012 - Site deve exibir o usuário que adicionou a notícia					
| Objetivo do Teste 	| Verificar se a notícia postada exibe o usuário que a postou |
| Passos 	| - Acessar a aplicação <br> - Visualizar o campo "Autor" |
|Critério de Êxito | - O autor da notícia é exibido na mesma |
|  	|  	|
| **Caso de Teste** 	| **CT-11 – Gerenciamento de Usuários** 	|
|	Requisito Associado 	| RF-013 - O administrador deve ser capaz de gerenciar usuários					
| Objetivo do Teste 	| Verificar se o administrador consegue consegue fazer atualizações nos perfis de usuários comuns |
| Passos 	| - Acessar a aplicação como administrador <br> - Buscar por usuários <br> - Selecionar a conta de usuário que deseja alterar <br> - Realizar alguma atualização na conta (inclusão, alteração ou exclusão) <br> - Confirmar alterações |
|Critério de Êxito | - As alterações realizadas na conta do usuário devem ser salvas |
|  	|  	|
| **Caso de Teste** 	| **CT-12 – Gerenciamento de Notícias** 	|
|	Requisito Associado 	| RF-014 - O administrador deve ser capaz de gerenciar notícias					
| Objetivo do Teste 	| Verificar se o administrador consegue consegue fazer atualizações nas notícias postadas por usuários comuns |
| Passos 	| - Acessar a aplicação como administrador <br> - Selecionar a notícia que deseja alterar <br> - Realizar alguma atualização na notícia (inclusão, alteração ou exclusão) <br> - Confirmar alterações |
|Critério de Êxito | - As alterações realizadas na notícia devem ser salvas |
|  	|  	|
