# Plano de Testes de Usabilidade

O plano de testes de usabilidade proposto para avaliação dos requisitos não-funcionais da aplicação é apresentado a seguir:

| **Caso de Teste** 	| **CT-01 – Verificar responsividade** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RNF-001- O sistema deve ser responsivo para ser compatível com dispositivos móveis	 |
| Objetivo do Teste 	| Verificar se a aplicação é responsiva e adequada para visualização em um dispositivo móvel. |
| Passos 	|  1. Acessar o Navegador em um celular. <br> 2. Informar o endereço da aplicação. <br> 3. Verificar se a página é visualizada corretamente. |
| Critério de Êxito | - A página deve ser visualizada de forma integral em um dispositivo móvel. |
|  	|  	|
| **Caso de Teste** 	| **CT-02 – Interação com banco de dados** 	|
|	Requisito Associado 	| RNF-002- A aplicação será desenvolvida através das linguagens C#, .NET e do banco de dados SQL.	 |
| Objetivo do Teste 	| Verificar se a aplicação consegue se comunicar com o banco de dados MySQL
 |
| Passos 	|  - Acessar o navegador <br> - Informar o endereço da aplicação |
| Critério de Êxito | - A conexão com o banco de dados deve ser estabelecida com sucesso <br> - Os dados devem ser recuperados e exibidos corretamente na aplicação |
|  	|  	|
| **Caso de Teste** 	| **CT-03 - Acessível publicamente na internet** 	|
|	Requisito Associado 	| RNF-003; RNF-004 - O site deve ser publicado em um ambiente acessível publicamente na Internet (GitHub, Heroku); O site deve ser compatível com os principais navegadores do mercado (Google Chrome, Firefox, Microsoft Edge)		 |
| Objetivo do Teste 	| Verificar se a aplicação está acessível nos navegadores mais utilizados do mercado |
| Passos 	|  - Acessar o navegador <br> - Informar o endereço da aplicação. <br> Verificar se a página é exibida integralmente em todos os navegadores. |
| Critério de Êxito | - A página deve ser exibida de forma integral em todos os navegadores testados (Google chrome, Firefox, Microsoft Edge). |
|  	|  	|
| **Caso de Teste** 	| **CT-04 - Tempo de resposta** 	|
|	Requisito Associado 	| RNF-005- O sistema deve respeitar o tempo máximo de 160 segundos durante processamentos.		 |
| Objetivo do Teste 	| Verificar se a aplicação responde aos comandos de maneira rápida. |
| Passos 	|  - Acessar o navegador <br> - Informar o endereço da aplicação. <br> Realizar diversas ações, como cadastro, log in, postagem e edição de notícias |
| Critério de Êxito | - O processamento de cada ação não deve ultrapassar o tempo limite de 160 segundos |
|  	|  	|
| **Caso de Teste** 	| **CT-05 - Verificar nível de contraste da aplicação** 	|
|	Requisito Associado 	| RNF-006- A aplicação deve ter bom nível de contraste entre os elementos da tela.		 |
| Objetivo do Teste 	| Verificar se a aplicação tem bom nível de contraste entre os elementos da tela. |
| Passos 	|  - Acessar o Navegador <br> - Informar o endereço da aplicação <br> - Realizar o login com um usuário válido <br> - Navegar pelas telas da aplicação <br> - Verificar se há uma boa distinção de cores entre os elementos da tela, com textos, botões e campos de entrada de dados <br> - Verificar se o contraste das cores atende às normas de acessibilidade. |
| Critério de Êxito | - Todos os elementos da tela devem ter uma boa distinção de cores, facilitando a visualização <br> - O contraste das cores deve atender às normas de acessibilidade, como a WCAG 2.0 (Web contente Acessibility Guidelines) <br> - A navegação pelas telas da aplicação deve ser fluída e sem erros visuais que prejudquem a experiência do usuário. |
|  	|  	|
| **Caso de Teste** 	| **CT-06 - Verificar preenchimento dos campos de cadastro de usuário** 	|
|	Requisito Associado 	| RNF-007- A aplicação não permite o recebimento de cadastros de usuários com dados necessários em branco.	 |
| Objetivo do Teste 	| Verificar se a aplicação cadastra apenas usuários com todos os campos preenchidos |
| Passos 	|  - Acessar o Navegador <br> - Informar o endereço da aplicação <br> - Realizar um cadastro fictício com algum dado faltante. <br> - Verificar se esse cadastro é recusado. |
| Critério de Êxito | - O cadastro incompleto é recusado |
|  	|  	|