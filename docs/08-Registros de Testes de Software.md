# Registros de Testes de Software

## Teste 1 - Login como administrador

[Assista ao vídeo](https://youtu.be/L-6RFkKR8aA)

## Teste 2 - Login como usuário comum

[Assista ao vídeo](https://youtu.be/UjbxbwKh64g)

### CT-01 – Cadastrar perfil

O usuário deve ser capaz de criar uma conta pessoal.
Tanto usuários comuns podem se cadastrar e usuários admin podem criar novos perfis, logo a funcionalidade foi implementada com sucesso.

### CT-02 – Alterar dados de conta

O usuário deve ser capaz de alterar dados da sua conta pessoal.
Apenas usuários admin têm a opção de editar suas contas, logo essa funcionalidade está incompleta e precisa de correção.
### CT-03 – Excluir conta

O usuário deve ser capaz de excluir sua conta pessoal
Apenas usuários admin têm a opção de excluir suas contas, logo essa funcionalidade está incompleta e precisa de correção.

### CT-04 – Login de usuário

O usuário deve ser capaz de logar em sua própria conta.
O sistema de login funciona perfeitamente, como apresentado nos vídeos.

### CT-05 – Logout de usuário

O usuário deve ser capaz de sair da sua própria conta.
A funcionalidade foi implementada com êxito.

### CT-06 – Adicionar notícias

O usuário deve ser capaz de adicionar notícias.
Tanto aministradores quanto usuários comuns têm permissão para postar novas notícias, portanto a funcionalidade foi implementada com sucesso.

### CT-07 – Editar notícias, CT-08 – Excluir notícias

Verificar se o usuário consegue editar/excluir notícias na aplicação.
Por enquanto apenas administradores possuem essa permissão, portanto, é uma correção a ser aplicada na próxima etapa.

### CT-09 – Filtro de notícias

O usuário deve ser capaz de filtrar as notícias, O site deve ter um sistema de “tags”, Site deve ter um sistema de filtro por tempo.
Os filtros de data, tag e pesquisa foram implementados e estão funcionando, logo as funcionalidades foram implementadas com sucesso.

### CT-10 – Exibir Autor da Notícia

Site deve exibir o usuário que adicionou a notícia.
A página de notícias ainda não exibe o usuário responsável por ela, apenas quando o usuário clica em "Detalhes", portanto a funcionalidade foi aplicada parcialmente.

### CT-11 – Gerenciamento de Usuários, CT-12 – Gerenciamento de Notícias

O administrador deve ser capaz de gerenciar usuários/notícias.
O usuário administrador consegue alterar os usuários e as notícias postadas por eles, logo, a funcionalidades foram implementada com sucesso.

## Método e participantes

Para o teste, foi criado um formulário com 9 questões com cada caso de teste analisado, aonde foram dadas as opções de: Sucesso; Sucesso, com dificuldades e Insucesso.

O formulário foi respondido por 4 participantes, na faixa hetária entre 23 e 30 anos, que possuem alguma familiaridade com tecnologia.
 **![](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t1-time4-agregador-noticias/blob/main/docs/img/resultados%20de%20testes.png)**

## Resultados

-Todos os usuários tiveram sucesso nos seguintes casos de teste: CT-01 – Cadastrar perfil, CT-04 – Login de usuário,  CT-05 – Logout de usuário, CT-06 – Adicionar notícias.

-50% dos usuários não tiveram sucesso em CT-02 – Alterar dados de conta.

-25% teve sucesso com dificuldades e outros 25% não tiveram sucesso em CT-03 – Excluir conta.

-25% dos usuários tiveram sucesso com dificuldades em CT-07 – Editar notícias, CT-08 – Excluir notícias.

-25% dos usuários tiveram sucesso com dificuldades em CT-09 – Filtro de notícias, CT-10 – Visualizar Autor da Notícia.

-25% dos usuários tiveram sucesso com dificuldades em CT-11 – Gerenciamento de Usuários, CT-12 – Gerenciamento de Notícias (adicionar, visualizar, editar e excluir) com usuário admin.

Alguns usuários deixaram algumas sugestões e críticas relativas à sua experiência na aplicação:

-Quando o admin edita uma notícia, ela deixa de aparecer se selecionado algum filtro.

-Necessário adicionar modais de feedback para o usuário, confirmando adição ou alteração de informação. Não possui aba de usuário para gerenciamento de conteúdo, portando houve falha total em editar conta ou excluir.

## Conclusão

Em relação às sugestões dos participantes do teste de usabilidade, chegamos às seguintes conclusões para melhorar o sistema:

- Adicionar a possibilidade de editar e excluir as próprias notícias;
- Adicionar feedbacks das ações realizadas;
- Mostrar o nome do usuário nas notícias postadas por ele;
- Corrigir o bug referente ao filtro.
