# Plano de Testes de Software
Requisitos para realização dos testes são:
- Site publicado na internet
-  Navegador da internet - Chrome

Os testes funcionais a serem realizados são descritos a seguir:


 
| **Caso de Teste** 	| **CT-01 – Efetuar login** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 - Permitir que o usuário faça login com verificação de senha. |
| Objetivo do Teste 	| Verificar se o usuário consegue efetuar o login na aplicação.<br>  Verificar as credenciais de acesso. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site: A definir<br> - Clicar em "Login" <br> - Preencher os campos obrigatórios (Usuário, Senha) <br> - Clicar em "Entrar" |
|Critério de Êxito | - Login efetuado com sucesso |
|  	|  	|
| **Caso de Teste** 	| **CT-02 – Adicionar produto no estoque**	|
|Requisito Associado | RF-002	- A aplicação deve possuir opção que permita o usuário inserir um produto no estoque. |
| Objetivo do Teste 	| Verificar se o usuário consegue inserir um produto no estoque. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site: A definir<br> - Efetuar login <br> - Entrar no campo de "estoque" <br> - Clicar em "Adicionar Produto" <br> - Preencher as caracteristicas do produto a ser inserido<br> - Clicar em "Adicionar" |
|Critério de Êxito | - Produto adicionado com  sucesso |
|  	|  	|
| **Caso de Teste** 	| **CT-03 – Classificar produtos por categoria no estoque**	|
|Requisito Associado | RF-003	- Permitir que o usuário classifique o produto inserido por categoria no estoque. |
| Objetivo do Teste 	| Verificar se o usuário consegue classificar um produto por categoria no estoque. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site: A definir<br> - Efetuar login <br> - Entrar no campo de "estoque" <br> - Clicar em "Filtrar" <br> - Clicar em "Categoria"<br> - Escolher a categoria do produto |
|Critério de Êxito | - Filtro aplicado. |
|  	|  	|
| **Caso de Teste** 	| **CT-04 – Permitir o usuário remover um produto do estoque**	|
|Requisito Associado | RF-004	- Permitir que o usuário remova um produto do estoque. |
| Objetivo do Teste 	| Verificar se o usuário consegue remover um produto do estoque. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site: A definir<br> - Efetuar login <br> - Entrar no campo de "estoque" <br> - Clicar em "Remover Produto" <br> - Inserir o "ID" do produto<br> - Clicar em "Remover" |
|Critério de Êxito | - Produto removido com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-05 – Classificar produtos por categoria no estoque**	|
|Requisito Associado | RF-005	- Permitir que o usuário pesquise um produto no estoque. |
| Objetivo do Teste 	| Verificar se o usuário consegue pesquisar produtos no estoque. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site: A definir<br> - Efetuar login <br> - Entrar no campo de "estoque" <br> - Clicar no campo de pesquisa <br> - Inserir "ID" ou "Nome" do produto.<br> - Clicar em "Pesquisar" |
|Critério de Êxito | - Produto encontrado. |
|  	|  	|
| **Caso de Teste** 	| **CT-06 – Mostrar quantidade de estoque atualizada**	|
|Requisito Associado | RF-006	- Permitir que o usuário tenha acesso à quantidade atualizada do itens no estoque. |
| Objetivo do Teste 	| Verificar quantidade de items no estoque para cada produto individual. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site: A definir<br> - Efetuar login <br> - Entrar no campo de "estoque" <br> - Clicar no produto <br> - Visualizar a quantidade de itens deste produto |
|Critério de Êxito | - Quantidade de itens visivel e correta. |
|  	|  	|
| **Caso de Teste** 	| **CT-07 – Quantidade de itens totais no estoque**	|
|Requisito Associado | RF-007	- Permitir que o usuário tenha acesso à contagem de itens totais no estoque. |
| Objetivo do Teste 	| Verificar se o usuário consegue visualizar a quantidade de itens totais do estoque. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site: A definir<br> - Efetuar login <br> - Entrar no campo de "estoque" <br> - Visualizar a quantidade total de itens contabilizada na interface. <br> |
|Critério de Êxito | - Quantidade total de itens visivel na interface. |
|  	|  	|
| **Caso de Teste** 	| **CT-08 – ID dos produtos no estoque**	|
|Requisito Associado | RF-008	- Permitir que cada item do estoque tenha um número único (ID). |
| Objetivo do Teste 	| Verificar se cada produto tem seu número de identificação (ID). |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site: A definir<br> - Efetuar login <br> - Entrar no campo de "estoque" <br> - Visualizar o canto esquerdo da tabela pelo número de ID do produto <br>  |
|Critério de Êxito | - Produto possuir ID. |
|  	|  	|
| **Caso de Teste** 	| **CT-09 – Gerar relatório da tabela de produtos**	|
|Requisito Associado | RF-009	- Permitir que o usuário gere um relatório da tabela de produtos da aplicação. |
| Objetivo do Teste 	| Verificar se o usuário consegue gerar o relatório em Excel da tabela de produtos. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site: A definir<br> - Efetuar login <br> - Entrar no campo de "Produtos" <br> - Clicar no icone de download (cor verde)<br> |
|Critério de Êxito | - Relatório gerado. |
 
