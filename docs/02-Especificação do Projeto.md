# Especificações do Projeto

A definição exata do problema e os pontos mais relevantes a serem tratados neste projeto foi consolidada com a participação dos usuários em um trabalho de imersão feita pelos membros da equipe a partir da observação dos usuários em seu local natural e por meio de entrevistas. Os detalhes levantados nesse processo foram consolidados na forma de personas e histórias de usuários. 

## Personas

As personas levantadas durante o processo de entendimento do problema são apresentadas nos quadros a seguir.

|![Persona-1](img/Personas/persona1.png) |
|------|
|**Nome:** `Felipe Gomes`| 
|**Idade:** `32`|  
|**Ocupação:** `Líder de Vendas em uma pequena empresa que aluga notebooks e realiza manutenções ` |  
|**Aplicativos:** `Instagram` `TikTok` `Facebook` `OLX` |  
|**Motivações** `Consolidar-se profissionalmente no ramo da informática `|
|**Frustrações:** `Gostaria de passar mais tempo com a família  ` |  
|**Hobbies:** `Amante de Fotografias e Animais ` |  

<br>

|![Persona-2](img/Personas/persona2.png) |
|------|
|**Nome:** `Patricia Santos `| 
|**Idade:** `37`|  
|**Ocupação:** `Vendedora de produtos eletrônicos pela internet, atuando como micro empresária diretamente de sua casa ` |  
|**Aplicativos:** `Instagram` `TikTok` `OLX` |  
|**Motivações** `Trabalho Home-Office com liberdade de horário  `|
|**Frustrações:** `Não ter expandido ainda os negócios  ` |  
|**Hobbies:** `Adora dançar e estar com os amigos  ` |  

<br>

|![Persona-3](img/Personas/persona3.png) |
|------|
|**Nome:** `Gustavo Kenji`| 
|**Idade:** `22`|  
|**Ocupação:** `Proprietário de uma pequena empresa virtual que comercializa todos os tipos de produtos gamers` |  
|**Aplicativos:** `Instagram` `Twitch ` `YouTube`|  
|**Motivações** `Independência financeira`|
|**Frustrações:** `Não possuir inglês fluente` |  
|**Hobbies:** `Jogar vídeo-game e praticar esportes` |  

<br>

|![Persona-4](img/Personas/persona4.png) |
|------|
|**Nome:** `Francisco Luz`| 
|**Idade:** `65`|  
|**Ocupação:** `Proprietário de Oficina de reparação automóveis ` |  
|**Aplicativos:** `Instagram` `OLX` |  
|**Motivações** `Paixão por automóveis`|
|**Frustrações:** `Gostaria de viajar mais com a família ` |  
|**Hobbies:** `Paixão por churrasco e assistir futebol` |  

<br>


## Histórias de Usuários

A partir da compreensão do dia a dia das personas identificadas para o projeto, foram registradas as seguintes histórias de usuários.

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ...                 |
|--------------------|------------------------------------|----------------------------------------|
|Felipe Gomes  | Organizar o fluxo de entrada e saída de equipamentos de manutenção.           | Diminuir prazos de entrega               |
|Patricia Santos       | Atualizar estoque de forma rápida eficiente                 | Garantir disponibilidade de produtos|
|Gustavo Kenji        | Emitir notas fiscais de forma rápida                 |Agilizar processos de venda e envio de produtos|
|Francisco Luz       | Emitir notas fiscais de forma rápida                 | Agilizar atendimento a clientes e garantir a procedência de peças|
|Francisco Luz       | Pesquisar disponibilidade de peças de veículos                 | Organizar demandas e facilitar reposição de estoque|



## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| Permitir que o usuário faça login com verificação de senha | ALTA |
|RF-002| Permitir que o usuário insira um produto no estoque | ALTA |
|RF-003| Permitir que o usuário classifique o produto inserido por categoria no estoque | MÉDIA |
|RF-004| Permitir que o usuário remova um produto do estoque   | ALTA |
|RF-005| Permitir que o usuário pesquise um produto no estoque | ALTA |
|RF-006| Permitir que o usuário tenha acesso à quantidade atualizada do item no estoque  | ALTA |
|RF-007| Permitir que o usuário tenha acesso à contagem de itens totais no estoque | MÉDIA |
|RF-008| Permitir que cada item do estoque tenha um número único | MÉDIA |
|RF-009| Permitir que o usuário gere uma nota fiscal a partir do número único do produto | MÉDIA |



### Requisitos não Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RNF-001| O banco de dados deve ser hospedado na nuvem para acesso da aplicação | ALTA |
|RNF-002| A aplicação deve ser publicada em um ambiente acessível publicamente na Internet | ALTA |
|RNF-003| A aplicação deve ter um tempo de resposta baixo para as requisições | MÉDIA |
|RNF-004| A aplicação deve ter bom nível de contraste entre os elementos da tela   | MÉDIA |


## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RE-001| O projeto deve ser entregue no prazo estipulado pelo cronograma letivo |ALTA| 
|RE-002| A aplicação deve se restringir às tecnologias propostas |ALTA|


## Diagrama de Casos de Uso

Na imagem abaixo é apresentado o diagrama de casos de uso do projeto.


<img src="img/Personas/CasodeUsoUML.png" />

